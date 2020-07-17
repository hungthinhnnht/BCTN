using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QuangCao : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    DataTable dtQuangCao;

    void loadQuangCao()
    {
        string sql = "select * from QuangCao";
        da = new SqlDataAdapter(sql, cnn);
        dtQuangCao = new DataTable();
        cnn.Open();
        da.Fill(dtQuangCao);
        cnn.Close();

        GrvQuangCao.DataSource = dtQuangCao;
        GrvQuangCao.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadQuangCao();
    }
}