using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_QL_Menu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    hamdungchung ham = new hamdungchung();
    DataTable dtMenu;

    void loadthongtincapnhat()
    {
        string sql = "select * from Menusan where Masomenu='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(sql,cnn);
        dtMenu = new DataTable();

        cnn.Open();
        da.Fill(dtMenu);
        cnn.Close();

        if (dtMenu.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtTengoi.Text = dtMenu.Rows[0]["Tengoi"].ToString();
            txtGia.Text = dtMenu.Rows[0]["Gia"].ToString();

            chkTrangThai.Checked = bool.Parse(dtMenu.Rows[0]["Trangthai"].ToString());
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
        string Menu = ham.PhatSinhMaTuDong("Menusan", "Masomenu", "MN", 7);
        string sql="insert into Menusan values('"+Menu+"',N'"+txtTengoi.Text+"','"+txtGia.Text+"','"+chkTrangThai.Checked.ToString()+"')";
        cmd=new SqlCommand(sql,cnn);

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("MenuSan.aspx");


    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update Menusan set Tengoi=N'" + txtTengoi.Text + "', Gia='" + txtGia.Text + "', Trangthai='" + chkTrangThai.Checked.ToString() + "'";
        sql += "where masomenu='" + lbid.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("MenuSan.aspx");

    }
}