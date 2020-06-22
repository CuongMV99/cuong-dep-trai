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

namespace WebBanHoa.Admin
{
    public partial class Login : System.Web.UI.UserControl
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
            sqlCom.Parameters.AddWithValue("@password",Password);
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                DataTable dt = new DataTable();
                dt = login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                   // Controls.Add(LoadControl("adminControl.ascx"));
                    Session["username"] = txtUserName.Text.Trim();
                }
            }
        }
    }
}