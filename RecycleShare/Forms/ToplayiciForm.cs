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

        public ToplayiciForm()
        {
            InitializeComponent();
            AtiklariGetir();
        }

        private void ToplayiciForm_Load(object sender, EventArgs e)
        {
            AtiklariGetir();
        }

        private void AtiklariGetir()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    // Sorguda isimleri büyük/küçük harf duyarlı hale getirdik
                    string query = "SELECT \"atik_id\", \"baslik\" FROM \"atiklar\" WHERE \"durum\" = 'musait'";

                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            comboBox1.DataSource = dt;
                            comboBox1.DisplayMember = "baslik";
                            comboBox1.ValueMember = "atik_id";
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
        private void label1_Click(object sender, EventArgs e)

        {



        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)

        {



        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {



        }

    }

}
