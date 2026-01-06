using System;
using System.Data;
using System.Windows.Forms;
using Npgsql; // PostgreSQL için gerekli kütüphane

namespace RecycleShare
{

    public partial class ToplayiciForm : Form
    {
        // Bağlantı cümlesini buraya kendi bilgilerine göre yaz
        string connectionString = "Host=localhost;Port=5432;Database=atik;Username=postgres;Password=313131";
        private int _currentCollectorId;
        public ToplayiciForm(int currentCollectorId)
        {
            InitializeComponent();
            _currentCollectorId = currentCollectorId;
            getUserInfo();
            IslemleriListele();
            AtiklariGetir();
        }

        private void ToplayiciForm_Load(object sender, EventArgs e)
        {
            AtiklariGetir();
            getUserInfo();
            IslemleriListele();
        }

        private void AtiklariGetir()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Sorguda isimleri büyük/küçük harf duyarlı hale getirdik
                    string query = "SELECT \"atik_id\", \"baslik\",\"aciklama\",\"miktar_kg\"  FROM \"atiklar\" WHERE \"durum\" = 'musait'";

                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            // ComboBox'ta daha detaylı bilgi göstermek için sanal bir sütun ekleyelim
                            dt.Columns.Add("GosterilecekMetin", typeof(string), "baslik + ' (' + aciklama + ') - ' + miktar_kg + 'kg'");

