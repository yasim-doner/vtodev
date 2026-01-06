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
    public partial class IslemYonetimForm : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";

        public IslemYonetimForm()
        {
            InitializeComponent();
        }

        private void IslemYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        // --- LİSTELEME (JOIN ile Detaylı) ---
        private void Listele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Sadece ID'leri değil, İsimleri de getiriyoruz ki Admin ne olduğunu anlasın.
                    string query = @"
                        SELECT 
                            i.islem_id,
                            a.baslik AS ""Atık Başlığı"",
                            (k.ad || ' ' || k.soyad) AS ""Alıcı (Toplayıcı)"",
                            i.durum AS ""Durum"",
                            i.islem_tarihi AS ""İşlem Tarihi""
                        FROM islemler i
                        JOIN atiklar a ON i.atik_id = a.atik_id
                        JOIN kullanicilar k ON i.alici_id = k.kullanici_id
                        ORDER BY i.islem_tarihi DESC";

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

        // --- SİLME ---
        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1. Seçim Kontrolü
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek işlemi listeden seçin.");
                return;
            }

            // Seçili satırdan ID ve Bilgi alma
            int islemId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["islem_id"].Value);
            string atikBaslik = dataGridView1.CurrentRow.Cells["Atık Başlığı"].Value.ToString();
            string alici = dataGridView1.CurrentRow.Cells["Alıcı (Toplayıcı)"].Value.ToString();

            // 2. Onay Mesajı
            DialogResult cevap = MessageBox.Show(
                $"{alici} tarafından alınan '{atikBaslik}' işlemini silmek istiyor musunuz?\n\n(Bu işlem geri alınamaz!)",
                "İşlem Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM islemler WHERE islem_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", islemId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("İşlem kaydı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele(); // Listeyi yenile
                    }
                    catch (Exception ex)
                    {
                        // İşlemler tablosu genellikle en son tablodur, silerken constraint hatası pek vermez.
                        // Ama yine de genel hatayı gösterelim.
                        MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
