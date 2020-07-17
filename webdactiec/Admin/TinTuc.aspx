<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="TinTuc.aspx.cs" Inherits="Admin_TinTuc" %>

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
            <td align="center"><h3>Danh Sach Tin Tức</h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvTinTuc" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvTinTuc_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="idtin" HeaderText="Mã Tin Tức" />
                        <asp:BoundField DataField="Tieude" HeaderText="Tiêu Đề" />
                        <asp:BoundField DataField="Ngaydang" HeaderText="Ngày Đăng" DataFormatString="{0:dd/MM/yyyy} " />
                        <asp:BoundField DataField="Noidung" HeaderText="Nôi Dung" Visible="False" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Hinh/TinTuc/"+Eval("Hinh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrangThai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Tomtat" HeaderText="Tóm Tắt" />
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_TinTuc.aspx?id=<%#Eval("idtin") %>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_TinTuc.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

