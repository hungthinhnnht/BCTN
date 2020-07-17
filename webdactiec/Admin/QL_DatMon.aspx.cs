﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_QL_DatMon : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dtDatMon;
    DataTable dtMonAn;
    DataTable dttest;
    hamdungchung ham = new hamdungchung();

    void loadthongtincapnhat()
    {
        string Sql = " select a.* ,b.Tenmon,b.Gia from DatMon a left join MonAn b on a.IdMon = b.idmonan where IdDatMon='" + Request.QueryString["id"] + "'";
        da = new SqlDataAdapter(Sql, cnn);
        dtDatMon = new DataTable();
        cnn.Open();
        da.Fill(dtDatMon);
        cnn.Close();

        if (dtDatMon.Rows.Count > 0)
        {
            lbid.Text = Request.QueryString["id"];
            txtIdDatMon.Text = dtDatMon.Rows[0]["IdDatMon"].ToString();
            txtNgayToChuc.Text = dtDatMon.Rows[0]["NgayToChuc"].ToString();
            txtTGTC.Text = dtDatMon.Rows[0]["ThoiGianToChuc"].ToString();
            txtGiaSanPham.Text = dtDatMon.Rows[0]["Gia"].ToString();
           // txtIdMon.Text = dtDatMon.Rows[0]["IdMon"].ToString();
            txtDiaChi.Text = dtDatMon.Rows[0]["DiaChi"].ToString();
            txtTenmon.Text = dtDatMon.Rows[0]["Tenmon"].ToString();
            txtSoLuong.Text = dtDatMon.Rows[0]["SoLuong"].ToString();
            txtThanhTien.Text = dtDatMon.Rows[0]["ThanhTien"].ToString();
        
        }
    }
    void loadMonAn()
    {
        //(idmonan + ',' + SPACE(1) + CAST(Gia AS varchar)) as combinedAddress  
        string sql = "select * from MonAn "; //order by idmonan = 'MA0003' desc ,idmonan asc
        da = new SqlDataAdapter(sql, cnn);
        dtMonAn = new DataTable();
        cnn.Open();
        da.Fill(dtMonAn);
        cnn.Close();

       
        DrlMA.DataSource = dtMonAn;
        DrlMA.DataTextField = "Tenmon";
        DrlMA.DataValueField = "idmonan";
        DrlMA.DataBind();
       

           for (int i = 0; i < DrlMA.Items.Count; i++)  
                {
                    var abc = dtMonAn.Rows[i]["Gia"].ToString();
                    DrlMA.Items[i].Attributes.Add("data-gia", abc);
                }  
             
   
    }
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                //btnCapNhat.Visible = true;
                //btnThem.Visible = false;
                loadthongtincapnhat();
                loadMonAn();

            }
            else
            {
                //btnThem.Visible = true;
               // btnCapNhat.Visible = false;


            }


        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string DatTiec = ham.PhatSinhMaTuDong("DatTiec", "iddattiec", "DT", 6);
    //    string sql = "insert into DatTiec values('" + DatTiec + "',N'" + txtHoTen.Text + "',N'" + txtNgayDat.Text + "',N'" + txtNgayDai.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSDT.Text + "',N'" + txtTongTien.Text + "','" + ChkTrangThai.Checked.ToString() + "')";
    //    cmd = new SqlCommand(sql, cnn);
    //    cnn.Open();
    //    cmd.ExecuteNonQuery();
    //    cnn.Close();

    //    Response.Redirect("DatTiec.aspx");
    //}
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        string sql = "Update DatMon  set  IdDatMon='" + txtIdDatMon.Text + "',NgayToChuc='" + txtNgayToChuc.Text + "',IdMon='" + DrlMA.SelectedValue + "',ThoiGianToChuc='" + txtTGTC.Text + "',SoLuong='" + txtSoLuong.Text + "',ThanhTien='" + txtThanhTien.Text + "',DiaChi=N'" + txtDiaChi.Text + "'";

        sql += "where IdDatMon='" + txtIdDatMon.Text + "'";
        cmd = new SqlCommand(sql, cnn);
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();

        Response.Redirect("DanhSachDatMon.aspx");
    }
}