<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="User_Menu" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="footer">
        <ul>
                        
                <asp:DataList ID="dtlMN" runat="server" OnItemDataBound="dtlMN_ItemDataBound" Width="100%" RepeatColumns="2">
                    <ItemTemplate>
                        <li>
                        <table class="auto-style1">
                            <tr>
                                <td align="center">
                                    <a href="DS_DatTiec.aspx?idmenu=<%#Eval("MaSoMenu") %>"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Tengoi") %>' Font-Size="X-Large" ForeColor="#FF3300" Height="50px" ></asp:Label></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DataList ID="dtlCT" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tenmon") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                            </li>
                    </ItemTemplate>
                </asp:DataList>
            <div>
            <cc1:CollectionPager ID="phantrang" runat="server" BackText="« Trở về" LabelText="Trang:" NextText="Tiếp đến »" PageSize="4" LabelStyle="" ResultsFormat="Hiển Thị {0}-{1} (Của {2})" ResultsStyle="PADDING-BOTTOM:10px;PADDING-TOP:4px;FONT-WEIGHT: bold;"></cc1:CollectionPager>
            </div>
            </ul>


                </div>
        


</asp:Content>

