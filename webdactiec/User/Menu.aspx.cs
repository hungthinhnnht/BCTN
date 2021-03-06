﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class User_Menu : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    SqlDataAdapter da;
    DataTable dtMN, dtCt;

    void LoadMN()
    {
        string sql = "select * from Menusan ";
        da = new SqlDataAdapter(sql, cnn);
        dtMN = new DataTable();

        cnn.Open();
        da.Fill(dtMN);
        cnn.Close();

        phantrang.DataSource = dtMN.DefaultView;
        phantrang.BindToControl = dtlMN;

        dtlMN.DataSource = phantrang.DataSourcePaged;
        dtlMN.DataBind();
                
    }
       


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMN();
        }
    }
   /* protected void dtlMenu_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView mn = e.Item.DataItem as DataRowView;
        if (mn != null)
        {
            string mamenu = mn.Row["Masomenu"].ToString();
           // string CT = mn.Row["idmonan"].ToString();

            string sql = "select * from CTMenu Ct, MonAn MA where   MA.idmonan=Ct.idmonan and Masomenu='"+mamenu+"'";
            da = new SqlDataAdapter(sql, cnn);
            dtMN = new DataTable();

            cnn.Open();
            da.Fill(dtMN);
            cnn.Close();

            DataList tam = e.Item.FindControl("dtlCT") as DataList;

            dtlMenu.DataSource = dtMN;
            dtlMenu.DataBind();
                                
                       
        }
    }*/
    protected void dtlMN_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView mn = e.Item.DataItem as DataRowView;
        if (mn != null)
        {
            string mamenu = mn.Row["Masomenu"].ToString();
            // string CT = mn.Row["idmonan"].ToString();

            string sql = "select * from CTMenu Ct, MonAn MA where   MA.idmonan=Ct.idmonan and Masomenu='" + mamenu + "'";
            da = new SqlDataAdapter(sql, cnn);
            dtCt = new DataTable();

            cnn.Open();
            da.Fill(dtCt);
            cnn.Close();

            DataList tam = e.Item.FindControl("dtlCT") as DataList;

            tam.DataSource = dtCt;
            tam.DataBind();
        }
    }
}