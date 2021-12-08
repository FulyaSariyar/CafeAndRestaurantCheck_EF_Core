namespace CafeAndRestaurantCheck_EF_Core.Forms
{
    partial class FrmBinaBilgileri
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCombolar = new System.Windows.Forms.Panel();
            this.cbTeras = new System.Windows.Forms.ComboBox();
            this.cbBahçe = new System.Windows.Forms.ComboBox();
            this.cbKat4 = new System.Windows.Forms.ComboBox();
            this.cbZemin = new System.Windows.Forms.ComboBox();
            this.cbKat3 = new System.Windows.Forms.ComboBox();
            this.cbKat1 = new System.Windows.Forms.ComboBox();
            this.cbKat2 = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.dtgrdBinaBilgileri = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnListele = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlCombolar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBinaBilgileri)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1193, 652);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Chocolate;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(15, 568);
            this.button4.Margin = new System.Windows.Forms.Padding(15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(1163, 69);
            this.button4.TabIndex = 40;
            this.button4.Text = "GERİ";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.pnlCombolar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkedListBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtgrdBinaBilgileri, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1187, 450);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pnlCombolar
            // 
            this.pnlCombolar.BackColor = System.Drawing.Color.White;
            this.pnlCombolar.Controls.Add(this.cbTeras);
            this.pnlCombolar.Controls.Add(this.cbBahçe);
            this.pnlCombolar.Controls.Add(this.cbKat4);
            this.pnlCombolar.Controls.Add(this.cbZemin);
            this.pnlCombolar.Controls.Add(this.cbKat3);
            this.pnlCombolar.Controls.Add(this.cbKat1);
            this.pnlCombolar.Controls.Add(this.cbKat2);
            this.pnlCombolar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCombolar.Location = new System.Drawing.Point(398, 65);
            this.pnlCombolar.Margin = new System.Windows.Forms.Padding(3, 65, 3, 3);
            this.pnlCombolar.Name = "pnlCombolar";
            this.pnlCombolar.Size = new System.Drawing.Size(389, 382);
            this.pnlCombolar.TabIndex = 16;
            // 
            // cbTeras
            // 
            this.cbTeras.BackColor = System.Drawing.Color.Chocolate;
            this.cbTeras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTeras.ForeColor = System.Drawing.Color.White;
            this.cbTeras.FormattingEnabled = true;
            this.cbTeras.Location = new System.Drawing.Point(26, 275);
            this.cbTeras.Name = "cbTeras";
            this.cbTeras.Size = new System.Drawing.Size(121, 28);
            this.cbTeras.TabIndex = 18;
            // 
            // cbBahçe
            // 
            this.cbBahçe.BackColor = System.Drawing.Color.Chocolate;
            this.cbBahçe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBahçe.ForeColor = System.Drawing.Color.White;
            this.cbBahçe.FormattingEnabled = true;
            this.cbBahçe.Location = new System.Drawing.Point(26, 13);
            this.cbBahçe.Name = "cbBahçe";
            this.cbBahçe.Size = new System.Drawing.Size(121, 28);
            this.cbBahçe.TabIndex = 12;
            // 
            // cbKat4
            // 
            this.cbKat4.BackColor = System.Drawing.Color.Chocolate;
            this.cbKat4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKat4.ForeColor = System.Drawing.Color.White;
            this.cbKat4.FormattingEnabled = true;
            this.cbKat4.Location = new System.Drawing.Point(26, 230);
            this.cbKat4.Name = "cbKat4";
            this.cbKat4.Size = new System.Drawing.Size(121, 28);
            this.cbKat4.TabIndex = 17;
            // 
            // cbZemin
            // 
            this.cbZemin.BackColor = System.Drawing.Color.Chocolate;
            this.cbZemin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZemin.ForeColor = System.Drawing.Color.White;
            this.cbZemin.FormattingEnabled = true;
            this.cbZemin.Location = new System.Drawing.Point(26, 58);
            this.cbZemin.Name = "cbZemin";
            this.cbZemin.Size = new System.Drawing.Size(121, 28);
            this.cbZemin.TabIndex = 13;
            // 
            // cbKat3
            // 
            this.cbKat3.BackColor = System.Drawing.Color.Chocolate;
            this.cbKat3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKat3.ForeColor = System.Drawing.Color.White;
            this.cbKat3.FormattingEnabled = true;
            this.cbKat3.Location = new System.Drawing.Point(26, 188);
            this.cbKat3.Name = "cbKat3";
            this.cbKat3.Size = new System.Drawing.Size(121, 28);
            this.cbKat3.TabIndex = 16;
            // 
            // cbKat1
            // 
            this.cbKat1.BackColor = System.Drawing.Color.Chocolate;
            this.cbKat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKat1.DropDownWidth = 121;
            this.cbKat1.ForeColor = System.Drawing.Color.White;
            this.cbKat1.FormattingEnabled = true;
            this.cbKat1.Location = new System.Drawing.Point(26, 102);
            this.cbKat1.Name = "cbKat1";
            this.cbKat1.Size = new System.Drawing.Size(121, 28);
            this.cbKat1.TabIndex = 14;
            // 
            // cbKat2
            // 
            this.cbKat2.BackColor = System.Drawing.Color.Chocolate;
            this.cbKat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKat2.ForeColor = System.Drawing.Color.White;
            this.cbKat2.FormattingEnabled = true;
            this.cbKat2.Location = new System.Drawing.Point(26, 144);
            this.cbKat2.Name = "cbKat2";
            this.cbKat2.Size = new System.Drawing.Size(121, 28);
            this.cbKat2.TabIndex = 15;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.checkedListBox1.BackColor = System.Drawing.Color.White;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBox1.ForeColor = System.Drawing.Color.Black;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Bahçe",
            "Zemin Kat",
            "Kat 1",
            "Kat 2",
            "Kat 3",
            "Kat 4 ",
            "Teras"});
            this.checkedListBox1.Location = new System.Drawing.Point(100, 65);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(100, 65, 10, 10);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(285, 375);
            this.checkedListBox1.TabIndex = 15;
            // 
            // dtgrdBinaBilgileri
            // 
            this.dtgrdBinaBilgileri.BackgroundColor = System.Drawing.Color.White;
            this.dtgrdBinaBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdBinaBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdBinaBilgileri.Location = new System.Drawing.Point(793, 3);
            this.dtgrdBinaBilgileri.Name = "dtgrdBinaBilgileri";
            this.dtgrdBinaBilgileri.RowHeadersWidth = 51;
            this.dtgrdBinaBilgileri.RowTemplate.Height = 29;
            this.dtgrdBinaBilgileri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdBinaBilgileri.Size = new System.Drawing.Size(391, 444);
            this.dtgrdBinaBilgileri.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btnSil, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnListele, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEkle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnGuncelle, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 459);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1187, 91);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.BackColor = System.Drawing.Color.Chocolate;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(607, 15);
            this.btnSil.Margin = new System.Windows.Forms.Padding(15);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(266, 61);
            this.btnSil.TabIndex = 41;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnListele
            // 
            this.btnListele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListele.BackColor = System.Drawing.Color.Chocolate;
            this.btnListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnListele.ForeColor = System.Drawing.Color.White;
            this.btnListele.Location = new System.Drawing.Point(903, 15);
            this.btnListele.Margin = new System.Windows.Forms.Padding(15);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(269, 61);
            this.btnListele.TabIndex = 40;
            this.btnListele.Text = "LİSTELE";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkle.BackColor = System.Drawing.Color.Chocolate;
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(15, 15);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(15);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(266, 61);
            this.btnEkle.TabIndex = 39;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuncelle.BackColor = System.Drawing.Color.Chocolate;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(311, 15);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(15);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(266, 61);
            this.btnGuncelle.TabIndex = 38;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            // 
            // FrmBinaBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 652);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmBinaBilgileri";
            this.Text = "FrmBinaBilgileri";
            this.Load += new System.EventHandler(this.FrmBinaBilgileri_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlCombolar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdBinaBilgileri)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlCombolar;
        private ComboBox cbTeras;
        private ComboBox cbBahçe;
        private ComboBox cbKat4;
        private ComboBox cbZemin;
        private ComboBox cbKat3;
        private ComboBox cbKat1;
        private ComboBox cbKat2;
        private CheckedListBox checkedListBox1;
        private DataGridView dtgrdBinaBilgileri;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnSil;
        private Button btnListele;
        private Button btnEkle;
        private Button btnGuncelle;
    }
}