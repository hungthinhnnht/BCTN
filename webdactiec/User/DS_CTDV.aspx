<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_CTDV.aspx.cs" Inherits="User_DS_CTDV" %>

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
						<h2>Chi Tiết Dịch Vụ</h2>
						
								<h4>
                                    <asp:Label ID="lbTenDV" runat="server"></asp:Label>
                                </h4>
								<p>
									<asp:Label ID="lbMoTa" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
								</p>
                                <p>
									<asp:Image ID="imgHinh" runat="server" Width="160px" />
								</p>
                                <p>
									<asp:Label ID="lbGia" runat="server"></asp:Label>
								</p>
                                <p>
									<asp:DataList ID="dtlCTDV" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td width="100px" valign="top">
                                                        <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%# "~/Hinh/HinhCTDV/"+Eval("Hinhanh") %>' />
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>

                                            <hr />

                                        </ItemTemplate>
                                    </asp:DataList>
							
						</div>
            </div>
         </div>
					

</asp:Content>

