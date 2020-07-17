<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_DatDichVu.aspx.cs" Inherits="Admin_QL_DatDichVu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 277px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center" colspan="2"><h3>Quản Lý Đặt Món   </h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Id Đặt Món </td>
            <td>
                <asp:TextBox ID="txtIdDatDichVu" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
            <td class="auto-style3">Ngày tổ chức</td>
            <td>
                <asp:TextBox ID="txtNgayToChuc" runat="server"></asp:TextBox>
            </td>
        </tr>



        <tr>
             
            <td class="auto-style3">Thời gian tổ chức</td>
            <td>
                <asp:TextBox ID="txtTGTC" runat="server"></asp:TextBox>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
               <%-- <asp:DropDownList ID="DropDownList1"  runat="server">
                    <asp:ListItem Value="">Trưa</asp:ListItem>
                     <asp:ListItem Value="">Chiều</asp:ListItem>
                </asp:DropDownList>--%>
            </td>

        </tr>
          <tr>
            <td class="auto-style3">Địa chỉ</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
            </td>
        </tr>
     

         <tr>
            <td class="auto-style3">DỊCH VỤ ĐANG ĐẶT </td>
            <td>
                <asp:TextBox ID="txtTenDichVu" runat="server"></asp:TextBox>
            </td>
        </tr>
      
        <tr>
            <td class="auto-style3">Gía một sản phẩm </td>
            <td>
                <asp:TextBox ID="txtGiaSanPham" runat="server"></asp:TextBox>
            </td>
        </tr>
         <%-- 
          <tr>
            <td class="auto-style3">Số lượng </td>
            <td>
                <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
            </td>
        </tr>
        
          <tr>
            <td style="background-color:red;color:white;padding:5px" class="auto-style3">Thành tiền </td>
            <td>
                <asp:TextBox  ID="txtThanhTien" runat="server"></asp:TextBox>
            </td>
        </tr>
--%>
    

         <tr>
            <td class="auto-style3">ĐỔI THÀNH DỊCH VỤ</td>
            <td>
                <asp:DropDownList ID="DrlDV"  runat="server">
                </asp:DropDownList>
            </td>
        </tr>
         <%-- <tr>
            <td class="auto-style3">THÀNH TIỀN SAU KHI ĐỔI MÓN </td>
            <td>
              <asp:Textbox id="Textbox1" runat="server" text="<%# txtThanhTien %>" />
            </td>
        </tr>--%>
        <%--  <tr>
            <td class="auto-style3">     TEST ID MÓN ĂN </td>
            <td>
                <asp:TextBox ID="txtIdMonAn" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">TÊN MÓN ĂN </td>
            <td>
                <asp:TextBox ID="txtTenMon" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td > <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" /></td>
           
        </tr>

       
       
    
    </table>
</asp:Content>

