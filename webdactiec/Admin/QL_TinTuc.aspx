<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_TinTuc.aspx.cs" Inherits="Admin_QL_TinTuc" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td colspan="2" align="center"><h3>Quản Lý Tin Tức</h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Tiêu Đề</td>
            <td>
                <asp:TextBox ID="txtTieuDe" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Ngày Đăng </td>
            <td>
                <asp:TextBox ID="txtNgayDang" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtNgayDang_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNgayDang">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Hình Ảnh</td>
            <td>
                <asp:FileUpload ID="FupHinh" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Tóm Tắt</td>
            <td>
                <asp:TextBox ID="txtTomTat" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Nội Dung</td>
            <td>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">
                <cc1:Editor ID="edt" runat="server" />
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
                <asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

