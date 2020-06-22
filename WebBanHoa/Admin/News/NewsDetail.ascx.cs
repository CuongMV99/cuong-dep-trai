using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHoa.Admin.News
{
    public partial class UserControlDeTail : System.Web.UI.UserControl
    {

        public DataTable GetList1()
        {
            SqlCommand sqlCom = new SqlCommand("Select * From DanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                txtIdTinTuc.Enabled = false;
            }
        }

        public void LoadData()
        {
            rptChiTietTinTuc.DataSource = GetList();
            rptChiTietTinTuc.DataBind();


            drpChiTietTinTuc.DataSource = GetList1();
            drpChiTietTinTuc.DataValueField = "idDanhMucTinTuc";
            drpChiTietTinTuc.DataTextField = "tenDanhMucTinTuc";
            drpChiTietTinTuc.DataBind();
        }

        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("Select * From DanhMucTinTuc, ChiTietTinTuc where DanhMucTinTuc.idDanhMucTinTuc = ChiTietTinTuc.idDanhMucTinTuc");
            sqlCom.CommandType = CommandType.Text;
            return SQLDB.SQLDB.GetData(sqlCom);
        }

        protected void lnkThemMoi_Click(object sender, EventArgs e)
        {
            hdInsertct.Value = "insert";
            mulChiTietTinTuc.ActiveViewIndex = 1;
            txtNgayDang.Enabled = false;
        }

        public DataTable GetListbyNewsID(String KHidChiTietTinTuc)
        {
            SqlCommand sqlCom = new SqlCommand("Select * From ChiTietTinTuc where KHidChiTietTinTuc = @KHidChiTietTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidChiTietTinTuc", KHidChiTietTinTuc);
            return SQLDB.SQLDB.GetData(sqlCom);
        }


        protected void rptChiTietTinTuc_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetListbyNewsID(e.CommandArgument.ToString());
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        txtIdTinTuc.Text = dt.Rows[0]["KHidChiTietTinTuc"].ToString();
                        txtTieuDe.Text = dt.Rows[0]["tieuDe"].ToString();
                        drpChiTietTinTuc.Text = dt.Rows[0]["idDanhMucTinTuc"].ToString();
                        ftb.Text = dt.Rows[0]["noiDung"].ToString();
                        txtTacGia.Text = dt.Rows[0]["tacGia"].ToString();
                        txtNgayDang.Text = dt.Rows[0]["ngayDang"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["active"]) ? true : false;
                        lbAnh.Text = dt.Rows[0]["anh"].ToString();
                        Image1.ImageUrl = dt.Rows[0]["anh"].ToString();

                    }
                    txtNgayDang.Enabled = true;

                    hdInsertct.Value = "update";

                    mulChiTietTinTuc.ActiveViewIndex = 1;
                    break;
                case "delete":
                    dt = GetListbyNewsID(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        Delete(e.CommandArgument.ToString());
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }

        public void Delete(string KHidChiTietTinTuc)
        {
            SqlCommand sqlCom = new SqlCommand("Delete From ChiTietTinTuc Where KHidChiTietTinTuc = @KHidChiTietTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidChiTietTinTuc", KHidChiTietTinTuc);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Update(string KHidChiTietTinTuc, int idDanhMucTinTuc, string tieuDe,string anh, string noiDung, string tacGia, string ngayDang, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Update ChiTietTinTuc set idDanhMucTinTuc = @idDanhMucTinTuc, tieuDe = @tieuDe, noiDung = @noiDung, tacGia = @tacGia, ngayDang = @ngayDang, active = @active, anh = @anh Where KHidChiTietTinTuc = @KHidChiTietTinTuc");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@KHidChiTietTinTuc", KHidChiTietTinTuc);
            sqlCom.Parameters.AddWithValue("@idDanhMucTinTuc", idDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@tieuDe", tieuDe);
            sqlCom.Parameters.AddWithValue("@anh", anh);
            sqlCom.Parameters.AddWithValue("@noiDung", noiDung);
            sqlCom.Parameters.AddWithValue("@tacGia", tacGia);
            sqlCom.Parameters.AddWithValue("@ngayDang", ngayDang);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        public void Insert(int idDanhMucTinTuc, string tieuDe,string anh, string noiDung, string tacGia, DateTime ngayDang, bool active)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into ChiTietTinTuc values(@idDanhMucTinTuc, @tieuDe, @anh, @noiDung, @tacGia, @ngayDang, @active)");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@idDanhMucTinTuc", idDanhMucTinTuc);
            sqlCom.Parameters.AddWithValue("@tieuDe", tieuDe);
            sqlCom.Parameters.AddWithValue("@anh", anh);
            sqlCom.Parameters.AddWithValue("@noiDung", noiDung);
            sqlCom.Parameters.AddWithValue("@tacGia", tacGia);
            sqlCom.Parameters.AddWithValue("@ngayDang", ngayDang);
            sqlCom.Parameters.AddWithValue("@active", active);
            SQLDB.SQLDB.ExecuteNoneQuery(sqlCom);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool active = chkActive.Checked ? true : false;


            SaveAnh(); // Lưu ảnh vào file Images

            if (hdInsertct.Value == "insert")
            {

                DateTime now = DateTime.Now;

                Insert(int.Parse(drpChiTietTinTuc.SelectedValue.Trim()), txtTieuDe.Text.Trim(), "~/Images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + FileUpload1.FileName.ToString(), ftb.Text.Trim(), txtTacGia.Text.Trim(), now, active);
                    Response.Redirect(Request.Url.ToString());
            }
            else
            {
                string a;
                if (FileUpload1.FileName.ToString() != "")
                {
                    a = "~/Images/"+ DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + FileUpload1.FileName.ToString();
                }
                else
                {
                    a = lbAnh.Text;
                }

                Update(txtIdTinTuc.Text.Trim(), int.Parse(drpChiTietTinTuc.SelectedValue.Trim()), txtTieuDe.Text.Trim(), a, ftb.Text.Trim(), txtTacGia.Text.Trim(), Convert.ToDateTime(txtNgayDang.Text).ToString("yyyy/MM/dd"), active);
                Response.Redirect(Request.Url.ToString());
            }

        }


        public void SaveAnh()
        {
            if (FileUpload1.FileName.ToString() != "" && CheckFileType(FileUpload1.FileName)) //kiểm tra xem đã có file ảnh hay chưa
            {
                string fileName = "~/images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
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
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }

    }
}