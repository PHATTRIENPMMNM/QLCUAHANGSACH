namespace GUI_Tier
{
    partial class frmInNguoiTra
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
            this.crvNguoiTra = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvNguoiTra
            // 
            this.crvNguoiTra.ActiveViewIndex = -1;
            this.crvNguoiTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNguoiTra.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvNguoiTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvNguoiTra.Location = new System.Drawing.Point(0, 0);
            this.crvNguoiTra.Name = "crvNguoiTra";
            this.crvNguoiTra.Size = new System.Drawing.Size(463, 357);
            this.crvNguoiTra.TabIndex = 0;
            // 
            // frmInNguoiTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 357);
            this.Controls.Add(this.crvNguoiTra);
            this.Name = "frmInNguoiTra";
            this.Text = "frmInNguoiTra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInNguoiTra_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNguoiTra;
    }
}