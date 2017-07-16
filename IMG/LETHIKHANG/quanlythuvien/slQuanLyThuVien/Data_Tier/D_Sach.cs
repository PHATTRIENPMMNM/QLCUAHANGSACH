using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.OleDb;
namespace Data_Tier
{
   public class D_Sach :Connect_Data
    {
       public DataSet getSach_Theo_MaLoaiSach(string strMaLoai) 
       {
           OleDbCommand cmd = new OleDbCommand("select * from Sach where maloaisach=@maloaisach", conn);
           cmd.Parameters.Add("@maloaisach", OleDbType.BSTR).Value = strMaLoai;
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataSet ds = new DataSet();
           da.Fill(ds, "Sach");
           return ds;
       }
       public DataSet getSach_Theo_MaSach(string strMasach)
       {
           OleDbCommand cmd = new OleDbCommand("select * from Sach where masach=@masach", conn);
           cmd.Parameters.Add("@masach", OleDbType.BSTR).Value = strMasach;
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataSet ds = new DataSet();
           da.Fill(ds, "Sach");
           return ds;
       }
       public DataSet getSach_Theo_Ten(string strTensach)
       {
           OleDbCommand cmd = new OleDbCommand("select * from Sach where tensach=@tensach", conn);
           cmd.Parameters.Add("@tensach", OleDbType.BSTR).Value = strTensach;
           OleDbDataAdapter da = new OleDbDataAdapter(cmd);
           DataSet ds = new DataSet();
           da.Fill(ds, "Sach");
           return ds;
       }
    }
}
