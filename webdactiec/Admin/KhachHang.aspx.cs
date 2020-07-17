using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_KhachHang : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtKhachHang;

    void loadKhachHang()
    {
        string sql = " select * from KhachHang";
        da = new SqlDataAdapter(sql, cnn);
        dtKhachHang = new DataTable();

        cnn.Open();
        da.Fill(dtKhachHang);
        cnn.Close();

        GrvMaKH.DataSource = dtKhachHang;
        GrvMaKH.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        loadKhachHang();
    }
}