<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_DichVu.aspx.cs" Inherits="Admin_QL_DichVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 277px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center" colspan="2"><h3>Quản Lý Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Tên Dịch Vụ</td>
            <td>
                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Tên Loại</td>
            <td>
                <asp:DropDownList ID="DrlLoaiDV" runat="server">
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
            <td class="auto-style3">Giá</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mô Tả</td>
            <td>
                <asp:TextBox ID="txtMota" runat="server"></asp:TextBox>
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
            <td class="auto-style3">Bắt Buộc</td>
            <td>
                <asp:CheckBox ID="chkBB" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" style="width: 48px" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

