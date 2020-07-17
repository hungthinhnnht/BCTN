using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_DatTiec : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    DataTable dtDatTiec;

    void loadDatTiec()
    {
        string sql = "select * from DatTiec";
        da = new SqlDataAdapter(sql, cnn);
        dtDatTiec = new DataTable();
        cnn.Open();
        da.Fill(dtDatTiec);
        cnn.Close();

        GrvDatTiec.DataSource = dtDatTiec;
        GrvDatTiec.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadDatTiec();
    }

    protected void GrvDatTiec_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDatTiec.PageIndex = e.NewPageIndex;
        GrvDatTiec.DataSource = dtDatTiec;
        GrvDatTiec.DataBind();
    }
}