using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_MenuSan : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    private static DataTable dtMenu, dtDS, dtct, dtChon, dtMN;
    hamdungchung ham = new hamdungchung();

    private static string masomenuchon = "";

    void LoadMenu()
    {
        string sql = "select * from Menusan";
        da = new SqlDataAdapter(sql, cnn);
        dtMenu = new DataTable();

        cnn.Open();
        da.Fill(dtMenu);
        cnn.Close();

        GrvMenu.DataSource = dtMenu;
        GrvMenu.DataBind();
        
    }

   /* void LoadMN()
    {
        string sql = "select * from Menusan where Masomenu='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtMenu = new DataTable();

        cnn.Open();
        da.Fill(dtMenu);
        cnn.Close();

        if (dtMenu.Rows.Count > 0)
        {
            lbMasomenu.Text = dtMenu.Rows[0]["Masomenu"].ToString();
            lbTengoi.Text = dtMenu.Rows[0]["Tengoi"].ToString();
            lbGia.Text = ham.chuyenDoiDinhDangTien (dtMenu.Rows[0]["Gia"].ToString(),",");
            lbTrangthai.Text = dtMenu.Rows[0]["Trangthai"].ToString();
        }
    }*/

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMenu();
            LoadDSMA("");
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Xem")
        {
            string Masomenu = e.CommandArgument.ToString();
            masomenuchon = Masomenu;
            string sql = "select * from Menusan where Masomenu='"+Masomenu+"'";
            da = new SqlDataAdapter(sql, cnn);
            dtct = new DataTable();
            cnn.Open();
            da.Fill(dtct);
            cnn.Close();

            if (dtct.Rows.Count > 0)
            {
                lbGia.Text ="Giá:" +ham.chuyenDoiDinhDangTien (dtct.Rows[0]["Gia"].ToString(),",")+" VNĐ";
                lbMasomenu.Text = dtct.Rows[0]["Masomenu"].ToString();
                lbTengoi.Text = dtct.Rows[0]["Tengoi"].ToString();
                //lbTrangthai.Text = dtMenu.Rows[0]["Trangthai"].ToString();

                sql = "select MA.idmonan, MA.Tenmon, MA.Hinhanh from CTMenu CT, MonAn MA Where CT.idmonan = MA.idmonan and CT.Masomenu='"+Masomenu+"'";
                da = new SqlDataAdapter(sql, cnn);
                dtMN = new DataTable();
                cnn.Open();
                da.Fill(dtMN);
                cnn.Close();

                GrvCTMenu.DataSource = dtMN;
                GrvCTMenu.DataBind();

            }

            dvCTmenu.Visible = true;

        }
    }
    void LoadDSMA(string mamenu)
    {
        //string sql = "select ma.idmonan, lm.Tenloai, ma.Tenmon, ma.Hinhanh, ma.Gia from MonAn ma, LoaiMon lm where ma.idloaimon=lm.idloaimon";
        string sql = " select m.idmonan, m.Tenmon, m.Hinhanh, m.Gia, lm.Tenloai from MonAn m, LoaiMon lm where m.idloaimon=lm.idloaimon and m.idmonan not in (select ct.idmonan from CTMenu ct where ct.Masomenu='"+mamenu+"')";
        da = new SqlDataAdapter(sql, cnn);
        dtDS = new DataTable();
        
        cnn.Open();
        da.Fill(dtDS);
        cnn.Close();

        GrvDSMA.DataSource = dtDS;
        GrvDSMA.DataBind();

 
    }
    protected void GrvDSMA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Chon" && lbMasomenu.Text!="")
        {
            string idmonan = e.CommandArgument.ToString();
            string sql = "insert into CTMenu values('"+masomenuchon+"','"+idmonan+"') ";

            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            GrvCTMenu.DataSource = dtChon;
            GrvCTMenu.DataBind();

        }
    }
    protected void lbtnDoi_Click(object sender, EventArgs e)
    {
        dvDSMonAn.Visible = true;
    }
    protected void GrvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Doi")
        {
            string Mamenu = e.CommandArgument.ToString();
            lbMasomenu.Text = Mamenu;
            masomenuchon = Mamenu;
            dvDSMonAn.Visible = true;
        }
        if (e.CommandName == "Xem")
        {
            string Masomenu = e.CommandArgument.ToString();
            masomenuchon = Masomenu;
            string sql = "select * from Menusan where Masomenu='" + Masomenu + "'";
            da = new SqlDataAdapter(sql, cnn);
            dtct = new DataTable();
            cnn.Open();
            da.Fill(dtct);
            cnn.Close();

            if (dtct.Rows.Count > 0)
            {
                lbGia.Text = "Giá: "+ ham.chuyenDoiDinhDangTien(dtct.Rows[0]["Gia"].ToString(), ",")+" VNĐ";
                lbMasomenu.Text = dtct.Rows[0]["Masomenu"].ToString();
                lbTengoi.Text = dtct.Rows[0]["Tengoi"].ToString();
                //lbTrangthai.Text = dtMenu.Rows[0]["Trangthai"].ToString();

                sql = "select MA.idmonan, MA.Tenmon, MA.Hinhanh from CTMenu CT, MonAn MA Where CT.idmonan = MA.idmonan and CT.Masomenu='" + Masomenu + "'";
                da = new SqlDataAdapter(sql, cnn);
                dtMN = new DataTable();
                cnn.Open();
                da.Fill(dtMN);
                cnn.Close();

                GrvCTMenu.DataSource = dtMN;
                GrvCTMenu.DataBind();


                LoadDSMA(lbMasomenu.Text);
            }

            dvCTmenu.Visible = true;

        }
    }
}