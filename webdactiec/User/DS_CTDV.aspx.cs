using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class User_DS_CTDV : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtDV, dtCTDV;
    hamdungchung ham = new hamdungchung();

    void loadDV()
    {
        string sql = "select * from Dichvu where iddichvu='" + Request.QueryString["id"] + "' ";
        da = new SqlDataAdapter(sql, cnn);
        dtDV = new DataTable();

        cnn.Open();
        da.Fill(dtDV);
        cnn.Close();

        if (dtDV.Rows.Count > 0)
        {
            lbTenDV.Text = dtDV.Rows[0]["Tendichvu"].ToString();
            lbMoTa.Text = dtDV.Rows[0]["MoTa"].ToString();
            lbGia.Text = "Giá:" + ham.chuyenDoiDinhDangTien(dtDV.Rows[0]["Gia"].ToString(),",") +" VNĐ";
            imgHinh.ImageUrl = "~/Hinh/hinhdichvu/"+dtDV.Rows[0]["Hinhanh"].ToString();

        }
        
    }
    void loadCTDV()
    {
        string sql = "select * from CTDichvu where iddichvu='" + Request.QueryString["id"] + "' and Trangthai='True'  ";
        da = new SqlDataAdapter(sql, cnn);
        dtCTDV = new DataTable();

        cnn.Open();
        da.Fill(dtCTDV);
        cnn.Close();

        dtlCTDV.DataSource = dtCTDV;
        dtlCTDV.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            loadDV();
            loadCTDV();
        }
        
    }
}