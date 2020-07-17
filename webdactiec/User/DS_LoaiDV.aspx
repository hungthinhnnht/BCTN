<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="DS_LoaiDV.aspx.cs" Inherits="User_DS_LoaiDV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="body">
        <div id="content">
            <div>
            <h2>Danh Sách Loại Dịch Vụ</h2>
            <asp:DataList ID="dtlLoaiDV" runat="server" Width="100%" RepeatColumns="2">
                <ItemTemplate>
                    <li>
                        <a href="DS_DichVu.aspx?id=<%#Eval("idloai") %>">

                            <%#Eval("Tenloai") %>
                            
                        </a>
                    </li>

                </ItemTemplate>
            </asp:DataList>
                <hr />
                <hr />
                <p>Với hơn 10 năm kinh nghiệm trong lĩnh vực tổ chức tiệc cưới và luôn đầu tư sáng tạo, hệ thống nhà hàng Secret vô cùng tự hào trở thành đơn vị đồng hành và địa điểm tin tưởng cho các cặp đôi chia sẻ niềm hỷ sự hạnh phúc, thể hiện tình cảm yêu quý với gia đình và bạn bè thân hữu trong ngày trọng đại của mình.</p>
                <p>Đến với hệ thống nhà hàng tiệc cưới Secret, các đôi uyên ương sẽ hoàn toàn cảm thấy hài lòng với không gian sang trọng; phong cách tinh tế; dịch vụ phong phú; phục vụ chu đáo; thực đơn đãi tiệc chắt lọc và bày trí bắt mắt. Khu vực tiền sảnh rộng rãi, thoáng mát cây xanh để khách mời thoải mải trò chuyện, gặp gỡ trước khi vào sảnh tiệc; giữa các sảnh đều có vách ngăn di động để mở rộng không gian cho những bữa tiệc lớn.</p>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Hinh/5.jpg" />
                <p>Công nghệ truyền hình trực tiếp nghi lễ cưới, hệ thống âm thanh, ánh sáng chuyên nghiệp, không gian sang trọng và ấm áp mang đến cho đôi uyên ương, gia đình cùng bạn bè những khoảnh khắc ấn tượng và thoải mái nhất. Đối với các cặp đôi cá tính - yêu thích sự lãng mạn, nghi lễ cưới đều được đội ngũ kỹ thuật viên chuyên nghiệp hiện thực hóa các ý tưởng, biên tập và hỗ trợ thực hiện để lưu giữ những khoảnh khắc đầy kỷ niệm. </p>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Hinh/2.png" />
                <p>Nhà hàng tiệc cưới Secret uy tín và chất lượng sẽ làm hài lòng Quý khách.</p>
            </div>
        </div>
    </div>

</asp:Content>

