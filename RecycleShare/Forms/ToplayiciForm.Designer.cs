namespace RecycleShare
{
    partial class ToplayiciForm
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            listBox2 = new ListBox();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            listBox3 = new ListBox();
            checkedListBox1 = new CheckedListBox();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(434, 68);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(341, 25);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(434, 35);
            label1.Name = "label1";
            label1.Size = new Size(198, 19);
            label1.TabIndex = 1;
            label1.Text = "Hangi atığı toplamak istersiniz?";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 182);
            label2.Name = "label2";
            label2.Size = new Size(114, 19);
            label2.TabIndex = 3;
            label2.Text = "Bekleyen İşlemler";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(478, 340);
            label3.Name = "label3";
            label3.Size = new Size(97, 19);
            label3.TabIndex = 5;
            label3.Text = "Bitmiş İşlemler";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(478, 371);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(297, 106);
            listBox2.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(434, 113);
            button1.Name = "button1";
            button1.Size = new Size(133, 26);
            button1.TabIndex = 6;
            button1.Text = "Atık Rezerve Et";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(45, 52, 54);
            label4.Location = new Point(49, 53);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 7;
            label4.Text = "Ad Soyad: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(39, 174, 96);
            label5.Location = new Point(49, 89);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 8;
            label5.Text = "Puan: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(478, 182);
            label6.Name = "label6";
            label6.Size = new Size(127, 19);
            label6.TabIndex = 10;
            label6.Text = "İptal Edilen İşlemler";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.Location = new Point(478, 214);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(297, 106);
            listBox3.TabIndex = 9;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(161, 214);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(297, 284);
            checkedListBox1.TabIndex = 11;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(52, 152, 219);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(31, 214);
            button2.Name = "button2";
            button2.Size = new Size(108, 26);
            button2.TabIndex = 12;
            button2.Text = "Tamamla";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(52, 152, 219);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(31, 247);
            button3.Name = "button3";
            button3.Size = new Size(108, 26);
            button3.TabIndex = 13;
            button3.Text = "İptal Et";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(638, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 25);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // ToplayiciForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(884, 561);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(checkedListBox1);
            Controls.Add(label6);
            Controls.Add(listBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Font = new Font("Segoe UI", 10F);
            Name = "ToplayiciForm";
            Text = "RecycleShare - Toplayıcı Paneli";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBox2;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox listBox3;
        private CheckedListBox checkedListBox1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
    }
}