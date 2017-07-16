using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


    public partial class DNhap : System.Web.UI.Page
    {
        string connString =@"provider= IBMDADB2.1; uid=LONG;pwd=bichhang; database= QLCHS1;server=127.0.0.1:50000";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool KTDangNhap(string TENDN, string MATKHAU)
        {
            string sql = "select TENDN from LONG.TAIKHOAN where TENDN='" + TENDN + "' and MATKHAU='" + MATKHAU + "'";
            OleDbConnection connDB = new OleDbConnection(connString);
            connDB.Open();
            OleDbCommand cmd = new OleDbCommand(sql, connDB);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                connDB.Close();
                return true;
            }
            else
            {
                connDB.Close();
                return false;
            }

        }


        protected void  Button1_Click(object sender, EventArgs e)
{
     if (KTDangNhap(txtu.Text, txtp.Text) == true)
    {
        Session["TENDN"] = txtu.Text;
        Response.Redirect("Default.aspx");
    }
    else
    {
        Session["TENDN"] = "";
        Labeltb.Text = "Thông tin đăng nhập không chính xác";
    }

}
}
       
    
