using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for hamdungchung
/// </summary>
public class hamdungchung
{
    private static SqlConnection cnn = new SqlConnection(Chuoiketnoi.ketnoidl);
    private static SqlCommand cmd;
    void moketnoi()
    {
        if (cnn.State == ConnectionState.Open)
            cnn.Open();
        cnn.Close();


    }

    /// </summary>
    /// <param name="tenbang">Tên bảng cần phát sinh mã</param>
    /// <param name="tencot">Cột mã cần phát sinh</param>
    /// <param name="chuoinhandang">Chuỗi nhận dạng VD: SP001 thì chuổi nhận dạng là SP</param>
    /// <param name="dodai">độ dài của mã VD: SP001 thì độ dài là 5</param>
    /// <returns></returns>
    public string PhatSinhMaTuDong(string tenbang, string tencot, string chuoinhandang, int dodai)
    {
        try
        {
            string kq = chuoinhandang + "0000000000000000000000000";
            string sql = "select Max(" + tencot.Trim() + ") from " + tenbang.Trim() + " where left(" + tencot.Trim() + "," + chuoinhandang.Length + ")='" + chuoinhandang.Trim() + "'";
            cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    kq = Convert.ToString(reader.GetValue(0));
            }
            kq = kq.Substring(chuoinhandang.Length);
            kq = "00000000000000000000000000000" + Convert.ToString(Convert.ToInt64(kq) + 1);
            kq = chuoinhandang.ToUpper() + kq.Substring(kq.Length - dodai + chuoinhandang.Length);
            cnn.Close();
            return kq;
        }
        catch
        {
            cnn.Close();
            return "";
        }
    }
    /// <summary>
    /// Hàm chuyển đổi định dạng tiền, tức là 3 ký số thì có 1 dấu,
    /// </summary>
    /// <param name="sotien">chuỗi tiền không có dấu </param>
    /// <returns>chuỗi tiền có dấu</returns>

    public string chuyenDoiDinhDangTien(string sotien, string dau)
    {
        string kq = "";
        char[] chuoi = sotien.ToCharArray();
        int dem = 0;
        int i = chuoi.Length - 1;
        while (i >= 0)
        {
            dem++;
            if (i != 0 && dem % 3 == 0)
            {
                kq = dau + chuoi[i].ToString() + kq;
            }
            else
                kq = chuoi[i].ToString() + kq;

            i--;
        }
        return kq;
    }


	public hamdungchung()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}