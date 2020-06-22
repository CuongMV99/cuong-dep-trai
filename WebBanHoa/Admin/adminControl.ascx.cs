using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin
{
    public partial class adminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("Administrator.aspx");
            string s = Request["f"];
            switch (s)
            {
                case "news":
                    plLoad.Controls.Add(LoadControl("News/NewsControl.ascx"));
                    break;
                case "product":
                    plLoad.Controls.Add(LoadControl("Product/ProductControl.ascx"));
                    break;
                case "user":
                    plLoad.Controls.Add(LoadControl("User/UserControl.ascx"));
                    break;
                case "contact":
                    plLoad.Controls.Add(LoadControl("Contact/ContactControl.ascx"));
                    break;
                default:
                    plLoad.Controls.Add(LoadControl("News/NewsControl.ascx"));
                    break;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Administrator.aspx");
        }
    }
}