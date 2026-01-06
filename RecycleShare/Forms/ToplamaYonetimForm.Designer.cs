namespace RecycleShare.Forms
{
    partial class ToplamaYonetimForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSil = new Button();
            btnEkle = new Button();
            label2 = new Label();
            label1 = new Label();
            txtMahalle = new TextBox();
            txtIlce = new TextBox();
            dataGridView1 = new DataGridView();
            txtAdres = new TextBox();
            txtTelefon = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.IndianRed;
            btnSil.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            btnSil.Location = new Point(686, 314);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 12;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(331, 228);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(197, 51);
            btnEkle.TabIndex = 11;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(521, 32);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 9;
            label2.Text = "Mahalle";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(203, 32);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 10;
            label1.Text = "İlçe";
            label1.Click += label1_Click;
            // 
            // txtMahalle
            // 
            txtMahalle.Location = new Point(521, 50);
            txtMahalle.Name = "txtMahalle";
            txtMahalle.Size = new Size(138, 23);
            txtMahalle.TabIndex = 7;
            // 
            // txtIlce
            // 
            txtIlce.Location = new Point(203, 50);
            txtIlce.Name = "txtIlce";
            txtIlce.Size = new Size(138, 23);
            txtIlce.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(203, 314);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(456, 150);
            dataGridView1.TabIndex = 6;
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(203, 111);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(138, 23);
            txtAdres.TabIndex = 8;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(521, 111);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(138, 23);
            txtTelefon.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(203, 93);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 10;
            label3.Text = "Tam Adre";
            label3.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(521, 93);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 9;
            label4.Text = "Telefon";
            // 
            // ToplamaYonetimForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtTelefon);
            Controls.Add(txtAdres);
            Controls.Add(txtMahalle);
            Controls.Add(txtIlce);
            Controls.Add(dataGridView1);
            Name = "ToplamaYonetimForm";
            Text = "ToplamaYonetimForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSil;
        private Button btnEkle;
        private Label label2;
        private Label label1;
        private TextBox txtMahalle;
        private TextBox txtIlce;
        private DataGridView dataGridView1;
        private TextBox txtAdres;
        private TextBox txtTelefon;
        private Label label3;
        private Label label4;
    }
}