<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="MonAn.aspx.cs" Inherits="Admin_MonAn" %>

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
            <td align="center"><h3>Danh Sách Món Ăn</h3></td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" class="auto-style3">
                    <tr>
                        <td>Tên Món Ăn</td>
                        <td>
                            <asp:TextBox ID="txtTenMon" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnTim" runat="server" OnClick="btnTim_Click" Text="Tìm" Width="100px" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GrvMonAn" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvMonAn_PageIndexChanging" PageSize="5" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="idmonan" HeaderText="Mã Món Ăn" />
                        <asp:BoundField DataField="Tenloai" HeaderText="Tên Loại Món" />
                        <asp:BoundField DataField="Tenmon" HeaderText="Tên Món" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                        <asp:BoundField DataField="Mota" HeaderText="Mô Tả" Visible="False" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrangThai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_MonAn.aspx?id=<%#Eval("idmonan") %>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Them" runat="server" PostBackUrl="~/Admin/QL_MonAn.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
</asp:Content>

