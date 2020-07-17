using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_DS_CTMA : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtCTMA;
    hamdungchung ham = new hamdungchung();

    void LoadCTMA()
    {
        string sql = "select * from MonAn where idmonan='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtCTMA = new DataTable();

        cnn.Open();
        da.Fill(dtCTMA);
        cnn.Close();

        if (dtCTMA.Rows.Count > 0)
        {
            lbTenMon.Text = dtCTMA.Rows[0]["Tenmon"].ToString();
            lbMoTa.Text = dtCTMA.Rows[0]["Mota"].ToString();
            lbGia.Text = "Giá:" + ham.chuyenDoiDinhDangTien(dtCTMA.Rows[0]["Gia"].ToString(), ",") + " VNĐ";
            imgHinh.ImageUrl = "~/Hinh/HinhMonAn/" + dtCTMA.Rows[0]["Hinhanh"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            LoadCTMA();
        }
    }
}