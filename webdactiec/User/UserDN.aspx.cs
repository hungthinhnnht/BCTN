using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_UserDN : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtDangNhap;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDN_Click(object sender, EventArgs e)
    {
         string sql = "select * from KhachHang where Tendangnhap='" + txtDN.Text + "' and MatKhau= '" + txtMK.Text + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtDangNhap = new DataTable();

        cnn.Open();
        da.Fill(dtDangNhap);
        cnn.Close();

        if (dtDangNhap.Rows.Count > 0)
        {
            Session["TenDangNhap"] = txtDN.Text;
            Session["MaKH"] = dtDangNhap.Rows[0]["MaKH"].ToString();
            Session["TenNguoiDung"] = dtDangNhap.Rows[0]["Hoten"].ToString();
            Session["DiaChi"] = dtDangNhap.Rows[0]["Diachi"].ToString();
            Session["DienThoai"] = dtDangNhap.Rows[0]["Dienthoai"].ToString();
            Session["Email"] = dtDangNhap.Rows[0]["Email"].ToString();
        }
        Response.Redirect("~/User/TrangChu.aspx");
    }
}