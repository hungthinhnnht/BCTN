<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_DatTiec.aspx.cs" Inherits="User_DS_DatTiec" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 18px;
        }
        .auto-style4 {
            width: 137px;
        }
    .auto-style5 {
        width: 137px;
        height: 30px;
    }
    .auto-style6 {
        height: 30px;
    }
    </style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="body">
				<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



    <div id="dvMonAn" runat="server" visible="true">
						<h2>Đặt Tiệc</h2>
        
						<ul>
							<li>
								<h4>Danh Sách Các Món Ăn</h4>								
							</li>
						</ul>
       
 Loại Món Ăn
					    <asp:DropDownList ID="DrvLoaiMon" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrvLoaiMon_SelectedIndexChanged">
                        </asp:DropDownList>
        
                        <br />
                        <asp:DataList ID="DtlMonan" runat="server" Width="100%">
                            <ItemTemplate>
                                <table class="auto-style1" >
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgHinh" runat="server" Width="100px" Height="100px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' />
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lbTenmon" runat="server" Text='<%# Eval("Tenmon") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="lbGia" runat="server" Text='<%# Eval("Gia","{0:#,##0}") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="lbidmonan" runat="server" Text='<%# Eval("idmonan") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:CheckBox ID="chkchon" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
            
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
                

                        <asp:Label ID="lbTenmon" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbHinh" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbGia" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbidmon" runat="server" Visible="False"></asp:Label>
                        <br />
                        Danh Sách Các Món Ăn Đã Chọn:<asp:GridView ID="GrvMonChon" runat="server" AutoGenerateColumns="False" OnRowCommand="GrvMonChon_RowCommand" Width="100%" PageSize="6">
                            <Columns>
                                <asp:BoundField DataField="idmonan" HeaderText="Mã Món Ăn" />
                                <asp:BoundField DataField="Tenmon" HeaderText="Tên Món" />
                                <asp:TemplateField HeaderText="Hình Ảnh">
                                    <ItemTemplate>
                                        <asp:Image ID="Image2" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="50px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                                <asp:BoundField DataField="Soluong" HeaderText="Số Lượng" />
                                <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" DataFormatString="{0:#,##0}" />
                                <asp:TemplateField HeaderText="Xóa">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnXoa" runat="server" OnClientClick="return confirm('Bạn có muôn xó không')"
                                             CommandArgument='<%# Eval("idmonan") %>' CommandName="Xoa">Xóa</asp:LinkButton>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
        Tổng Số Tiền:
                        <asp:Label ID="lbtongtien" runat="server"></asp:Label>
                       <p> <asp:Button ID="btnChon" runat="server" Text="Chọn Dịch Vụ" OnClick="btnChon_Click1" /></p>
        
					</div>

       
            <div id="dvDichVu" runat="server" visible="false">
						<h2>Dịch Vụ</h2>
						<ul>
							<li>
								<h4>Danh Sách Các Dịch Vụ</h4>								
							</li>
						</ul>
						
					

    Loại Dịch Vụ:<asp:DropDownList ID="DrvLoaiDV" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrvLoaiDV_SelectedIndexChanged">
    </asp:DropDownList>
                        <asp:DataList ID="DtlDichVu" runat="server" Width="100%">
                            <ItemTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        
                                        <td>
                                            <asp:Image ID="imgHinh" runat="server" Height="100px" ImageUrl='<%# "~/Hinh/Hinhdichvu/"+Eval("Hinhanh") %>' Width="100px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbTen" runat="server" Text='<%# Eval("Tendichvu") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="lbGia" runat="server" Text='<%# Eval("Gia","{0:#,##0}") %>'></asp:Label>
                                            <asp:Label ID="lbidDV" runat="server" Text='<%# Eval("iddichvu") %>' Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkchon" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                <hr />
                <hr />
                <h2 align="center">Dịch Vụ Bắt Buộc</h2>
                <asp:DataList ID="DtlDVBB" runat="server" Width="100%">
                    <ItemTemplate>
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Image ID="imgHinh" runat="server" Height="100px" ImageUrl='<%# "~/Hinh/Hinhdichvu/"+Eval("Hinhanh") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lbTen" runat="server" Text='<%# Eval("Tendichvu") %>'></asp:Label>
                                    <asp:Label ID="lbGia" runat="server" Text='<%# Eval("Gia","{0:#,##0}") %>'></asp:Label>
                                    <asp:Label ID="lbidbb" runat="server" Text='<%# Eval("iddichvu") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="bacbuoc" runat="server" Text='<%# Eval("BatBuoc") %>' Visible="False"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkChon" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                        </asp:DataList>
    
    &nbsp;<asp:Button ID="btnThemDV" runat="server" Text="Thêm" OnClick="btnThemDV_Click" />
    

    <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbTenDV" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    Danh Sách Dịch Vụ Đã Chọn:<asp:GridView ID="GrvDVChon" runat="server" AutoGenerateColumns="False" OnRowCommand="GrvDVChon_RowCommand" Width="100%">
        <Columns>
            <asp:BoundField DataField="iddichvu" HeaderText="Mã Dịch Vụ" />
            <asp:BoundField DataField="Tendichvu" HeaderText="Tên Dịch Vụ" />
            <asp:TemplateField HeaderText="Hình Ảnh">
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
            <asp:BoundField DataField="ThanhTien" HeaderText="Thành Tiền" DataFormatString="{0:#,##0}" />
            <asp:TemplateField HeaderText="Xem Chi Tiết" Visible="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnXem" runat="server" CommandArgument='<%# Eval("iddichvu") %>' CommandName="Xem">Xem</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnXoa" runat="server" OnClientClick ="return confirm('Bạn có muôn xó không')"
                        CommandArgument='<%# Eval("iddichvu") %>' CommandName="Xoa">Xóa</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    Tổng Số Tiền:<asp:Label ID="lbTienDV" runat="server"></asp:Label>


                        
    


            <%--<div id="dvchitietdv" runat="server" visible="false">

                <p>Tên:<asp:Label ID="lbTen" runat="server"></asp:Label>
                </p>
                <p>Giá:<asp:Label ID="lbGiaDV" runat="server"></asp:Label>
                </p>
                <p>Mô Tả:<asp:Label ID="lbmota" runat="server"></asp:Label>
                </p>
                <p>Chi Tiết Dịch Vụ<asp:DataList ID="dtlCTDV" runat="server" Width="100%">
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
                </p>

            </div>--%>
                <p>
                    <asp:Button ID="btnTiep" runat="server" Text="Điền Thông Tin" OnClick="btnTiep_Click" />
                    <asp:Button ID="btnChonMon" runat="server" OnClick="btnChonMon_Click" Text="Chọn Món" />
                </p>
      </div>

            <div id="dvKhacHang" runat="server" visible="false">
                
                <table align="center" class="auto-style1">
                    <tr>
                        <td class="auto-style2" colspan="2">Thông Tin Khách Hàng</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Họ và Tên:</td>
                        <td>
                            <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Tên Đăng Nhập</td>
                        <td>
                            <asp:TextBox ID="txtDN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Ngày Đặt:</td>
                        <td>
                            <asp:Label ID="lbNgayDat" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Ngày Đãi:</td>
                        <td>
                            <asp:TextBox ID="txtNgayDai" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Thời Gian Đãi</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Trưa</asp:ListItem>
                                <asp:ListItem>Chiều</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Địa Chỉ:</td>
                        <td>
                            <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">SĐT:</td>
                        <td>
                            <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Số Lượng Bàn</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtSLB" runat="server"></asp:TextBox>
                            <asp:Label ID="lbmaso" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Ghi Chú</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtGhiChu" runat="server" Height="83px" TextMode="MultiLine" Width="528px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style6">
                            <asp:Label ID="lbTongSoTien" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="btnKetThuc" runat="server" OnClick="btnKetThuc_Click" Text="Kết Thúc" />
                        </td>
                        <td align="right">
                            <asp:Button ID="Button1" runat="server" PostBackUrl="~/User/LSDT.aspx" Text="Lịch Sử Đặt Tiệc" />
                        </td>
                    </tr>
                </table>
                
            </div>
            
                <asp:Label ID="lbBB" runat="server"></asp:Label>

            
            
        </ContentTemplate>

    </asp:UpdatePanel>
</div>
        </div>

</asp:Content>

