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
    public partial class DanhMucSach : Form
    {
        public DanhMucSach()
        {
            InitializeComponent();
        }
        DataTable dtLoaiSach, dtSach;
        B_LoaiSach objLoaiSach=new B_LoaiSach();
        B_Sach objSach = new B_Sach();
        private void DanhMucSach_Load(object sender, EventArgs e)
        {
            NapDuLieuLoaiSach();
        }
        private void NapDuLieuLoaiSach() 
        {
            dtLoaiSach = objLoaiSach.getTableLoaiSach();
            foreach(DataRow dr in dtLoaiSach.Rows)
            {
                ListViewItem li = lvwLoaiSach.Items.Add(dr["TenLoai"].ToString());
                li.Tag = dr["MaLoaiSach"].ToString();
                li.ImageIndex = 0;
            }
        }
        private void lvwLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwDanhSach.Items.Clear();
            if (lvwLoaiSach.SelectedItems.Count > 0) 
            {
                dtSach = objSach.getTableSach_Theo_MaLoaiSach(lvwLoaiSach.SelectedItems[0].Tag.ToString());
                foreach (DataRow dr in dtSach.Rows)
                {
                    ListViewItem li = lvwDanhSach.Items.Add(dr["MaSach"].ToString());
                    li.Tag = dr["MaSach"].ToString();
                    li.SubItems.Add(dr["TenSach"].ToString());
                    li.SubItems.Add(dr["MaLoaiSach"].ToString());
                    li.SubItems.Add(dr["SoLuong"].ToString());
                    li.SubItems.Add(dr["MaTG"].ToString());
                    li.ImageIndex = 1;
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
                //strMaLoaiSach_Chon = lvwLoaiSach.SelectedItems[0].Tag.ToString();
                CapNhat f = new CapNhat();
                f.ShowDialog();
        }

        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvw in lvwDanhSach.SelectedItems)
                {
                    ListViewItem item = lvwDanhSach.SelectedItems[0];
                    txtMaSach.Text = lvw.SubItems[0].Text;
                    txtTenSach.Text = lvw.SubItems[1].Text;
                    txtMaLoai.Text = lvw.SubItems[2].Text;
                    txtSoLuong.Text = lvw.SubItems[3].Text;
                    txtMaTG.Text = lvw.SubItems[4].Text;

                }
            }
        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            QuanLyDocGia f = new QuanLyDocGia();
            f.ShowDialog();
        }

        private void btnQuanLyTacGia_Click(object sender, EventArgs e)
        {
            TacGia f = new TacGia();
            f.ShowDialog();
        }

        private void btnQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            MuonTraSach f = new MuonTraSach();
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSach f = new TimKiemSach();
            f.ShowDialog();
        }

        private void loaiSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInBangSach f = new frmInBangSach();
            f.ShowDialog();
        }

        private void đôcGiaMươnSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInNguoiMuon f = new frmInNguoiMuon();
            f.ShowDialog();
        }

        private void danhSachĐôcGiaTraSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInNguoiTra f = new frmInNguoiTra();
            f.ShowDialog();
        }

        private void DanhMucSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
