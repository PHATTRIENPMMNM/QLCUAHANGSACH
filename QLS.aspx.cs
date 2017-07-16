using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
public partial class QLS : System.Web.UI.Page
{

    string connString = @"Provider=IBMDADB2.DB2COPY1;Data Source=QLCHS1;User ID=long;Password=bichhang ;Server=127.0.0.1:50000";

    DataTable TimSach(string keywordfind, int i)
    {
        string sql = "";
        if (i == 0)
        {
            sql = "SELECT ROW_NUMBER() OVER (ORDER BY TENSACH)  STT,MASACH,TENSACH,SOLUONGNHAP,GIABAN,MANXB FROM LONG.LOAISACH  WHERE ((Upper(TENSACH) LIKE Upper('%" + keywordfind + "%')))";
        }
        else
        {
            sql = "SELECT ROW_NUMBER() OVER (ORDER BY MASACH)  STT,MASACH,TENSACH,SOLUONGNHAP,GIABAN,MANXB FROM LONG.LOAISACH  WHERE ((Upper(MASACH) LIKE Upper('%" + keywordfind + "%')))";
         }
        OleDbDataAdapter ad = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        ad.Fill(ds);
        return ds;
    }


    //Hàm trả về danh sách 
    DataTable LOAISACHDS()
    {
        string sql = "SELECT * FROM long.LOAISACH";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    DataTable NXBDS()
    {
        string sql = "SELECT * FROM long.NXB";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    void LOAISACHXoa(string MASACH)
    {
        string sql = "DELETE FROM LONG.LOAISACH WHERE MASACH='" + MASACH + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    void LOAISACHThem(string MASACH, string TENSACH, string SOLUONGNHAP, int GIABAN, string MANXB)
    {
        string sql = "INSERT INTO LONG.LOAISACH VALUES('" + MASACH + "','" + TENSACH + "'," + SOLUONGNHAP + "," + GIABAN + ",'" + MANXB + "')";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        //txttimkiem.Text = sql;
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }
  
    void LOAISACHSua(string MASACH, string TENSACH, string SOLUONGNHAP, int GIABAN, string MANXB)
    {
        string sql = "UPDATE LONG.LOAISACH SET TENSACH='" + TENSACH + "',SOLUONGNHAP='" + SOLUONGNHAP + "',GIABAN='" + GIABAN + "',MANXB='" + MANXB + "' WHERE MASACH='" + MASACH + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    
      
       {    gridLOAISACH.DataSource = LOAISACHDS();
            gridLOAISACH.DataBind();
           
            if (!IsPostBack)
            { 
                DropDownList1.DataSource = NXBDS();
                DropDownList1.DataTextField = "TENNXB";
                DropDownList1.DataValueField = "MANXB";
                DropDownList1.DataBind();
            }
        
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            LOAISACHThem(txtms.Text, txtts.Text, txtsln.Text, int.Parse(txtgb.Text), DropDownList1.SelectedValue.ToString());
            gridLOAISACH.DataSource = LOAISACHDS();
            gridLOAISACH.DataBind();
            lbltb.Text = "Đã thêm vào thành công.";
        }
        catch
        {
            lbltb.Text = "Không thể thêm thông tin này. Vui lòng kiểm tra lại.";
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        LOAISACHXoa(txtms.Text);
        gridLOAISACH.DataSource = LOAISACHDS();
        gridLOAISACH.DataBind();
    }
    protected void btns_Click(object sender, EventArgs e)
    {
        LOAISACHSua(txtms.Text, txtts.Text, txtsln.Text, int.Parse(txtgb.Text), DropDownList1.SelectedValue.ToString());
        gridLOAISACH.DataSource = LOAISACHDS();
        gridLOAISACH.DataBind();
    }

    protected void tntk_Click(object sender, EventArgs e)
    {
          
        gridLOAISACH.DataSource = TimSach(txt_timkiem.Text, int.Parse(ddl_searchby.SelectedValue));
        gridLOAISACH.DataBind();
    }
}