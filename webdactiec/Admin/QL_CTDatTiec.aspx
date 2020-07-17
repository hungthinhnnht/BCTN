<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="QL_CTDatTiec.aspx.cs" Inherits="Admin_QL_CTDatTiec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
        .auto-style4 {
            width: 213px;
        }
        .auto-style5 {
            width: 213px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td class="auto-style3" colspan="2">Quan Ly Chi Tiet Dat Tiec</td>
        </tr>
        <tr>
            <td class="auto-style4">ID Dat Tiec</td>
            <td>
                <asp:DropDownList ID="DrlDatTiec" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">ID Mon An</td>
            <td>
                <asp:DropDownList ID="DrlMonAn" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">ID Dich Vu</td>
            <td>
                <asp:DropDownList ID="DrlDichVu" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">So Luong</td>
            <td>
                <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Gia</td>
            <td>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" />
            </td>
            <td class="auto-style6"></td>
        </tr>
    </table>
</asp:Content>

