using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebBanHoa.display.News
{
    public partial class dNewsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadList();
            }
        }

        public DataTable GetNewsList() // Hiển thị danh sách tin tức
        {
            SqlCommand sqlCom = new SqlCommand("Select * from ChiTietTinTuc, DanhMucTintuc where ChiTietTinTuc.idDanhMucTinTuc = DanhMucTintuc.idDanhMucTinTuc ");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        void LoadList()
        {
            rptProductList.DataSource = GetProductCategoryList();
            rptProductList.DataBind();

            rptChiTietTinTuc.DataSource = GetNewsList();
            rptChiTietTinTuc.DataBind();
        }

        public DataTable GetProductCategoryList() // Hiển thị danh sách tin tức
        {
            SqlCommand sqlCom = new SqlCommand("Select * from DanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }


    }
}