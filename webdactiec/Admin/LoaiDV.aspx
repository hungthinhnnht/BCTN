<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="LoaiDV.aspx.cs" Inherits="Admin_LoaiDV" %>

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
            <td align="center"><h3>Danh Sách Loại Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvLoaiDV" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvLoaiDV_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="idloai" HeaderText="Mã Loại Dịch Vụ" />
                        <asp:BoundField DataField="Tenloai" HeaderText="Tên Loại Dịch Vụ" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrangThai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_LoaiDichVu.aspx?id=<%#Eval("idloai")%>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_LoaiDichVu.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

