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
    public partial class MuonTraSach : Form
    {
        public MuonTraSach()
        {
            InitializeComponent();
        }
        B_MuonTraSach objMuonTra = new B_MuonTraSach();
        B_Sach objSach = new B_Sach();
        B_LoaiSach objLoaiSach = new B_LoaiSach();
        DataTable dtMuonTra,dtSach;
        private void MuonTraSach_Load(object sender, EventArgs e)
        {
            NapListviewMuonSach();
            NapListviewTraSach();
            LoadComboBox();
            LoadComboBoxTraSach();
        }
        private void LoadComboBox() 
        {
            dtMuonTra = objMuonTra.getTableMuonTraSach();
            cbMaDG.DataSource = dtMuonTra;
            cbMaDG.DisplayMember = "MaDG";
            cbMaDG.ValueMember = "MaDG";
            dtSach = objSach.getTableSach();
            cbChonMaSach.DataSource = dtSach;
            cbChonMaSach.DisplayMember = "TenSach";
            cbChonMaSach.ValueMember = "MaSach";
        }
        private void LoadComboBoxTraSach() 
        {
            dtMuonTra = objMuonTra.getTableMuonTraSach();
            cbMaDG_TraSach.DataSource = dtMuonTra;
            cbMaDG_TraSach.DisplayMember = "MaDG";
            cbMaDG_TraSach.ValueMember = "MaDG";
        }
        private void NapListviewMuonSach() 
        {
            dtMuonTra = objMuonTra.getTableMuonTraSach();
            foreach (DataRow dr in dtMuonTra.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Text = dr["MaDG"].ToString();
                li.SubItems.Add(dr["MaSach"].ToString());
                li.SubItems.Add(dr["SoLuong"].ToString());
                string ngaymuon = Convert.ToDateTime(dr["NgayMuon"].ToString()).ToShortDateString();
                li.SubItems.Add(ngaymuon);
                string ngayhentra = Convert.ToDateTime(dr["NgayHenTra"].ToString()).ToShortDateString();
                li.SubItems.Add(ngayhentra);
                lvwDanhSach.Items.Add(li);

            }
        }
        private void NapListviewTraSach()
        {
            dtMuonTra = objMuonTra.getTableMuonTraSach();
            foreach (DataRow dr in dtMuonTra.Rows)
            {
                ListViewItem li = lvwDanhSachTra.Items.Add(dr["MaDG"].ToString());
                li.Text = dr["MaDG"].ToString();
                li.SubItems.Add(dr["MaSach"].ToString());
                li.SubItems.Add(dr["SoLuong"].ToString());
                string ngaymuon = Convert.ToDateTime(dr["NgayMuon"].ToString()).ToShortDateString();
                li.SubItems.Add(ngaymuon);
                string ngayhentra = Convert.ToDateTime(dr["NgayHenTra"].ToString()).ToShortDateString();
                li.SubItems.Add(ngayhentra);
                string ngaytra = Convert.ToDateTime(dr["NgayTra"].ToString()).ToShortDateString();
                li.SubItems.Add(ngaytra);
                //lvwDanhSachTra.Items.Add(li);

            }
        }

        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                ListViewItem li = lvwDanhSach.SelectedItems[lvwDanhSach.SelectedItems.Count - 1];
                foreach (ListViewItem lvw in lvwDanhSach.SelectedItems)
                {
                    cbMaDG.Text = lvw.SubItems[0].Text;
                    txtMaSach.Text = lvw.SubItems[1].Text;
                    txtSoLuong.Text = lvw.SubItems[2].Text;
                    dtNgayMuon.Text = lvw.SubItems[3].Text;
                    dtNgayHenTra.Text = lvw.SubItems[4].Text;
                }
            }
        }

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            cbMaDG.Text = "";
            txtMaSach.Text = "";
            dtNgayMuon.Text = "";
            dtNgayHenTra.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") 
            {
                MessageBox.Show("Chưa nhập mã sách!");
                txtMaSach.Focus();
            }
            else if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng sách cho mượn!");
                txtSoLuong.Focus();
            }
            else
            {
                try
                {
                    //lvwDanhSach.Items.Clear();
                    DataRow dr = dtMuonTra.NewRow();
                    dr["MaDG"] = cbMaDG.Text;
                    dr["MaSach"] = txtMaSach.Text;
                    dr["SoLuong"] = txtSoLuong.Text;
                    dr["NgayMuon"] = dtNgayMuon.Value;
                    dr["NgayHenTra"] = dtNgayHenTra.Text;
                    dtMuonTra.Rows.Add(dr);
                    objMuonTra.CapNhatTable_MuonTra(dtMuonTra);
                    //setButton();
                    NapListviewMuonSach();
                    MessageBox.Show("Đã cho mượn thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã sách "+txtMaSach.Text+" không có trong kho sách!\nHãy nhập mã sách khác!");
                    NapListviewMuonSach();
                    txtMaSach.Focus();
                }
            }
        }
        private void cbChonMaSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string strmasach = cbChonMaSach.SelectedValue.ToString();
            dtSach = objSach.getTableSach_Theo_MaSach(strmasach);
            foreach (DataRow drw in dtSach.Rows)
            { 
                lblMaSach.Text = drw["MaSach"].ToString();
                lblMaLoai.Text = drw["MaLoaiSach"].ToString();
                lblSoLuong.Text = drw["SoLuong"].ToString();
                lblMaTG.Text = drw["MaTG"].ToString();
            }
        }

        private void MuonTraSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lvwDanhSachTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSachTra.SelectedItems.Count > 0)
            {
                ListViewItem li = lvwDanhSachTra.SelectedItems[lvwDanhSachTra.SelectedItems.Count - 1];
                foreach (ListViewItem lvw in lvwDanhSachTra.SelectedItems)
                {
                    cbMaDG_TraSach.SelectedValue = lvw.SubItems[0].Text;
                    txtMaSach_TraSach.Text = lvw.SubItems[1].Text;
                    txtSoLuong_TraSach.Text = lvw.SubItems[2].Text;
                    dtNgayMuon_TraSach.Text = lvw.SubItems[3].Text;
                    dtNgayHenTra_TraSach.Text = lvw.SubItems[4].Text;
                    dtNgayTra.Text = lvw.SubItems[5].Text;
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            DateTime ngayhentra = dtNgayHenTra_TraSach.Value;
            DateTime ngaytra = dtNgayTra.Value;
            if (ngaytra<=ngayhentra)
            {
                lblTinhTrangTraSach.Text = "Đúng hạn";
            }
            else 
            {
                lblTinhTrangTraSach.Text = "Quá hạn";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dtMuonTra.NewRow();
                dr["MaDG"] = cbMaDG_TraSach.Text;
                dr["MaSach"] = txtMaSach_TraSach.Text;
                dr["SoLuong"] = txtSoLuong_TraSach.Text;
                dr["NgayMuon"] = dtNgayMuon_TraSach.Text;
                dr["NgayHenTra"] = dtNgayHenTra_TraSach.Text;
                dr["NgayTra"] = dtNgayTra.Value;
                dtMuonTra.Rows.Add(dr);
                objMuonTra.CapNhatTable_MuonTra(dtMuonTra);
                NapListviewTraSach();
                MessageBox.Show("Đã trả!");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
