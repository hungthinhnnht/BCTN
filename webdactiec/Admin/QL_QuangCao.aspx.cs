using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class Admin_QL_QuangCao : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    hamdungchung ham = new hamdungchung();
    DataTable dtQuangCao;

    void loadthongtincapnhat()
    {
        string Sql = " select * from QuangCao where idqc='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtQuangCao = new DataTable();
        cnn.Open();
        da.Fill(dtQuangCao);
        cnn.Close();

        if (dtQuangCao.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtTenQC.Text = dtQuangCao.Rows[0]["Tenqc"].ToString();
            txtNBD.Text = DateTime.Parse(dtQuangCao.Rows[0]["Ngaybatdau"].ToString()).ToShortDateString();
            txtNKT.Text = DateTime.Parse(dtQuangCao.Rows[0]["Ngayketthuc"].ToString()).ToShortDateString();
            txtLink.Text = dtQuangCao.Rows[0]["Link"].ToString();
                        

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
        string maquangcao = ham.PhatSinhMaTuDong("QuangCao", "idqc", "QC", 5);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/QuangCao/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into QuangCao values('"+maquangcao+"',N'" + txtTenQC.Text+ "',N'"+txtNBD.Text+"',N'"+txtNKT.Text+"',N'"+FupHinh.FileName+ "',N'" + txtLink.Text + "')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("QuangCao.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update QuangCao set Tenqc=N'"+txtTenQC.Text+"',Ngaybatdau=N'"+txtNBD.Text+"',Ngayketthuc=N'"+txtNKT.Text+"',Link=N'"+txtLink.Text+"'";
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/QuangCao/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ",Hinh=N'"+FupHinh.FileName+"'";
        }
        sql += "where idqc='" + lbid.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("QuangCao.aspx");
    }
}