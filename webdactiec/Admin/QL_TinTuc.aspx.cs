using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_TinTuc : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    hamdungchung ham = new hamdungchung();
    DataTable dtTinTuc;

    void loadthongtincapnhat()
    {
        string Sql = " select * from TinTuc where idtin='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtTinTuc = new DataTable();
        cnn.Open();
        da.Fill(dtTinTuc);
        cnn.Close();

        if (dtTinTuc.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtTieuDe.Text = dtTinTuc.Rows[0]["Tieude"].ToString();
            txtNgayDang.Text = DateTime.Parse(dtTinTuc.Rows[0]["Ngaydang"].ToString()).ToShortDateString();
            edt.Content = dtTinTuc.Rows[0]["Noidung"].ToString();
            txtTomTat.Text = dtTinTuc.Rows[0]["Tomtat"].ToString();

            chkTrangThai.Checked = bool.Parse(dtTinTuc.Rows[0]["Trangthai"].ToString());
           


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
    protected void btnThem_Click(object sender, EventArgs e)
    {
        string matintuc = ham.PhatSinhMaTuDong("TinTuc", "idtin", "TT", 5);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/TinTuc/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into TinTuc values('" + matintuc + "',N'" + txtTieuDe.Text + "',N'" + txtNgayDang.Text + "',N'" + edt.Content+ "',N'" + FupHinh.FileName + "','" + chkTrangThai.Checked.ToString() + "',N'"+txtTomTat.Text+"')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("TinTuc.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "update TinTuc set Tieude=N'" + txtTieuDe.Text + "',Ngaydang=N'"+txtNgayDang.Text+"',NoiDung=N'"+edt.Content+"',Trangthai='"+chkTrangThai.Checked.ToString()+"',Tomtat=N'"+txtTomTat.Text+"'";
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/TinTuc/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ",Hinh='" + FupHinh.FileName + "'";
        }
        sql += " where idtin= '" + lbid.Text + "' ";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("TinTuc.aspx");

    }
}