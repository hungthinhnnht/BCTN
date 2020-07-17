using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_CTUser : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dtCTDT, dtMonAn, dtDichVu;

    void loadThongTin()
    {
        
        string sql = "select * from DatTiec where iddattiec = '"+Request.QueryString["id"]+"'";
        da = new SqlDataAdapter(sql, cnn);
        dtCTDT = new DataTable();
        cnn.Open();
        da.Fill(dtCTDT);
        cnn.Close();

        if (dtCTDT.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            lbHoTen.Text = dtCTDT.Rows[0]["Hoten"].ToString();
            lbNgayDat.Text = dtCTDT.Rows[0]["NgayDat"].ToString();
            lbNgayDai.Text = dtCTDT.Rows[0]["Ngaydai"].ToString();
            lbSLB.Text = dtCTDT.Rows[0]["Soluongban"].ToString();
            lbTGD.Text = dtCTDT.Rows[0]["TGD"].ToString();
            lbDiaChi.Text = dtCTDT.Rows[0]["Diachi"].ToString();
            lbSDT.Text = dtCTDT.Rows[0]["Dienthoai"].ToString();
            lbTongsotien.Text = dtCTDT.Rows[0]["Tongsotien"].ToString();
                                    
        }

    }
    void loadMonAn()
    {
        string sql = "select MA.Tenmon, MA.Hinhanh, CT.*, (CT.Gia*CT.SoLuong) as ThanhTien from CTDattiec CT, MonAn MA where CT.idmonan=MA.idmonan and ct.iddattiec='"+Request.QueryString["id"]+"'";
        //string sql = "select * from Dattiec where Tendangnhap ='"+Session["Tendangnhap"].ToString()+"' ";
        da = new SqlDataAdapter(sql, cnn);
        dtMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

        GrvMA.DataSource = dtMonAn;
        GrvMA.DataBind();
    }
        

    void loadDichVu()
    {
        string sql = "select DV.Tendichvu, DV.Hinhanh, CT.*, (CT.Gia*CT.Soluong) as ThanhTien from CTDattiec CT, Dichvu DV where CT.iddichvu=DV.iddichvu and ct.iddattiec='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtDichVu = new DataTable();
        cnn.Open();
        da.Fill(dtDichVu);
        cnn.Close();

        GrvDV.DataSource = dtDichVu;
        GrvDV.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Tendangnhap"] != null)
            {
                loadThongTin();
                loadMonAn();
                loadDichVu(); 
            }
            
        }
    }
}