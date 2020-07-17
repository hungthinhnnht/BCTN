using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for XuLyDatDV
/// </summary>
public class XuLyDatDV
{
	public XuLyDatDV()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool BatBuoc { get; set; }
    public string iddichvu { get; set; }
    public string Tendichvu { get; set; }
    public string Hinhanh { get; set; }
    public decimal Gia { get; set; }
    public int Soluong { get; set; }
    public decimal ThanhTien { get; set; }
    public string GhiChu { get; set; }

    public ArrayList ThemDichVu(ArrayList ds, XuLyDatDV dto)
    {
        foreach (XuLyDatDV dichvu in ds)
        {
            if (dichvu.iddichvu == dto.iddichvu)
            {
                return ds;
            }
        }
        ds.Add(dto);
        return ds;
    }
    public ArrayList XoaDichVu(ArrayList ds, string iddichvu_)
    {
        foreach (XuLyDatDV dichvu in ds)
        {
            if (dichvu.iddichvu == iddichvu_)
            {
                ds.Remove(dichvu);
                return ds;
            }
        }
        return ds;
    }
    public decimal TinhTongTienDV(ArrayList ds)
    {
        decimal tong = 0;
        foreach (XuLyDatDV dichvu in ds)
        {
            tong += dichvu.ThanhTien;
        }
        return tong;
    }
}