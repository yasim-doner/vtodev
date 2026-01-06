using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RecycleShare.Forms
{
    public partial class AtikYonetimForm : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";

        public AtikYonetimForm()
        {
            InitializeComponent();
        }

        private void AtikYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        // --- LİSTELEME (Detaylı JOIN Sorgusu) ---
        private void Listele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // ID'ler yerine İsimleri getiriyoruz.
                    // Ayrıca COALESCE ile nokta_id NULL ise 'Ev Adresinden' yazdırıyoruz.
                    string query = @"
                        SELECT 
                            a.atik_id,
                            (k.ad || ' ' || k.soyad) AS ""Kullanıcı"",
                            c.kategori_adi AS ""Kategori"",
                            a.baslik AS ""Başlık"",
                            a.miktar_kg AS ""Miktar (KG)"",
                            COALESCE(tn.ilce || ' - ' || tn.mahalle, 'Ev Adresinden') AS ""Konum"",
                            a.durum AS ""Durum"",
                            a.ekleme_tarihi AS ""Tarih""
                        FROM atiklar a
                        JOIN kullanicilar k ON a.kullanici_id = k.kullanici_id
                        JOIN atik_kategorileri c ON a.kategori_id = c.kategori_id
                        LEFT JOIN toplama_noktalari tn ON a.nokta_id = tn.nokta_id
                        ORDER BY a.ekleme_tarihi DESC";

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Liste yüklenirken hata: " + ex.Message);
                }
            }
        }

        // --- SİLME (Constraint Korumalı) ---
        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1. Seçim Kontrolü
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek atığı listeden seçin.");
                return;
            }

            // Verileri al
            int atikId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["atik_id"].Value);
            string baslik = dataGridView1.CurrentRow.Cells["Başlık"].Value.ToString();
            string kullanici = dataGridView1.CurrentRow.Cells["Kullanıcı"].Value.ToString();

            // 2. Onay Mesajı
            DialogResult cevap = MessageBox.Show(
                $"{kullanici} kişisine ait '{baslik}' başlıklı atığı silmek istiyor musunuz?",
                "Atık Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM atiklar WHERE atik_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", atikId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Atık kaydı silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele(); // Listeyi yenile
                    }
                    catch (PostgresException ex)
                    {
                        // ÖNEMLİ: Eğer bu atık bir "İşlem"e girdiyse (yani bir toplayıcı bunu aldıysa)
                        // 'islemler' tablosunda kaydı vardır. Veritabanı silmeye izin vermez (RESTRICT).
                        if (ex.SqlState == "23503" || ex.SqlState == "23001")
                        {
                            MessageBox.Show("Bu atığı SİLEMEZSİNİZ!\n\nSebep: Bu atık için başlatılmış bir toplama işlemi ('İşlemler' tablosunda) mevcut. Önce işlemin iptal edilmesi veya silinmesi gerekir.",
                                            "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            MessageBox.Show("Veritabanı hatası: " + ex.SqlState, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}