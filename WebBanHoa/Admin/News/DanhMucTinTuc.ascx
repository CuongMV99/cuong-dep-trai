<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhMucTinTuc.ascx.cs" Inherits="WebBanHoa.Admin.News.DanhMucTinTuc" %>

<asp:MultiView ID="mul" runat ="server" ActiveViewIndex="0">

        <asp:View ID="v1" runat="server">
            <div>
                <asp:Repeater ID="rptTinTuc" runat="server" OnItemCommand="rptTinTuc_ItemCommand">
                    <HeaderTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td class="canGiuaPhanTu boldChu">Mã Danh Mục</td>
                                <td class="canGiuaPhanTu boldChu">Tên Danh Mục</td>
                                <td class="canGiuaPhanTu boldChu">Active</td>
                                <td class="canGiuaPhanTu boldChu">Chức năng</td>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr class="border">
                            <td class="border canGiuaPhanTu">
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%#:Eval("KHidDanhMucTinTuc") %>'><%#:Eval("KHidDanhMucTinTuc") %></asp:LinkButton>
                            </td>
                            <td class="border canGiuaPhanTu"><%#:Eval("tenDanhMucTinTuc") %></td>
                            <td class="border canGiuaPhanTu"><%#:Eval("active") %></td>
                            <td class="border canGiuaPhanTu">
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#:Eval("KHidDanhMucTinTuc") %>' OnLoad ="msgDel" CssClass="buttonXoa">Xóa</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>

                    <AlternatingItemTemplate>
                        <tr class="border darker">
                            <td class="border canGiuaPhanTu">
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%#:Eval("KHidDanhMucTinTuc") %>' ><%#:Eval("KHidDanhMucTinTuc") %></asp:LinkButton>
                            </td>
                            <td class="border canGiuaPhanTu"><%#:Eval("tenDanhMucTinTuc") %></td>
                            <td class="border canGiuaPhanTu"><%#:Eval("active") %></td>
                            <td class="border canGiuaPhanTu">
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#:Eval("KHidDanhMucTinTuc") %>' OnLoad="msgDel" CssClass="buttonXoa">Xóa</asp:LinkButton>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>

                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div>
                <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click" CssClass="buttonXoa">Add New</asp:LinkButton></div>
        </asp:View>

        <asp:View ID="v2" runat="server">
            <asp:HiddenField ID="hdIdDanhMucTinTuc" runat="server" />
            <asp:HiddenField ID="hdInsert" runat="server" />
            <table>
                <tr>
                    <td class="chinhForm">ID Danh Mục Tin Tức</td>
                    <td class="chinhForm">
                        <asp:TextBox ID="txtidDanhMucTinTuc" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="chinhForm">Tên Tin Tức</td>
                    <td class="chinhForm">
                        <asp:TextBox ID="txtTenDanhMucTinTuc" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="chinhForm">Active</td>
                    <td class="chinhForm"><asp:CheckBox ID="chkActive" runat="server" Checked="true"/></td>
                </tr>
                <tr>
                    <td class="chinhForm"></td>
                    <td class="chinhForm">
                        <asp:Button ID="btnSave" runat="server" Text="Cập nhật" OnClick="btnSave_Click" class="buttonCapNhat" Height="29px" /></td>
                </tr>
            </table>
         </asp:View>

</asp:MultiView>



