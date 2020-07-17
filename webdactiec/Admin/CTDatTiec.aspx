<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="CTDatTiec.aspx.cs" Inherits="Admin_CTDatTiec" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
        .auto-style4 {
            width: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="CTDT" runat="server" visible="true">
    <table align="center" class="auto-style2">
        <tr>
            <td align="center"><h3>Danh Sách Chi Tiết Đặt Tiệc</h3></td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" class="auto-style2">
                    <tr>
                        <td class="auto-style3" colspan="2">Thông Tin Khách Hàng</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Họ và Tên</td>
                        <td>
                            <asp:Label ID="lbHoTen" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Ngày Đặt</td>
                        <td>
                            <asp:Label ID="lbNgayDat" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Ngày Đãi</td>
                        <td>
                            <asp:Label ID="lbNgayDai" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Địa Chỉ</td>
                        <td>
                            <asp:Label ID="lbDiaChi" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">SĐT</td>
                        <td>
                            <asp:Label ID="lbSDT" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Tổng Số Tiền</td>
                        <td>
                            <asp:Label ID="lbTongTien" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <h3 align="center">Thông Tin Món Ăn</h3>
                <asp:GridView ID="GrvMonAn" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="idmonan" HeaderText="Mã Món Ăn" />
                        <asp:BoundField DataField="Tenmon" HeaderText="Tên Món Ăn" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Gia" HeaderText="Giá" />
                        <asp:BoundField DataField="Soluong" HeaderText="Số Lượng" />
                        <asp:BoundField DataField="ThanhTien" DataFormatString="{0:#,##0}" HeaderText="Thành Tiền" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <h3 align="center">Thông Tin Dịch Vụ</h3>
                <asp:GridView ID="GrvDichVu" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="iddichvu" HeaderText="Mã Dịch Vụ" />
                        <asp:BoundField DataField="Tendichvu" HeaderText="Tên Dịch Vụ" />
                        <asp:TemplateField HeaderText="Hình Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Height="50px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Gia" DataFormatString="{0:#,##0}" HeaderText="Giá" />
                        <asp:BoundField DataField="Soluong" HeaderText="Số Lượng" />
                        <asp:BoundField DataField="ThanhTien" DataFormatString="{0:#,##0}" HeaderText="Thành Tiền" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
                <br />
            </td>
        </tr>
    </table>
    </div>
    <div id="CapNhat" runat="server" visible="false">
       <p>Họ và Tên: 
           <asp:Label ID="lbTen" runat="server"></asp:Label>
        </p>
       <p>Ngày Đặt:<asp:Label ID="lbNgay" runat="server"></asp:Label>
        </p>
       <p> Ngày Đãi:<asp:TextBox ID="txtNgayDai" runat="server"></asp:TextBox>
           <asp:CalendarExtender ID="txtNgayDai_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtNgayDai">
           </asp:CalendarExtender>
           <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
        </p>
        <p>Địa Chỉ:<asp:Label ID="lbDC" runat="server" Text="Label"></asp:Label>
        </p>
       <p>SĐT:<asp:Label ID="lbDT" runat="server"></asp:Label>
        </p>
        <p>Tổng Số Tiền:<asp:Label ID="lbTST" runat="server"></asp:Label>
        </p>
       <p> Trạng Thái:<asp:DropDownList ID="DrlTrangthai" runat="server">
           <asp:ListItem>Đang Chờ Xác Nhận</asp:ListItem>
           <asp:ListItem>Đã Xác Nhận</asp:ListItem>
           <asp:ListItem>Đã Đặt Cọc</asp:ListItem>
           <asp:ListItem>Đã Thanh Toán</asp:ListItem>
           <asp:ListItem>Hủy</asp:ListItem>
           </asp:DropDownList>
       </p>
       

           <asp:Button ID="btnThayDoi" runat="server" Text="Cập Nhật" OnClick="btnThayDoi_Click" />
        
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

