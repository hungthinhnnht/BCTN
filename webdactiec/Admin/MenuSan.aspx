<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="MenuSan.aspx.cs" Inherits="Admin_MenuSan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 251px;
        }
        .auto-style4 {
            width: 222px;
        }
        .auto-style5 {
            width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center"><h3>Danh Sách Menu </h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvMenu" runat="server" AutoGenerateColumns="False" OnRowCommand="GrvMenu_RowCommand" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Masomenu" HeaderText="Mã Số Menu" />
                        <asp:BoundField DataField="Tengoi" HeaderText="Tên Gọi" />
                        <asp:BoundField DataField="Gia" DataFormatString="{0:#,###0}" HeaderText="Giá" />
                        <asp:TemplateField HeaderText="Trạng Thái">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Trangthai").ToString()=="True"?"Còn":"Hết" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Xem Chi Tiết">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnXem" runat="server" CommandArgument='<%# Eval("Masomenu") %>' CommandName="Xem">Xem</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_Menu.aspx?id=<%#Eval("masomenu") %>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Đổi Món Ăn">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDoi" runat="server" CommandArgument='<%# Eval("Masomenu") %>' CommandName="Doi" OnClick="lbtnDoi_Click">Thay Đổi</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnThem" runat="server" PostBackUrl="~/Admin/QL_Menu.aspx" Text="Thêm" />
            </td>
        </tr>
    </table>
    <div id="dvCTmenu" runat="server" visble="false">
        <h2 align="center">Chi Tiết Menu</h2>
        <table align="center" class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lbMasomenu" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lbTengoi" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lbGia" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTrangthai" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <p align="center">
            <asp:GridView ID="GrvCTMenu" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%">
                <Columns>
                    <asp:BoundField DataField="idmonan" HeaderText="Mã Món Ăn" />
                    <asp:BoundField DataField="Tenmon" HeaderText="Tên Món" />
                    <asp:TemplateField HeaderText="Hình">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>

    </div>
    <div id="dvDSMonAn" runat="server" visible="false">
        <h2 align="center">Danh Sách Món Ăn</h2>
        <p align="center">
        <asp:GridView ID="GrvDSMA" runat="server" AutoGenerateColumns="False" OnRowCommand="GrvDSMA_RowCommand" Width="100%">
            <Columns>
                <asp:BoundField DataField="idmonan" HeaderText="Mã Món Ăn" />
                <asp:BoundField DataField="Tenloai" HeaderText="Tên Loại Món" />
                <asp:BoundField DataField="Tenmon" HeaderText="Tên Món" />
                <asp:BoundField DataField="Gia" DataFormatString="{0:#,##0}" HeaderText="Giá" />
                <asp:TemplateField HeaderText="Hình Ảnh">
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chọn">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnChon" runat="server" CommandArgument='<%# Eval("idmonan") %>' CommandName="Chon">Chọn</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </p>
    </div>
</asp:Content>

