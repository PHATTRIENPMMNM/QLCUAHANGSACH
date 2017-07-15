using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Data_Tier;

namespace Business_Tier
{
    public  class B_DocGia
    {
        D_DocGia objDocGia = new D_DocGia();

        public DataTable getTableDocGia() 
        {
            return objDocGia.getAllTable("NguoiMuon").Tables["NguoiMuon"];
        }
        public DataTable getTableDocGia_Theo_MaDG(string strMaDG) 
        {
            return objDocGia.getDocGia_Theo_MaDG(strMaDG).Tables["NguoiMuon"];
        }
        public void CapNhatTable_DocGia(DataTable tbDocGia)
        {
            objDocGia.CapNhatDuLieu(tbDocGia, "NguoiMuon");
        }
    }
}
