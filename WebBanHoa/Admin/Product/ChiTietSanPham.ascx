<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietSanPham.ascx.cs" Inherits="WebBanHoa.Admin.Product.ChiTietSanPham" %>

<div></div>
<div style="width:100%; ">
    <asp:HiddenField ID="hdIdSanPham" runat="server"/>
    <asp:HiddenField ID="hdUpdate" runat="server" />
    <div>
        <table>
            <tr>
                <td class="chinhForm">Danh Mục Sản Phẩm</td>
                <td><asp:DropDownList ID="drpDanhMucSanPhamTimKiem" runat="server"></asp:DropDownList></td>
                <td class="chinhForm"><asp:Button ID="btnTimKiem" Text="Tìm Kiếm" runat="server" OnClick="btnTimKiem_Click"/></td>
                <td class="chinhForm"><asp:Button ID="btnLamMoi" Text="Load Data" runat="server" OnClick="btnLamMoi_Click"/></td>
            </tr>
            <tr>
                <td class="chinhForm">ID Sản Phẩm</td>
                <td class="chinhForm"><asp:TextBox ID="txtidSanPham" runat="server"></asp:TextBox></td>
                <td class="chinhForm">Danh Mục Sản Phẩm</td>
                <td class="chinhForm"><asp:DropDownList ID="drpDanhMucSanPham" runat="server"></asp:DropDownList></td>
                <td class="chinhForm">Tên Sản Phẩm</td>
                <td class="chinhForm"><asp:TextBox ID="txtTenSanPham" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Mô Tả</td>
                <td class="chinhForm"><asp:TextBox ID="txtMoTa" runat="server"></asp:TextBox></td>
                <td class="chinhForm">Hình Ảnh</td>
                <td class="chinhForm">
                    <asp:FileUpload ID="fulSanPham" runat="server" Width="348px" Height="27px" />
                    <asp:Image ID="imgSanPham" runat="server" Width="20%"/>
                    <asp:Label ID="lbAnh" runat="server"></asp:Label>
                </td>
                <td class="chinhForm">Số Lượng Tồn</td>
                <td class="chinhForm"><asp:TextBox ID="txtSoLuongTon" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Màu</td>
                <td class="chinhForm"><asp:TextBox ID="txtMau" runat="server"></asp:TextBox></td>
                <td class="chinhForm">Chiều Cao</td>
                <td class="chinhForm"><asp:TextBox ID="txtCao" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Đơn Giá</td>
                <td class="chinhForm"><asp:TextBox ID="txtDonGia" runat="server"></asp:TextBox></td>
                <td class="chinhForm">Active</td>
                <td class="chinhForm"><asp:CheckBox ID="chkActive" runat="server" checked="true"/></td>
            </tr>
        </table>
    </div>
</div>
<asp:LinkButton ID="lnkThemSanPham" runat="server" OnClick="lnkThemSanPham_Click" CssClass="buttonXoa">Thêm Sản Phẩm</asp:LinkButton>

<asp:Repeater ID="rptSanPham" runat="server" OnItemCommand="rptSanPham_ItemCommand">
    <HeaderTemplate>
        <table style="width:100%" class="canTren">
            <tr>
                <td class="boldChu canGiuaPhanTu">id Sản Phẩm</td>
                <td class="boldChu canGiuaPhanTu">Danh Mục Sản Phẩm</td>
                <td class="boldChu canGiuaPhanTu">Tên Sản Phẩm</td>
                <td class="boldChu canGiuaPhanTu">Mô Tả</td>
                <td class="boldChu canGiuaPhanTu">Hình Ảnh</td>
                <td class="boldChu canGiuaPhanTu">Số Lượng Tồn</td>
                <td class="boldChu canGiuaPhanTu">Màu</td>
                <td class="boldChu canGiuaPhanTu">Chiều cao</td>
                <td class="boldChu canGiuaPhanTu">Đơn Giá</td>
                <td class="boldChu canGiuaPhanTu">Trạng Thái</td>
                <td class="boldChu canGiuaPhanTu">Chức năng</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="border">
            <td class="border canGiuaPhanTu"><%#:Eval("KHidSanPham") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("tenDanhMuc") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("tenSanPham") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("moTa") %></td>
            <td style="width:20%" class="border canGiuaPhanTu"><asp:Image ID="imgLoadAnh" runat="server" ImageUrl='<%#:Eval("hinhAnh") %>' style="width:50%"/> </td>
            <td class="border canGiuaPhanTu"><%#:Eval("soLuongTon") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("mau") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("cao") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("donGia") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("active") %></td>
            <td class="border canGiuaPhanTu">
                <asp:LinkButton ID="lnkSua" runat="server" CommandName="update" CommandArgument='<%#:Eval("idSanPham") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkXoa" runat="server" CommandName="delete" CommandArgument='<%#:Eval("idSanPham") %>' CssClass="buttonXoa" OnLoad ="msgDel">Xóa</asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="border darker">
            <td class="border canGiuaPhanTu"><%#:Eval("KHidSanPham") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("tenDanhMuc") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("tenSanPham") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("moTa") %></td>
            <td style="width:20%" class="border canGiuaPhanTu"><asp:Image ID="imgLoadAnh" runat="server" ImageUrl='<%#:Eval("hinhAnh") %>' style="width:50%"/> </td>
            <td class="border canGiuaPhanTu"><%#:Eval("soLuongTon") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("mau") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("cao") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("donGia") %></td>
            <td class="border canGiuaPhanTu"><%#:Eval("active") %></td>
            <td class="border canGiuaPhanTu">
                <asp:LinkButton ID="lnkSua" runat="server" CommandName="update" CommandArgument='<%#:Eval("idSanPham") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkXoa" runat="server" CommandName="delete" CommandArgument='<%#:Eval("idSanPham") %>' CssClass="buttonXoa" OnLoad ="msgDel">Xóa</asp:LinkButton>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
                </table>
    </FooterTemplate>
</asp:Repeater>