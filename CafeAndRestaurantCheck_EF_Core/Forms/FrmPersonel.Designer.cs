namespace CafeAndRestaurantCheck_EF_Core.Forms
{
    partial class FrmPersonel
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flwpBinaBolumleri = new System.Windows.Forms.FlowLayoutPanel();
            this.flwpMasa = new System.Windows.Forms.FlowLayoutPanel();
            this.MasaMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MasaTasi = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.MasaMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.flwpBinaBolumleri, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flwpMasa, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 747);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flwpBinaBolumleri
            // 
            this.flwpBinaBolumleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwpBinaBolumleri.Location = new System.Drawing.Point(3, 3);
            this.flwpBinaBolumleri.Name = "flwpBinaBolumleri";
            this.flwpBinaBolumleri.Size = new System.Drawing.Size(268, 741);
            this.flwpBinaBolumleri.TabIndex = 0;
            // 
            // flwpMasa
            // 
            this.flwpMasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwpMasa.Location = new System.Drawing.Point(277, 3);
            this.flwpMasa.Name = "flwpMasa";
            this.flwpMasa.Size = new System.Drawing.Size(1090, 741);
            this.flwpMasa.TabIndex = 1;
            // 
            // MasaMenuStrip
            // 
            this.MasaMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MasaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MasaTasi});
            this.MasaMenuStrip.Name = "MasaMenuStrip";
            this.MasaMenuStrip.Size = new System.Drawing.Size(142, 28);
            // 
            // MasaTasi
            // 
            this.MasaTasi.Name = "MasaTasi";
            this.MasaTasi.Size = new System.Drawing.Size(141, 24);
            this.MasaTasi.Text = "Masa Taşı";
            this.MasaTasi.Click += new System.EventHandler(this.MasaTasi_Click);
            // 
            // FrmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPersonel";
            this.Text = "FrmPersonel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPersonel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MasaMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flwpBinaBolumleri;
        private FlowLayoutPanel flwpMasa;
        private ContextMenuStrip MasaMenuStrip;
        private ToolStripMenuItem MasaTasi;
    }
}