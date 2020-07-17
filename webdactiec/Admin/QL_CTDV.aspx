<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_CTDV.aspx.cs" Inherits="Admin_QL_CTDV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 252px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td colspan="2" align="center"><h3>Quản Lý Chi Tiết Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Tên Dịch Vụ</td>
            <td>
                <asp:DropDownList ID="DrlIDdv" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Hình Ảnh</td>
            <td>
                <asp:FileUpload ID="FupHinh" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mô Tả</td>
            <td>
                <asp:TextBox ID="txtMota" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Trạng Thái</td>
            <td>
                <asp:CheckBox ID="chkTrangThai" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Giá</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" OnClick="btnCapNhat_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

