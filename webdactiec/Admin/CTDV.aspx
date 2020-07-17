<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CTDV.aspx.cs" Inherits="Admin_CTDV" %>

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
            <td align="center"><h3>Danh Sách Chi Tiết Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvCTDV" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvCTDV_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="idChiTiet" HeaderText="Mã Chi Tiết Dịch Vụ" />
                        <asp:BoundField DataField="Tendichvu" HeaderText="Tên Dịch Vụ" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Hinh/HinhCTDV/"+Eval("Hinhanh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MoTa" HeaderText="Mô Tả" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Trangthai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_CTDV.aspx?id=<%#Eval("idChiTiet")%>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_CTDV.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

