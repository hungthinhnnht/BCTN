using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
/// <summary>
/// Summary description for XuLyDatMon
/// </summary>
public class XuLyDatMon
{
	public XuLyDatMon()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string idmonan { get; set; }
    public string Tenmon { get; set; }
    public string Hinhanh { get; set; }
    public decimal Gia {get;set;}
    public int Soluong {get;set;}
    public decimal ThanhTien { get; set; }
    public string GhiChu { get; set; }

    public ArrayList ThemMonAn(ArrayList ds, XuLyDatMon dto)
    {
        foreach (XuLyDatMon mon in ds)
        {
            if (mon.idmonan == dto.idmonan)
            {
                return ds;
            }
        }
        ds.Add(dto);
        return ds;

    }
    public ArrayList XoaMon(ArrayList ds, string idmonan_)
    {
        foreach (XuLyDatMon mon in ds)
        {
            if (mon.idmonan == idmonan_)
            {
                ds.Remove(mon);
                return ds;
            }
        }
        return ds;
    }
    public decimal TinhTongTienMonAn(ArrayList ds)
    {
        decimal tong = 0;
        foreach (XuLyDatMon mon in ds)
        {
            tong += mon.ThanhTien;
        }
        return tong;
    }

}