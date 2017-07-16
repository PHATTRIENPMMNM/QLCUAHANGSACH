namespace GUI_Tier
{
    partial class frmInBangSach
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
            this.crv_InDanhMucSach = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crv_InDanhMucSach
            // 
            this.crv_InDanhMucSach.ActiveViewIndex = -1;
            this.crv_InDanhMucSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_InDanhMucSach.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_InDanhMucSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_InDanhMucSach.Location = new System.Drawing.Point(0, 0);
            this.crv_InDanhMucSach.Name = "crv_InDanhMucSach";
            this.crv_InDanhMucSach.Size = new System.Drawing.Size(557, 369);
            this.crv_InDanhMucSach.TabIndex = 0;
            // 
            // frmInBangSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 369);
            this.Controls.Add(this.crv_InDanhMucSach);
            this.Name = "frmInBangSach";
            this.Text = "frmInBangSach";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInBangSach_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_InDanhMucSach;

    }
}