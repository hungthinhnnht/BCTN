using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_CTDatTiec : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    hamdungchung ham = new hamdungchung();
    DataTable dtDatTiec, dtMonAn, dtDichVu, dtCTDT;

    void loadCTDatTiec()
    {
        string sql = "select * from DatTiec";
         da = new SqlDataAdapter(sql, cnn);
         dtDatTiec = new DataTable();
         cnn.Open();
         da.Fill(dtDatTiec);
         cnn.Close();
         DrlDatTiec.DataSource = dtDatTiec;
         DrlDatTiec.DataTextField = "Hoten";
         DrlDatTiec.DataValueField = "iddattiec";
         DrlDatTiec.DataBind();

         sql = "select * from MonAn";
         da = new SqlDataAdapter(sql, cnn);
         dtMonAn = new DataTable();
         cnn.Open();
         da.Fill(dtMonAn);
         cnn.Close();
         DrlMonAn.DataSource = dtMonAn;
         DrlMonAn.DataTextField = "Tenmon";
         DrlMonAn.DataValueField = "idmonan";
         DrlMonAn.DataBind();

         sql = "select * from Dichvu";
         da = new SqlDataAdapter(sql, cnn);
         dtDichVu = new DataTable();
         cnn.Open();
         da.Fill(dtDichVu);
         cnn.Close();
         DrlDichVu.DataSource = dtDichVu;
         DrlDichVu.DataTextField = "Tendichvu";
         DrlDichVu.DataValueField = "iddichvu";
         DrlDichVu.DataBind();
    }

    void loadthongtincapnhat()
    {
        string Sql = " select * from CTDatTiec where idct='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtCTDT = new DataTable();
        cnn.Open();
        da.Fill(dtCTDT);
        cnn.Close();

        if (dtCTDT.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            DrlDatTiec.SelectedValue = dtCTDT.Rows[0].ToString();
            DrlMonAn.SelectedValue = dtCTDT.Rows[0].ToString();
            DrlDichVu.SelectedValue = dtCTDT.Rows[0].ToString();
            txtGia.Text = dtCTDT.Rows[0]["Gia"].ToString();
            txtSoLuong.Text = dtCTDT.Rows[0]["Soluong"].ToString();

           
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loadCTDatTiec();
            if (Request.QueryString["id"] != null)
            {
                btnCapNhat.Visible = true;
                btnThem.Visible = false;
                loadthongtincapnhat();


            }
            else
            {
                btnThem.Visible = true;
                btnCapNhat.Visible = false;


            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string idChiTiec = ham.PhatSinhMaTuDong("CTDatTiec", "idct", "CTDT", 6);

        string sql = "insert into CTDatTiec values('" + idChiTiec + "','" + DrlDatTiec.SelectedValue + "','" + DrlMonAn.SelectedValue + "','" + DrlDichVu.SelectedValue + "',N'" + txtSoLuong.Text + "',N'" + txtGia.Text + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("CTDatTiec.aspx");
    }
}