using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Data_Tier;

namespace Business_Tier
{
    public class B_Sach
    {
        D_Sach objSach = new D_Sach();
        public DataTable getTableSach_Theo_MaSach(string strMaSach) 
        {
            return objSach.getSach_Theo_MaSach(strMaSach).Tables["Sach"];
        }
        public DataTable getTableSach_Theo_MaLoaiSach(string strMaLoaiSach)
        {
            return objSach.getSach_Theo_MaLoaiSach(strMaLoaiSach).Tables["Sach"];
        }
        public DataTable getTableSach_Theo_TenSach(string strTenSach)
        {
            return objSach.getSach_Theo_Ten(strTenSach).Tables["Sach"];
        }
        public DataTable getTableSach() 
        {
            return objSach.getAllTable("Sach").Tables["Sach"];
        }
        public void CapNhatTable_Sach(DataTable tbSach)
        {
            objSach.CapNhatDuLieu(tbSach,"Sach");
        }    
    }
}
