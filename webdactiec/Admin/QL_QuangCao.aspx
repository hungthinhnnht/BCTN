<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_QuangCao.aspx.cs" Inherits="Admin_QL_QuangCao" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style2 {
        width: 100%;
    }
    .auto-style3 {
        width: 261px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
    <tr>
        <td colspan="2" align="center"><h3>Quản Lý Quảng Cáo</h3></td>
    </tr>
    <tr>
        <td class="auto-style3">Tên Quảng Cáo</td>
        <td>
            <asp:TextBox ID="txtTenQC" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Ngày Bắt Đầu</td>
        <td>
            <asp:TextBox ID="txtNBD" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="txtNBD_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNBD">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Ngày Kết Thúc</td>
        <td>
            <asp:TextBox ID="txtNKT" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="txtNKT_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNKT">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Hình Ảnh</td>
        <td>
            <asp:FileUpload ID="FupHinh" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Link</td>
        <td>
            <asp:TextBox ID="txtLink" runat="server"></asp:TextBox>
            <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="Button1_Click" style="height: 26px" />
            <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

