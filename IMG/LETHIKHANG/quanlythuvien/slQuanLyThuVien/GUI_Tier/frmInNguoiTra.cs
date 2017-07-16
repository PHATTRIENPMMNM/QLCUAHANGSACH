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
    public partial class frmInNguoiTra : Form
    {
        public frmInNguoiTra()
        {
            InitializeComponent();
        }
        B_MuonTraSach objNguoiTra = new B_MuonTraSach();
        DataTable dtNguoiTra = new DataTable();
        rptInNguoiTra rpt = new rptInNguoiTra();
        private void frmInNguoiTra_Load(object sender, EventArgs e)
        {
            dtNguoiTra = objNguoiTra.getTableMuonTraSach();
            rpt.SetDataSource(dtNguoiTra);
            rpt.Refresh();
            crvNguoiTra.ReportSource = rpt;
        }
    }
}
