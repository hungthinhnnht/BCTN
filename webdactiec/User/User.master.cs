using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_User : System.Web.UI.MasterPage
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtQuangCao;

    void loadQuangCao()
    {
        string sql = "select * from QuangCao ";
        da = new SqlDataAdapter(sql,cnn);
        dtQuangCao = new DataTable();
        cnn.Open();
        da.Fill(dtQuangCao);
        cnn.Close();

        dtlquangcao.DataSource = dtQuangCao;
        dtlquangcao.DataBind();


    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["TenDangNhap"] == null)
        //{
        //    Response.Redirect("~/User/TrangChu.aspx");
        //    //lbHoten.Text = Session["TenNguoiDung"].ToString();
        //}
        //else
        //{
        //    Response.Redirect("~/User/TrangChu.aspx");
        //    lbHoten.Text = Session["TenNguoiDung"].ToString();
        //}
        loadQuangCao();
    }
    //protected void btnThoat_Click(object sender, EventArgs e)
    //{
    //    Session.Remove("TenDangNhap");
    //    Session.Remove("TenNguoiDung");

    //    Response.Redirect(Request.Url.ToString());
    //}
}
