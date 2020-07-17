using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_MonAn : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    private static DataTable dtMonAn;

    void loadMonAn()
    {
        string sql = "select ma.idmonan, lm.Tenloai, ma.Tenmon, ma.Hinhanh, ma.Gia, ma.Mota, ma.Trangthai from MonAn ma, LoaiMon lm where ma.idloaimon=lm.idloaimon";
        da = new SqlDataAdapter(sql, cnn);
        dtMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

        GrvMonAn.DataSource = dtMonAn;
        GrvMonAn.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadMonAn();
    }
    protected void GrvMonAn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvMonAn.PageIndex = e.NewPageIndex;
        GrvMonAn.DataSource = dtMonAn;
        GrvMonAn.DataBind();
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        String sql = "select ma.idmonan, lm.Tenloai, ma.Tenmon, ma.Hinhanh, ma.Gia, ma.Mota, ma.Trangthai from MonAn ma, LoaiMon lm where ma.idloaimon=lm.idloaimon and ma.Tenmon like N'%" + txtTenMon.Text + "%'";
        da = new SqlDataAdapter(sql,cnn);
        dtMonAn = new DataTable();

        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

        GrvMonAn.DataSource = dtMonAn;
        GrvMonAn.DataBind();


    }
}