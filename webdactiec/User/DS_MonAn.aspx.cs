using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_DS_MonAn : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtLoaiMon, dtMonAn;

    /* day la 1 loai mon cu the, trong ruot cua loai mon nay, chua danh sach cac mon an thuoc loai do
     * <li class="odd">
								<h2>a place holder</h2>
								<ul>
									<li>
										<h2><a href="food.html">This is just a place holder</a></h2>
										<span>$00.00</span>
										<p>
											You can replace all this text with your own text. 
										</p>
									</li>
									<li>
										<h2><a href="food.html">This is just a place holder</a></h2>
										<span>$00.00</span>
										<p>
											You can replace all this text with your own text.
										</p>
									</li>
									<li>
										<h2><a href="food.html">This is just a place holder</a></h2>
										<span>$00.00</span>
										<p>
											You can replace all this text with your own text.
										</p>
									</li>
									<li>
										<h2><a href="food.html">This is just a place holder</a></h2>
										<span>$00.00</span>
										<p>
											You can replace all this text with your own text.
										</p>
									</li>
									<li class="last">
										<h2><a href="food.html">This is just a place holder</a></h2>
										<span>$00.00</span>
										<p>
											You can replace all this text with your own text.
										</p>
									</li>
								</ul>
							</li>*/

    void loadLoaiMon()
    {
        string sql = "select * from LoaiMon where Trangthai='True'and idLoaiMon='" + Request.QueryString["id"] + "' ";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiMon = new DataTable();
        cnn.Open();
        da.Fill(dtLoaiMon);
        cnn.Close();

        if (dtLoaiMon.Rows.Count > 0)
        {
            lbLoaiMon.Text = dtLoaiMon.Rows[0]["Tenloai"].ToString();
        }
        
    }
    void loadMonAn()
    {
        string sql = "select * from MonAn where Trangthai='True' and idLoaiMon='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

        phantrang.DataSource = dtMonAn.DefaultView;
        phantrang.BindToControl = dtlMonAn;

        dtlMonAn.DataSource = phantrang.DataSourcePaged;
        dtlMonAn.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            loadLoaiMon();
            loadMonAn();
        }
       
    }
}