using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Admin_LoaiDV : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

   private static DataTable dtloaidichvu;

    void loadLoaidichvu()
    {
        string sql = "select * from loaiDichVu";
        da = new SqlDataAdapter(sql, cnn);
        dtloaidichvu = new DataTable();
        cnn.Open();
        da.Fill(dtloaidichvu);
        cnn.Close();

        GrvLoaiDV.DataSource = dtloaidichvu;
        GrvLoaiDV.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadLoaidichvu();
    }
    protected void GrvLoaiDV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvLoaiDV.PageIndex = e.NewPageIndex;
        GrvLoaiDV.DataSource = dtloaidichvu;
        GrvLoaiDV.DataBind();

    }
}