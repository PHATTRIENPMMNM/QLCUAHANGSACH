using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class HOADON : System.Web.UI.Page
{
    string connString = @"Provider=IBMDADB2.DB2COPY1;Data Source=QLCHS1;User ID=long;Password=bichhang ;Server=127.0.0.1:50000";

    //Hàm trả về danh sách 
    DataTable HOADONDS()
    {
        string sql = "SELECT * FROM long.HOADON";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    DataTable HOADONDSbyDate(string date)
    {
        string sql = "SELECT * FROM long.HOADON Where NgayLapHD = '"+date+"'";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    DataTable KHACHHANGDS()
    {
        string sql = "SELECT * FROM long.KHACHHANG";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    DataTable NHANVIENDS()
    {
        string sql = "SELECT * FROM long.NHANVIEN";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    DataTable LOAISACHDS()
    {
        string sql = "SELECT * FROM long.LOAISACH";

        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }

    void HOADONXoa(string MAHD)
    {
        string sql = "DELETE FROM LONG.HOADON WHERE MAHD='" + MAHD + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    void HOADONThem(string MAHD, string MAKH, string MANV,string MASACH, string SOLUONG)
    {
        DateTime ngaylaphoadon = DateTime.Now;
        string sql = "INSERT INTO LONG.HOADON VALUES('" + MAHD + "','" + MAKH + "','" + MANV + "','" + ngaylaphoadon.Year +"-"+ ngaylaphoadon.Month+"-"+ngaylaphoadon.Day + "')";
        string sql1 = "INSERT INTO LONG.CTHD VALUES('"+txt_ctdh.Text+"','"+txtmhd.Text+"','"+txtms.Text+"','"+txtsl.Text+"')";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        OleDbCommand sqlCom1 = new OleDbCommand(sql1, conn);

        conn.Open();
        sqlCom.ExecuteNonQuery();
        sqlCom1.ExecuteNonQuery();
        conn.Close();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        gridHOADON.DataSource = HOADONDS();
        gridHOADON.DataBind();
        
       
    }
    protected void btnt_Click(object sender, EventArgs e)
    {
       try
       {
            HOADONThem(txtmhd.Text, txtmkh.Text,txtmnv.Text,txtms.Text, txtsl.Text);
            gridHOADON.DataSource = HOADONDS();
            gridHOADON.DataBind();
            Labeltb.Text = "Đã thêm vào thành công.";
       }
       catch
       {
            Labeltb.Text = "Không thể thêm thông tin này. Vui lòng kiểm tra lại.";
       }
    }
    
    protected void btnx_Click(object sender, EventArgs e)
    {
        HOADONXoa(txtms.Text);
        gridHOADON.DataSource = HOADONDS();
        gridHOADON.DataBind();
    }
    protected void btntk_Click(object sender, EventArgs e)
    {
        string key;
        try { key = txtTimkiem.Text.Split('/')[2] + "-" + txtTimkiem.Text.Split('/')[1] + "-" + txtTimkiem.Text.Split('/')[0]; }
        catch {
            try { key = txtTimkiem.Text.Split('/')[1] + "-" + txtTimkiem.Text.Split('/')[0]; }
            catch { key = txtTimkiem.Text; }
        }
        gridHOADON.DataSource = HOADONDSbyDate(key);
        gridHOADON.DataBind();
    }
}