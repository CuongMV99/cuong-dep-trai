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
    public partial class AdminUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string BuildPassword(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for(int i = 0; i< data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        public void Insert(string UserName, string Password)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into AdimUser values(@UserName, @Password)");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@UserName", UserName);
            sqlCom.Parameters.AddWithValue("@Password", Password);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text.Trim())){
                Insert(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                Response.Redirect(Request.Url.ToString());
            }
                
        }
    }
}