<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoiMatKhau.ascx.cs" Inherits="WebBanHoa.Admin.User.DoiMatKhau" %>
<div>
    <table>
        <tr>
            <td>Mật khẩu cũ:</td>
            <td><asp:TextBox ID="txtMatKhauCu" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>Mật khẩu mới:</td>
            <td><asp:TextBox ID="txtMatKhauMoi" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>Nhập lại mật khẩu mới:</td>
            <td><asp:TextBox ID="txtNhapLaiMatKhauMoi" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnLuuMatKhau" runat="server" Text="Cập nhật" OnClick="btnLuuMatKhau_Click"/></td>
        </tr>
    </table>
</div>