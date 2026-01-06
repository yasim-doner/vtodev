using System;
using System.Data;
using Npgsql;

namespace RecycleShare
{
    public class DatabaseHelper
    {
        // Bağlantı cümleni buraya yaz.
        // Veritabanı adının "recycle_db" olduğunu varsayıyorum, değilse değiştir.
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=313131;Database=atik";

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
    }
}