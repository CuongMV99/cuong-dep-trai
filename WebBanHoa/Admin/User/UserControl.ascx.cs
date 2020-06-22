using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.User
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("~/Administrator.aspx");

            string fs = Request["fs"];
            switch (fs)
            {
                case "ttk":
                    Controls.Add(LoadControl("AdminUsers.ascx"));
                    break;
                default:
                    Controls.Add(LoadControl("DoiMatKhau.ascx"));
                    break;
            }
        }
    }
}