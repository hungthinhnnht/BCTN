<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QuangCao.aspx.cs" Inherits="Admin_QuangCao" %>

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
            <td align="center">Danh Sach Quang Cao</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvQuangCao" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="idqc" HeaderText="Mã Quảng Cáo" />
                        <asp:BoundField DataField="Tenqc" HeaderText="Tên Quảng Cáo" />
                        <asp:BoundField DataField="ngaybatdau" HeaderText="Ngày Bắt Đầu" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Ngayketthuc" HeaderText="Ngày Kết Thúc" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Hinh/QuangCao/"+Eval("Hinh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Link" HeaderText="Link" />
                        <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_QuangCao.aspx?id=<%#Eval("idqc") %>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Admin/QL_QuangCao.aspx" Text="Them" />
            </td>
        </tr>
    </table>
</asp:Content>

