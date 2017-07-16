using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Data_Tier
{
    public  class D_DocGia :Connect_Data
    {
        public DataSet getDocGia_Theo_MaDG(string strMaDG) 
        {
            OleDbCommand cmd = new OleDbCommand("select * from NguoiMuon where madg=@madg", conn);
            cmd.Parameters.Add("@madg", OleDbType.BSTR).Value = strMaDG;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "NguoiMuon");
            return ds;
        }
    }
}
