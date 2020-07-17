using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Admin_TinTuc : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

   private static DataTable dtTinTuc;

    void loadTinTuc()
    {
        string sql = "select * from TinTuc";
        da = new SqlDataAdapter(sql, cnn);
        dtTinTuc = new DataTable();
        cnn.Open();
        da.Fill(dtTinTuc);
        cnn.Close();

        GrvTinTuc.DataSource = dtTinTuc;
        GrvTinTuc.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
       loadTinTuc();
    }
    protected void GrvTinTuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvTinTuc.PageIndex = e.NewPageIndex;
        GrvTinTuc.DataSource = dtTinTuc;
        GrvTinTuc.DataBind();
    }
}