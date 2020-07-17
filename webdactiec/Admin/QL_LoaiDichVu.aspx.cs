using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_QL_LoaiDichVu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dtloaidichvu;
    hamdungchung ham = new hamdungchung();

    void loadthongtincapnhat()
    {
        string Sql = " select * from loaiDichVu where idloai='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtloaidichvu = new DataTable();
        cnn.Open();
        da.Fill(dtloaidichvu);
        cnn.Close();

        if (dtloaidichvu.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtTen.Text = dtloaidichvu.Rows[0]["Tenloai"].ToString();
            chkTrangThai.Checked = bool.Parse(dtloaidichvu.Rows[0]["Trangthai"].ToString());

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
        string loaidichvu = ham.PhatSinhMaTuDong("LoaiDichVu", "idloai", "LDV", 6);

        string sql = "insert into LoaiDichVu values('"+loaidichvu+"',N'"+txtTen.Text+"','"+chkTrangThai.Checked.ToString()+"')";
        cmd=new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();


        Response.Redirect("LoaiDV.aspx");



    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update loaiDichVu set Tenloai=N'" + txtTen.Text + "',TrangThai='" + chkTrangThai.Checked.ToString() + "'";
        sql += "where idloai='" + lbid.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();


        Response.Redirect("LoaiDV.aspx");
    }
}