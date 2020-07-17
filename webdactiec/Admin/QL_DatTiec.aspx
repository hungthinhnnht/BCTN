<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="QL_DatTiec.aspx.cs" Inherits="Admin_QL_DatTiec" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 25px;
        }
        .auto-style4 {
            height: 25px;
            width: 227px;
        }
        .auto-style5 {
            width: 227px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td colspan="2" align="center"><h3>Quản Lý Đặt Tiệc</h3></td>
        </tr>
        <tr>
            <td class="auto-style4">Họ Tên</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Ngày Đặt</td>
            <td>
                <asp:TextBox ID="txtNgayDat" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtNgayDat_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNgayDat">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Ngày Đãi</td>
            <td>
                <asp:TextBox ID="txtNgayDai" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtNgayDai_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNgayDai">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Địa Chỉ</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Điện Thoại</td>
            <td>
                <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Tổng Số Tiền</td>
            <td>
                <asp:TextBox ID="txtTongTien" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Trạng Thái</td>
            <td>
                <asp:CheckBox ID="ChkTrangThai" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Button ID="btnThem" runat="server" OnClick="Button1_Click" Text="Thêm" />
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" OnClick="btnCapNhat_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

