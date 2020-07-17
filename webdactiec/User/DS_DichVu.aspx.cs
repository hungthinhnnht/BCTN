using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_DS_DichVu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtDichVu,dtloaidv;

    void loadDichVu()
    {
        string sql = "select * from Dichvu where Trangthai = 'True' and idloai='"+Request.QueryString["id"]+"'";
        da = new SqlDataAdapter(sql, cnn);
        dtDichVu = new DataTable();
        cnn.Open();
        da.Fill(dtDichVu);
        cnn.Close();               

        dtlDichVu.DataSource = dtDichVu;
        dtlDichVu.DataBind();
                
    }
    void loadLoaiDV()
    {
        string sql = "select * from loaiDichVu where idLoai='"+Request.QueryString["id"]+"' ";
        da = new SqlDataAdapter(sql, cnn);
        dtloaidv = new DataTable();
        cnn.Open();
        da.Fill(dtloaidv);
        cnn.Close();
        if (dtloaidv.Rows.Count > 0)
        {
            lbTenDV.Text = dtloaidv.Rows[0]["Tenloai"].ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            loadLoaiDV();
            loadDichVu();
        }
    }
}