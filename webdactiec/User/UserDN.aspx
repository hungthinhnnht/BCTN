<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="UserDN.aspx.cs" Inherits="User_UserDN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 206px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="body">
        <div id="content">
            <div>

                <table align="center" class="auto-style1">
                    <tr>
                        <td colspan="2"><h3 align="center">ĐĂNG NHẬP</h3></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Tên Đăng Nhập</td>
                        <td>
                            <asp:TextBox ID="txtDN" runat="server" Width="60%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Mật Khẩu</td>
                        <td>
                            <asp:TextBox ID="txtMK" runat="server" Width="60%" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2" align="center">
                            <asp:Button ID="btnDN" runat="server" Text="Đăng Nhập" OnClick="btnDN_Click" />
                        </td>
                    </tr>
                </table>

                </div>
            </div>
        </div>

</asp:Content>

