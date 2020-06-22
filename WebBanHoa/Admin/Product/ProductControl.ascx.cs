using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.Product
{
    public partial class ProductControls : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("~/Administrator.aspx");

            string fs = Request["fs"];
            switch (fs)
            {
                case "chitietsanpham":
                    Controls.Add(LoadControl("ChiTietSanPham.ascx"));
                    lbTitle.Text = "Chi Tiết Sản Phẩm";
                    break;
                default:
                    Controls.Add(LoadControl("DanhMucSanPham.ascx"));
                    lbTitle.Text = "Danh Mục Sản Phẩm";
                    break;
            }
        }
    }
}