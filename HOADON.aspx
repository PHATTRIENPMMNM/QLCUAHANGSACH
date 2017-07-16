<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage/Client.master" AutoEventWireup="true" CodeFile="HOADON.aspx.cs" Inherits="HOADON" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="467px">
    <table class="style1">
        <tr>
            <td style="width: 116px">
                <asp:TextBox ID="txtTimkiem" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btntk" runat="server" Text="Tìm kiếm" onclick="btntk_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                CHI TIẾT HÓA ĐƠN</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label2" runat="server" Text="Mã HĐ:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmhd" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label3" runat="server" Text="Mã KH:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmkh" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label4" runat="server" Text="Mã NV:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtmnv" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label5" runat="server" Text="Mã sách:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtms" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label7" runat="server" Text="Mã CTHD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_ctdh" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                <asp:Label ID="Label6" runat="server" Text="Số lượng:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtsl" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px; text-align: right">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnt" runat="server" Text="Thêm" onclick="btnt_Click" />
                <asp:Button ID="btnx" runat="server" Text="Xóa" onclick="btnx_Click" />
                <asp:Label ID="Labeltb" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 116px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                HÓA ĐƠN</td>
        </tr>
        <tr>
            <td style="width: 116px">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gridHOADON" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MaHD" HeaderText="Mã hóa đơn" />
                        <asp:BoundField DataField="MaKH" HeaderText="Mã khách hàng" />
                        <asp:BoundField DataField="MaNV" HeaderText="Mã nhân viên" />
                        <asp:BoundField DataField="NgayLapHD" DataFormatString="{0:dd/MM/yyyy}" 
                            HeaderText="Ngày lập hóa đơn" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

