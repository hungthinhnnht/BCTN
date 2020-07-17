<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="NoiDungTT.aspx.cs" Inherits="User_NoiDungTT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="body">
        <div id="content">
            <div>
						<h2>Tin Tức</h2>
						
								<h4>
                                    <asp:Label ID="lbTieuDe" runat="server"></asp:Label>
                                </h4>
								<p>
									&nbsp;<asp:Label ID="lbTomTat" runat="server"></asp:Label>
								</p>
                                <p>
									<asp:Label ID="lbNoiDung" runat="server"></asp:Label>
								</p>
							
						
					</div>
            </div>
         </div>


</asp:Content>

