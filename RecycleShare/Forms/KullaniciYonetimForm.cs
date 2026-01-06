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
    public partial class KullaniciYonetimForm : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";

        public KullaniciYonetimForm()
        {
            InitializeComponent();
        }

        private void KullaniciYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        // --- LİSTELEME ---
        private void Listele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Şifreyi çekmiyoruz, güvenlik için gerek yok.
                    string query = "SELECT * FROM vw_kullanici_vitrini";

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
                MessageBox.Show("Lütfen silinecek kullanıcıyı listeden seçin.");
                return;
            }

            // Verileri al
            int userId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kullanici_id"].Value);
            string adSoyad = dataGridView1.CurrentRow.Cells["ad"].Value.ToString() + " " +
                             dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            string rol = dataGridView1.CurrentRow.Cells["rol"].Value.ToString();

            // 2. Kendini Silme Koruması (Opsiyonel ama mantıklı)
            // Eğer admin yanlışlıkla kendini silmeye kalkarsa diye basit bir uyarı.
            // (Burada mevcut giriş yapanın ID'sini bilmediğimiz için sadece rol kontrolü yapabiliriz)
            if (rol == "admin")
            {
                DialogResult adminOnay = MessageBox.Show("DİKKAT: Bir ADMIN hesabını silmek üzeresiniz. Bu kişi siz olabilirsiniz.\nDevam etmek istiyor musunuz?", "Admin Siliniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (adminOnay == DialogResult.No) return;
            }

            // 3. Silme Onayı
            DialogResult cevap = MessageBox.Show(
                $"{adSoyad} isimli kullanıcıyı silmek istediğinize emin misiniz?",
                "Kullanıcı Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM kullanicilar WHERE kullanici_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", userId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele(); // Listeyi yenile
                    }
                    catch (PostgresException ex)
                    {
                        // 23503 & 23001: Bu kullanıcının atıkları veya işlemleri varsa silinemez.
                        if (ex.SqlState == "23503" || ex.SqlState == "23001")
                        {
                            MessageBox.Show("Bu kullanıcıyı SİLEMEZSİNİZ!\n\nSebep: Bu kullanıcının sisteme eklediği atık kayıtları veya yaptığı işlemler var. Veri bütünlüğü bozulacağı için silme engellendi.\n\n(Önce kullanıcının tüm verilerini silmeniz gerekir.)",
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
