using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["f"])
            {
                case "news":
                    plIndex.Controls.Add(LoadControl("display/News/dNewsControl.ascx"));
                    break;
                case "contact":
                    break;
                default:
                    plIndex.Controls.Add(LoadControl("display/Utilities/dIndex.ascx"));
                    break;
            }
        }
    }
}