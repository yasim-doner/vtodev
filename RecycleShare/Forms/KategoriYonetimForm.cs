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
            // 1. Seçim Kontrolü
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek satırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int seciliId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kategori_id"].Value);
            string kategoriAdi = dataGridView1.CurrentRow.Cells["kategori_adi"].Value.ToString();

            // 2. Kullanıcı Onayı
            DialogResult cevap = MessageBox.Show(
                $"{kategoriAdi} kategorisini silmek istediğinize emin misiniz?",
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
                        string query = "DELETE FROM atik_kategorileri WHERE kategori_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", seciliId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
                    }
                    catch (PostgresException ex)
                    {
                        // ÖZEL SQL DURUMLARI (Güvenli Mesajlar)

                        // 23503: Foreign Key Violation (Bağlı veri hatası)
                        // Bu kod, senin tablonun "RESTRICT" özelliğinden dolayı fırlatılır.
                        if (ex.SqlState == "23503")
                        {
                            MessageBox.Show("Bu kategoriyi SİLEMEZSİNİZ.\n\nSebep: Bu kategoriye ait sistemde kayıtlı atıklar mevcut. Veri güvenliği için önce o atıkların silinmesi gerekir.",
                                            "İşlem Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            // DİĞER SQL HATALARI (Else Kısmı)
                            // BURAYI GÜVENLİ HALE GETİRDİK:
                            // Kullanıcıya "ex.Message" göstermiyoruz! Sadece genel bilgi veriyoruz.
                            MessageBox.Show("İşlem sırasında teknik bir veritabanı hatası oluştu.\nLütfen sistem yöneticisine başvurun.",
                                            "Teknik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Geliştirici notu: Gerçek hatayı log dosyasına yazabilirsin ama ekrana basma.
                            // Console.WriteLine(ex.Message); 
                        }
                    }
                    catch (Exception ex)
                    {
                        // SQL DIŞI HATALAR (Kod hatası, dönüştürme hatası vb.)
                        // Burada da teknik detay vermiyoruz.
                        MessageBox.Show("Beklenmedik bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
