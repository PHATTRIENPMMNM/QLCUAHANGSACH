using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class QLKH : System.Web.UI.Page
{
    string connString = @"Provider=IBMDADB2.DB2COPY1;Data Source=QLCHS1;User ID=long;Password=bichhang ;Server=127.0.0.1:50000";
    DataTable TimKH(string hoTen)
    {
        string sql = "SELECT ROW_NUMBER() OVER (ORDER BY TENKH)  STT,MAKH,TENKH,DIACHKH,SDTKH FROM LONG.KHACHHANG where upper(TenKH) like upper('%"+hoTen+"%') ORDER BY TENKH ";
        OleDbDataAdapter ad = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        ad.Fill(ds);
        return ds;
    }
    //Hàm trả về danh sách 
    DataTable KHACHHANGDS()
    {
        string sql = "SELECT * FROM long.KHACHHANG";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    void KHACHHANGXoa(string MAKH)
    {
        string sql = "DELETE FROM LONG.KHACHHANG WHERE MAKH='" + MAKH + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    void KHACHHANGThem(string MAKH, string TENKH, string DIACHKH, string SDTKH)
    {
        string sql = "INSERT INTO LONG.KHACHHANG VALUES('" + MAKH + "','" + TENKH + "','" + DIACHKH + "','" + SDTKH + "')";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);

        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }
    void KHACHHANGSua(string MAKH, string TENKH, string DIACHKH, string SDTKH)
    {
        string sql = "UPDATE LONG.KHACHHANG SET TENKH= '" + TENKH + "',DIACHKH='" + DIACHKH + "',SDTKH='" + SDTKH + "'WHERE MAKH='" + MAKH + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();

        sqlCom.ExecuteNonQuery();
        conn.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        gridKHACHHANG.DataSource = KHACHHANGDS();
        gridKHACHHANG.DataBind();
    }
  
    protected void btnt_Click(object sender, EventArgs e)
    {
        try
        {
            KHACHHANGThem(txtmkh.Text, txttkh.Text, txtdckh.Text, txtsdtkh.Text);
            gridKHACHHANG.DataSource = KHACHHANGDS();
            gridKHACHHANG.DataBind();
            labeltb.Text = "Đã thêm vào thành công.";
        }
        catch
        {
            labeltb.Text = "Không thể thêm thông tin này. Vui lòng kiểm tra lại.";
        }
    }
    protected void btns_Click(object sender, EventArgs e)
    {
        KHACHHANGSua(txtmkh.Text, txttkh.Text, txtdckh.Text, txtsdtkh.Text);
        gridKHACHHANG.DataSource = KHACHHANGDS();
        gridKHACHHANG.DataBind();
    }
    protected void btnx_Click(object sender, EventArgs e)
    {
        KHACHHANGXoa(txtmkh.Text);
        gridKHACHHANG.DataSource = KHACHHANGDS();
        gridKHACHHANG.DataBind();
    }

    protected void btntk_Click(object sender, EventArgs e)
    {
        gridKHACHHANG.DataSource = TimKH(txttk.Text);
        gridKHACHHANG.DataBind();
    }
    
}