using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Dangnhap : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtDangNhap;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btnDangNhap_Click(object sender, EventArgs e)
    //{
    //    string sql = "select * from NguoiDung where Tendn='"+txtTenDN.Text+"' and Matkhau= '"+txtPass.Text+"' and Quyen='True' ";
    //    da = new SqlDataAdapter(sql, cnn);
    //    dtDangNhap = new DataTable();

    //    cnn.Open();
    //    da.Fill(dtDangNhap);
    //    cnn.Close();

    //    if (dtDangNhap.Rows.Count > 0)
    //    {
    //        Session["TenDangNhap"] = txtTenDN.Text;
    //        Session["TenNguoiDung"] = dtDangNhap.Rows[0]["Hoten"].ToString();

    //        Response.Redirect("TrangChu.aspx");
    //    }

    //}
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string sql = "select * from NguoiDung where Tendn='" + txtDN.Text + "' and Matkhau= '" + txtPW.Text + "' and Quyen='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtDangNhap = new DataTable();

        cnn.Open();
        da.Fill(dtDangNhap);
        cnn.Close();

        if (dtDangNhap.Rows.Count > 0)
        {
            Session["TenDangNhap"] = txtDN.Text;
            Session["TenNguoiDung"] = dtDangNhap.Rows[0]["Hoten"].ToString();

            Response.Redirect("TrangChu.aspx");
        }
    }
}