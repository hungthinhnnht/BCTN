using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_DanhSachDatSanh : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dsDatSanh;

    void loadDanhSachDatSanh()
    {
        string sql = "select a.* , b.Tendichvu , c.Hoten,c.Dienthoai  from DatSanh a inner join Dichvu b on a.IdDichVu = b.iddichvu left join KhachHang c on a.MaKH = c.MaKH  order by MaKH";
        da=new SqlDataAdapter(sql,cnn);
        dsDatSanh = new DataTable();
        cnn.Open();
        da.Fill(dsDatSanh);
        cnn.Close();
       
        GrvDanhSachDatSanh.DataSource = dsDatSanh;
        GrvDanhSachDatSanh.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        loadDanhSachDatSanh();
    }
    protected void GrvDanhSachDatSanh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDanhSachDatSanh.PageIndex = e.NewPageIndex;
        GrvDanhSachDatSanh.DataSource = dsDatSanh;
        GrvDanhSachDatSanh.DataBind();
    }
}