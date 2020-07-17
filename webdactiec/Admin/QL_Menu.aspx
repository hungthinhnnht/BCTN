<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_Menu.aspx.cs" Inherits="Admin_QL_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
        .auto-style4 {
            width: 169px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center" class="auto-style3" colspan="2"><h3>Quản Lý Menu</h3></td>
        </tr>
        <tr>
            <td class="auto-style4">Tên Gọi</td>
            <td>
                <asp:TextBox ID="txtTengoi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Giá</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Trạng Thái</td>
            <td>
                <asp:CheckBox ID="chkTrangThai" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

