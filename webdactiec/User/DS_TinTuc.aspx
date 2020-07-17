<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_TinTuc.aspx.cs" Inherits="User_DS_TinTuc" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="body">
        <div id="content">
            <div>
						<h2>Tin Tức</h2>
						
								<%--<h4>You can replace all this text with your own text</h4>
								<p>
									This website template has been designed by <a href="http://www.freewebsitetemplates.com/">Free Website Templates</a> for you, for free. You can replace all this text with your own text
									You can remove any links to our website from this website template, you're free to use this website template without linking back to us.
									If you're having a problems editing this temlate, then don't hesitate to ask for help on the <a href="http://www.freewebsitetemplates.com/forums">Forums</a>.--%>
								    <asp:DataList ID="dtlTinTuc" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <a href="NoiDungTT.aspx?id=<%#Eval("idtin") %>"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Tieude") %>'></asp:Label></a>
                                             <table class="auto-style1">
                                                <tr>
                                                    <td rowspan="2" width="160px" valign="top">
                                                        <asp:Image ID="Image1" runat="server" Width="160px" ImageUrl='<%# "~/Hinh/TinTuc/"+Eval("Hinh") %>' />
                                                    </td>
                                                    <td valign="top" align="left">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tomtat") %>' Font-Size="Smaller"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                <div>
                    <cc1:CollectionPager ID="phantrang" runat="server" BackText="« Trở Về" LabelStyle="" LabelText="Trang" NextText="Tiếp »" PageSize="5" ResultsFormat="Hiển thị {0}-{1} (Của {2})" ResultsStyle="PADDING-BOTTOM:10px;PADDING-TOP:4px;FONT-WEIGHT: bold;"></cc1:CollectionPager>
                </div>
								</p>
						
						</div>
            </div>
        </div>					

</asp:Content>

