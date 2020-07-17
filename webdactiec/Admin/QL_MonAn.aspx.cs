using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_QL_MonAn : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    hamdungchung ham = new hamdungchung();
    DataTable dtMonAn, dtcnMonAn;

    void loadthongtincapnhat()
    {
        string Sql = " select * from MonAn where idmonan='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtcnMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtcnMonAn);
        cnn.Close();

        if (dtcnMonAn.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            DrlMonAn.SelectedValue = dtcnMonAn.Rows[0]["idloaimon"].ToString();
            txtTenMon.Text = dtcnMonAn.Rows[0]["Tenmon"].ToString();
            txtGia.Text = dtcnMonAn.Rows[0]["Gia"].ToString();
            txtMota.Text = dtcnMonAn.Rows[0]["MoTa"].ToString();

            ChkTrangThai.Checked = bool.Parse(dtcnMonAn.Rows[0]["Trangthai"].ToString());

        }
    }
      void loadMonAn()
      {
          string sql = "select * from LoaiMon";
          da = new SqlDataAdapter(sql, cnn);
          dtMonAn = new DataTable();
          cnn.Open();
          da.Fill(dtMonAn);
          cnn.Close();
          DrlMonAn.DataSource = dtMonAn;
          DrlMonAn.DataTextField = "Tenloai";
          DrlMonAn.DataValueField = "idloaimon";
          DrlMonAn.DataBind();
      }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loadMonAn();
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
        string MonAn = ham.PhatSinhMaTuDong("MonAn", "idmonan", "MA", 6);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/HinhMonAn/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into MonAn values('" + MonAn + "','" + DrlMonAn.SelectedValue+ "',N'" + txtTenMon.Text + "',N'" + FupHinh.FileName + "',N'" + txtGia.Text + "',N'" + txtMota.Text + "','" + ChkTrangThai.Checked.ToString() + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();


        Response.Redirect("MonAn.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update MonAn set idloaimon='" + DrlMonAn.SelectedValue + "',Tenmon=N'"+txtTenMon.Text+"',Gia=N'"+txtGia.Text+"',Mota=N'"+txtMota.Text+"',TrangThai='"+ChkTrangThai.Checked.ToString()+"' ";
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/HinhMonAn/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ",Hinhanh='" + FupHinh.FileName + "'";

        }
        sql += "where idmonan='" + lbid.Text + "' ";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("MonAn.aspx");
    }
}