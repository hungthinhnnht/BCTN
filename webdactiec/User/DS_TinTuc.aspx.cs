using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class User_DS_TinTuc : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtTinTuc;

    void loadTinTuc()
    {
        string sql = "select * from TinTuc where Trangthai='true'";
        da = new SqlDataAdapter(sql, cnn);
        dtTinTuc = new DataTable();
        cnn.Open();
        da.Fill(dtTinTuc);
        cnn.Close();

        phantrang.DataSource = dtTinTuc.DefaultView;
        phantrang.BindToControl = dtlTinTuc;

        dtlTinTuc.DataSource = phantrang.DataSourcePaged;
        dtlTinTuc.DataBind();



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        loadTinTuc();

    }
}