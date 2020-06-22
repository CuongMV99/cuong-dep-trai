using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebBanHoa.App_Code
{
    public class clsNews
    {

        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("Select * from TinTuc");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        public void Insert(String TenDanhMucTinTuc, String idDanhMucTinTuc)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into DanhMucTinTuc values(@idDanhMucTinTuc, @TenDanhMucTinTuc)");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@TenDanhMucTinTuc", TenDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@idDanhMucTinTuc", idDanhMucTinTuc);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

    }
}