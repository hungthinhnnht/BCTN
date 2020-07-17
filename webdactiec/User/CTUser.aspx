<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="CTUser.aspx.cs" Inherits="User_CTUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 158px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="body">
        <div id="content">
            <div>
                <h2 align="center">Đơn Đặt Hàng Của Bạn</h2>
                <ul>

                    <table class="auto-style1">
                        <tr>
                            <td colspan="2" align="center">Thông Tin Khách Hàng</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Họ Và Tên</td>
                            <td>
                                <asp:Label ID="lbHoTen" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Ngày Đặt</td>
                            <td>
                                <asp:Label ID="lbNgayDat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Ngày Đãi</td>
                            <td>
                                <asp:Label ID="lbNgayDai" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Thời Gian Đãi</td>
                            <td>
                                <asp:Label ID="lbTGD" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Số Lượng Bàn</td>
                            <td>
                                <asp:Label ID="lbSLB" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Địa Chỉ</td>
                            <td>
                                <asp:Label ID="lbDiaChi" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Điện Thoại</td>
                            <td>
                                <asp:Label ID="lbSDT" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Ghi Chú</td>
                            <td class="auto-style4">
                                <asp:Label ID="lbGhiChu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Tổng Số Tiền</td>
                            <td class="auto-style4">
                                <asp:Label ID="lbTongsotien" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" colspan="2">Danh sách dịch vụ:</td>
                        </tr>
                        <tr>
                            <td class="auto-style2" colspan="2">
                                <asp:GridView ID="GrvDV" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Tendichvu" HeaderText="Tên Dịch Vụ" />
                                        <asp:TemplateField HeaderText="Hình Ảnh">
                                            <ItemTemplate>
                                                <asp:Image ID="Image2" runat="server" Height="70px" ImageUrl='<%# "~/Hinh/hinhdichvu/"+Eval("Hinhanh") %>' Width="70px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2" colspan="2">Danh Sach Mon An:</td>
                        </tr>
                        <tr>
                            <td class="auto-style2" colspan="2">
                                <asp:GridView ID="GrvMA" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Tenmon" HeaderText="Tên Món Ăn" />
                                        <asp:TemplateField HeaderText="Hình Ảnh">
                                            <ItemTemplate>
                                                <asp:Image ID="Image3" runat="server" Height="70px" ImageUrl='<%# "~/Hinh/HinhMonAn/"+Eval("Hinhanh") %>' Width="70px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Gia" HeaderText="Giá" DataFormatString="{0:#,##0}" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>

                   

                </ul>
                 <p><h3 align="center">Hình Thức Thanh Toán</h3></p>
                    <ol>
                    <li> Quý khách đặt cọc trước 40% giá trị hợp đồng không quá 3 ngày sau khi đặt tiệc</li>
                    <li>Số tiền còn lại và các chi phí phát sinh (nếu có) Quý khách sẽ thanh toán ngay khi vừa kết thúc tiệc.</li>
                    <li>Thanh toán trực tiếp tại quầy tiếp tân tại trung tâm</li>
                    <p>Địa Chỉ:155 Sư Vạn Hạnh (nd), phường 13, Quận 10, TP. HCM</p>
                    <p>SĐT:01225119688</p>
                    
                </ol>
                <p><h3 align="center">Hình Thức Hủy Đơn Đặt Tiệc</h3></p>
                <ol>
                   <li> Hủy trước 2 ngày sau khi đặt cọc Quý khách sẽ chịu phí là 50% số tiền đã đặt cọc.</li>
                    <li>Sau thời gian trên Quý khách sẽ chịu phí là 100% số tiền đã đặt cọc.</li>
                    <li>Khi có thay đổi tăng hoặc giảm số lượng bàn, Quý khách vui lòng báo trước 24h.</li>
                    <p>Mọi thay đổi xin liên hệ SDT:01225119688</p>
     
                </ol>
            </div>
            </div>
        </div>
</asp:Content>

