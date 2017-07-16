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
    public partial class frmInBangSach : Form
    {
        public frmInBangSach()
        {
            InitializeComponent();
        }
        B_Sach objSach = new B_Sach();
        DataTable dtSach = new DataTable();
        rptInDanhMucSach rpt = new rptInDanhMucSach();//Tao doi tuong
        private void frmInBangSach_Load(object sender, EventArgs e)
        {
            dtSach = objSach.getTableSach();
            rpt.SetDataSource(dtSach);
            rpt.Refresh();
            crv_InDanhMucSach.ReportSource = rpt;
        }
    }
}
