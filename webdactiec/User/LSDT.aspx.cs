using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_LSDT : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtKH;

    void loadKH()
    {
        string sql = " select * from DatTiec where Tendangnhap ='" + Session["Tendangnhap"].ToString() + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtKH = new DataTable();

        cnn.Open();
        da.Fill(dtKH);
        cnn.Close();

        if (dtKH.Rows.Count > 0)
        {
            lbHoten.Text = dtKH.Rows[0]["Hoten"].ToString();
            lbDC.Text = dtKH.Rows[0]["Diachi"].ToString();
            lbSDT.Text = dtKH.Rows[0]["Dienthoai"].ToString();
            lbTenDN.Text = dtKH.Rows[0]["Tendangnhap"].ToString();
                
        }

        GrvKH.DataSource = dtKH;
        GrvKH.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        loadKH();
    }
}