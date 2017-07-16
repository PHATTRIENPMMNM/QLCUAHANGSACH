namespace GUI_Tier
{
    partial class frmInNguoiMuon
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
            this.crvNguoiMuon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvNguoiMuon
            // 
            this.crvNguoiMuon.ActiveViewIndex = -1;
            this.crvNguoiMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvNguoiMuon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvNguoiMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvNguoiMuon.Location = new System.Drawing.Point(0, 0);
            this.crvNguoiMuon.Name = "crvNguoiMuon";
            this.crvNguoiMuon.Size = new System.Drawing.Size(558, 393);
            this.crvNguoiMuon.TabIndex = 0;
            // 
            // frmInNguoiMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 393);
            this.Controls.Add(this.crvNguoiMuon);
            this.Name = "frmInNguoiMuon";
            this.Text = "frmInNguoiMuon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInNguoiMuon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvNguoiMuon;
    }
}