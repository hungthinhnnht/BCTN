using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_DanhSachDatMon : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dsDatMon;

    void loadDanhSachDatMon()
    {
        string sql = "select a.*,b.Tenmon, c.Hoten,c.Dienthoai from DatMon a left join MonAn b on a.IdMon = b.idmonan left join KhachHang c on a.MaKH = c.MaKH order by MaKH";
        da=new SqlDataAdapter(sql,cnn);
        dsDatMon = new DataTable();
        cnn.Open();
        da.Fill(dsDatMon);
        cnn.Close();
       
        GrvDanhSachDatMon.DataSource = dsDatMon;
        GrvDanhSachDatMon.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadDanhSachDatMon();
    }
    protected void GrvDanhSachDatMon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDanhSachDatMon.PageIndex = e.NewPageIndex;
        GrvDanhSachDatMon.DataSource = dsDatMon;
        GrvDanhSachDatMon.DataBind();
    }
}