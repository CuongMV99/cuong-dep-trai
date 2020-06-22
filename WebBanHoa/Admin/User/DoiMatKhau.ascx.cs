using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.User
{
    public partial class DoiMatKhau : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string BuildPassword(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public DataTable login(string UserName, string Password)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From AdimUser where UserName=@username and Password=@password");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@username", UserName);
            sqlCom.Parameters.AddWithValue("@password", BuildPassword(Password));
            return SQLDB.SQLDB.GetData(sqlCom);
        }


        public DataTable GetID(string taiKhoan, string matKhau)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From AdimUser where UserName=@username and Password=@password");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@username", taiKhoan);
            sqlCom.Parameters.AddWithValue("@password", BuildPassword(matKhau));
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        public void Update(string taiKhoan, string matKhau, string kHidAdimUser)
        {
            SqlCommand sqlCom = new SqlCommand("Update AdimUser set UserName = @UserName, Password = @password where KHidAdimUser = @idadimuser");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@UserName", taiKhoan);
            sqlCom.Parameters.AddWithValue("@password", BuildPassword(matKhau));
            sqlCom.Parameters.AddWithValue("@idadimuser", kHidAdimUser);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        protected void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
                dt = login(Session["username"].ToString(), txtMatKhauCu.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    DataTable dtt = new DataTable();
                    dtt = GetID(Session["username"].ToString(), txtMatKhauCu.Text.Trim());
                   if(txtMatKhauMoi.Text.Trim() == txtNhapLaiMatKhauMoi.Text.Trim())
                    {
                        Update(Session["username"].ToString(), txtNhapLaiMatKhauMoi.Text.Trim(), dtt.Rows[0]["KHidAdimUser"].ToString());
                        Response.Redirect(Request.Url.ToString());
                    }
                }
        }
    }
}