<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Client.master" AutoEventWireup="true" CodeFile="QLKH.aspx.cs" Inherits="QLKH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="411px">
    <table class="style1">
        <tr>
            <td style="text-align: right">
                <asp:TextBox ID="txttk" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btntk" runat="server" onclick="btntk_Click" Text="Tìm kiếm" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
            <td colspan="2">
                THÔNG TIN KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Mã khách hàng:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmkh" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Tên khách hàng:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttkh" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Địa chỉ KH:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdckh" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="SĐT KH:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsdtkh" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnt" runat="server" onclick="btnt_Click" Text="Thêm" />
            </td>
            <td>
                <asp:Button ID="btns" runat="server" onclick="btns_Click" Text="Sửa " />
                <asp:Button ID="btnx" runat="server" onclick="btnx_Click" Text="Xóa" />
                <asp:Label ID="labeltb" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                DANH SÁCH KHÁCH HÀNG</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="gridKHACHHANG" runat="server"  >
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

