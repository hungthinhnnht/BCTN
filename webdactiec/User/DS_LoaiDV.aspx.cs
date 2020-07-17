using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class User_DS_LoaiDV : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtLoaiDV;

    void loadLoaiDV()
    {
        string sql = "select * from loaiDichVu where TrangThai='True'";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiDV = new DataTable();
        cnn.Open();
        da.Fill(dtLoaiDV);
        cnn.Close();

        dtlLoaiDV.DataSource = dtLoaiDV;
        dtlLoaiDV.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadLoaiDV();
    }
}