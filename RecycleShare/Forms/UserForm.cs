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

namespace RecycleShare
{
    public partial class UserForm : Form
    {

        private int _currentUserId;

        // Veritabanı bağlantı cümlen (Kendi şifreni kontrol et)
        string connectionString = "Server=localhost;Port=5432;Database=atik;User Id=postgres;Password=15995161;";

        // CONSTRUCTOR (KURUCU METOT) - Form1'den maili burada alıyoruz
        public UserForm(int userId)
        {
            InitializeComponent();
            _currentUserId = userId; // Maili içeri aldık
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Form açılınca ComboBox'ları ve Listeyi doldur
            KategorileriDoldur();
            ToplamaNoktalariniDoldur();
            AtiklariListele();
        }

        // 1. Kategorileri ComboBox'a Doldurma
        private void KategorileriDoldur()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT kategori_id, kategori_adi FROM atik_kategorileri ORDER BY kategori_adi";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategori.DisplayMember = "kategori_adi";
                cmbKategori.ValueMember = "kategori_id";
                cmbKategori.DataSource = dt;
                cmbKategori.SelectedIndex = -1; // Boş gelsin
            }
        }

        // 2. Toplama Noktalarını ComboBox'a Doldurma
        private void ToplamaNoktalariniDoldur()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                // Kullanıcıya İlçe ve Mahalle bilgisini birleştirip gösteriyoruz
                string query = "SELECT nokta_id, (ilce || ' - ' || mahalle) AS gorunen_isim FROM toplama_noktalari";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbToplamaNoktasi.DisplayMember = "gorunen_isim";
                cmbToplamaNoktasi.ValueMember = "nokta_id";
                cmbToplamaNoktasi.DataSource = dt;
                cmbToplamaNoktasi.SelectedIndex = -1; // Boş gelsin (Boşsa EV demektir)
            }
        }

        // 3. Mail Adresinden User ID Bulma Fonksiyonu


        // 4. KAYDET BUTONU
        private void btnAtikEkle_Click(object sender, EventArgs e)
        {
            int currentUserId = _currentUserId;

            if (currentUserId == 0)
            {
                MessageBox.Show("Kullanıcı bulunamadı, lütfen tekrar giriş yapın.");
                this.Close();
                return;
            }

            // Kategori Seçili mi?
            if (cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
                return;
            }

            string baslik = txtBaslik.Text;
            string aciklama = txtAciklama.Text;
            int kategoriId = (int)cmbKategori.SelectedValue;
            decimal miktar = 0;

            if (!decimal.TryParse(txtKilo.Text, out miktar))
            {
                MessageBox.Show("Geçerli bir kilo giriniz (Örn: 1.5).");
                return;
            }

            // Toplama Noktası Seçili Değilse NULL (Ev) Olacak
            object noktaId = DBNull.Value;
            if (cmbToplamaNoktasi.SelectedIndex != -1)
            {
                noktaId = (int)cmbToplamaNoktasi.SelectedValue;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO atiklar (kullanici_id, kategori_id, nokta_id, baslik, aciklama, miktar_kg) 
                                 VALUES (@uid, @katId, @noktaId, @baslik, @aciklama, @miktar)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", currentUserId);
                    cmd.Parameters.AddWithValue("@katId", kategoriId);
                    cmd.Parameters.AddWithValue("@noktaId", noktaId);
                    cmd.Parameters.AddWithValue("@baslik", baslik);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama);
                    cmd.Parameters.AddWithValue("@miktar", miktar);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Atık başarıyla eklendi!");
            AtiklariListele(); // Listeyi güncelle
            Temizle(); // Kutuları boşalt
        }

        // 5. Grid Listeleme (Kendi Eklediklerini Görsün)
        private void AtiklariListele()
        {
            int currentUserId = _currentUserId;


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        a.baslik AS ""Başlık"",
                        k.kategori_adi AS ""Kategori"",
                        a.miktar_kg AS ""KG"",
                        COALESCE(tn.ilce || ' - ' || tn.mahalle, 'Ev Adresim') AS ""Teslim Yeri"",
                        a.durum AS ""Durum"",
                        a.ekleme_tarihi AS ""Tarih""
                    FROM atiklar a
                    JOIN atik_kategorileri k ON a.kategori_id = k.kategori_id
                    LEFT JOIN toplama_noktalari tn ON a.nokta_id = tn.nokta_id
                    WHERE a.kullanici_id = @uid
                    ORDER BY a.ekleme_tarihi DESC";

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@uid", currentUserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Temizle()
        {
            txtBaslik.Clear();
            txtAciklama.Clear();
            txtKilo.Clear();
            cmbKategori.SelectedIndex = -1;
            cmbToplamaNoktasi.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
