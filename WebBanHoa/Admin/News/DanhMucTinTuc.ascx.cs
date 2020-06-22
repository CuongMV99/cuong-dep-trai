using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebBanHoa.Admin.News;

namespace WebBanHoa.Admin.News
{
    public partial class DanhMucTinTuc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                txtidDanhMucTinTuc.Enabled = false;
            }
                
        }

        void LoadData()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BMEO5CM\\SQLEXPRESS; Initial Catalog=WebBanHoa;  User ID = sa; Password = 123");
            conn.Open();

            SqlCommand sqlCom = new SqlCommand("Select * from DanhMucTintuc", conn);
            sqlCom.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCom;
            da.Fill(ds);
            rptTinTuc.DataSource = ds.Tables[0];
            rptTinTuc.DataBind();
            conn.Close();

            //rptTinTuc.DataSource = GetList();
            //rptTinTuc.DataBind();

        }

        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("Select * from DanhMucTintuc");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
                mul.ActiveViewIndex = 1;


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool active = chkActive.Checked ? true : false;
            if (hdInsert.Value == "insert")
            {
                Insert(txtTenDanhMucTinTuc.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
            else //update
            {
                Update(txtidDanhMucTinTuc.Text.Trim(), txtTenDanhMucTinTuc.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
        }

        public void Insert(String TenDanhMucTinTuc, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into DanhMucTinTuc values(@TenDanhMucTinTuc, @active)");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@TenDanhMucTinTuc", TenDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public DataTable GetListbyCategoryID(String KHidDanhMucTinTuc)
        {
            SqlCommand sqlCom = new SqlCommand("Select * from DanhMucTintuc where KHidDanhMucTinTuc=@KHidDanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucTinTuc", KHidDanhMucTinTuc);
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void rptTinTuc_ItemCommand(object source, RepeaterCommandEventArgs e)//e đại diện cho repeater
        {
           
            DataTable dt = new DataTable();
            dt = GetListbyCategoryID(e.CommandArgument.ToString());
            switch (e.CommandName.ToString())
            {
               
                case "update":

                    if (dt.Rows.Count > 0)
                    {
                        txtidDanhMucTinTuc.Text = dt.Rows[0]["KHidDanhMucTinTuc"].ToString();
                        txtTenDanhMucTinTuc.Text = dt.Rows[0]["tenDanhMucTinTuc"].ToString();
                        chkActive.Checked = ((bool) dt.Rows[0]["active"]) ? true : false;
                    }

                    hdIdDanhMucTinTuc.Value = e.CommandArgument.ToString();
                    hdInsert.Value = "Update";

                    mul.ActiveViewIndex = 1;

                    break;
                case "delete":
                    dt = GetListbyCategoryID(e.CommandArgument.ToString());
                    if(dt.Rows.Count > 0)
                    {
                        Delete(e.CommandArgument.ToString());
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }

        public void Update(string KHidDanhMucTinTuc, String TenDanhMucTinTuc, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Update DanhMucTinTuc set tenDanhMucTinTuc = @TenDanhMucTinTuc, active = @active where KHidDanhMucTinTuc = @KHidDanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucTinTuc", KHidDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@TenDanhMucTinTuc", TenDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Delete(string KHidDanhMucTinTuc)
        {
            SqlCommand sqlCom = new SqlCommand("Delete From DanhMucTinTuc where KHidDanhMucTinTuc = @KHidDanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucTinTuc", KHidDanhMucTinTuc);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        protected void msgDel(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }


    }

}