using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.Product
{
    public partial class ChiTietSanPham : System.Web.UI.UserControl
    {
      

        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("Select * From SanPham, DanhMucSanPham where DanhMucSanPham.idDanhMucSanPham = SanPham.idDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }


        public DataTable GetListTimKiem()
        {
            SqlCommand sqlCom = new SqlCommand("Select * From DanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }


        void LoadData()
        {
            if (Session["timkiem"] == null)
            {
                rptSanPham.DataSource = GetList();
                rptSanPham.DataBind();

                drpDanhMucSanPham.DataSource = GetListTimKiem();
                drpDanhMucSanPham.DataValueField = "idDanhMucSanPham";
                drpDanhMucSanPham.DataTextField = "tenDanhMuc";
                drpDanhMucSanPham.DataBind();

                drpDanhMucSanPhamTimKiem.DataSource = GetListTimKiem();
                drpDanhMucSanPhamTimKiem.DataValueField = "idDanhMucSanPham";
                drpDanhMucSanPhamTimKiem.DataTextField = "tenDanhMuc";
                drpDanhMucSanPhamTimKiem.DataBind();
            }
            else if (Session["timkiem"] != null)
            {
                drpDanhMucSanPham.DataSource = GetListTimKiem();
                drpDanhMucSanPham.DataValueField = "idDanhMucSanPham";
                drpDanhMucSanPham.DataTextField = "tenDanhMuc";
                drpDanhMucSanPham.DataBind();

                drpDanhMucSanPhamTimKiem.DataSource = GetListTimKiem();
                drpDanhMucSanPhamTimKiem.DataValueField = "idDanhMucSanPham";
                drpDanhMucSanPhamTimKiem.DataTextField = "tenDanhMuc";
                drpDanhMucSanPhamTimKiem.DataBind();

                DataTable dtTimKiem = new DataTable();
                dtTimKiem = GetListDanhMucSanPhamIDTimKiem(Session["timkiem"].ToString());
                if (dtTimKiem.Rows.Count > 0)
                {
                    drpDanhMucSanPhamTimKiem.Text = dtTimKiem.Rows[0]["idDanhMucSanPham"].ToString();
                    Session["timkiem"] = null;

                    rptSanPham.DataSource = dtTimKiem;
                    rptSanPham.DataBind();

                }

            }

            txtidSanPham.Enabled = false;

        }

        public void Insert(int idDanhMucSanPham, String tenSanPham, String moTa, String hinhAnh, String soLuongTon, String donGia, bool active, string mau, int cao)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into SanPham values(@idDanhMucSanPham, @tenSanPham, @moTa, @hinhAnh, @soLuongTon, @donGia, @cao, @mau, @active)");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@idDanhMucSanPham", idDanhMucSanPham);
            sqlCom.Parameters.AddWithValue("@tenSanPham", tenSanPham);
            sqlCom.Parameters.AddWithValue("@moTa", moTa);
            sqlCom.Parameters.AddWithValue("@hinhAnh", hinhAnh);
            sqlCom.Parameters.AddWithValue("@soLuongTon", soLuongTon);
            sqlCom.Parameters.AddWithValue("@donGia", donGia);
            sqlCom.Parameters.AddWithValue("@cao", cao);
            sqlCom.Parameters.AddWithValue("@mau", mau);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);

        }

        public void Update(string KHidSanPham, int idDanhMucSanPham, String tenSanPham, String moTa, String hinhAnh, String soLuongTon, String donGia, bool active, int cao, string mau)
        {
            SqlCommand sqlCom = new SqlCommand("Update SanPham set idDanhMucSanPham=@idDanhMucSanPham, tenSanPham=@tenSanPham, moTa=@moTa, hinhAnh=@hinhAnh, soLuongTon=@soLuongTon, donGia=@donGia, active=@active, cao=@cao, mau=@mau where KHidSanPham=@KHidSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidSanPham", KHidSanPham);
            sqlCom.Parameters.AddWithValue("@idDanhMucSanPham", idDanhMucSanPham);
            sqlCom.Parameters.AddWithValue("@tenSanPham", tenSanPham);
            sqlCom.Parameters.AddWithValue("@moTa", moTa);
            sqlCom.Parameters.AddWithValue("@hinhAnh", hinhAnh);
            sqlCom.Parameters.AddWithValue("@soLuongTon", soLuongTon);
            sqlCom.Parameters.AddWithValue("@cao", cao);
            sqlCom.Parameters.AddWithValue("@mau", mau);
            sqlCom.Parameters.AddWithValue("@donGia", donGia);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Delete(String KHidSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Delete From SanPham where KHidSanPham = @KHidSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidSanPham", KHidSanPham);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public DataTable GetListSanPhamID(String KHidSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From SanPham where idSanPham=@KHidSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidSanPham", KHidSanPham);
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        public DataTable GetListDanhMucSanPhamIDTimKiem(string KHidDanhMucSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From SanPham, DanhMucSanPham where KHidDanhMucSanPham=@KHidDanhMucSanPham AND DanhMucSanPham.idDanhMucSanPham = SanPham.idDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidDanhMucSanPham", KHidDanhMucSanPham);
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                LoadData();

        }

        public void empty()
        {
            txtidSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtMoTa.Text = "";
            txtSoLuongTon.Text = "";
            txtDonGia.Text = "";
        }

        protected void lnkThemSanPham_Click(object sender, EventArgs e)
        {
            bool active = chkActive.Checked ? true : false;

            SaveAnh(); // Lưu ảnh vào file Images

            if (hdUpdate.Value == "update")
            {
                string a;
                if (fulSanPham.FileName.ToString() != "")
                {
                    a = "~/Images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fulSanPham.FileName.ToString();
                }
                else
                {
                    a = lbAnh.Text;
                }

                Update(txtidSanPham.Text.Trim(),int.Parse(drpDanhMucSanPham.SelectedValue.Trim()), txtTenSanPham.Text.Trim(), txtMoTa.Text.Trim(), a, txtSoLuongTon.Text.Trim(), txtDonGia.Text.Trim(), active, int.Parse(txtCao.Text.Trim()), txtMau.Text.Trim());
                hdUpdate.Value = "insert";
                empty();
                Response.Redirect(Request.Url.ToString());
            }
            else{
                Insert(int.Parse(drpDanhMucSanPham.SelectedValue.Trim()), txtTenSanPham.Text.Trim(), txtMoTa.Text.Trim(), "~/Images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fulSanPham.FileName.ToString(), txtSoLuongTon.Text.Trim(), txtDonGia.Text.Trim(), active, txtMau.Text.Trim(), int.Parse(txtCao.Text.Trim()));
                empty();
                Response.Redirect(Request.Url.ToString());

            }
        }

        protected void rptSanPham_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetListSanPhamID(e.CommandArgument.ToString());
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        txtidSanPham.Text = dt.Rows[0]["KHidSanPham"].ToString();
                        drpDanhMucSanPham.Text = dt.Rows[0]["idDanhMucSanPham"].ToString();
                        txtTenSanPham.Text = dt.Rows[0]["tenSanPham"].ToString();
                        txtMoTa.Text = dt.Rows[0]["moTa"].ToString();
                        imgSanPham.ImageUrl = dt.Rows[0]["hinhAnh"].ToString();
                        lbAnh.Text = dt.Rows[0]["hinhAnh"].ToString();
                        txtSoLuongTon.Text = dt.Rows[0]["soLuongTon"].ToString();
                        txtMau.Text = dt.Rows[0]["mau"].ToString();
                        txtCao.Text = dt.Rows[0]["cao"].ToString();
                        txtDonGia.Text = dt.Rows[0]["donGia"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["active"]) ? true : false;
                    }
                    hdIdSanPham.Value = e.CommandArgument.ToString();
                    hdUpdate.Value = "update";

                    //Response.Redirect(Request.Url.ToString());
                    break;
                case "delete":
                    dt = GetListSanPhamID(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        Delete(e.CommandArgument.ToString());
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }


        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public DataTable GetListTimKiem(int idDanhMucSanPham)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From SanPham, DanhMucSanPham where DanhMucSanPham.idDanhMucSanPham = @idDanhMucSanPham AND DanhMucSanPham.idDanhMucSanPham = SanPham.idDanhMucSanPham");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@idDanhMucSanPham", idDanhMucSanPham);
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            rptSanPham.DataSource = GetListTimKiem(int.Parse(drpDanhMucSanPhamTimKiem.SelectedValue.Trim()));
            rptSanPham.DataBind();
        }


        public void SaveAnh()
        {
            if (fulSanPham.FileName.ToString() != "" && CheckFileType(fulSanPham.FileName)) //kiểm tra xem đã có file ảnh hay chưa
            {
                string fileName = "~/images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fulSanPham.FileName;
                string filePath = MapPath(fileName);
                fulSanPham.SaveAs(filePath);
            }
        }

        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        protected void msgDel(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn có muốn xóa không')";
        }
    }
}