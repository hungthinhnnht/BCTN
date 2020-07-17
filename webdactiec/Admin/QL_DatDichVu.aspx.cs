using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_DatDichVu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dtDatDichVu;
    DataTable dtDichVu;
    DataTable dttest;
    hamdungchung ham = new hamdungchung();

    void loadthongtincapnhat()
    {
        string Sql = " select a.* ,b.Gia,b.Tendichvu from DatSanh a left join Dichvu b on a.IdDichVu = b.iddichvu where IdDatSanh='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtDatDichVu = new DataTable();
        cnn.Open();
        da.Fill(dtDatDichVu);
        cnn.Close();

        if (dtDatDichVu.Rows.Count > 0)
        {
            //lbid.Text = Request.QueryString["id"];
            txtIdDatDichVu.Text = dtDatDichVu.Rows[0]["IdDatSanh"].ToString();
            txtNgayToChuc.Text = dtDatDichVu.Rows[0]["NgayToChuc"].ToString();
            txtTGTC.Text = dtDatDichVu.Rows[0]["ThoiGianToChuc"].ToString();
            txtGiaSanPham.Text = dtDatDichVu.Rows[0]["Gia"].ToString();
            //txtIdMon.Text = dtDatMon.Rows[0]["IdMon"].ToString();
            txtDiaChi.Text = dtDatDichVu.Rows[0]["DiaChi"].ToString();
            txtTenDichVu.Text = dtDatDichVu.Rows[0]["Tendichvu"].ToString();
           // txtSoLuong.Text = dtDatMon.Rows[0]["SoLuong"].ToString();
           // txtThanhTien.Text = dtDatMon.Rows[0]["ThanhTien"].ToString();
        
        }
    }
    void loadDichVu()
    {
        string sql = "select * from Dichvu "; //order by idmonan = 'MA0003' desc ,idmonan asc
        da = new SqlDataAdapter(sql, cnn);
        dtDichVu = new DataTable();
        cnn.Open();
        da.Fill(dtDichVu);
        cnn.Close();


        DrlDV.DataSource = dtDichVu;
        DrlDV.DataTextField = "Tendichvu";
        DrlDV.DataValueField = "iddichvu";
        //DrlMA.SelectedValue = dtMonAn.Rows[0]["MA0003"].ToString();
        DrlDV.DataBind();


    }
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                //btnCapNhat.Visible = true;
                //btnThem.Visible = false;
                loadthongtincapnhat();
                 loadDichVu();

            }
            else
            {
                //btnThem.Visible = true;
               // btnCapNhat.Visible = false;


            }


        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string DatTiec = ham.PhatSinhMaTuDong("DatTiec", "iddattiec", "DT", 6);
    //    string sql = "insert into DatTiec values('" + DatTiec + "',N'" + txtHoTen.Text + "',N'" + txtNgayDat.Text + "',N'" + txtNgayDai.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSDT.Text + "',N'" + txtTongTien.Text + "','" + ChkTrangThai.Checked.ToString() + "')";
    //    cmd = new SqlCommand(sql, cnn);
    //    cnn.Open();
    //    cmd.ExecuteNonQuery();
    //    cnn.Close();

    //    Response.Redirect("DatTiec.aspx");
    //}
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update DatSanh  set NgayToChuc='" + txtNgayToChuc.Text + "',ThoiGianToChuc='" + txtTGTC.Text + "',IdDichVu='" + DrlDV.SelectedValue + "',DiaChi=N'" + txtDiaChi.Text + "'";

        sql += "where IdDatSanh='" + txtIdDatDichVu.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("DanhSachDatSanh.aspx");
    }
}