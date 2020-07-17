using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class User_DS_DatTiec : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    SqlCommand cmd;
    DataTable dtLoaiMon, dtMonAn, dtMonChon, dtLoaiDV, dtDichVu, dtChonDV, dtDV, dtCTDV, dtmonansan, dtdvbb, dtChk;
    XuLyDatMon mon = new XuLyDatMon();
    XuLyDatDV DichVu = new XuLyDatDV();
    XuLyDatDV DVBatBuoc = new XuLyDatDV();
    hamdungchung ham = new hamdungchung();

    static ArrayList listmonan, listdichvu;
    static ArrayList ds;

    void loadLoaiMon()
    {
        string sql = "select * from LoaiMon where Trangthai='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiMon = new DataTable();

        cnn.Open();
        da.Fill(dtLoaiMon);
        cnn.Close();

        DrvLoaiMon.DataSource = dtLoaiMon;
        DrvLoaiMon.DataTextField = "TenLoai";
        DrvLoaiMon.DataValueField = "idloaimon";
        DrvLoaiMon.DataBind();

    }
    void loadMonAn(string idloai)
    {
        string sql = "select * from MonAn where Trangthai='True'";
        if (idloai != "")
        {
            sql += " and idLoaimon='"+idloai+"'";
        }
        da=new SqlDataAdapter(sql,cnn);
        dtMonAn = new DataTable();

              

        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();



        DtlMonan.DataSource = dtMonAn;
        DtlMonan.DataBind();
        
    }

    void loadmenusan()
    {
        string sql = "select * from CTMenu Ct, MonAn MA where MA.idmonan=Ct.idmonan and Masomenu=  '" + Request.QueryString["idmenu"] + "'";
        da = new SqlDataAdapter(sql, cnn);
        dtmonansan = new DataTable();

        cnn.Open();
        da.Fill(dtmonansan);
        cnn.Close();
        // xu ly load

        for (int i = 0; i < dtmonansan.Rows.Count; i++)
        {
            mon = new XuLyDatMon
            {
                idmonan = dtmonansan.Rows[i]["idmonan"].ToString(),
                Tenmon = dtmonansan.Rows[i]["Tenmon"].ToString(),
                Hinhanh = dtmonansan.Rows[i]["Hinhanh"].ToString(),
                Gia = decimal.Parse(dtmonansan.Rows[i]["Gia"].ToString()),
                Soluong = 1,
                ThanhTien = decimal.Parse(dtmonansan.Rows[i]["Gia"].ToString())
            };
            listmonan = mon.ThemMonAn(listmonan, mon);
            //Session["monan"] = listmonan;
        }
        GrvMonChon.DataSource = listmonan; //(ArrayList)Session["monan"];
        GrvMonChon.DataBind();

        //Response.Redirect(Request.Url.ToString());//refresh trang
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {      
           
            loadLoaiMon();
            loadMonAn("");            
            listmonan = new ArrayList();
        
            loadLoaiDV();
            loadDichVu("");
            loadDVBB();
            listdichvu = new ArrayList();

            if (Request.QueryString["idmenu"] != null)
            {
                loadmenusan();

            }
            if (Session["Tendangnhap"] != null)
            {
                txtDiaChi.Text = Session["DiaChi"].ToString();
                txtHoTen.Text = Session["TenNguoiDung"].ToString();
                //txtSDT.Text = Session["DienThoai"].ToString();
                txtDN.Text = Session["Tendangnhap"].ToString();
            }
        }
    }
    protected void DrvLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadMonAn(DrvLoaiMon.SelectedValue);
    }
    /*protected void GrvMonAn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "chonmon")
        {
            string idmonan = e.CommandArgument.ToString();
            loadMonChon(idmonan);
            dvsoluongmon.Visible = true;
        }
    }*/
    void loadMonChon(string idmonan)
    {
        lbidmon.Text=idmonan;
        string sql = "select * from MonAn where idmonan='"+idmonan+"' ";
        da = new SqlDataAdapter(sql, cnn);
        dtMonChon = new DataTable();

        cnn.Open();
        da.Fill(dtMonChon);
        cnn.Close();
        if (dtMonChon.Rows.Count > 0)
        {
            lbTenmon.Text = dtMonChon.Rows[0]["TenMon"].ToString();
            lbHinh.Text = dtMonChon.Rows[0]["Hinhanh"].ToString();
            lbGia.Text = ham.chuyenDoiDinhDangTien (dtMonChon.Rows[0]["Gia"].ToString(),",") + " VNĐ";            
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        foreach (DataListItem Dtl in DtlMonan.Items)
        {
            CheckBox chk = (CheckBox)Dtl.FindControl("chkchon");
            if (chk.Checked == true)
            {
                Label lbma = (Label)Dtl.FindControl("lbidmonan");
                Label lbten = (Label)Dtl.FindControl("lbTenmon");
                Label lbGia = (Label)Dtl.FindControl("lbGia");
                Image imgHinh = (Image)Dtl.FindControl("imgHinh");
                mon = new XuLyDatMon
                {
                    idmonan = lbma.Text,
                    Tenmon = lbten.Text,
                    Hinhanh = imgHinh.ImageUrl.Replace("~/Hinh/HinhMonAn/",""),
                    Gia = decimal.Parse(lbGia.Text),
                    Soluong = 1,
                    ThanhTien = decimal.Parse(lbGia.Text)
                };

                listmonan = mon.ThemMonAn(listmonan, mon);//
            }
        }


        //mon = new XuLyDatMon
        //{
        //    idmonan = lbidmon.Text,
        //    Tenmon = lbTenmon.Text,
        //    Hinhanh = lbHinh.Text,
        //    Gia = decimal.Parse(lbGia.Text),
        //    Soluong = 1,
        //    ThanhTien = /*int.Parse(txtSoluong.Text) */ decimal.Parse(lbGia.Text)
        //};
        //

        GrvMonChon.DataSource = listmonan;//
        GrvMonChon.DataBind();
        lbtongtien.Text ="Giá: " + ham.chuyenDoiDinhDangTien( mon.TinhTongTienMonAn(listmonan).ToString(),",")+" VNĐ";//
    }
    protected void GrvMonChon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Xoa")
        {
            listmonan = mon.XoaMon(listmonan, e.CommandArgument.ToString());
            Session["XuLyDatMon"] = listmonan;
            loadMonChon(e.CommandArgument.ToString());

            GrvMonChon.DataSource = listmonan;
            GrvMonChon.DataBind();
            lbtongtien.Text ="Giá: " + ham.chuyenDoiDinhDangTien( mon.TinhTongTienMonAn(listmonan).ToString(),",")+" VNĐ";
        }
    }
    /*protected void GrvMonAn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvMonAn.PageIndex = e.NewPageIndex;
        GrvMonAn.DataSource = dtMonAn;
        GrvMonAn.DataBind();
    }*/
    void loadLoaiDV()
    {
        string sql = "select * from loaiDichVu where TrangThai='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtLoaiDV = new DataTable();

        cnn.Open();
        da.Fill(dtLoaiDV);
        cnn.Close();

        DrvLoaiDV.DataSource = dtLoaiDV;
        DrvLoaiDV.DataTextField = "Tenloai";
        DrvLoaiDV.DataValueField = "idloai";
        DrvLoaiDV.DataBind();

    }
    void loadDichVu(string idloai)
    {
        string sql = "select * from Dichvu where Trangthai='True' and BatBuoc='False'";
        if (idloai != "")
        {
            sql += " and idloai='" + idloai + "'";
        }

        da = new SqlDataAdapter(sql, cnn);
        dtDichVu = new DataTable();

        cnn.Open();
        da.Fill(dtDichVu);
        cnn.Close();



        DtlDichVu.DataSource = dtDichVu;
        DtlDichVu.DataBind();

    }
    void loadDVBB()
    {
        string sql = "select * from Dichvu where Trangthai='True' and BatBuoc='True'";
        da = new SqlDataAdapter(sql, cnn);
        dtdvbb = new DataTable();

        cnn.Open();
        da.Fill(dtdvbb);
        cnn.Close();

        DtlDVBB.DataSource = dtdvbb;
        DtlDVBB.DataBind();

    }
    protected void DrvLoaiDV_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDichVu(DrvLoaiDV.SelectedValue);
    }
    protected void GrvDichVu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ChonDV")
        {
            string iddichvu = e.CommandArgument.ToString();
            loadChonDV(iddichvu);


        }
        //if (e.CommandName == "Xem")
        //{
        //    string iddichvu = e.CommandArgument.ToString();
        //    loadDV(iddichvu);
        //    loadCTDV(iddichvu);
        //    dvchitietdv.Visible = true;
        //}
    }
    void loadChonDV(string iddichvu)
    {
        lbid.Text = iddichvu;
        string sql = "select * from Dichvu where iddichvu='" + iddichvu + "' ";
        da = new SqlDataAdapter(sql, cnn);
        dtChonDV = new DataTable();

        cnn.Open();
        da.Fill(dtChonDV);
        cnn.Close();

        if (dtChonDV.Rows.Count > 0)
        {
            lbTenDV.Text = dtChonDV.Rows[0]["Tendichvu"].ToString();
            lbGia.Text =ham.chuyenDoiDinhDangTien (dtChonDV.Rows[0]["Gia"].ToString(),",") +" VNĐ";
            lbHinh.Text = dtChonDV.Rows[0]["Hinhanh"].ToString();


        }
    }
    protected void btnThemDV_Click(object sender, EventArgs e)
    {

        foreach (DataListItem Dtl in DtlDichVu.Items)
        {
            CheckBox chk = (CheckBox)Dtl.FindControl("chkchon");
            if (chk.Checked == true)
            {
                Label lbma = (Label)Dtl.FindControl("lbidDV");
                Label lbten = (Label)Dtl.FindControl("lbTen");
                Label lbGia = (Label)Dtl.FindControl("lbGia");
                Image imgHinh = (Image)Dtl.FindControl("imgHinh");

                DichVu = new XuLyDatDV
                    {
                        iddichvu = lbma.Text,
                        Tendichvu = lbten.Text,
                        Hinhanh = imgHinh.ImageUrl.Replace("~/Hinh/Hinhdichvu/",""),
                        Gia = decimal.Parse(lbGia.Text),
                        Soluong = 1,
                        ThanhTien = decimal.Parse(lbGia.Text)
                    };

                listdichvu = DichVu.ThemDichVu(listdichvu, DichVu);
                //Session["dichvu"] = listdichvu;
            }
        }

        foreach (DataListItem dtl in DtlDVBB.Items)
        {
            CheckBox CHK = (CheckBox)dtl.FindControl("chkChon");
            if (CHK.Checked == true)
            {
                Label lbma = (Label)dtl.FindControl("lbidbb");
                Label lbTen = (Label)dtl.FindControl("lbTen");
                Label lbGia = (Label)dtl.FindControl("lbGia");
                Image imgHinh = (Image)dtl.FindControl("imgHinh");
                Label lbbacbuoc = (Label)dtl.FindControl("bacbuoc");
                DVBatBuoc = new XuLyDatDV
                {
                    iddichvu = lbma.Text,
                    Tendichvu = lbTen.Text,
                    Hinhanh = imgHinh.ImageUrl.Replace("~/Hinh/Hinhdichvu/",""),
                    Gia = decimal.Parse(lbGia.Text),
                    Soluong = 1,
                    BatBuoc=bool.Parse(lbbacbuoc.Text),
                    ThanhTien = decimal.Parse(lbGia.Text)
                 };

                listdichvu = DVBatBuoc.ThemDichVu(listdichvu, DVBatBuoc);
               }

            }
        

        //DichVu = new XuLyDatDV
        //{
        //    iddichvu = lbid.Text,
        //    Tendichvu = lbTenDV.Text,
        //    Hinhanh = lbHinh.Text,
        //    Gia = decimal.Parse(lbGia.Text),
        //    Soluong=1,
        //    ThanhTien = decimal.Parse(lbGia.Text)
        //};
        

        GrvDVChon.DataSource = listdichvu;
        GrvDVChon.DataBind();
        lbTienDV.Text ="Giá: " + ham.chuyenDoiDinhDangTien( DichVu.TinhTongTienDV(listdichvu).ToString(), ",") +" VNĐ" ;

    }
    protected void GrvDVChon_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Xoa")
        {
            listdichvu = DichVu.XoaDichVu(listdichvu, e.CommandArgument.ToString());
            Session["XuLyDichVu"] = listdichvu;
            loadChonDV(e.CommandArgument.ToString());

            GrvDVChon.DataSource = listdichvu;
            GrvDVChon.DataBind();
            lbtongtien.Text ="Giá: " + ham.chuyenDoiDinhDangTien( DichVu.TinhTongTienDV(listdichvu).ToString(), ",") + " VNĐ";

        }
        //if (e.CommandName == "Xem")
        //{
        //    string iddichvu = e.CommandArgument.ToString();
        //    loadDV(iddichvu);
        //    loadCTDV(iddichvu);
        //    dvchitietdv.Visible = true;
        //}
    }

    //public ArrayList ds { get; set; }
   /* protected void GrvDichVu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrvDichVu.PageIndex = e.NewPageIndex;
        GrvDichVu.DataSource = dtDichVu;
        GrvDichVu.DataBind();
    }*/
    //void loadDV(string iddv)
    //{
    //    string sql = "select * from Dichvu where iddichvu='" + iddv + "' ";
    //    da = new SqlDataAdapter(sql, cnn);
    //    dtDV = new DataTable();

    //    cnn.Open();
    //    da.Fill(dtDV);
    //    cnn.Close();

    //    if (dtDV.Rows.Count > 0)
    //    {
    //        lbTen.Text = dtDV.Rows[0]["Tendichvu"].ToString();
    //        lbmota.Text = dtDV.Rows[0]["MoTa"].ToString();
    //        lbGiaDV.Text = ham.chuyenDoiDinhDangTien (dtDV.Rows[0]["Gia"].ToString(),",") +" VNĐ";
    //    }
    //}
    //void loadCTDV(string iddv)
    //{
    //    string sql = "select * from CTDichvu where iddichvu='" + iddv + "' and Trangthai='True'  ";
    //    da = new SqlDataAdapter(sql, cnn);
    //    dtCTDV = new DataTable();

    //    cnn.Open();
    //    da.Fill(dtCTDV);
    //    cnn.Close();

    //    dtlCTDV.DataSource = dtCTDV;
    //    dtlCTDV.DataBind();
    //}
   
    protected void btnChon_Click1(object sender, EventArgs e)
    {
        dvMonAn.Visible = false;
        dvDichVu.Visible = true;

    }
    protected void btnKetThuc_Click(object sender, EventArgs e)
    {
        bool ketthuc = true;
        // LinQ
        XuLyDatDV ds = (from XuLyDatDV dv in listdichvu
                 where dv.BatBuoc == true
                 select dv).Single();
        //int sl = ds.Count<XuLyDatDV>();
        
        if (ds==null)//sl == 0)
        {
            lbBB.Text = "Xin Chọn Sãnh";
            ketthuc = false;
        }
        string madv_ = ds.iddichvu;
        string sql = "select * from DatTiec dt, CTDatTiec ct ,Dichvu dv where dt.iddattiec = ct.iddattiec and dt.ngaydai='"+txtNgayDai.Text+"' and ct.iddichvu='"+madv_+"' and dv.iddichvu=ct.iddichvu and dv.BatBuoc='True' ";
        da = new SqlDataAdapter(sql, cnn);
        dtChk = new DataTable();

        cnn.Open();
        da.Fill(dtChk);
        cnn.Close();
        if (dtChk.Rows.Count > 0)
        {

            lbBB.Text = "Xin Chọn Sãnh Khác, Sãnh Này Đã Có người Đặt!!! ";
            ketthuc = false;
        }
        if(ketthuc == true )
        {
            string DatTiec = ham.PhatSinhMaTuDong("DatTiec", "iddattiec", "DT", 6);
            decimal tongchiphi = (decimal.Parse(lbtongtien.Text.Replace(",", "").Replace(" VNĐ", "").Replace("Giá: ", "")) * int.Parse(txtSLB.Text)) + decimal.Parse(lbTienDV.Text.Replace(",", "").Replace(" VNĐ", "").Replace("Giá: ", ""));
             sql = "insert into DatTiec values('" + DatTiec + "',N'" + txtHoTen.Text + "','" + DateTime.Now.ToShortDateString() + "','" + txtNgayDai.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSDT.Text + "'," + tongchiphi.ToString() + ",N'Đang Chờ','" + txtSLB.Text + "',NULL,N'" + txtGhiChu.Text + "',NULL,N'"+txtDN.Text+"','" + DropDownList1.SelectedValue + "','"+Session["MaKH"].ToString()+"')";
            cmd = new SqlCommand(sql, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            sql = ""; string ma = "";
            //listdichvu=(ArrayList)Session["dichvu"];
            foreach (XuLyDatDV dv in listdichvu)
            {
                ma = ham.PhatSinhMaTuDong("CTDattiec", "idct", "CT", 7);
                sql = "insert into CTDatTiec values('" + ma + "','" + DatTiec + "',NULL,'" + dv.iddichvu + "'," + dv.Soluong + "," + dv.Gia + ")";
                cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }

            //listmonan = (ArrayList)Session["monan"];
            foreach (XuLyDatMon mon in listmonan)
            {
                ma = ham.PhatSinhMaTuDong("CTDattiec", "idct", "CT", 7);
                sql = "insert into CTDatTiec values('" + ma + "','" + DatTiec + "','" + mon.idmonan + "',NULL," + mon.Soluong + "," + mon.Gia + ")";
                cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            lbBB.Text = "Đặt Tiệc Thành Công";
            
        }
    }
    protected void btnTiep_Click(object sender, EventArgs e)
    {
        //decimal tongchiphi = decimal.Parse(lbtongtien.Text)/*decimal.Parse(txtSLB.Text))*/ + decimal.Parse(lbTienDV.Text);
         
        //lbTongSoTien.Text = tongchiphi.ToString();
        lbNgayDat.Text= DateTime.Now.ToShortDateString();

        dvKhacHang.Visible = true;
        dvDichVu.Visible = false;
        //dvMonAn.Visible = false;
    }
    protected void btnChonMon_Click(object sender, EventArgs e)
    {
        dvDichVu.Visible = false;
        dvKhacHang.Visible = false;
        dvMonAn.Visible = true;
    }

   
}