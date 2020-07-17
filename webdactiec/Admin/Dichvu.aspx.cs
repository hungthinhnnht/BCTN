using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_Dichvu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    private static DataTable dtdichvu;

    void loaddichvu()
    {
        string sql = "select dv.iddichvu, dv.Tendichvu, ldv.Tenloai, dv.Hinhanh, dv.Gia, dv.Mota, dv.Trangthai from Dichvu dv, loaiDichVu ldv where dv.idloai=ldv.idloai";
        da = new SqlDataAdapter(sql, cnn);
        dtdichvu = new DataTable();
        cnn.Open();
        da.Fill(dtdichvu);
        cnn.Close();

        GrvDichVu.DataSource = dtdichvu;
        GrvDichVu.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loaddichvu();
    }
    protected void GrvDichVu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDichVu.PageIndex = e.NewPageIndex;
        GrvDichVu.DataSource = dtdichvu;
        GrvDichVu.DataBind();
    }
    
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string sql = "select dv.iddichvu, dv.Tendichvu, ldv.Tenloai, dv.Hinhanh, dv.Gia, dv.Mota, dv.Trangthai from Dichvu dv, loaiDichVu ldv where dv.idloai=ldv.idloai and dv.Tendichvu like N'%" + txtDichVu.Text + "%'";
        da = new SqlDataAdapter(sql, cnn);
        dtdichvu= new DataTable();

        cnn.Open();
        da.Fill(dtdichvu);
        cnn.Close();

        GrvDichVu.DataSource = dtdichvu;
        GrvDichVu.DataBind();

    }
}