using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


public partial class User_ChonDichVu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtLoaiDV, dtDichVu, dtChonDV, dtDV, dtCTDV;
    XuLyDatDV DichVu = new XuLyDatDV();

    static ArrayList listmonan, listdichvu;
    static ArrayList ds;

    void loadLoaiDV()
    {
        string sql = "select * from loaiDichVu where TrangThai='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiDV = new DataTable();

        cnn.Open();
        da.Fill(dtLoaiDV);
        cnn.Close();
        
        DrvLoaiDV.DataSource = dtLoaiDV;
        DrvLoaiDV.DataTextField = "Tenloai";
        DrvLoaiDV.DataValueField = "idloai";
        DrvLoaiDV.DataBind();

    }
    void loadDichVu(string idloai)
    {
        string sql = "select * from Dichvu where Trangthai='True'";
        if(idloai != "")
        {
            sql +=" and idloai='"+idloai+"'";
        }

        da = new SqlDataAdapter(sql, cnn);
        dtDichVu = new DataTable();

        cnn.Open();
        da.Fill(dtDichVu);
        cnn.Close();

        GrvDichVu.DataSource = dtDichVu;
        GrvDichVu.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadLoaiDV();
            loadDichVu("");
            listdichvu = new ArrayList();
        }
    }
    protected void DrvLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDichVu(DrvLoaiDV.SelectedValue);
    }
    protected void GrvDichVu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ChonDV")
        {
            string iddichvu = e.CommandArgument.ToString();
            loadChonDV(iddichvu);
            

        }
        if (e.CommandName == "Xem")
        {
            string iddichvu = e.CommandArgument.ToString();
            loadDV(iddichvu);
            loadCTDV(iddichvu);
            dvchitietdv.Visible = true;
        }
    }
    void loadChonDV(string iddichvu)
    {
        lbid.Text = iddichvu;
        string sql = "select * from Dichvu where iddichvu='"+iddichvu+"' ";
        da = new SqlDataAdapter(sql, cnn);
        dtChonDV = new DataTable();

        cnn.Open();
        da.Fill(dtChonDV);
        cnn.Close();

        if (dtChonDV.Rows.Count > 0)
        {
            lbTenDV.Text = dtChonDV.Rows[0]["Tendichvu"].ToString();
            lbGia.Text = dtChonDV.Rows[0]["Gia"].ToString();
            lbHinh.Text = dtChonDV.Rows[0]["Hinhanh"].ToString();

            
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        DichVu = new XuLyDatDV
        {
            iddichvu = lbid.Text,
            Tendichvu = lbTenDV.Text,
            Hinhanh = lbHinh.Text,
            Gia = decimal.Parse(lbGia.Text),            
            ThanhTien =decimal.Parse(lbGia.Text)
        };
        listdichvu = DichVu.ThemDichVu(listdichvu, DichVu);

        GrvDVChon.DataSource = listdichvu;
        GrvDVChon.DataBind();
        lbtongtien.Text = DichVu.TinhTongTienDV(listdichvu).ToString();
        
    }
    protected void GrvDVChon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Xoa")
        {
            listdichvu = DichVu.XoaDichVu(listdichvu, e.CommandArgument.ToString());
            Session["XuLyDichVu"] = listdichvu;
            loadChonDV(e.CommandArgument.ToString());

            GrvDVChon.DataSource = listdichvu;
            GrvDVChon.DataBind();
            lbtongtien.Text = DichVu.TinhTongTienDV(listdichvu).ToString();
            
        }
        if (e.CommandName == "Xem")
        {
            string iddichvu = e.CommandArgument.ToString();
            loadDV(iddichvu);
            loadCTDV(iddichvu);
            dvchitietdv.Visible = true;
        }
    }

    //public ArrayList ds { get; set; }
    protected void GrvDichVu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDichVu.PageIndex = e.NewPageIndex;
        GrvDichVu.DataSource = dtDichVu;
        GrvDichVu.DataBind();
    }
    void loadDV(string iddv)
    {
        string sql = "select * from Dichvu where iddichvu='" + iddv + "' ";
        da = new SqlDataAdapter(sql, cnn);
        dtDV = new DataTable();

        cnn.Open();
        da.Fill(dtDV);
        cnn.Close();

        if (dtDV.Rows.Count > 0)
        {
            lbTen.Text = dtDV.Rows[0]["Tendichvu"].ToString();
            lbmota.Text = dtDV.Rows[0]["MoTa"].ToString();
            lbGiaDV.Text = dtDV.Rows[0]["Gia"].ToString();          
        }        
    }
    void loadCTDV(string iddv)
    {
        string sql = "select * from CTDichvu where iddichvu='" + iddv + "' and Trangthai='True'  ";
        da = new SqlDataAdapter(sql, cnn);
        dtCTDV = new DataTable();

        cnn.Open();
        da.Fill(dtCTDV);
        cnn.Close();

        dtlCTDV.DataSource = dtCTDV;
        dtlCTDV.DataBind();
    }
}
