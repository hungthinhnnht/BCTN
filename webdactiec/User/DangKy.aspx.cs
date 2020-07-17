using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_DangKy : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dtKH;

    void LoadTen()
    {
        string sql = "select * from DatTiec where iddattiec='"+Request.QueryString["id"]+"' ";
        da = new SqlDataAdapter(sql, cnn);
        dtKH = new DataTable();

        cnn.Open();
        da.Fill(dtKH);
        cnn.Close();

        if (dtKH.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            lbTenDN.Text = dtKH.Rows[0]["Tendangnhap"].ToString();
            lbHoten.Text = dtKH.Rows[0]["Hoten"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTen();
    }
    protected void btnDangKy_Click(object sender, EventArgs e)
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
            lbNLMK.Text = "Kiểm tra lại dùm đi bạn...";
        }

        if (duocdangky == true)
        {
            string sql = "insert into NguoiDung values('" + lbTenDN.Text + "','" + txtMK.Text + "',N'" + lbHoten.Text + "',N'" + txtEmail.Text + "','True','False')";
            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();


            string kqthem="chúc mừng bạn đã là thành viên của trang web của chung tôi.";
            dvthongbao.InnerHtml = kqthem;
            //xoa control
            txtEmail.Text = "";

        }
        dvthongbao.Visible = true;
        //Response.Redirect("DKTC.aspx");
    }
}