using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_CTDatTiec : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dtCTDT, dtMonAn, dtDichVu;

    void loadThongTin()
    {
        lbid.Text = Request.QueryString["id"];
        string sql="select * from DatTiec where iddattiec='"+Request.QueryString["id"]+"'  ";
        da=new SqlDataAdapter(sql,cnn);
        dtCTDT=new DataTable();
        cnn.Open();
        da.Fill(dtCTDT);
        cnn.Close();

        if(dtCTDT.Rows.Count>0)
        {
            lbHoTen.Text=dtCTDT.Rows[0]["Hoten"].ToString();
            lbNgayDat.Text=dtCTDT.Rows[0]["NgayDat"].ToString();
            lbNgayDai.Text=dtCTDT.Rows[0]["Ngaydai"].ToString();
            lbDiaChi.Text=dtCTDT.Rows[0]["Diachi"].ToString();
            lbSDT.Text=dtCTDT.Rows[0]["Dienthoai"].ToString();
            lbTongTien.Text=dtCTDT.Rows[0]["Tongsotien"].ToString();

            lbTen.Text = dtCTDT.Rows[0]["Hoten"].ToString();
            lbNgay.Text = dtCTDT.Rows[0]["NgayDat"].ToString();
            lbDC.Text = dtCTDT.Rows[0]["Diachi"].ToString();
            lbDT.Text = dtCTDT.Rows[0]["Dienthoai"].ToString();
            lbTST.Text = dtCTDT.Rows[0]["Tongsotien"].ToString();

        }

    }

    void loadMonAn()
    {
        string sql="select MA.Tenmon, MA.Hinhanh, CT.*, (CT.Gia*CT.SoLuong) as ThanhTien from CTDattiec CT, MonAn MA where CT.idmonan=MA.idmonan";
        da = new SqlDataAdapter(sql, cnn);
        dtMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

        GrvMonAn.DataSource = dtMonAn;
        GrvMonAn.DataBind();

    }

    void loadDichVu()
    {
        string sql = "select DV.Tendichvu, DV.Hinhanh, CT.*, (CT.Gia*CT.Soluong) as ThanhTien from CTDattiec CT, Dichvu DV where CT.iddichvu=DV.iddichvu";
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
            loadThongTin();
            loadMonAn();
            loadDichVu();
        }
    }

    protected void btnThayDoi_Click(object sender, EventArgs e)
    {
        string sql = "Update DatTiec set NgayDai='" + txtNgayDai.Text + "', Trangthai=N'" + DrlTrangthai.SelectedValue + "' where iddattiec='" + lbid.Text + "' ";

        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("DatTiec.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        CapNhat.Visible = true;
    }
}