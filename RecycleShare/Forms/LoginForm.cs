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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kullan�c�dan Email ve �ifre al�yoruz
            string email = txtUsername.Text; // Formda "Kullan�c� Ad�" kutusuna Email yazacaklar
            string sifre = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("L�tfen E-Mail ve �ifre giriniz.");
                return;
            }

            DatabaseHelper db = new DatabaseHelper();

            // Veritaban�na sor: Bu mail ve �ifreye sahip biri var m�?
            string rol = db.Login(email, sifre);

            if (rol != null)
            {
                MessageBox.Show("Giri� Ba�ar�l�! Rol: " + rol);
                this.Hide();

                // Senin veritaban�ndaki CHECK constraint'e g�re roller: 'admin', 'user', 'toplayici'
                switch (rol)
                {
                    case "admin":
                        AdminForm adminPage = new AdminForm();
                        adminPage.Show();
                        break;

                    case "toplayici":
                        ToplayiciForm toplayiciPage = new ToplayiciForm();
                        toplayiciPage.Show();
                        break;

                    case "user":
                        UserForm userPage = new UserForm();
                        userPage.Show();
                        break;

                    default:
                        MessageBox.Show("Rol�n�z sisteme tan�ml� de�il!");
                        this.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("E-Mail veya �ifre hatal�!");
            }
        }
    }
}
