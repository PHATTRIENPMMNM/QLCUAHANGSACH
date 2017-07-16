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
    public partial class TimKiemSach : Form
    {
        public TimKiemSach()
        {
            InitializeComponent();
        }
        B_Sach objSach = new B_Sach();

        private void TimKiemSach_Load(object sender, EventArgs e)
        {

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtMa = objSach.getTableSach_Theo_MaSach(txtTimSach.Text.ToString());
            DataTable dtTen = objSach.getTableSach_Theo_TenSach(txtTimSach.Text.ToString());
            int a = 0;
            if (btnTimKiem.Text == "Tìm Kiếm")
            {
                if (txtTimSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTimSach.Focus();
                }
                else
                {
                    if (radMasach.Checked == false && radTensach.Checked == false)
                    {
                        MessageBox.Show("Vui lòng lựa chọn tìm kiếm theo mã sách hoặc tên sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        btnTimKiem.Text = "Thử lại";
                        txtTimSach.Enabled = false;
                        if (radMasach.Checked == true)
                        {
                            foreach (DataRow drw in dtMa.Rows)
                            {
                                txtMaSach.Text = drw["MaSach"].ToString();
                                txtTenSach.Text = drw["TenSach"].ToString();
                                txtSoLuong.Text = drw["SoLuong"].ToString();
                                txtMaTacGia.Text = drw["MaTG"].ToString();
                                txtMaLoai.Text = drw["MaloaiSach"].ToString();
                                a++;
                            }
                        }
                        else if (radTensach.Checked == true)
                        {
                            foreach (DataRow drw in dtTen.Rows)
                            {
                                txtMaSach.Text = drw["MaSach"].ToString();
                                txtTenSach.Text = drw["TenSach"].ToString();
                                txtSoLuong.Text = drw["SoLuong"].ToString();
                                txtMaTacGia.Text = drw["MaTG"].ToString();
                                txtMaLoai.Text = drw["MaloaiSach"].ToString();
                                a++;
                            }
                        }
                        if (a != 0)
                        {
                            lblTTTimKiem.Text = "Thông tin về sách:  " + txtTimSach.Text;
                        }
                        else
                        {
                            lblTTTimKiem.Text = "Không tìm thấy sách này trong thông tin sách";
                        }
                    }
                }
            }
            else
            {
                btnTimKiem.Text = "Tìm Kiếm";
                txtTimSach.Enabled = true;
                txtTimSach.Text = "";
                txtTimSach.Focus();

                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtSoLuong.Text = "";
                txtMaTacGia.Text = "";
                txtMaLoai.Text = "";
                lblTTTimKiem.Text = "";
            }
        }

        private void TimKiemSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
