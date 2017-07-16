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
    public partial class QuanLyDocGia : Form
    {
        public QuanLyDocGia()
        {
            InitializeComponent();            
        }

        DataTable dtDocGia;
        B_DocGia objDocGia = new B_DocGia();
        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            NapListViewDSDocGia();
            grbChiTietDG.Enabled = false;
            radNam.Checked = true;
        }
        private void NapListViewDSDocGia() 
        {
            dtDocGia = objDocGia.getTableDocGia();
            lvwDanhSachDG.Items.Clear();
            foreach (DataRow dr in dtDocGia.Rows) 
            {
                ListViewItem li = lvwDanhSachDG.Items.Add(dr["MaDG"].ToString());
                li.Tag = dr["MaDG"].ToString();
                li.SubItems.Add(dr["TenDG"].ToString());
                li.SubItems.Add((bool)dr["GioiTinh"] == false ? "Nam" : "Nữ");
                string ngaymuon = Convert.ToDateTime(dr["NgayMuon"].ToString()).ToShortDateString();
                li.SubItems.Add(ngaymuon);
                li.SubItems.Add(dr["DiaChi"].ToString());
                li.ImageIndex = 0;

            }
        }

        private void lvwDanhSachDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSachDG.SelectedItems.Count > 0)
            {
                ListViewItem li = lvwDanhSachDG.SelectedItems[lvwDanhSachDG.SelectedItems.Count-1];
                foreach (ListViewItem lvw in lvwDanhSachDG.SelectedItems)
                {
                    txtMaDG.Text = lvw.SubItems[0].Text;
                    txtTenDG.Text = lvw.SubItems[1].Text;
                    dtNgayMuon.Text = lvw.SubItems[3].Text;
                    if (lvw.SubItems[2].Text == "Nam")
                        radNam.Checked = true;
                    else
                        radNu.Checked = true;
                    txtDiaChi.Text = lvw.SubItems[4].Text;
                }
            }

        }
        private void setButton() 
        {
            btnThem.Text = "Thêm";
            txtMaDG.Text = "";
            txtTenDG.Text = "";
            radNam.Checked = true;
            dtNgayMuon.Text = "";
            txtDiaChi.Text = "";
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            lvwDanhSachDG.Enabled = true;
        }
        private void LuuThemDG() 
        {
            try
            {
                lvwDanhSachDG.Items.Clear();
                DataRow dr = dtDocGia.NewRow();
                dr["MaDG"] = txtMaDG.Text;
                dr["TenDG"] = txtTenDG.Text;
                dr["GioiTinh"] = radNu.Checked ? true : false;
                dr["NgayMuon"] = dtNgayMuon.Value;
                dr["DiaChi"] = txtDiaChi.Text;
                dtDocGia.Rows.Add(dr);
                objDocGia.CapNhatTable_DocGia(dtDocGia);
                setButton();
                NapListViewDSDocGia();
                MessageBox.Show("Lưu dữ liệu thành công!");
            }
            catch (Exception)
            {
                NapListViewDSDocGia();
                MessageBox.Show("Lưu dữ liệu thất bại!");
            }
        }
        private void LuuSuaDG() 
        {
            try
            {
                dtDocGia = objDocGia.getTableDocGia_Theo_MaDG(lvwDanhSachDG.SelectedItems[0].Text);
                dtDocGia.Rows[0]["MaDG"] = txtMaDG.Text;
                dtDocGia.Rows[0]["TenDG"] = txtTenDG.Text;
                dtDocGia.Rows[0]["GioiTinh"] = radNu.Checked ? true : false;
                dtDocGia.Rows[0]["NgayMuon"] = dtNgayMuon.Value;
                dtDocGia.Rows[0]["DiaChi"] = txtDiaChi.Text;
                objDocGia.CapNhatTable_DocGia(dtDocGia);
                MessageBox.Show("Lưu sửa dữ liệu thành công!");
                NapListViewDSDocGia();
            }
            catch (Exception)
            {

                MessageBox.Show("Thất bại!","Error");
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "")
            {
                MessageBox.Show("Chưa nhập mã Độc Giả!","Thông báo");
                txtMaDG.Focus();
            }
            else if (txtTenDG.Text == "")
            {
                MessageBox.Show("Chưa nhập Tên Độc Giả!","Thông báo");
                txtTenDG.Focus();
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ độc giả!","Thông báo");
                txtDiaChi.Focus();
            }
            else
            {
                if (lvwDanhSachDG.SelectedItems.Count == 0)
                    LuuThemDG();
                else
                    LuuSuaDG();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                grbChiTietDG.Enabled = true;
                txtMaDG.Text = "";
                txtTenDG.Text = "";
                dtNgayMuon.Text="";
                txtDiaChi.Text = "";
                txtMaDG.Focus();
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                lvwDanhSachDG.Enabled = false;
            }
            else
            {
                setButton();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachDG.SelectedItems.Count > 0)
            {
                if (btnSua.Text == "Sửa")
                {
                    btnSua.Text = "Hủy";
                    grbChiTietDG.Enabled = true;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = true;
                    dtNgayMuon.Text = "";
                    txtMaDG.Focus();
                }
                else
                {
                    btnSua.Text = "Sửa";
                    grbChiTietDG.Enabled = false;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    dtNgayMuon.Text = "";
                }
            }
            else 
            {
                MessageBox.Show("Bạn hãy chọn dữ liệu cần sửa!","Thông báo");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwDanhSachDG.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dl == DialogResult.Yes)
                {
                    DataRow[] dr = dtDocGia.Select("MaDG='" + txtMaDG.Text + "'");
                    dr[0].Delete();
                    objDocGia.CapNhatTable_DocGia(dtDocGia);
                    // clear text
                    txtMaDG.Text = "";
                    txtTenDG.Text = "";
                    radNam.Checked = true;
                    dtNgayMuon.Text = "";
                    txtDiaChi.Text = "";
                    grbChiTietDG.Enabled = false;
                    NapListViewDSDocGia();
                    MessageBox.Show("Xóa dữ liệu thành công!","Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn dữ liệu cần xóa!", "Thông báo");
            }
        }

        private void QuanLyDocGia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
