<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dangnhap.aspx.cs" Inherits="Admin_Dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProAdmin - Login</title>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />

<!--// FOLLOWING SCRIPT IS FOR PNG FIX IE5.5/IE6-->
    

<!--[if lt IE 7]>
<script defer type="text/javascript" src="js/pngfix.js"></script> 
<![endif]--> 


<!--//  Styles starts -->


<link href="css/login.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
        <%--<div>
    
        <table align="center" class="auto-style1">
            <tr>
                <td colspan="2">&#272;&#258;NG NH&#7852;P</td>
            </tr>
            <tr>
                <td>Tên &#272;&#259;ng Nh&#7853;p</td>
                <td>
                    <asp:TextBox ID="txtTenDN" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnDangNhap" runat="server" OnClick="btnDangNhap_Click" Text="&#272;&#259;ng Nh&#7853;p" />
                </td>
            </tr>
        </table>
    
    </div>--%>
        <div id="logo">
	<img src="images/logo.png" alt="logopng" width="116" height="34" /> <!--//  Logo on upper corner -->
</div>


<div class="box">
	<div class="welcome" id="welcometitle">Chào Mừng Đến Trang Admin <!--//  Welcome message -->
</div>
  
  
  <div id="fields"> 
    <table width="333">
      <tr>
        <td width="200" height="35"><span class="login">Tên Đăng Nhập</span></td>
        <td width="244" height="35"><label>
          &nbsp;<asp:TextBox ID="txtDN" runat="server"></asp:TextBox> <!--//  Username field  -->
        </label></td>
      </tr>
      
      
      <tr>
        <td height="35"><span class="login">Mật Khẩu</span><M&#7853;t Kh&#7849;u</span></td>
        <td height="35"><iPASSWORD</span><asp:TextBox ID="txtPW" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td height="35">&nbsp;</td> <!--//  Password field -->
      </tr>
      
      
      <tr>
        <td height="65">&nbsp;</td>
        <td height="65" valign="&nbsp;</td>
        <td height="65" valign="middle"><label>
            <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" type="submit" class="button" value="LOGIN" OnClick="btnLogin_Click" />
            <%--<input name="button" type="submit" class="button" id="button" value="LOGIN" />--%>
          <!--//  login button -->
        </label></td>
      </tr>
    </table>
  </div>
  
  
  
      <%--<div class="copyright" id="copyright">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Mauris risus mauris.<br />
  <!--//  copyright / footer -->
  Copyright &copy; Company People 2008.
  <a href="index-2.html">Back to index.</a>
</div>--%>
    </form>
</body>
</html>
