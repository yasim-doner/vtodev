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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
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
            btnRaporGor = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
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
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 493);
            panel1.TabIndex = 0;
            // 
            // txtAciklama
            // 
            txtAciklama.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAciklama.Location = new Point(182, 173);
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(504, 67);
            txtAciklama.TabIndex = 6;
            txtAciklama.Text = "";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(510, 11);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 5;
            label2.Text = "Miktar (KG)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(72, 69);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 5;
            label3.Text = "Toplama Nokta";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(510, 69);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 5;
            label4.Text = "Kategori";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            label1.Location = new Point(72, 11);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Başlık";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(72, 334);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(751, 156);
            dataGridView1.TabIndex = 4;
            // 
            // cmbToplamaNoktasi
            // 
            cmbToplamaNoktasi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbToplamaNoktasi.FormattingEnabled = true;
            cmbToplamaNoktasi.Location = new Point(72, 87);
            cmbToplamaNoktasi.Name = "cmbToplamaNoktasi";
            cmbToplamaNoktasi.Size = new Size(334, 23);
            cmbToplamaNoktasi.TabIndex = 3;
            // 
            // cmbKategori
            // 
            cmbKategori.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(510, 87);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(334, 23);
            cmbKategori.TabIndex = 2;
            // 
            // txtKilo
            // 
            txtKilo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtKilo.Location = new Point(510, 29);
            txtKilo.Name = "txtKilo";
            txtKilo.Size = new Size(313, 23);
            txtKilo.TabIndex = 1;
            txtKilo.Tag = "";
            // 
            // txtBaslik
            // 
            txtBaslik.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBaslik.Location = new Point(72, 29);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.Size = new Size(313, 23);
            txtBaslik.TabIndex = 1;
            txtBaslik.Tag = "";
            // 
            // btnAtikEkle
            // 
            btnAtikEkle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAtikEkle.BackColor = SystemColors.ActiveCaption;
            btnAtikEkle.Location = new Point(251, 271);
            btnAtikEkle.Name = "btnAtikEkle";
            btnAtikEkle.Size = new Size(380, 53);
            btnAtikEkle.TabIndex = 0;
            btnAtikEkle.Text = "Atık Ekle";
            btnAtikEkle.UseVisualStyleBackColor = false;
            btnAtikEkle.Click += btnAtikEkle_Click;
            // 
            // btnRaporGor
            // 
            btnRaporGor.BackColor = Color.IndianRed;
            btnRaporGor.Dock = DockStyle.Top;
            btnRaporGor.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
            btnRaporGor.Location = new Point(0, 0);
            btnRaporGor.Name = "btnRaporGor";
            btnRaporGor.Size = new Size(884, 50);
            btnRaporGor.TabIndex = 7;
            btnRaporGor.Text = "Rapor Görüntüleme";
            btnRaporGor.UseVisualStyleBackColor = false;
            btnRaporGor.Click += btnRaporGor_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(btnRaporGor);
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
        private Button btnRaporGor;
    }
}