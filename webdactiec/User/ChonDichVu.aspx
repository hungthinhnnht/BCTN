<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="ChonDichVu.aspx.cs" Inherits="User_ChonDichVu" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="DichVu">
						<h2>Dịch Vụ</h2>
						<ul>
							<li>
								<h4>Danh Sách Các Dịch Vụ</h4>								
							</li>
						</ul>
						
					

    Loại Dịch Vụ:<asp:DropDownList ID="DrvLoaiDV" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrvLoaiDV_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:GridView ID="GrvDichVu" runat="server" AutoGenerateColumns="False" OnRowCommand="GrvDichVu_RowCommand" AllowPaging="True" OnPageIndexChanging="GrvDichVu_PageIndexChanging" Width="100%">
        <Columns>
            <asp:BoundField DataField="iddichvu" HeaderText="Mã Dịch Vụ" />
            <asp:BoundField DataField="Tendichvu" HeaderText="Tên Dịch Vụ" />
            <asp:TemplateField HeaderText="Hình Ảnh">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
            <asp:TemplateField HeaderText="Chọn Dịch Vụ">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnChon" runat="server" CommandArgument='<%# Eval("iddichvu") %>' CommandName="ChonDV">Chọn</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xem Chi Tiết">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnXem" runat="server" CommandArgument='<%# Eval("iddichvu") %>' CommandName="Xem">Xem</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
    &nbsp;<asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" />
    

    <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbTenDV" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbHinh" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbGia" runat="server"></asp:Label>
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
            <asp:TemplateField HeaderText="Xem Chi Tiết">
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
    Tổng Số Tiền:<asp:Label ID="lbtongtien" runat="server"></asp:Label>


                        
    </div>


            <div id="dvchitietdv" runat="server" visible="false">

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

            </div>
        </ContentTemplate>

        </asp:UpdatePanel>

</asp:Content>

