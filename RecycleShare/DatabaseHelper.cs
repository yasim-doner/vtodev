using System;
using System.Data;
using Npgsql;

namespace RecycleShare
{
    public class DatabaseHelper
    {
        // Bağlantı cümleni buraya yaz.
        // Veritabanı adının "recycle_db" olduğunu varsayıyorum, değilse değiştir.
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=15995161;Database=atik";

        // Giriş yaparken E-Mail ve Şifre kontrolü yapacağız
        public string Login(string email, string password)
        {
            string userRole = null;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SENİN ŞEMANA GÖRE SORGULAMA:
                    // Tablo: kullanicilar
                    // Sütunlar: email, sifre, rol
                    string sql = "SELECT rol FROM kullanicilar WHERE email = @e AND sifre = @s";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("e", email);
                        cmd.Parameters.AddWithValue("s", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            userRole = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                }
            }

            return userRole; // 'admin', 'user' veya 'toplayici' döner
        }

        public int GetUserIdByEmail(string email)
        {
            int userId = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT kullanici_id FROM kullanicilar WHERE email = @mail";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mail", email);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }
            return userId;
        }

        public NpgsqlConnection GetAuthorizedConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open(); // Bağlantıyı açtık

            // Eğer Session'da bir rol tanımlıysa (Login olunmuşsa)
            if (!string.IsNullOrEmpty(Session.DbRoleName))
            {
                // SQL tarafında kimlik değiştiriyoruz
                string roleQuery = $"SET ROLE {Session.DbRoleName}";

                using (NpgsqlCommand cmd = new NpgsqlCommand(roleQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Hazır, yetkisi kısıtlanmış bağlantıyı geri döndür
            return conn;
        }

        public bool RegisterUser(string ad, string soyad, string email, string sifre, string rol)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString)) // connectionString sınıfın tepesinde tanımlı zaten
            {
                try
                {
                    conn.Open();
                    // Email unique olduğu için aynı mail varsa veritabanı hata fırlatır, onu catch'te yakalarız.
                    string query = "INSERT INTO kullanicilar (ad, soyad, email, sifre, rol, puan) VALUES (@ad, @soyad, @email, @sifre, @rol, 0)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", ad);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@sifre", sifre);
                        cmd.Parameters.AddWithValue("@rol", rol); // 'user' veya 'toplayici' gidecek

                        int result = cmd.ExecuteNonQuery();
                        return result > 0; // Kayıt başarılıysa true döner
                    }
                }
                catch (PostgresException ex)
                {
                    // 23505: Unique violation (Bu mail adresi zaten var hatası)
                    if (ex.SqlState == "23505")
                    {
                        System.Windows.Forms.MessageBox.Show("Bu E-Mail adresi zaten kayıtlı!");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Genel hata: " + ex.Message);
                    return false;
                }
            }
        }
    }
}