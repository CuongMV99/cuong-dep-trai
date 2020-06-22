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
    public partial class dNewsDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDetail();
            }
        }

        void LoadDetail()
        {
            int id = int.Parse(Request["id"]);
            DataTable dt = new DataTable();
            dt = GetNewsDetail(id);
            if (dt.Rows.Count > 0)
            {
                ltTitle.Text = dt.Rows[0]["tieuDe"].ToString();
                ltNewsCategory.Text = dt.Rows[0]["tenDanhMucTinTuc"].ToString();
                ltDate.Text = dt.Rows[0]["ngayDang"].ToString();
                ltContent.Text = dt.Rows[0]["noiDung"].ToString();
                imgNewsDetail.ImageUrl = dt.Rows[0]["anh"].ToString();
            }
        }

        public DataTable GetNewsDetail(int id)
        {
            SqlCommand sqlCom = new SqlCommand("Select * from ChiTietTinTuc, DanhMucTinTuc where idTinTuc = @id AND ChiTietTinTuc.idDanhMucTinTuc = DanhMucTinTuc.idDanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@id", id);
            return SQLDB.SQLDB.GetData(sqlCom);
        }
    }
}