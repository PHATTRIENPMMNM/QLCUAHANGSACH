using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Data_Tier
{
    public class D_TacGia : Connect_Data
    {
        public DataSet getTacGia_Theo_MaTG(string strMaTG)
        {
            OleDbCommand cmd = new OleDbCommand("select * from TacGia where matg=@matg", conn);
            cmd.Parameters.Add("@matg", OleDbType.BSTR).Value = strMaTG;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "TacGia");
            return ds;
        }
    }
}
