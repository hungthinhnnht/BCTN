using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_LoaiMA : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtLoaiMA;

    void LoadLoaiMon()
    {
        string sql = "select * from LoaiMon where Trangthai='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiMA = new DataTable();

        cnn.Open();
        da.Fill(dtLoaiMA);
        cnn.Close();

        dtlLoaiMon.DataSource = dtLoaiMA;
        dtlLoaiMon.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadLoaiMon();
    }
}