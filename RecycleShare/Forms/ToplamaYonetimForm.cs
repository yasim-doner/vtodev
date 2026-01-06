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
    public partial class ToplamaYonetimForm : Form
    {

        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";
        public ToplamaYonetimForm()
        {
            InitializeComponent();
        }

        private void ToplamaYonetimForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Listele()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Tablonun tüm sütunlarını çekiyoruz
                    string query = "SELECT nokta_id, ilce, mahalle, tam_adres, telefon FROM toplama_noktalari ORDER BY ilce, mahalle";

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

        // --- EKLEME ---
        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Basit boşluk kontrolü
            if (string.IsNullOrWhiteSpace(txtIlce.Text) || string.IsNullOrWhiteSpace(txtMahalle.Text) || string.IsNullOrWhiteSpace(txtAdres.Text))
            {
                MessageBox.Show("Lütfen İlçe, Mahalle ve Adres bilgilerini giriniz.");
                return;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO toplama_noktalari (ilce, mahalle, tam_adres, telefon) 
                                     VALUES (@ilce, @mah, @adres, @tel)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ilce", txtIlce.Text);
                        cmd.Parameters.AddWithValue("@mah", txtMahalle.Text);
                        cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelefon.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Yeni toplama noktası eklendi!");
                    Listele();
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme hatası: " + ex.Message);
                }
            }
        }

        // --- SİLME (Güvenli Mod - Restrict Korumalı) ---
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silinecek adresi listeden seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["nokta_id"].Value);

            // Kullanıcı neyi sildiğini görsün diye başlık oluşturuyoruz
            string adresBasligi = dataGridView1.CurrentRow.Cells["ilce"].Value.ToString() + " - " +
                                  dataGridView1.CurrentRow.Cells["mahalle"].Value.ToString();

            DialogResult cevap = MessageBox.Show(
                $"{adresBasligi} noktasını silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM toplama_noktalari WHERE nokta_id = @id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", seciliId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Toplama noktası silindi.");
                        Listele();
                    }
                    catch (PostgresException ex)
                    {
                        // 23503: Foreign Key (Genel), 23001: Restrict (Özel)
                        // Eğer bu noktaya bırakılmış atık varsa silmeyi engelliyoruz.
                        if (ex.SqlState == "23503" || ex.SqlState == "23001")
                        {
                            MessageBox.Show("Bu toplama noktasını SİLEMEZSİNİZ.\n\nSebep: Bu noktaya bırakılmış ve hala sistemde duran atık kayıtları var. Veri bütünlüğü için silme engellendi.",
                                            "Silinemez", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            // Diğer veritabanı hataları
                            MessageBox.Show("Veritabanı hatası oluştu.\nHata Kodu: " + ex.SqlState, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Beklenmedik hata: " + ex.Message);
                    }
                }
            }
        }

        private void Temizle()
        {
            txtIlce.Clear();
            txtMahalle.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
        }
    }
}
