using RecycleShare.Forms;

namespace RecycleShare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            // Kayıt formunu açıyoruz
            RegisterForm frm = new RegisterForm();
            frm.ShowDialog(); // ShowDialog kullanıyoruz ki kayıt bitmeden arkadaki login'e basamasınlar
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kullanýcýdan Email ve Þifre alýyoruz
            string email = txtUsername.Text; // Formda "Kullanýcý Adý" kutusuna Email yazacaklar
            string sifre = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen E-Mail ve Þifre giriniz.");
                return;
            }

            DatabaseHelper db = new DatabaseHelper();

            // Veritabanýna sor: Bu mail ve þifreye sahip biri var mý?
            string rol = db.Login(email, sifre);

            if (rol != null)
            {
                int gelenId = db.GetUserIdByEmail(email);
                MessageBox.Show("Giriþ Baþarýlý! Rol: " + rol);
                this.Hide();

                switch (rol)
                {
                    case "admin":
                        Session.DbRoleName = "admin_role";
                        break;
                    case "user":
                        Session.DbRoleName = "user_role";
                        break;
                    case "toplayici":
                        Session.DbRoleName = "toplayici_role";
                        break;
                    default:
                        Session.DbRoleName = "user_role"; // Varsayılan
                        break;
                }

                // Senin veritabanýndaki CHECK constraint'e göre roller: 'admin', 'user', 'toplayici'
                switch (rol)
                {
                    case "admin":
                        AdminForm adminPage = new AdminForm();
                        adminPage.Show();
                        break;

                    case "toplayici":
                        ToplayiciForm toplayiciPage = new ToplayiciForm(gelenId);
                        toplayiciPage.Show();
                        break;

                    case "user":
                        UserForm userPage = new UserForm(gelenId);
                        userPage.Show();
                        break;

                    default:
                        MessageBox.Show("Rolünüz sisteme tanýmlý deðil!");
                        this.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("E-Mail veya Þifre hatalý!");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}