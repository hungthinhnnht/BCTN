<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="QL_DatMon.aspx.cs" Inherits="Admin_QL_DatMon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 277px;
        }
    </style>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script>
        // var a = document.getElementById("ContentPlaceHolder1_DrlMA").value();
        //var a = $('#DrlMA').val();
       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center" colspan="2"><h3>Quản Lý Đặt Món   </h3></td>
        </tr>
        <tr>
            <td class="auto-style3">Id Đặt Món </td>
            <td>
                <asp:TextBox ID="txtIdDatMon" runat="server"></asp:TextBox>
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
            </td>

        </tr>
      
          <tr>
            <td class="auto-style3">Địa chỉ</td>
            <td>
                <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td style="background-color:blue;color:white;padding:5px" class="auto-style3" class="auto-style3">MÓN ĐANG ĐẶT </td>
            <td>
                <asp:TextBox ID="txtTenmon" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style3">Gía một sản phẩm </td>
            <td>
                <asp:TextBox ID="txtGiaSanPham" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="auto-style3">Số lượng </td>
            <td>
                <asp:TextBox ID="txtSoLuong" onchange="GiaKhiDoiSoLuong(this)" runat="server"></asp:TextBox>
            </td>
        </tr>
        
          <tr>
            <td style="background-color:red;color:white;padding:5px" class="auto-style3">THÀNH TIỀN </td>
            <td>
                <asp:TextBox   ID="txtThanhTien" runat="server"></asp:TextBox>
            </td>
        </tr>

    

         <tr>
            
            
            <td style="background-color:yellow;color:black;padding:5px" class="auto-style3" class="auto-style3">ĐỔI THÀNH MÓN</td>
           
               <td>
                <asp:DropDownList ID="DrlMA"  runat="server" onchange="GiaKhiDoiMon(this)">
                </asp:DropDownList>
                
            </td>
            <%-- <td>
                  <asp:CheckBox ID="DoiMon" runat="server" Text="  ĐỔI MÓN" />  
             </td>--%>
        </tr>
          <tr style="display:none">
            <td class="auto-style3">GIÁ MÓN ĐANG CHỌN </td>
           <td> <asp:TextBox   ID="GiaMonChon" runat="server"></asp:TextBox></td>
        </tr>
         <tr style="display:none">
            <td class="auto-style3" style="background-color:yellow;color:black;padding:5px">THÀNH TIỀN SAU KHI ĐỔI MÓN </td>
           <td> <asp:TextBox   ID="ThanhTienMoi" runat="server"></asp:TextBox></td>
        </tr>
       
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

    <script type = "text/javascript">
        var SoLuong = document.getElementById("<%=txtSoLuong.ClientID%>");
        var TienMonChon = document.getElementById("<%=GiaMonChon.ClientID%>");
        var ThanhTienMoi = document.getElementById("<%=ThanhTienMoi.ClientID%>");
        var ThanhTien1 = document.getElementById("<%=txtThanhTien.ClientID%>");

        ThanhTienMoi.value = ThanhTien1.value;
        TienMonChon.value = ThanhTien1.value/SoLuong.value;

        function GiaKhiDoiMon(sel) {
            var GiaMonChon = sel.options[sel.selectedIndex].getAttribute('data-gia');
            var SoLuong = document.getElementById("<%=txtSoLuong.ClientID%>");
            var TienMonChon = document.getElementById("<%=GiaMonChon.ClientID%>");
            var GiaSanPham = document.getElementById("<%=txtGiaSanPham.ClientID%>");
            // alert(SoLuong.value * GiaMonChon);
            TienMonChon.value = GiaMonChon;
            GiaSanPham.value = GiaMonChon;
            var ThanhTienMoi = document.getElementById("<%=txtThanhTien.ClientID%>");
            ThanhTienMoi.value = SoLuong.value * GiaMonChon;
            //alert(GiaMonChon);
        }
        function GiaKhiDoiSoLuong(sl) {

            var SL = sl.value;
            var TienMonChon = document.getElementById("<%=GiaMonChon.ClientID%>");
            var ThanhTienMoi = document.getElementById("<%=txtThanhTien.ClientID%>");
            //alert(TienMonChon.value)
            ThanhTienMoi.value =TienMonChon.value * SL;
         
        }
    </script>

  

</asp:Content>





