<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhMucSanPham.ascx.cs" Inherits="WebBanHoa.Admin.Product.DanhMucSanPham" %>
<div></div>


<asp:MultiView ID="mulDanhMucSanPham" runat="server" ActiveViewIndex="0">
    <asp:View ID="dmsp1" runat="server">
         <asp:Repeater ID="rptDanhMucSanPham" runat="server" OnItemCommand="rptDanhMucSanPham_ItemCommand">
                <HeaderTemplate>
                    <table style="width:100%; margin-bottom: 10px" class="border">
                        <tr>
                            <td  class="boldChu canGiuaPhanTu border">Mã Danh Mục Sản Phẩm</td>
                            <td  class="boldChu canGiuaPhanTu border">Tên Danh Mục Sản Phẩm</td>
                            <td  class="boldChu canGiuaPhanTu border">Active</td>
                            <td  class="boldChu canGiuaPhanTu border">Chức năng</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="canGiuaPhanTu border">
                            <%#:Eval("KHidDanhMucSanPham") %>
                        </td>
                        <td class="canGiuaPhanTu border"><%#:Eval("tenDanhMuc") %></td>
                        <td class="canGiuaPhanTu border"><%#:Eval("active") %></td>
                        <td class="canGiuaPhanTu border">
                            <asp:LinkButton ID="lnkSua" runat="server" CommandName="update" CommandArgument='<%#:Eval("KHidDanhMucSanPham") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkXoa" runat="server" CommandName="delete" CommandArgument='<%#:Eval("KHidDanhMucSanPham") %>' OnLoad ="msgDel" CssClass="buttonXoa">Xóa</asp:LinkButton>
                           <%-- <asp:LinkButton ID="lnkXem" runat="server" CommandName="view" CommandArgument='<%#:Eval("KHidDanhMucSanPham") %>' >Xem</asp:LinkButton>--%>
                        </td>
                    </tr>
                </ItemTemplate>
             <AlternatingItemTemplate>
                 <tr class="darker">
                        <td class="canGiuaPhanTu">
                            <%#:Eval("KHidDanhMucSanPham") %>
                        </td>
                        <td class="canGiuaPhanTu border"><%#:Eval("tenDanhMuc") %></td>
                        <td class="canGiuaPhanTu border"><%#:Eval("active") %></td>
                        <td class="canGiuaPhanTu border">
                            <asp:LinkButton ID="lnkSua" runat="server" CommandName="update" CommandArgument='<%#:Eval("KHidDanhMucSanPham") %>' CssClass="buttonXoa">Sửa</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lnkXoa" runat="server" CommandName="delete" CommandArgument='<%#:Eval("KHidDanhMucSanPham") %>' OnLoad ="msgDel" CssClass="buttonXoa">Xóa</asp:LinkButton>
                        </td>
                  </tr>
             </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        <div>
            <asp:LinkButton ID="lnkThemDanhMucSanPham" runat="server" OnClick="lnkThemDanhMucSanPham_Click" CssClass="buttonCapNhat"> Thêm Danh Mục Sản Phẩm</asp:LinkButton>
        </div>
    </asp:View>
    <asp:View ID="dmsp2" runat="server">
       <asp:HiddenField ID="hdIdDanhMucSanPham" runat="server" />
        <asp:HiddenField ID="hdInsert" runat="server" />
        <table>
            <tr>
                <td class="chinhForm">Mã Danh Mục Sản Phẩm</td>
                <td class="chinhForm"><asp:TextBox ID="txtIdDanhMucSanPham" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Tên Danh Mục Sản Phẩm</td>
                <td class="chinhForm"><asp:TextBox ID="txtTenDanhMucSanPham" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="chinhForm">Active</td>
                <td class="chinhForm"><asp:CheckBox ID="chkActive" runat="server" Checked="true"/></td>
            </tr>
            <tr>
                <td class="chinhForm"><asp:Button ID="btnLuu" runat="server" Text="Cập nhật" OnClick="btnLuu_Click" class="buttonCapNhat"/></td>
            </tr>
        </table>
    </asp:View>
    
</asp:MultiView>
           
        
