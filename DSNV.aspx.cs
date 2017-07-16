using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class DSNV : System.Web.UI.Page
{
    string connString = @"Provider=IBMDADB2.DB2COPY1;Data Source=QLCHS1;User ID=long;Password=bichhang ;Server=127.0.0.1:50000";
    
    DataTable TimNhanVien(string hoTen)
    {
        string sql = "SELECT ROW_NUMBER() OVER (ORDER BY TENNV)  STT,MANV,HONV,TENNV,CASE WHEN GioiTinh = 1 THEN N'Nam' ELSE N'Nữ' END GioiTinh,DiaChi,SDT FROM LONG.NHANVIEN WHERE ((Upper(HONV) LIKE Upper('%" + hoTen + "%')) OR (Upper(TENNV) LIKE Upper('%" + hoTen + "%')))ORDER BY TENNV";
        OleDbDataAdapter ad = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        ad.Fill(ds);
        return ds;
    }

    //Hàm trả về danh sách 
    DataTable NHANVIENDS()
    {
        string sql = "SELECT * FROM long.NHANVIEN";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, connString);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;
    }
    void NHANVIENXoa(string MANV)
    {
        string sql = "DELETE FROM LONG.NHANVIEN WHERE MANV='" + MANV + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    void NHANVIENThem(string MANV, string HONV,string TENNV,Boolean GIOITINH,string SDT, string DIACHI)
    {
        string gt = "1"; if (GIOITINH == true) gt = "0";
        string sql = "INSERT INTO LONG.NHANVIEN VALUES('" + MANV + "','" + HONV + "','" + TENNV + "','" + DIACHI + "','" + gt + "','" + SDT + "')";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        
        conn.Open();
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }
    void NHANVIENSua(string MANV, string HONV, string TENNV, Boolean GIOITINH, string SDT, string DIACHI)
    {
        string gt = "1"; if (GIOITINH == true) gt = "0";
        string sql = "UPDATE LONG.NHANVIEN SET HONV= '" + HONV + "',TENNV='" + TENNV + "',GIOITINH=" + gt + ",SDT='" + SDT + "', DIACHI='" + DIACHI + "' WHERE MANV='" + MANV + "'";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand sqlCom = new OleDbCommand(sql, conn);
        conn.Open();
       
        sqlCom.ExecuteNonQuery();
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        gridNHANVIEN.DataSource = NHANVIENDS();
        gridNHANVIEN.DataBind();
        
    }
    protected void txtmnv_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnt_Click(object sender, EventArgs e)
    {
        try
        {
            NHANVIENThem(txtmnv.Text, txthnv.Text, txttnv.Text, radionu.Checked,txtsdt.Text,txtdc.Text);
            gridNHANVIEN.DataSource = NHANVIENDS();
            gridNHANVIEN.DataBind();
            lbltb.Text = "Đã thêm vào thành công.";
        }
        catch
        {
            lbltb.Text = "Không thể thêm thông tin này. Vui lòng kiểm tra lại.";
        }
    }
    protected void btns_Click(object sender, EventArgs e)
    {
        NHANVIENSua(txtmnv.Text, txthnv.Text, txttnv.Text, radionu.Checked, txtsdt.Text, txtdc.Text);
        gridNHANVIEN.DataSource = NHANVIENDS();
        gridNHANVIEN.DataBind();
    }
    protected void btnx_Click(object sender, EventArgs e)
    {
        NHANVIENXoa(txtmnv.Text);
        gridNHANVIEN.DataSource = NHANVIENDS();
        gridNHANVIEN.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        gridNHANVIEN.DataSource = TimNhanVien(txttimkiem.Text);
        gridNHANVIEN.DataBind();
    }
}