using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class User_NoiDungTT : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtNDTT;

    void LoadNDTT()
    {
        string sql = "select * from TinTuc where idtin='"+Request.QueryString["id"]+"' ";
        da = new SqlDataAdapter(sql,cnn);
        dtNDTT = new DataTable();

        cnn.Open();
        da.Fill(dtNDTT);
        cnn.Close();

        if (dtNDTT.Rows.Count > 0)
        {
            lbTieuDe.Text = dtNDTT.Rows[0]["Tieude"].ToString();
            lbTomTat.Text = dtNDTT.Rows[0]["Tomtat"].ToString();
            lbNoiDung.Text = dtNDTT.Rows[0]["Noidung"].ToString();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            LoadNDTT();
 
        }
        
    }
}