using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_QL_LoaiMon : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    hamdungchung ham = new hamdungchung();
    DataTable dtLoaiMon;

    void loadthongtincapnhat()
    {
        string Sql = " select * from LoaiMon where idloaimon='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtLoaiMon = new DataTable();
        cnn.Open();
        da.Fill(dtLoaiMon);
        cnn.Close();

        if (dtLoaiMon.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtTLMon.Text = dtLoaiMon.Rows[0]["Tenloai"].ToString();
           

            ChkTrangThai.Checked = bool.Parse(dtLoaiMon.Rows[0]["Trangthai"].ToString());

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
        string loaimon = ham.PhatSinhMaTuDong("LoaiMon", "idloaimon", "LM", 6);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/LoaiMon/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into LoaiMon values('" +loaimon + "',N'" + txtTLMon.Text + "',N'" + FupHinh.FileName + "','" + ChkTrangThai.Checked.ToString() + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();


        Response.Redirect("LoaiMon.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = " Update LoaiMon set TenLoai=N'" + txtTLMon.Text + "',TrangThai='" + ChkTrangThai.Checked.ToString() + "' ";
        if(FupHinh.FileName !="")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/LoaiMon/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ",Logo=N'" + FupHinh.FileName + "'";
        }
        sql+= "where idloaimon='"+lbid.Text+"'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("LoaiMon.aspx");
    }
}