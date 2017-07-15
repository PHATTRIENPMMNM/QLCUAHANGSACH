using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Data_Tier
{
    public class D_LoaiSach :Connect_Data
    {
        public DataSet getLoaiSach_Theo_MaLoai(string strMaLoai) 
        {
            OleDbCommand cmd = new OleDbCommand("Select * from LoaiSach where maloaisach=@maloaisach", conn);
            cmd.Parameters.Add("@maloaisach", OleDbType.BSTR).Value = strMaLoai;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "LoaiSach");
            return ds;
        }
    }
}
