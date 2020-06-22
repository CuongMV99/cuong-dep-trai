using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.News
{
    public partial class NewsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("~/Administrator.aspx");

            string fs = Request["fs"];
            switch (fs)
            {
                case "des":
                    lbTitleTinTuc.Text = "Chi Tiết Tin Tức";
                    Controls.Add(LoadControl("NewsDetail.ascx"));
                    break;
                default:
                    lbTitleTinTuc.Text = "Danh Mục Tin Tức";
                    Controls.Add(LoadControl("DanhMucTinTuc.ascx"));
                    break;
            }
        }
    }
}