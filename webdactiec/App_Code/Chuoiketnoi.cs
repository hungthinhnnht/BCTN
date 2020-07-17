using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Chuoiketnoi
/// </summary>
public class Chuoiketnoi
{

    public static string ketnoidl = ConfigurationManager.ConnectionStrings["tiec cuoi"].ConnectionString;

	public Chuoiketnoi()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}