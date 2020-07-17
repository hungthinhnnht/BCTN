<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_LoaiDichVu.aspx.cs" Inherits="Admin_QL_LoaiDichVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 343px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td colspan="2" align="center"><h3>Quản Lý Loại Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Tên Loại</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Trạng Thái</td>
            <td>
                <asp:CheckBox ID="chkTrangThai" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

