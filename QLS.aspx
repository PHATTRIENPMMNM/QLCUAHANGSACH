<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Client.master" AutoEventWireup="true" CodeFile="QLS.aspx.cs" Inherits="QLS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txt_timkiem" runat="server"></asp:TextBox>
    <asp:DropDownList ID="ddl_searchby" runat="server">
        <asp:ListItem Value="0">Tên sách</asp:ListItem>
        <asp:ListItem Value="1">Mã sách</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="tntk" runat="server" Text="Tìm kiếm" onclick="tntk_Click" />
<br />
<asp:Panel ID="Panel1" runat="server" Height="211px">
    <table class="style1">
        <tr>
            <td colspan="2">
                DANH SÁCH CÁC LOẠI SÁCH NHẬP KHO</td>
        </tr>
        <tr>
            <td style="width: 173px">
                Mã sách:</td>
            <td>
                <asp:TextBox ID="txtms" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 173px">
                Tên sách:</td>
            <td>
                <asp:TextBox ID="txtts" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 173px">
                Số lượng nhập:</td>
            <td>
                <asp:TextBox ID="txtsln" runat="server" style="margin-left: 0px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 173px">
                Gía bán: </td>
            <td>
                <asp:TextBox ID="txtgb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 173px">
                Tên NXB:</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 173px; text-align: right;">
                <asp:Button ID="btnt" runat="server" onclick="Button3_Click" Text="Thêm" />
            </td>
            <td>
                <asp:Button ID="btns" runat="server" onclick="btns_Click" Text="Sửa" />
                <asp:Button ID="btnx" runat="server" onclick="Button5_Click" Text="Xóa" />
                <asp:Label ID="lbltb" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left;">
                SỐ LƯỢNG SÁCH</td>
        </tr>
        <tr>
            <td style="width: 173px; text-align: right;">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gridLOAISACH" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
&nbsp;
</asp:Content>

