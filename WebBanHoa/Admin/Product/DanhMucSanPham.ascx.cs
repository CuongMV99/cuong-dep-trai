using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebBanHoa.Admin.Product
{
    public partial class DanhMucSanPham : System.Web.UI.UserControl
    {

        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("Select * from DanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        void LoadData()
        {
            rptDanhMucSanPham.DataSource = GetList();
            rptDanhMucSanPham.DataBind();
        }

        public void Insert(String TenDanhMucSanPham, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into DanhMucSanPham values(@TenDanhMucSanPham, @active)");
            sqlCom.Parameters.AddWithValue("@TenDanhMucSanPham", TenDanhMucSanPham);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Update(string KHidDanhMucSanPham, String tenDanhMucSanPham, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Update DanhMucSanPham set tenDanhMuc = @TenDanhMucSanPham, active = @active where KHidDanhMucSanPham = @KHidDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucSanPham", KHidDanhMucSanPham);
            sqlCom.Parameters.AddWithValue("@TenDanhMucSanPham", tenDanhMucSanPham);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Delete(string KHidDanhMucSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Delete From DanhMucSanPham where KHidDanhMucSanPham = @KHidDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucSanPham", KHidDanhMucSanPham);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public DataTable GetListIdDanhMucSanPham(String KHidDanhMucSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From DanhMucSanPham where KHidDanhMucSanPham=@KHidDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucSanPham", KHidDanhMucSanPham);
            return SQLDB.SQLDB.GetData(sqlCom);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
                txtIdDanhMucSanPham.Enabled = false;
                LoadData();
        }


        protected void btnLuu_Click(object sender, EventArgs e)
        {
            bool active = chkActive.Checked ? true : false;

            if (hdInsert.Value == "insert")
            {
                    Insert(txtTenDanhMucSanPham.Text.Trim(), active);
                    Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Update(txtIdDanhMucSanPham.Text.Trim(), txtTenDanhMucSanPham.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
               
            }
        }

        protected void lnkThemDanhMucSanPham_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
            mulDanhMucSanPham.ActiveViewIndex = 1;
        }

        protected void rptDanhMucSanPham_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetListIdDanhMucSanPham(e.CommandArgument.ToString());
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        mulDanhMucSanPham.ActiveViewIndex = 1;
                        txtIdDanhMucSanPham.Text = dt.Rows[0]["KHidDanhMucSanPham"].ToString();
                        txtTenDanhMucSanPham.Text = dt.Rows[0]["tenDanhMuc"].ToString();
                    }
                    hdIdDanhMucSanPham.Value = e.CommandArgument.ToString();
                    hdInsert.Value = "Update";
                    break;
                case "delete":
                    dt = GetListIdDanhMucSanPham(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        Delete(e.CommandArgument.ToString());
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
                case "view":
                        Session["timkiem"] = e.CommandArgument;
                        Controls.Add(LoadControl("ChiTietSanPham.ascx"));
                    break;
            }
        }


        protected void msgDel(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn có muốn xóa không')";
        }
    }
}