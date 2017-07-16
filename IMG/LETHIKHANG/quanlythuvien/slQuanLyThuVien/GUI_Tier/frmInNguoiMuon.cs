using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business_Tier;
namespace GUI_Tier
{
    public partial class frmInNguoiMuon : Form
    {
        public frmInNguoiMuon()
        {
            InitializeComponent();
        }
        B_MuonTraSach objNguoiMuon = new B_MuonTraSach();
        DataTable dtNguoiMuon = new DataTable();
        rptDanhSachMuonSach rpt = new rptDanhSachMuonSach();
        private void frmInNguoiMuon_Load(object sender, EventArgs e)
        {
            dtNguoiMuon = objNguoiMuon.getTableMuonTraSach();
            rpt.SetDataSource(dtNguoiMuon);
            rpt.Refresh();
            crvNguoiMuon.ReportSource = rpt;
        }
    }
}
