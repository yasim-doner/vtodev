namespace RecycleShare
{
    partial class UserForm
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
            panel1 = new Panel();
            txtAciklama = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            cmbToplamaNoktasi = new ComboBox();
            cmbKategori = new ComboBox();
            txtKilo = new TextBox();
            txtBaslik = new TextBox();
            btnAtikEkle = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(txtAciklama);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(cmbToplamaNoktasi);
            panel1.Controls.Add(cmbKategori);
            panel1.Controls.Add(txtKilo);
            panel1.Controls.Add(txtBaslik);
            panel1.Controls.Add(btnAtikEkle);
            panel1.Location = new Point(100, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(671, 482);
            panel1.TabIndex = 0;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(182, 173);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(291, 56);
            txtAciklama.TabIndex = 6;
            txtAciklama.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(363, 35);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Miktar (KG)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(16, 93);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 5;
            label3.Text = "Toplama Nokta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(378, 93);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 5;
            label4.Text = "Kategori";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(182, 155);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 5;
            label5.Text = "Açıklama";
            label5.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(61, 35);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Başlık";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 334);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(626, 145);
            dataGridView1.TabIndex = 4;
            // 
            // cmbToplamaNoktasi
            // 
            cmbToplamaNoktasi.FormattingEnabled = true;
            cmbToplamaNoktasi.Location = new Point(112, 90);
            cmbToplamaNoktasi.Name = "cmbToplamaNoktasi";
            cmbToplamaNoktasi.Size = new Size(121, 23);
            cmbToplamaNoktasi.TabIndex = 3;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(431, 90);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(121, 23);
            cmbKategori.TabIndex = 2;
            // 
            // txtKilo
            // 
            txtKilo.Location = new Point(441, 32);
            txtKilo.Name = "txtKilo";
            txtKilo.Size = new Size(100, 23);
            txtKilo.TabIndex = 1;
            txtKilo.Tag = "";
            // 
            // txtBaslik
            // 
            txtBaslik.Location = new Point(121, 32);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.Size = new Size(100, 23);
            txtBaslik.TabIndex = 1;
            txtBaslik.Tag = "";
            // 
            // btnAtikEkle
            // 
            btnAtikEkle.BackColor = SystemColors.ActiveCaption;
            btnAtikEkle.Location = new Point(251, 271);
            btnAtikEkle.Name = "btnAtikEkle";
            btnAtikEkle.Size = new Size(167, 42);
            btnAtikEkle.TabIndex = 0;
            btnAtikEkle.Text = "Atık Ekle";
            btnAtikEkle.UseVisualStyleBackColor = false;
            btnAtikEkle.Click += btnAtikEkle_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(panel1);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtKilo;
        private TextBox txtBaslik;
        private Button btnAtikEkle;
        private ComboBox cmbToplamaNoktasi;
        private ComboBox cmbKategori;
        private DataGridView dataGridView1;
        private Label label1;
        private RichTextBox txtAciklama;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}