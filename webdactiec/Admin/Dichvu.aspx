<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="Dichvu.aspx.cs" Inherits="Admin_Dichvu" %>

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
            <td align="center"><h3>Danh Sách Dịch Vụ</h3></td>
        </tr>
        <tr>
            <td  align="center">
                <table align="center" class="auto-style3">
                    <tr>
                        <td>Dịch Vụ</td>
                        <td>
                            <asp:TextBox ID="txtDichVu" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm" Width="100px" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GrvDichVu" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvDichVu_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="iddichvu" HeaderText="Mã Dịch Vụ" />
                        <asp:BoundField DataField="Tenloai" HeaderText="Tên Loại Dịch Vụ" />
                        <asp:BoundField DataField="Tendichvu" HeaderText="Dịch Vụ" />
                        <asp:TemplateField HeaderText="Hình">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                        <asp:BoundField DataField="Mota" HeaderText="Mô Tả" DataFormatString="{0:#,##0}" Visible="False" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrangThai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bắt Buộc">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_DichVu.aspx?id=<%#Eval("iddichvu")%>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_DichVu.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

