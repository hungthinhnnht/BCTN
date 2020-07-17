<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="Admin_KhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="auto-style1">
        <tr>
            <td ><h2 align="center">Danh Sách Khách Hàng</h2></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GrvMaKH" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="MaKH" HeaderText="Mã Khách Hàng" />
                        <asp:BoundField DataField="Hoten" HeaderText="Họ &amp; Tên Khách Hàng" />
                        <asp:BoundField DataField="Tendangnhap" HeaderText="Tên Đăng Nhập" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="MatKhau" HeaderText="Mật Khẩu" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa Chỉ" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

