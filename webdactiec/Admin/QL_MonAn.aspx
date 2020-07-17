<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_MonAn.aspx.cs" Inherits="Admin_QL_MonAn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
        .auto-style4 {
            width: 249px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td class="auto-style3" colspan="2" align="center"><h3>Quản Lý Món Ăn</h3></td>
        </tr>
        <tr>
            <td class="auto-style4">Tên Loại Món</td>
            <td>
                <asp:DropDownList ID="DrlMonAn" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Tên Món</td>
            <td>
                <asp:TextBox ID="txtTenMon" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Hình Ảnh</td>
            <td>
                <asp:FileUpload ID="FupHinh" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Giá</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Mô Tả</td>
            <td>
                <asp:TextBox ID="txtMota" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Trạng Thái</td>
            <td>
                <asp:CheckBox ID="ChkTrangThai" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" OnClick="btnCapNhat_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

