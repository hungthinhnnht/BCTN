<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="DatTiec.aspx.cs" Inherits="Admin_DatTiec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center"><h3>Danh Sách Đặt Tiệc</h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvDatTiec" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvDatTiec_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Hoten" HeaderText="Họ Tên" />
                        <asp:BoundField DataField="Ngaydat" HeaderText="Ngày Đặt Tiệc" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Ngaydai" HeaderText="Ngày Đãi Tiệc" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa Chỉ" />
                        <asp:BoundField DataField="Dienthoai" HeaderText="Điện Thoại" />
                        <asp:BoundField DataField="Tongsotien" HeaderText="Tổng Số Tiền" DataFormatString="{0:#,##0}" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Trangthai") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Xem Chi Tiết">
                            <ItemTemplate>
                                <a href="CTDatTiec.aspx?id=<%#Eval("iddattiec") %>">Xem</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_DatTiec.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

