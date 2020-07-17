using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_KHDangKy : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    hamdungchung ham = new hamdungchung();

    

    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnDK_Click(object sender, EventArgs e)
    {
        bool duocdangky = true;

        if (txtMK.Text.Trim() == "" || txtMK.Text.Trim().Length < 6)
        {
            duocdangky = false;
            lbMK.Text = "Vui lòng nhập mật khẩu phải trên 6 ký tự";
        }

        if (txtNLMK.Text.Trim() != txtMK.Text.Trim())
        {
            duocdangky = false;
            lbNLMK.Text = "Vui Lòng Kiểm Tra Lại";
        }

        if (duocdangky == true)
        {
            string kh = ham.PhatSinhMaTuDong("KhachHang", "MaKH", "KH", 6);
            string sql = "insert into KhachHang values('"+kh+"',N'" + txtHoten.Text + "','" + txtTenDN.Text + "',N'" + txtEmail.Text + "','" + txtMK.Text + "',N'" + txtDC.Text + "',N'" + txtSDT + "')";
            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


            string kqthem = "Chúc Mừng Bạn Đã Đang Ký Thành Công.";
            dvthongbao.InnerHtml = kqthem;
            //xoa control
            txtEmail.Text = "";
            
        }
        
    }
}