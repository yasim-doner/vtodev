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
    public partial class KategoriYonetimForm : Form
    {
        // Bağlantı cümlen (Senin verdiğin şifre ve db ismine göre)
        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";

        public KategoriYonetimForm()
        {
            InitializeComponent();
        }

        private void KategoriYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        // --- LİSTELEME FONKSİYONU ---
        private void Listele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT kategori_id, kategori_adi, birim_puan FROM atik_kategorileri ORDER BY kategori_id ASC";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // --- EKLEME BUTONU ---
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtPuan.Text))
            {
                MessageBox.Show("Lütfen ad ve puan giriniz.");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO atik_kategorileri (kategori_adi, birim_puan) VALUES (@ad, @puan)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                    // Puanı sayıya çeviriyoruz (Hata olursa 0 alır)
                    int puan = 0;
                    int.TryParse(txtPuan.Text, out puan);
                    cmd.Parameters.AddWithValue("@puan", puan);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kategori eklendi!");
            Listele(); // Listeyi yenile
            txtAd.Clear();
            txtPuan.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1. KONTROL: Kullanıcı listeden bir şeye tıklamış mı?
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Dayı önce listeden silinecek satıra bir tıkla.");
                return;
            }

            // 2. VERİYİ ALMA: Seçili satırdan ID'yi ve Adı çekiyoruz
            // (Arka planda "kategori_id" hücresini okuyoruz)
            int seciliId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kategori_id"].Value);
            string kategoriAdi = dataGridView1.CurrentRow.Cells["kategori_adi"].Value.ToString();

            // 3. ONAY: Yanlışlıkla basarsa diye soralım
            DialogResult cevap = MessageBox.Show(
                $"{kategoriAdi} kategorisini silmek istiyor musun?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // ID'ye göre silme işlemi
                        string query = "DELETE FROM atik_kategorileri WHERE kategori_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", seciliId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Temizlendi!");
                        Listele(); // Listeyi yenile ki silinen satır ekrandan gitsin
                    }
                    catch (PostgresException ex)
                    {
                        // 23503: Foreign Key Violation
                        // 23001: Restrict Violation (Senin aldığın hata bu)
                        if (ex.SqlState == "23503" || ex.SqlState == "23001")
                        {
                            MessageBox.Show("Bu kategoriyi SİLEMEZSİNİZ.\n\nSebep: Bu kategoriye ait sistemde kayıtlı atıklar mevcut. Veri güvenliği için önce o atıkların silinmesi gerekir.",
                                            "İşlem Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            // Diğer teknik hatalar
                            MessageBox.Show("İşlem sırasında teknik bir veritabanı hatası oluştu.\nHata Kodu: " + ex.SqlState,
                                            "Teknik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
