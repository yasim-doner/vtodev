namespace RecycleShare.Forms
{
    partial class KategoriYonetimForm
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
            dataGridView1 = new DataGridView();
            txtAd = new TextBox();
            label1 = new Label();
            txtPuan = new TextBox();
            label2 = new Label();
            btnEkle = new Button();
            btnSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(184, 253);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(456, 150);
            dataGridView1.TabIndex = 0;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(184, 66);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(138, 23);
            txtAd.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(184, 48);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 3;
            label1.Text = "Kategori Adı";
            // 
            // txtPuan
            // 
            txtPuan.Location = new Point(502, 66);
            txtPuan.Name = "txtPuan";
            txtPuan.Size = new Size(138, 23);
            txtPuan.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(502, 48);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Puan Miktarı";
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(317, 122);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(197, 51);
            btnEkle.TabIndex = 4;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.IndianRed;
            btnSil.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            btnSil.Location = new Point(667, 253);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 5;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // KategoriYonetimForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPuan);
            Controls.Add(txtAd);
            Controls.Add(dataGridView1);
            Name = "KategoriYonetimForm";
            Text = "KategoriYonetimForm";
            Load += KategoriYonetimForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtAd;
        private Label label1;
        private TextBox txtPuan;
        private Label label2;
        private Button btnEkle;
        private Button btnSil;
    }
}