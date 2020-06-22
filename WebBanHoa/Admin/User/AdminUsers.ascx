<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.ascx.cs" Inherits="WebBanHoa.Admin.User.AdminUsers" %>

<div>
    <table>
        <tr>
            <td>Tài Khoản: </td>
            <td><asp:TextBox ID="txtTaiKhoan" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Mật khẩu: </td>
            <td><asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnCapNhat" runat="server"  Text="Cập nhật" OnClick="btnCapNhat_Click"/></td>
        </tr>
    </table>
</div>