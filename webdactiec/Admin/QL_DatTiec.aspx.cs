using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_DatTiec : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dtDatTiec;
    hamdungchung ham = new hamdungchung();

    void loadthongtincapnhat()
    {
        string Sql = " select * from DatTiec where iddattiec='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtDatTiec = new DataTable();
        cnn.Open();
        da.Fill(dtDatTiec);
        cnn.Close();

        if (dtDatTiec.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtHoTen.Text = dtDatTiec.Rows[0]["Hoten"].ToString();
            txtNgayDat.Text = DateTime.Parse(dtDatTiec.Rows[0]["Ngaydat"].ToString()).ToShortDateString();
            txtNgayDai.Text = DateTime.Parse(dtDatTiec.Rows[0]["Ngaydai"].ToString()).ToShortDateString();
            txtDiaChi.Text = dtDatTiec.Rows[0]["Diachi"].ToString();
            txtSDT.Text = dtDatTiec.Rows[0]["Dienthoai"].ToString();
            txtTongTien.Text = dtDatTiec.Rows[0]["Tongsotien"].ToString();

            ChkTrangThai.Checked = bool.Parse(dtDatTiec.Rows[0]["Trangthai"].ToString());

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        string DatTiec = ham.PhatSinhMaTuDong("DatTiec", "iddattiec", "DT", 6);
        string sql = "insert into DatTiec values('" + DatTiec + "',N'" + txtHoTen.Text + "',N'" + txtNgayDat.Text + "',N'" + txtNgayDai.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSDT.Text + "',N'" + txtTongTien.Text + "','" + ChkTrangThai.Checked.ToString() + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("DatTiec.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {

    }
}