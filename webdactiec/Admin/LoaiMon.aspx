<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="LoaiMon.aspx.cs" Inherits="Admin_LoaiMon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style2 {
        width: 100%;
    }
    .auto-style3 {
        width: 400px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
    <tr>
        <td align="center"><h3>Danh Sách Loại Món</h3></td>
    </tr>
    <tr>
        <td align="center">
            <table align="center" class="auto-style3">
                <tr>
                    <td>Tên Loại Món</td>
                    <td>
                        <asp:TextBox ID="txtTenLoai" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm" Width="100px" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GrvLoaiMon" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvLoaiMon_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="idloaimon" HeaderText="Mã Loại Món" />
                    <asp:BoundField DataField="Tenloai" HeaderText="Tên Loại" />
                    <asp:TemplateField HeaderText="Hình Ảnh">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Hinh/LoaiMon/"+Eval("Logo") %>' Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Trạng Thái">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrangThai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cập Nhật">
                        <ItemTemplate>
                            <a href="QL_LoaiMon.aspx?id=<%#Eval("idloaimon") %>">Chọn</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Them" runat="server" PostBackUrl="~/Admin/QL_LoaiMon.aspx" Text="Thêm" OnClick="Them_Click" />
        </td>
    </tr>
</table>
</asp:Content>

