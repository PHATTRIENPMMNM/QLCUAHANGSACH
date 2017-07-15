using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Data_Tier
{
  public class Connect_Data
    {
        public OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=QuanLyThuVien.accdb;");
        public DataSet getAllTable(string strTable) 
        {
            OleDbCommand cmd = new OleDbCommand("select * from "+strTable, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds, strTable);
            return ds;
        }
        public void CapNhatDuLieu(DataTable dtTable, string strTableName) 
        {
            OleDbCommand cmd = new OleDbCommand("select * from " + strTableName + " where 8=16 ", conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds, strTableName);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(da);
            da.Update(dtTable);
        }
    }
}