                            // ComboBox Güncelleme
                            comboBox1.DataSource = dt;
                            comboBox1.DisplayMember = "GosterilecekMetin"; // Kullanıcının göreceği birleşik metin
                            comboBox1.ValueMember = "atik_id";           // Arka planda tutulan ID
                        }
                        else
                        {
                            MessageBox.Show("Veritabanında 'Müsait' durumda atık bulunamadı!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void getUserInfo()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Kullanıcı bilgilerini ID'ye göre çekiyoruz
                    string query = "SELECT \"ad\", \"soyad\", \"puan\" FROM \"kullanicilar\" WHERE \"kullanici_id\" = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", _currentCollectorId);

                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // Veritabanından gelen verileri labellara yazdırıyoruz
                                label4.Text = "Hoş geldin, " + dr["ad"].ToString() + " " + dr["soyad"].ToString();
                                label5.Text = "Puanın: " + dr["puan"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void IslemleriListele()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    checkedListBox1.Items.Clear(); // Bekliyor
                    listBox2.Items.Clear(); // Tamamlandı
                    listBox3.Items.Clear(); // İptal

                    string query = @"
                SELECT a.""baslik"", i.""durum"", i.""islem_tarihi"", i.""islem_id"" 
                FROM ""islemler"" i
                JOIN ""atiklar"" a ON i.""atik_id"" = a.""atik_id""
                WHERE i.""alici_id"" = @aliciId";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("aliciId", _currentCollectorId);

                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string baslik = dr["baslik"].ToString();
                                string durum = dr["durum"].ToString();
                                string tarih = Convert.ToDateTime(dr["islem_tarihi"]).ToShortDateString();

                                string listeMetni = $"{baslik} - {tarih}";

                                ListeEleman yeniEleman = new ListeEleman
                                {
                                    ID = Convert.ToInt32(dr["islem_id"]),
                                    Metin = $"{baslik} - {tarih}"
                                };

                                // Duruma göre ilgili listeye yönlendiriyoruz
                                if (durum == "bekliyor")
                                {
                                    checkedListBox1.Items.Add(yeniEleman);
                                }
                                else if (durum == "tamamlandi")
                                {
                                    listBox2.Items.Add(listeMetni);
                                }
                                else if (durum == "iptal edildi")
                                {
                                    listBox3.Items.Add(listeMetni);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlemler listelenirken hata: " + ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)

        {



        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)

        {



        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. ComboBox'tan seçilen atık ID'sini al
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir atık seçin!");
                return;
            }

            int atikId = Convert.ToInt32(comboBox1.SelectedValue);

            // 2. Alıcı ID 
            int aliciId = _currentCollectorId;

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // PostgreSQL fonksiyonunu SELECT ile çağırıyoruz
                    string sql = "SELECT fn_rezervasyon_yap(@atik_id, @alici_id)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        // Parametreleri ekleyelim
                        cmd.Parameters.AddWithValue("atik_id", atikId);
                        cmd.Parameters.AddWithValue("alici_id", aliciId);

                        // Fonksiyonun sonucunu almak istersen (boole, int vb. dönüyorsa)
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string dönenMesaj = result.ToString();

                            // Veritabanından gelen string mesajı ekranda gösteriyoruz
                            MessageBox.Show(dönenMesaj, "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // 3. İşlem başarılıysa listeyi yenile (Atık artık "Müsait" olmayabilir)
                        AtiklariGetir();
                        IslemleriListele();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fonksiyon hatası: " + ex.Message);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Hiçbir şey seçilmemişse uyar
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Lütfen önce listeden işlem seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int aliciId = _currentCollectorId; // Giriş yapan kullanıcının ID'si (Bunu dinamik yapabilirsin)
            string topluMesaj = ""; // Fonksiyondan gelen tüm cevapları burada toplayacağız

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // 2. Seçili olan her bir eleman için döngü başlat
                    foreach (object item in checkedListBox1.CheckedItems)
                    {
                        // Nesneyi daha önce oluşturduğumuz sınıfa cast ediyoruz
                        ListeEleman eleman = (ListeEleman)item;
                        int islemId = eleman.ID;

                        // 3. Fonksiyonu çağır
                        string sql = "SELECT fn_islemi_tamamla(@islem_id, @alici_id)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("islem_id", islemId);
                            cmd.Parameters.AddWithValue("alici_id", aliciId);

                            // Fonksiyonun döndürdüğü string mesajı al
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                topluMesaj += $"- {eleman.Metin}: {result.ToString()}\n";
                            }
                        }
                    }
                }

                // 4. Tüm sonuçları tek bir MessageBox'ta göster
                MessageBox.Show(topluMesaj, "İşlem Sonuçları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Listeleri ve Kullanıcı Puanını Yenile
                IslemleriListele();
                getUserInfo();
                AtiklariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Hiçbir şey seçilmemişse uyar
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Lütfen önce listeden işlem seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int aliciId = _currentCollectorId; // Giriş yapan kullanıcının ID'si (Bunu dinamik yapabilirsin)
            string topluMesaj = ""; // Fonksiyondan gelen tüm cevapları burada toplayacağız

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // 2. Seçili olan her bir eleman için döngü başlat
                    foreach (object item in checkedListBox1.CheckedItems)
                    {
                        // Nesneyi daha önce oluşturduğumuz sınıfa cast ediyoruz
                        ListeEleman eleman = (ListeEleman)item;
                        int islemId = eleman.ID;

                        // 3. Fonksiyonu çağır
                        string sql = "SELECT fn_rezervasyon_iptal(@islem_id, @alici_id)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("islem_id", islemId);
                            cmd.Parameters.AddWithValue("alici_id", aliciId);

                            // Fonksiyonun döndürdüğü string mesajı al
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                topluMesaj += $"- {eleman.Metin}: {result.ToString()}\n";
                            }
                        }
                    }
                }

                // 4. Tüm sonuçları tek bir MessageBox'ta göster
                MessageBox.Show(topluMesaj, "İşlem Sonuçları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Listeleri ve Kullanıcı Puanını Yenile
                IslemleriListele();
                getUserInfo();
                AtiklariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Hacı çok hızlı yazılırsa veritabanını yormamak için boş kontrolü
            string aramaMetni = textBox1.Text.Trim();

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    // Fonksiyonu SELECT * FROM ile çağırıyoruz
                    string sql = "SELECT * FROM \"fn_atik_ara\"(@anahtar)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        // SQL Injection önlemi ve parametre atama
                        cmd.Parameters.AddWithValue("anahtar", aramaMetni);

                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // ComboBox'ta daha detaylı bilgi göstermek için sanal bir sütun ekleyelim
                        dt.Columns.Add("GosterilecekMetin", typeof(string), "baslik + ' (' + aciklama + ') - ' + miktar + 'kg'");

                        // ComboBox Güncelleme
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "GosterilecekMetin"; // Kullanıcının göreceği birleşik metin
                        comboBox1.ValueMember = "ilan_no";           // Arka planda tutulan ID
                    }
                }

                // Eğer sonuç varsa ComboBox'ı otomatik aşağı açar (Opsiyonel)
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.DroppedDown = true;
                    // Yazmaya devam ederken imlecin kaybolmaması için:
                    textBox1.Focus();
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimini burada yapabilirsin
                Console.WriteLine("Arama hatası: " + ex.Message);
            }
        }
    }

    public class ListeEleman
    {
        public int ID { get; set; }
        public string Metin { get; set; }

        // ListBox'ta ne görüneceğini burası belirler
        public override string ToString()
        {
            return Metin;
        }
    }


}
