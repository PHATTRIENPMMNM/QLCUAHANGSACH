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
    public partial class CapNhat : Form
    {
        public CapNhat()
        {
            InitializeComponent();
        }
        DataTable dtSach,dtLoaiSach,dtTacGia;
        B_LoaiSach objLoaiSach=new B_LoaiSach();
        B_Sach objSach=new B_Sach();
        B_TacGia objTacGia = new B_TacGia();
        BindingSource bs = new BindingSource();
        public static string strCapNhat;
        private void CapNhat_Load(object sender, EventArgs e)
        {
            NapListViewDanhSach();
            NapListViewLoaiSach();
            NapComboBox();
            grbChiTietLoaiSach.Enabled = false;
            grbChiTietSach.Enabled = false;
        }
        private void NapListViewDanhSach() 
        {        
            dtSach = objSach.getTableSach();
            lvwDanhSach.Items.Clear();
            foreach (DataRow dr in dtSach.Rows)
            {
                ListViewItem li = lvwDanhSach.Items.Add(dr["MaSach"].ToString());
                li.Tag = dr["MaSach"].ToString();
                li.SubItems.Add(dr["TenSach"].ToString());
                li.SubItems.Add(dr["MaLoaiSach"].ToString());
                li.SubItems.Add(dr["SoLuong"].ToString());
                li.SubItems.Add(dr["MaTG"].ToString());
                li.ImageIndex = 0;
            }
        }
        private void NapListViewLoaiSach() 
        {
            dtLoaiSach = objLoaiSach.getTableLoaiSach();
            lvwDanhSachLoaiSach.Items.Clear();
            foreach (DataRow dr in dtLoaiSach.Rows)
            {
                ListViewItem li = lvwDanhSachLoaiSach.Items.Add(dr["MaLoaiSach"].ToString());
                li.Tag = dr["MaLoaiSach"].ToString();
                li.SubItems.Add(dr["TenLoai"].ToString());
                li.SubItems.Add(dr["KieuSach"].ToString());
                li.ImageIndex = 0;
            }
        }
        private void NapComboBox() 
        {
            dtLoaiSach=objLoaiSach.getTableLoaiSach();
            cbMaLoai.DataSource = dtLoaiSach;
            cbMaLoai.DisplayMember = "TenLoai";
            cbMaLoai.ValueMember = "MaLoaiSach";
            dtTacGia = objTacGia.getTableTacGia();
            cbTenTG.DataSource = dtTacGia;
            cbTenTG.DisplayMember = "TenTG";
            cbTenTG.ValueMember = "MaTG";
        }
        private void lvwDanhSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwDanhSach.SelectedItems[0];
                if (item != null)
                {
                    foreach (ListViewItem lvw in lvwDanhSach.SelectedItems)
                    {
                        txtMaSach.Text = lvw.SubItems[0].Text;
                        txtTenSach.Text = lvw.SubItems[1].Text;
                        cbMaLoai.SelectedValue = lvw.SubItems[2].Text;
                        txtSoLuong.Text = lvw.SubItems[3].Text;
                        cbTenTG.SelectedValue = lvw.SubItems[4].Text;
                    }
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtSoLuong.Text = "";
                grbChiTietSach.Enabled = true;
                txtMaSach.Focus();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                lvwDanhSach.Enabled = false;
            }
            else
            {
                grbChiTietSach.Enabled = false;
                btnThem.Text = "Thêm";
                txtMaSach.Text = "";
                txtTenSach.Text = "";
                txtSoLuong.Text = "";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                lvwDanhSach.Enabled = true;
            }
        }
        private void LuuThem() 
        {
            try
            {
                DataRow dr = dtSach.NewRow();
                dr["masach"] = txtMaSach.Text;
                dr["tensach"] = txtTenSach.Text;
                dr["maloaisach"] = cbMaLoai.SelectedValue;
                dr["soluong"] = Convert.ToInt32(txtSoLuong.Text);
                dr["matg"] = cbTenTG.SelectedValue;
                dtSach.Rows.Add(dr);
                objSach.CapNhatTable_Sach(dtSach);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                lvwDanhSach.Enabled = true;
                btnThem.Text = "Thêm";
                MessageBox.Show("Lưu mới dữ liệu " + txtMaSach.Text + " thành công!");
                NapListViewDanhSach();
            }
            catch (Exception)
            {
                MessageBox.Show("Mã Sách " + txtMaSach.Text + " đã tồn tại! \nVui nhập nhập mã sách khác!");
                NapListViewDanhSach();
                txtMaSach.Focus();
            }
        }
        private void LuuSua() 
        {
            try
            {
                dtSach = objSach.getTableSach_Theo_MaSach(lvwDanhSach.SelectedItems[0].Text);
                dtSach.Rows[0]["MaSach"] = txtMaSach.Text;
                dtSach.Rows[0]["TenSach"] = txtTenSach.Text;
                dtSach.Rows[0]["MaLoaiSach"] = cbMaLoai.SelectedValue;
                dtSach.Rows[0]["MaTG"] = cbTenTG.SelectedValue;
                dtSach.Rows[0]["SoLuong"] = Convert.ToInt32(txtSoLuong.Text);
                objSach.CapNhatTable_Sach(dtSach);
                MessageBox.Show("Lưu sửa dữ liệu thành công!");
                NapListViewDanhSach();
            }
            catch (Exception)
            {

                MessageBox.Show("Thất bại!");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") 
            {
                MessageBox.Show("Chưa nhập mã sách!", "Error");
                txtMaSach.Focus();
            }
            else if (txtTenSach.Text == "") 
            {
                MessageBox.Show("Chưa nhập tên sách!", "Error");
                txtTenSach.Focus();
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng sách!", "Error");
                txtSoLuong.Focus();
            }
            else
            {
                if (lvwDanhSach.SelectedItems.Count == 0)
                {
                    LuuThem();
                }
                else 
                {
                    LuuSua();
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Bạn có chắc muốn xoa dữ liệu này không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    try
                    {
                        DataRow[] dr = dtSach.Select("MaSach='" + txtMaSach.Text + "'");
                        dr[0].Delete();
                        objSach.CapNhatTable_Sach(dtSach);
                        // clear text
                        txtMaSach.Text = "";
                        txtTenSach.Text = "";
                        cbMaLoai.Text = "";
                        txtSoLuong.Text = "";
                        cbTenTG.Text = "";
                        MessageBox.Show("Đã xóa dữ liệu!", "Thông Báo!");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else 
            {
                MessageBox.Show("Hãy chọn dữ liệu cần xóa!", "Thông báo");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                if (btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Hủy";
                    grbChiTietSach.Enabled = true;
                    txtMaSach.Enabled = false;
                    txtTenSach.SelectAll();
                    txtTenSach.Focus();
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                {
                    btnSua.Text = "Sửa";
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    grbChiTietSach.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn dữ liệu cần sửa!", "Thông Báo!");
                grbChiTietSach.Enabled = false;
            }
        }
        private void CapNhat_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                e.Handled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setButtonLoaiSach()
        {
            btnThemLoaiSach.Text = "Thêm";
            txtMaLoaiSach.Text = "";
            txtTenLoaiSach.Text = "";
            txtKieuSach.Text = "";
            txtMaLoaiSach.Focus();
            btnXoaLoaiSach.Enabled = true;
            btnSuaLoaiSach.Enabled = true;
            lvwDanhSachLoaiSach.Enabled = true;
        }

        private void lvwDanhSachLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSachLoaiSach.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvw in lvwDanhSachLoaiSach.SelectedItems)
                {
                    ListViewItem item = new ListViewItem();
                    txtMaLoaiSach.Text = lvw.SubItems[0].Text;
                    txtTenLoaiSach.Text = lvw.SubItems[1].Text;
                    txtKieuSach.Text = lvw.SubItems[2].Text;
                }
            }
        }
        private void btnThemLoaiSach_Click(object sender, EventArgs e)
        {
            if (btnThemLoaiSach.Text == "Thêm")
            {
                btnThemLoaiSach.Text = "Hủy";
                txtMaLoaiSach.Text = "";
                txtTenLoaiSach.Text = "";
                txtKieuSach.Text = "";
                grbChiTietLoaiSach.Enabled = true;
                txtMaLoaiSach.Focus();
                btnXoaLoaiSach.Enabled = false;
                btnSuaLoaiSach.Enabled = false;
                lvwDanhSachLoaiSach.Enabled = false;
            }
            else
            {
                setButtonLoaiSach();
                grbChiTietLoaiSach.Enabled = false;
            }
        }
        private void LuuThemLoaiSach() 
        {
            try
            {
                lvwDanhSachLoaiSach.Items.Clear();
                DataRow dr = dtLoaiSach.NewRow();
                dr["MaLoaiSach"] = txtMaLoaiSach.Text;
                dr["TenLoai"] = txtTenLoaiSach.Text;
                dr["KieuSach"] = txtKieuSach.Text;
                setButtonLoaiSach();
                dtLoaiSach.Rows.Add(dr);
                objLoaiSach.CapNhatTale_LoaiSach(dtLoaiSach);
                NapListViewLoaiSach();
                MessageBox.Show("Lưu mới dữ liệu thành công!");
            }
            catch (Exception)
            {
                NapListViewLoaiSach();
                MessageBox.Show("Mã loại sách " + txtMaLoaiSach.Text + " đã tồn tại!\nVui lòng nhập lại mã loại sách!");
                txtMaLoaiSach.Focus();
            }
        }
        private void LuuSuaLoaiSach()
        {
            try
            {
                dtLoaiSach = objLoaiSach.getTableLoaiSach_Theo_MaLoai(lvwDanhSachLoaiSach.SelectedItems[0].Text);
                dtLoaiSach.Rows[0]["MaLoaiSach"] = txtMaLoaiSach.Text;
                dtLoaiSach.Rows[0]["TenLoai"] = txtTenLoaiSach.Text;
                dtLoaiSach.Rows[0]["KieuSach"] = txtKieuSach.Text;
                objLoaiSach.CapNhatTale_LoaiSach(dtLoaiSach);
                MessageBox.Show("Lưu sửa dữ liệu thành công!");
                NapListViewLoaiSach();
            }
            catch (Exception)
            {

                MessageBox.Show("Thất bại!");
            }
        }
        private void btnLuuLoaiSach_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiSach.Text == "")
            {
                MessageBox.Show("Chưa nhập mã loại sách!", "Error");
                txtMaLoaiSach.Focus();
            }
            else if (txtTenLoaiSach.Text == "")
            {
                MessageBox.Show("Chưa nhập tên loại sách!", "Error");
                txtTenLoaiSach.Focus();
            }
            else if (txtKieuSach.Text == "")
            {
                MessageBox.Show("Chưa nhập kiểu sách!", "Error");
                txtKieuSach.Focus();
            }
            else
            {
                if (lvwDanhSachLoaiSach.SelectedItems.Count == 0)
                {
                    LuuThemLoaiSach();
                }
                else
                {
                    LuuSuaLoaiSach();
                }
            }
        }
        private void btnXoaLoaiSach_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachLoaiSach.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Bạn có chắc muốn xoa dữ liệu này không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    try
                    {
                        DataRow[] dr = dtLoaiSach.Select("MaLoaiSach='" + txtMaLoaiSach.Text + "'");
                        dr[0].Delete();
                        objLoaiSach.CapNhatTale_LoaiSach(dtLoaiSach);
                        // clear text
                        txtMaLoaiSach.Text = "";
                        txtTenLoaiSach.Text = "";
                        txtKieuSach.Text = "";
                        setButtonLoaiSach();
                        NapListViewLoaiSach();
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
                MessageBox.Show("Bạn hãy chọn dữ liệu cần xóa!");
            }
        }

        private void btnThoatLoaiSach_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSuaLoaiSach_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachLoaiSach.SelectedItems.Count >0)
            {
                if (btnSuaLoaiSach.Text == "Sửa")
                {
                    btnSuaLoaiSach.Text = "Hủy";
                    grbChiTietLoaiSach.Enabled = true;
                    txtMaLoaiSach.Enabled = false;
                    txtTenLoaiSach.SelectAll();
                    txtTenLoaiSach.Focus();
                    btnThemLoaiSach.Enabled = false;
                    btnXoaLoaiSach.Enabled = false;
                }
                else
                {
                    btnSuaLoaiSach.Text = "Sửa";
                    grbChiTietLoaiSach.Enabled = false;
                    btnThemLoaiSach.Enabled = true;
                    btnXoaLoaiSach.Enabled = true;
                }
            }
            else 
            {
                MessageBox.Show("Chưa chọn dữ liệu cần sữa!");
            }
        }
    }
}
