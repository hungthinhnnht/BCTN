<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_LoaiMA.aspx.cs" Inherits="User_LoaiMA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="body">
        <div id="content">
            <div>
                <h2>Danh Sách Loại Món Ăn</h2>
                <asp:DataList ID="dtlLoaiMon" runat="server" Width="100%" RepeatColumns="2">
                    <ItemTemplate>
                        <li>
                            <a href="DS_MonAn.aspx?id=<%#Eval("idloaimon") %>">

                                <%#Eval("Tenloai") %>
                                

                            </a>
                        </li>

                    </ItemTemplate>

                </asp:DataList>
                 <hr />
                <hr />
                <p>Đến với hệ thống nhà hàng tiệc cưới Secret, chuyên tổ chức nấu ăn phục vụ tiệc cưới, liên hoan, sinh nhật, hội nghị, sự kiện, buffet, tại gia, công ty, cơ quan, nhà trường, hội chợ, buổi dã ngoại. Với kinh nghiệm trên 10 năm, chúng tôi bảo đảm bạn sẽ có những buổi tiệc ấm cùng trong không gian ẩm thực tuyệt vời, cùng cung cách phục vụ chuyên nghiệp, và chi phí bỏ ra luôn xứng đắng và hợp lý.</p>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Hinh/daubepvietnam-iron_chef_viet_nam_2013-2.jpg" />
                <h3>Catering là gì?</h3>
                <p>Bản chất của catering như thông thường nhiều người vẫn biết hoặc nghe nói đến nó chỉ đơn thuần chỉ là những dịch vụ cung cấp thức ăn như suất ăn công nghiệp hoặc cơm trưa văn phòng. Tuy nhiên trong tổ chức sự kiện, Catering chỉ việc cung cấp đồ ăn thức uống theo những tiêu chuẩn chuyên nghiệp và khắt khe hết sức. Khách tham dự sẽ hoàn toàn có cảm nhận khác về chữ catering, có thể gọi nôm na là cả một sự kiện về Ẩm thực.</p>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Hinh/sup-luon-nau-sa-gay-ngac-nhien-trong-sieu-dau-bep-viet-11.jpg" />
                <p>Dịch vụ Catering sẽ không chỉ đơn giản mang thức ăn đến cho Khách hàng của bạn, mà họ còn mang đến cả một ekip để phục vụ cho sự kiện của bạn từ việc tư vấn chọn thực đơn, cách trang trí, sắp đặt bàn ăn trong khán phòng cho tới việc thực hiện cả một chương trình giải trí như dàn dựng âm thanh, ánh sáng, ca sĩ...</p>
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Hinh/cuoc-thi-sieu-dau-bep-11.jpg" />
                <p>Chính vì tính chuyên nghiệp trong việc tổ chức như vậy nên hiện nay trên thị trường Việt Nam rất ít các dịch vụ có loại hình như vậy, và hầu hết nếu có thì nó cũng chỉ thường được cung cấp bởi các khách sạn năm sao. nhưng nay chúng tôi sẽ cung cấp cho bạn dịch vụ Catering không đơn giản là chỉ mang đến cho sự kiện các món lạ, các bữa ăn ngon mà cả một gói dịch vụ cao cấp, một buổi tiệc trang trọng theo phong cách và tiêu chuẩn cao trong môi trường làm việc chuyên nghiệp với nhân sự có một nền tảng vững chắc về Ẩm thực và kiến thức và kinh nghiệm tổ chức tiệc.</p>
            </div>
        </div>
    </div>
</asp:Content>

