<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_MonAn.aspx.cs" Inherits="User_DS_MonAn" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="footer">
        <ul>
            <asp:Label ID="lbLoaiMon" runat="server"></asp:Label>
            <asp:DataList ID="dtlMonAn" runat="server" RepeatColumns="2" Width="100%">
                <ItemTemplate>
                    <li>
                        <h2><a href="DS_CTMA.aspx?id=<%#Eval("idmonan") %>"><asp:Label ID="Label1" runat="server" Text='<%# Eval("TenMon") %>'></asp:Label></a></h2>
                        <a href="DS_CTMA.aspx?id=<%#Eval("idmonan") %>">
                            <asp:Image ID="Image2" runat="server" Height="100%" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="100%" />
                        </a>
                    &nbsp;</li>
                   
                </ItemTemplate>
            </asp:DataList>
            <div>
                <cc1:CollectionPager ID="phantrang" runat="server" BackText="« Trở Về" LabelStyle="" LabelText="Trang" NextText="Tiếp »" PageSize="5" ResultsFormat="Hiển Thị {0}-{1} (Của {2})" ResultsStyle="PADDING-BOTTOM:10px;PADDING-TOP:4px;FONT-WEIGHT: bold;"></cc1:CollectionPager>
            </div>

        </ul>
    </div>



</asp:Content>

