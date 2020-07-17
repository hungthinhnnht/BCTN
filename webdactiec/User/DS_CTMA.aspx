<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_CTMA.aspx.cs" Inherits="User_DS_CTMA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="body">
        <div id="content">
            <div>
                <div>
                    <ul>
                        <li>
                            <h3>
                                <asp:Label ID="lbTenMon" runat="server"></asp:Label>
                            </h3>
                            <a href="index.html">
                                <asp:Image ID="imgHinh" runat="server" Height="100%" Width="100%" />
                            </a>&nbsp;<p>
                                <asp:Label ID="lbMoTa" runat="server" Font-Size="Smaller"></asp:Label> 
								
                            </p>
                            <p><asp:Label ID="lbGia" runat="server"></asp:Label>
                            </p>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

