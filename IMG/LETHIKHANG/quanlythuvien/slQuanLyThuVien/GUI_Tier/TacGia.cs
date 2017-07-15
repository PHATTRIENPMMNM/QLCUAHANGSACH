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
    public partial class TacGia : Form
    {
        public TacGia()
        {
            InitializeComponent();
        }

        DataTable dtTacGia;
        B_TacGia objTacGia = new B_TacGia();
        private void TacGia_Load(object sender, EventArgs e)
        {
            NapListView();
            grbChiTietTG.Enabled = false;
        }
        private void NapListView()
        {
            dtTacGia = objTacGia.getTableTacGia();
            lvwDanhSachTG.Items.Clear();
            foreach (DataRow dr in dtTacGia.Rows)
            {
                ListViewItem li = lvwDanhSachTG.Items.Add(dr["MaTG"].ToString());
                li.Tag = dr["MaTG"].ToString();
                li.SubItems.Add(dr["TenTG"].ToString());
                li.SubItems.Add(dr["DiaChi"].ToString());
                li.ImageIndex = 0;
            }
        }
        private void setButton()
        {
            btnThem.Text = "Thêm";
            txtMaTG.Text = "";
            txtTenTG.Text = "";
            txtDiaChi.Text = "";
            txtMaTG.Focus();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            lvwDanhSachTG.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                txtMaTG.Text = "";
                txtTenTG.Text = "";
                txtDiaChi.Text = "";
                txtMaTG.Focus();
                grbChiTietTG.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                lvwDanhSachTG.Enabled = false;
            }
            else
            {
                setButton();
            }
        }
        private void LuuThemTG() 
        {
            try
            {
                lvwDanhSachTG.Items.Clear();
                DataRow dr = dtTacGia.NewRow();
                dr["MaTG"] = txtMaTG.Text;
                dr["TenTG"] = txtTenTG.Text;
                dr["DiaChi"] = txtDiaChi.Text;
                dtTacGia.Rows.Add(dr);
                objTacGia.CapNhatTable_TacGia(dtTacGia);
                setButton();
                NapListView();
                MessageBox.Show("Lưu mới tác giả thành công!");
            }
            catch (Exception)
            {
                NapListView();
                MessageBox.Show("Mã tác giả " + txtMaTG.Text + " đã tồn tại\nVui lòng nhập mã tác giả khác!");
                txtMaTG.Focus();
            }
        }
        private void LuuSuaTG() 
        {
            try
            {
                dtTacGia = objTacGia.getTableTG_Theo_MaTG(lvwDanhSachTG.SelectedItems[0].Text);
                dtTacGia.Rows[0]["MaTG"] = txtMaTG.Text;
                dtTacGia.Rows[0]["TenTG"] = txtTenTG.Text;
                dtTacGia.Rows[0]["DiaChi"] = txtDiaChi.Text;
                objTacGia.CapNhatTable_TacGia(dtTacGia);
                MessageBox.Show("Lưu sửa dữ liệu thành công!");
                NapListView();
            }
            catch (Exception)
            {

                MessageBox.Show("Thất bại!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTG.Text == "") 
            {
                MessageBox.Show("Chưa nhập mã tác giả!","Error");
                txtMaTG.Focus();
            }
            else if (txtTenTG.Text == "") 
            {
                MessageBox.Show("Chưa nhập tên tác giả!","Error");
                txtTenTG.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ tác giả", "Error");
                txtDiaChi.Focus();
            }
            else
            {
                if (lvwDanhSachTG.SelectedItems.Count == 0)
                    LuuThemTG();
                else
                    LuuSuaTG();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachTG.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Bạn có chắc muốn xoa dữ liệu này không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    try
                    {
                        DataRow[] dr = dtTacGia.Select("MaTG='" + txtMaTG.Text + "'");
                        dr[0].Delete();
                        objTacGia.CapNhatTable_TacGia(dtTacGia);
                        // clear text
                        txtMaTG.Text = "";
                        txtTenTG.Text = "";
                        txtDiaChi.Text = "";
                        setButton();
                        NapListView();
                        MessageBox.Show("Xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dữ liệu cần xóa!");
            }
        }
        private void lvwDanhSachTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSachTG.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvw in lvwDanhSachTG.SelectedItems)
                {
                    ListViewItem item = new ListViewItem();
                    txtMaTG.Text = lvw.SubItems[0].Text;
                    txtTenTG.Text = lvw.SubItems[1].Text;
                    txtDiaChi.Text = lvw.SubItems[2].Text;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachTG.SelectedItems.Count > 0)
            {
                if (btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Hủy";
                    grbChiTietTG.Enabled = true;
                    txtMaTG.Focus();
                    txtMaTG.SelectAll();
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    txtMaTG.Enabled = false;
                }
                else
                {
                    btnSua.Text = "Sửa";
                    grbChiTietTG.Enabled = false;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
            else 
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu cần sửa!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TacGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }
    }
}
