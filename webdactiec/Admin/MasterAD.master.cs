using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterAD : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TenDangNhap"] == null)
        {
            Response.Redirect("DangNhap.aspx");
        }
        else
        {
            lbHoTen.Text = Session["TenNguoiDung"].ToString();
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session.Remove("TenDangNhap");
        Session.Remove("TenNguoiDung");

        Response.Redirect(Request.Url.ToString());
    }
}
