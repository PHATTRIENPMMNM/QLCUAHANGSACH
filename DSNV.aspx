<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Client.master" AutoEventWireup="true" CodeFile="DSNV.aspx.cs" Inherits="DSNV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txttimkiem" runat="server"></asp:TextBox>
<asp:Button ID="Button2" runat="server" Text="Tìm kiếm" onclick="Button2_Click" />
<br />
<table class="style1">
    <tr>
        <td colspan="2">
            THÔNG TIN NHÂN VIÊN</td>
    </tr>
    <tr>
        <td style="width: 105px">
            Mã nhân viên:</td>
        <td>
            <asp:TextBox ID="txtmnv" runat="server" ontextchanged="txtmnv_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            Họ nhân viên:</td>
        <td>
            <asp:TextBox ID="txthnv" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            Tên nhân viên:</td>
        <td>
            <asp:TextBox ID="txttnv" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            Giới tính:</td>
        <td>
            <asp:RadioButton ID="radion" runat="server" Text="Nam" GroupName="1" />
            <asp:RadioButton ID="radionu" runat="server" Text="Nữ" GroupName="1" />
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            Số điện thoại:</td>
        <td>
            <asp:TextBox ID="txtsdt" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            Địa chỉ:</td>
        <td>
            <asp:TextBox ID="txtdc" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 105px; text-align: right;">
            <asp:Button ID="btnt" runat="server" onclick="btnt_Click" Text="Thêm" />
        </td>
        <td>
            <asp:Button ID="btns" runat="server" Text="Sửa" onclick="btns_Click" />
            <asp:Button ID="btnx" runat="server" Text="Xóa" onclick="btnx_Click" />
            <asp:Label ID="lbltb" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 105px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            DANH SÁCH NHÂN VIÊN HIỆN TẠI</td>
    </tr>
    <tr>
        <td style="width: 105px">
            &nbsp;</td>
        <td>
            <asp:GridView ID="gridNHANVIEN" runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
&nbsp;
</asp:Content>

