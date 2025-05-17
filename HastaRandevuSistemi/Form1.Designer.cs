namespace HastaRandevuSistemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbBrans = new ComboBox();
            cmbDoktor = new ComboBox();
            dtpTarih = new DateTimePicker();
            cmbSaat = new ComboBox();
            txtHastaAdi = new TextBox();
            txtHastaSoyadi = new TextBox();
            btnRandevuOlustur = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblSaat = new Label();
            lblHastaAdi = new Label();
            lblHastaSoyadi = new Label();
            SuspendLayout();
            // 
            // cmbBrans
            // 
            cmbBrans.FormattingEnabled = true;
            cmbBrans.Location = new Point(244, 35);
            cmbBrans.Name = "cmbBrans";
            cmbBrans.Size = new Size(164, 33);
            cmbBrans.TabIndex = 0;
            cmbBrans.SelectedIndexChanged += cmbBrans_SelectedIndexChanged;
            // 
            // cmbDoktor
            // 
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(226, 75);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(182, 33);
            cmbDoktor.TabIndex = 1;
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(226, 135);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(206, 31);
            dtpTarih.TabIndex = 2;
            // 
            // cmbSaat
            // 
            cmbSaat.FormattingEnabled = true;
            cmbSaat.Location = new Point(228, 201);
            cmbSaat.Name = "cmbSaat";
            cmbSaat.Size = new Size(180, 33);
            cmbSaat.TabIndex = 3;
            // 
            // txtHastaAdi
            // 
            txtHastaAdi.Location = new Point(228, 267);
            txtHastaAdi.Name = "txtHastaAdi";
            txtHastaAdi.Size = new Size(164, 31);
            txtHastaAdi.TabIndex = 4;
            // 
            // txtHastaSoyadi
            // 
            txtHastaSoyadi.Location = new Point(228, 339);
            txtHastaSoyadi.Name = "txtHastaSoyadi";
            txtHastaSoyadi.Size = new Size(164, 31);
            txtHastaSoyadi.TabIndex = 5;
            // 
            // btnRandevuOlustur
            // 
            btnRandevuOlustur.Location = new Point(466, 296);
            btnRandevuOlustur.Name = "btnRandevuOlustur";
            btnRandevuOlustur.Size = new Size(239, 57);
            btnRandevuOlustur.TabIndex = 6;
            btnRandevuOlustur.Text = "Randevu Oluştur";
            btnRandevuOlustur.UseVisualStyleBackColor = true;
            btnRandevuOlustur.Click += btnRandevuOlustur_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 26);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 7;
            label1.Text = "Branş seçiniz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 75);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 8;
            label2.Text = "Doktor seçiniz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 141);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 9;
            label3.Text = "Tarih seçiniz";
            // 
            // lblSaat
            // 
            lblSaat.AutoSize = true;
            lblSaat.Location = new Point(71, 204);
            lblSaat.Name = "lblSaat";
            lblSaat.Size = new Size(92, 25);
            lblSaat.TabIndex = 10;
            lblSaat.Text = "Saat Seçin";
            // 
            // lblHastaAdi
            // 
            lblHastaAdi.AutoSize = true;
            lblHastaAdi.Location = new Point(83, 267);
            lblHastaAdi.Name = "lblHastaAdi";
            lblHastaAdi.Size = new Size(86, 25);
            lblHastaAdi.TabIndex = 11;
            lblHastaAdi.Text = "Hasta adı";
            // 
            // lblHastaSoyadi
            // 
            lblHastaSoyadi.AutoSize = true;
            lblHastaSoyadi.Location = new Point(83, 339);
            lblHastaSoyadi.Name = "lblHastaSoyadi";
            lblHastaSoyadi.Size = new Size(120, 25);
            lblHastaSoyadi.TabIndex = 12;
            lblHastaSoyadi.Text = "Hasta Soyadı:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHastaSoyadi);
            Controls.Add(lblHastaAdi);
            Controls.Add(lblSaat);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRandevuOlustur);
            Controls.Add(txtHastaSoyadi);
            Controls.Add(txtHastaAdi);
            Controls.Add(cmbSaat);
            Controls.Add(dtpTarih);
            Controls.Add(cmbDoktor);
            Controls.Add(cmbBrans);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBrans;
        private ComboBox cmbDoktor;
        private DateTimePicker dtpTarih;
        private ComboBox cmbSaat;
        private TextBox txtHastaAdi;
        private TextBox txtHastaSoyadi;
        private Button btnRandevuOlustur;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblSaat;
        private Label lblHastaAdi;
        private Label lblHastaSoyadi;
    }
}
