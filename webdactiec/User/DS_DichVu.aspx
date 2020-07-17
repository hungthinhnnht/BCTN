<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_DichVu.aspx.cs" Inherits="User_DS_DichVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="body">
        <div id="content">
            <h2>DANH SÁCH DỊCH VỤ</h2>
            <div>
                <ul>
                    <asp:Label ID="lbTenDV" runat="server"></asp:Label>
                    <asp:DataList ID="dtlDichVu" runat="server" Width="100%">
                        <ItemTemplate>
                            <li>
                                <a href="DS_CTDV.aspx?id=<%#Eval("iddichvu") %>">
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Hinh/Hinhdichvu/"+Eval("Hinhanh") %>' Height="100px" Width="100px" />
                                </a>
                                &nbsp;<div>
                                    <h3><a href="DS_CTDV.aspx?id=<%#Eval("iddichvu") %>">
                                        <asp:Label ID="lbTen" runat="server" Text='<%# Eval("Tendichvu") %>'></asp:Label>
                                        </a></h3>
                                    <p>
                                        <asp:Label ID="lbMoTa" runat="server" Text='<%# Eval("Mota") %>'></asp:Label>
&nbsp;</p>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>






                </ul>
            </div>
        </div>
    </div>


    <%--<asp:DataList ID="dtlDichVu" runat="server" Width="100%" RepeatColumns="4">
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td align="center">
                        <a href="DS_CTDV.aspx?id=<%#Eval("iddichvu") %>"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Tendichvu") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' />
                    </td>
                </tr>
                <tr>
                    <td align="center">Giá:
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Gia") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
                        </asp:DataList>--%>
</asp:Content>

