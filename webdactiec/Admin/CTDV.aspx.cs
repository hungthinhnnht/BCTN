using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Admin_CTDV : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    private static DataTable dtCTDV;

    void loadCTDV()
    {
        string sql = "select CT.idChiTiet, DV.Tendichvu, CT.Hinhanh, CT.MoTa, CT.Trangthai, CT.Gia from CTDichvu CT, Dichvu DV where CT.iddichvu=DV.iddichvu";
        da = new SqlDataAdapter(sql, cnn);
        dtCTDV = new DataTable();
        cnn.Open();
        da.Fill(dtCTDV);
        cnn.Close();

        GrvCTDV.DataSource = dtCTDV;
        GrvCTDV.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadCTDV();
    }


    protected void GrvCTDV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvCTDV.PageIndex = e.NewPageIndex;
        GrvCTDV.DataSource = dtCTDV;
        GrvCTDV.DataBind();
    }
}