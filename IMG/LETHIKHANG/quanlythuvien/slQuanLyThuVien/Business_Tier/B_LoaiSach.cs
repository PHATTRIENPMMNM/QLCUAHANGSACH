using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Data_Tier;
namespace Business_Tier
{
    public class B_LoaiSach
    {
        D_LoaiSach objLoaiSach = new D_LoaiSach();
        public DataTable getTableLoaiSach()
        {
            return objLoaiSach.getAllTable("LoaiSach").Tables["LoaiSach"];
        }
        public DataTable getTableLoaiSach_Theo_MaLoai(string strMaLoai) 
        {
            return objLoaiSach.getLoaiSach_Theo_MaLoai(strMaLoai).Tables["LoaiSach"];
        }
        public void CapNhatTale_LoaiSach(DataTable dtLoaiSach)
        {
            objLoaiSach.CapNhatDuLieu(dtLoaiSach, "LoaiSach");
        }
    }
}
