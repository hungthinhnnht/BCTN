<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="LSDT.aspx.cs" Inherits="User_LSDT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
        }

        .auto-style3 {
            width: 275px;
        }

        .auto-style4 {
            width: 275px;
            height: 20px;
        }

        .auto-style5 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="body">
        <div id="content">
            <div>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2" colspan="2"><h3 align="center">THÔNG TIN KHÁCH HÀNG</h3></td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Họ Tên Khách Hàng</td>
                        <td class="auto-style5">
                            <asp:Label ID="lbHoten" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Tên Đăng Nhập</td>
                        <td>
                            <asp:Label ID="lbTenDN" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Điện Thoại</td>
                        <td>
                            <asp:Label ID="lbSDT" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Địa Chỉ</td>
                        <td>
                            <asp:Label ID="lbDC" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GrvKH" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Hoten" HeaderText="Họ Tên Khách Hàng" />
                        <asp:BoundField DataField="Ngaydat" HeaderText="Ngày Đặt" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Ngaydai" HeaderText="Ngày Đãi" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="TGD" HeaderText="Thời Gian" />
                        <asp:BoundField DataField="Soluongban" HeaderText="Số Lượng Bàn" />
                        <asp:BoundField DataField="Ghichu" HeaderText="Ghi Chú" />
                        <asp:BoundField DataField="Tongsotien" HeaderText="Tống Số Tiền" DataFormatString="{0:#,##0}" />
                        <asp:TemplateField HeaderText="xem chi tiết">
                            <ItemTemplate>
                                <a href="CTUser.aspx?id=<%#Eval("iddattiec") %>">chọn</a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

