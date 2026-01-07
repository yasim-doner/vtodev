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

        // ARTIK BAĞLANTI CÜMLESİNE BURADA GEREK YOK.
        // DatabaseHelper sınıfı hallediyor.

        public UserForm(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            KategorileriDoldur();
            ToplamaNoktalariniDoldur();
            AtiklariListele();
        }

        // 1. Kategorileri Doldur
        private void KategorileriDoldur()
        {
            DatabaseHelper db = new DatabaseHelper();

            // DİKKAT: GetAuthorizedConnection() hem bağlantıyı açar hem yetkiyi ayarlar.
            using (NpgsqlConnection conn = db.GetAuthorizedConnection())
            {
                // conn.Open();  <-- BU SATIRI SİLDİK, ZATEN AÇIK GELİYOR

                string query = "SELECT kategori_id, kategori_adi FROM atik_kategorileri ORDER BY kategori_adi";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbKategori.DisplayMember = "kategori_adi";
                cmbKategori.ValueMember = "kategori_id";
                cmbKategori.DataSource = dt;
                cmbKategori.SelectedIndex = -1;
            }
        }

        // 2. Toplama Noktalarını Doldur
        private void ToplamaNoktalariniDoldur()
        {
            DatabaseHelper db = new DatabaseHelper();

            using (NpgsqlConnection conn = db.GetAuthorizedConnection())
            {
                // Kullanıcıya İlçe ve Mahalle bilgisini birleştirip gösteriyoruz
                // NOT: Burada 'vw_nokta_vitrini' view'ını kullanırsan daha şık olur ama tablo da çalışır.
                string query = "SELECT nokta_id, (ilce || ' - ' || mahalle) AS gorunen_isim FROM toplama_noktalari";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbToplamaNoktasi.DisplayMember = "gorunen_isim";
                cmbToplamaNoktasi.ValueMember = "nokta_id";
                cmbToplamaNoktasi.DataSource = dt;
                cmbToplamaNoktasi.SelectedIndex = -1;
            }
        }

        // 4. KAYDET BUTONU
        private void btnAtikEkle_Click(object sender, EventArgs e)
        {
            // Session'dan gelen ID ile constructor'dan gelen ID aynıdır.
            // Güvenlik için Session.UserId de kullanabilirsin ama bu da doğru.
            int currentUserId = _currentUserId;

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

            object noktaId = DBNull.Value;
            if (cmbToplamaNoktasi.SelectedIndex != -1)
            {
                noktaId = (int)cmbToplamaNoktasi.SelectedValue;
            }

            DatabaseHelper db = new DatabaseHelper();

            // YETKİLİ BAĞLANTIYI ALIYORUZ
            using (NpgsqlConnection conn = db.GetAuthorizedConnection())
            {
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
            AtiklariListele();
            Temizle();
        }

        // 5. Grid Listeleme
        private void AtiklariListele()
        {
            DatabaseHelper db = new DatabaseHelper();

            using (NpgsqlConnection conn = db.GetAuthorizedConnection())
            {
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
                    da.SelectCommand.Parameters.AddWithValue("@uid", _currentUserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnRaporGor_Click(object sender, EventArgs e)
        {
            string raporMetni = "";
            DatabaseHelper db = new DatabaseHelper();

            using (NpgsqlConnection conn = db.GetAuthorizedConnection())
            {
                try
                {
                    // Fonksiyon çağırma
                    string query = "SELECT fn_aylik_cevresel_etki_raporu(@uid)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _currentUserId);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            raporMetni = result.ToString();
                        }
                    }

                    MessageBox.Show(raporMetni, "Çevresel Etki Raporunuz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rapor alınırken hata oluştu: " + ex.Message);
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

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show(
            "Oturumu kapatmak istediğinize emin misiniz?",
            "Çıkış Yap",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                // 1. HAFIZAYI TEMİZLE (Rolü sıfırla)
                // Bunu yapmazsan bir sonraki giren kişi eski yetkilerle kalabilir!
                Session.Reset();

                // 2. Login Ekranını Aç
                Form1 loginEkrani = new Form1();
                loginEkrani.Show();

                // 3. Mevcut Sayfayı Kapat
                this.Close();
            }
        }
    }
}