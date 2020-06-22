<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="WebBanHoa.Admin.News.UserControlDeTail" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>


<div></div>
    <asp:MultiView ID="mulChiTietTinTuc" runat="server" ActiveViewIndex="0">
        <asp:View ID="vct1" runat="server">
            <asp:Repeater ID="rptChiTietTinTuc" runat="server" OnItemCommand="rptChiTietTinTuc_ItemCommand">
        <HeaderTemplate>
            <table style="width:100%; margin-bottom:10px;">
                <tr>
                    <td class="canGiuaPhanTu boldChu">Mã Tin Tức</td>
                    <td class="canGiuaPhanTu boldChu">Danh Mục Tin Tức</td>
                    <td class="canGiuaPhanTu boldChu">Tiêu Đề</td>
                    <td class="canGiuaPhanTu boldChu">Hình Ảnh</td>
                    <td class="canGiuaPhanTu boldChu">Nội Dung</td>
                    <td class="canGiuaPhanTu boldChu">Tác Giả</td>
                    <td class="canGiuaPhanTu boldChu">Ngày Đăng</td>
                    <td class="canGiuaPhanTu boldChu">Active</td>
                    <td class="canGiuaPhanTu boldChu">Chức năng</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr class="border">
                    <td class="canGiuaPhanTu border"><%#:Eval("KHidChiTietTinTuc")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("tenDanhMucTinTuc")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("tieuDe")%></td>
                    <td style="width:20%" class="canGiuaPhanTu border"><asp:Image ID="imgChiTietTinTuc" runat="server" ImageUrl='<%#:Eval("anh")%>' style="width:50%"/></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("noiDung")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("tacGia")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("ngayDang")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("active")%></td>
                    <td class="canGiuaPhanTu border">
                        <asp:LinkButton runat="server" ID="lnkXoa" CommandName="delete" CommandArgument='<%#:Eval("KHidChiTietTinTuc") %>' CssClass="buttonXoa" OnLoad="msgDel">Xóa</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lnkSua" CommandName="update" CommandArgument='<%#:Eval("KHidChiTietTinTuc") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>
                    </td>
                </tr>
        </ItemTemplate>
                <AlternatingItemTemplate>
                <tr class="darker border">
                    <td class="canGiuaPhanTu border"><%#:Eval("KHidChiTietTinTuc")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("tenDanhMucTinTuc")%></td>
                    <td class="canGiuaPhanTu"><%#:Eval("tieuDe")%></td>
                    <td style="width:20%" class="canGiuaPhanTu border"><asp:Image ID="imgChiTietTinTuc" runat="server" ImageUrl='<%#:Eval("anh")%>' style="width:50%"/></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("noiDung")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("tacGia")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("ngayDang")%></td>
                    <td class="canGiuaPhanTu border"><%#:Eval("active")%></td>
                    <td class="canGiuaPhanTu border">
                        <asp:LinkButton runat="server" ID="lnkXoa" CommandName="delete" CommandArgument='<%#:Eval("KHidChiTietTinTuc") %>' CssClass="buttonXoa" OnLoad="msgDel">Xóa</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lnkSua" CommandName="update" CommandArgument='<%#:Eval("KHidChiTietTinTuc") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>
                    </td>
                </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
            <div><asp:LinkButton ID="lnkThemMoi" runat="server" OnClick="lnkThemMoi_Click" CssClass="buttonXoa">Add News</asp:LinkButton></div>
        </asp:View>

    
    <asp:View ID="vct2" runat="server">
        <asp:HiddenField ID="hdInsertct" runat="server" />
        <table>
            <tr>
                <td class="chinhForm">ID Tin Tức</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:TextBox runat="server" ID="txtIdTinTuc"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Danh Mục Tin Tức</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:DropDownList ID="drpChiTietTinTuc" runat="server" CssClass="drp"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="chinhForm">Tiêu Đề</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:TextBox runat="server" ID="txtTieuDe"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Ảnh</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="348px" Height="27px" />
                </td>
                <td class="chinhForm">
                    <asp:Image ID="Image1" runat="server" Width="150px"/>
                </td>
                <td class="chinhForm"><asp:Label ID="lbAnh" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="chinhForm">Nội Dung</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><FTB:FreeTextBox ID="ftb" runat="server"></FTB:FreeTextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Tác Giả</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:TextBox runat="server" ID="txtTacGia"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Ngày Đăng</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:TextBox runat="server" ID="txtNgayDang"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Active</td>
                <td style="width:20px" class="chinhForm"></td>
                <td class="chinhForm"><asp:CheckBox ID="chkActive" runat="server"  Checked="true"/></td>
            </tr>
            <tr>
                <td class="chinhForm"></td>
                <td class="chinhForm"><asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" class="buttonCapNhat"/></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>

