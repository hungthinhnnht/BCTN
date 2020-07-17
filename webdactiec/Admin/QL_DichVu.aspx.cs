using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_DichVu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    hamdungchung ham = new hamdungchung();
    DataTable dtloaidichvu,dtDichVu;

     void loadLoaidichvu()
     {
         string sql = "select * from loaiDichVu";
         da = new SqlDataAdapter(sql, cnn);
         dtloaidichvu = new DataTable();
         cnn.Open();
         da.Fill(dtloaidichvu);
         cnn.Close();
         DrlLoaiDV.DataSource = dtloaidichvu;
         DrlLoaiDV.DataTextField = "Tenloai";
         DrlLoaiDV.DataValueField = "idloai";
         DrlLoaiDV.DataBind();


     }
     void loadthongtincapnhat()
     {
         string Sql = " select * from Dichvu where iddichvu='" + Request.QueryString["id"] + "'";
         da = new SqlDataAdapter(Sql, cnn);
         dtDichVu = new DataTable();
         cnn.Open();
         da.Fill(dtDichVu);
         cnn.Close();

         if (dtDichVu.Rows.Count > 0)
         {
             lbid.Text = Request.QueryString["id"];
             txtTen.Text = dtDichVu.Rows[0]["Tendichvu"].ToString();
             DrlLoaiDV.SelectedValue=dtDichVu.Rows[0].ToString();
             txtGia.Text = dtDichVu.Rows[0]["Gia"].ToString();
             txtMota.Text = dtDichVu.Rows[0]["MoTa"].ToString();

             chkTrangThai.Checked = bool.Parse(dtDichVu.Rows[0]["TrangThai"].ToString());
             //chkBB.Checked = bool.Parse(dtDichVu.Rows[0]["BatBuoc"].ToString());
         }
     }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loadLoaidichvu();
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
        string DichVu = ham.PhatSinhMaTuDong("Dichvu", "iddichvu", "DV", 5);
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/hinhdichvu/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
        }
        string sql = "insert into Dichvu values('" + DichVu + "',N'" + txtTen.Text + "','"+DrlLoaiDV.SelectedValue+"',N'"+FupHinh.FileName+"',"+txtGia.Text+",N'"+txtMota.Text+"','" + chkTrangThai.Checked.ToString() + "','"+chkBB.Checked.ToString()+"')";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();


        Response.Redirect("DichVu.aspx");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update Dichvu set Tendichvu=N'" + txtTen.Text + "',idloai='" + DrlLoaiDV.SelectedValue + "',Gia=N'"+txtGia.Text+"',Mota=N'"+txtMota.Text+"',TrangThai='"+chkTrangThai.Checked.ToString()+"', BatBuoc='"+chkBB.Checked.ToString()+"'";
        if (FupHinh.FileName != "")
        {
            string tenfilehinh = Server.MapPath("~/Hinh/hinhdichvu/" + FupHinh.FileName);
            FupHinh.PostedFile.SaveAs(tenfilehinh);
            sql += ", Hinhanh=N'" + FupHinh.FileName + "'";
        }
        sql += "where iddichvu='" + lbid.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("DichVu.aspx");
    }

}