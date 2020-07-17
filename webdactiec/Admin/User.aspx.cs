using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Admin_User : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;

    DataTable dtUser;

    void loadUser()
    {
        string sql = "select * from NguoiDung";
        da = new SqlDataAdapter(sql, cnn);
        dtUser = new DataTable();
        cnn.Open();
        da.Fill(dtUser);
        cnn.Close();

        GrvUser.DataSource = dtUser;
        GrvUser.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadUser();
    }
}