using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Admin_QL_CTDV : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    hamdungchung ham = new hamdungchung();
    DataTable dtCTDV, dtDV;

    void loadCTDV()
    {
        string sql = "select * from Dichvu";
        da = new SqlDataAdapter(sql, cnn);
        dtCTDV = new DataTable();
        cnn.Open();
        da.Fill(dtCTDV);
        cnn.Close();
        cnn.Close();
        DrlIDdv.DataSource = dtCTDV;
        DrlIDdv.DataTextField = "Tendichvu";
        DrlIDdv.DataValueField = "iddichvu";
        DrlIDdv.DataBind();
    }
    void loadthongtincapnhat()
    {
        string Sql = " select * from CTDichvu where idChiTiet='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtDV = new DataTable();
        cnn.Open();
        da.Fill(dtDV);
        cnn.Close();

        if (dtDV.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            DrlIDdv.SelectedValue = dtDV.Rows[0]["iddichvu"].ToString();
            txtMota.Text = dtDV.Rows[0]["MoTa"].ToString();
            txtGia.Text = dtDV.Rows[0]["Gia"].ToString();

            chkTrangThai.Checked = bool.Parse(dtDV.Rows[0]["Trangthai"].ToString());

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCTDV();
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
        string chitietdichvu = ham.PhatSinhMaTuDong("CTDichvu", "idChiTiet", "CTDV", 9);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/HinhCTDV/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into CTDichvu values('" + chitietdichvu + "','" + DrlIDdv.SelectedValue + "',N'" + FupHinh.FileName + "',N'" + txtMota.Text + "','" + chkTrangThai.Checked.ToString() + "',N'" + txtGia.Text + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
        Response.Redirect("CTDV.aspx");
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update CTDichvu set iddichvu='" + DrlIDdv.SelectedValue + "', MoTa=N'"+txtMota.Text+"',Trangthai='"+chkTrangThai.Checked.ToString()+"',Gia='"+txtGia.Text+"'";
        {
            string tenfilehinh = Server.MapPath("~/Hinh/HinhCTDV/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ", Hinhanh=N'" + FupHinh.FileName + "'";
        }
        sql += "where idChiTiet='" + lbid.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("CTDV.aspx");
    }
}