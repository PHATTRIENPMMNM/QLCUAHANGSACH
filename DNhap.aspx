<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DNhap.aspx.cs" Inherits="DNhap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td colspan="3">
                    <asp:Image ID="Image1" runat="server" Height="240px"
                        ImageUrl="~/IMG/book-flower-55-banner.jpg" Width="100%" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtu" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Mật khẩu:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtp" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btndn" runat="server" onclick="Button1_Click" 
                        Text="Đăng nhập" />
                    <asp:Label ID="Labeltb" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
