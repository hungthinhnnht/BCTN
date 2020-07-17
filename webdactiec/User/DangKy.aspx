<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DangKy.aspx.cs" Inherits="User_DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="body">
        <div id="content">
            <div>
    <table align="center" class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2" align="center"><h2>ĐĂNG KÝ THÀNH VIÊN</h2></td>
        </tr>
        <tr>
            <td class="auto-style3">Tên Đăng Nhập</td>
            <td>
                <asp:Label ID="lbTenDN" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mật Khẩu</td>
            <td>
                <asp:TextBox ID="txtMK" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                <br />
                <asp:Label ID="lbMK" runat="server"></asp:Label>
            </td>
        </tr>

        

        <tr>
            <td class="auto-style3">Nhập Lại Mật Khẩu</td>
            <td>
                <asp:TextBox ID="txtNLMK" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                <asp:Label ID="lbNLMK" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Họ và Tên</td>
            <td>
                <asp:Label ID="lbHoten" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="Đăng Ký" />
            </td>
            <td>
                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <div id="dvthongbao" runat="server" visible="false">
        <h2 align="center">Chúc Mừng Bạn Đã Đang Ký Thành Công</h2>
    </div>
                </div>
            </div>
         </div>
</asp:Content>

