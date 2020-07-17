using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_LoaiMon : System.Web.UI.Page
{

    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    private static DataTable dtLoaiMon;

    void loadLoaiMon()
    {
        string sql = "select * from LoaiMon";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiMon = new DataTable();
        cnn.Open();
        da.Fill(dtLoaiMon);
        cnn.Close();

        GrvLoaiMon.DataSource = dtLoaiMon;
        GrvLoaiMon.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadLoaiMon();
    }
    protected void GrvLoaiMon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvLoaiMon.PageIndex = e.NewPageIndex;
        GrvLoaiMon.DataSource = dtLoaiMon;
        GrvLoaiMon.DataBind();
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string sql= "select * from LoaiMon where Tenloai like N'%"+txtTenLoai.Text+"%'";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiMon = new DataTable();

        cnn.Open();
        da.Fill(dtLoaiMon);
        cnn.Close();

        GrvLoaiMon.DataSource = dtLoaiMon;
        GrvLoaiMon.DataBind();


    }
    protected void Them_Click(object sender, EventArgs e)
    {

    }
}