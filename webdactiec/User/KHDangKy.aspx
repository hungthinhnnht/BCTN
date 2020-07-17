<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="KHDangKy.aspx.cs" Inherits="User_KHDangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 199px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="body">
        <div id="content">
            <div>
                
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2" colspan="2"><h2 align="center">Bảng Đăng Ký Khách Hàng</h2></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Họ Tên Khách Hàng</td>
                            <td>
                                <asp:TextBox ID="txtHoten" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Tên Đăng Nhập</td>
                            <td>
                                <asp:TextBox ID="txtTenDN" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Mật Khẩu</td>
                            <td>
                                <asp:TextBox ID="txtMK" runat="server" TextMode="Password" Width="80%"></asp:TextBox>
                                <br />
                                <asp:Label ID="lbMK" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Nhập Lại Mật Khẩu</td>
                            <td>
                                <asp:TextBox ID="txtNLMK" runat="server" Width="80%" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:Label ID="lbNLMK" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Email</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Địa Chỉ</td>
                            <td>
                                <asp:TextBox ID="txtDC" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Điện Thoại</td>
                            <td>
                                <asp:TextBox ID="txtSDT" runat="server" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Button ID="btnDK" runat="server" OnClick="btnDK_Click" Text="Đăng Ký" />
                            </td>
                            <td>
                                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                <asp:Button ID="btnDN" runat="server" Text="Đăng Nhập" align="right" PostBackUrl="~/User/UserDN.aspx" Width="150px" />
                <div id="dvthongbao" runat="server"  >
                    
        
    </div>
                
            </div>
        </div>
    </div>


</asp:Content>

