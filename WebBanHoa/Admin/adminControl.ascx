<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminControl.ascx.cs" Inherits="WebBanHoa.Admin.adminControl" %>

<%@ Register src="Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<form runat="server" enctype="multipart/form-data" method="post">
<%--<div>banner admin username:[<%=Session["username"] %>]&nbsp;<asp:LinkButton id="lnkEdit" runat="server" onclick="lnkEdit_Click">exit</asp:LinkButton></div>--%>

     <div id="wrapper" style="padding:0px;">
         <nav class="navbar-default navbar-static-side" role="navigation">
             <uc1:Menu ID="Menu2" runat="server" />
         </nav>
         <div id="page-wrapper" class="gray-bg">
             <asp:PlaceHolder ID ="plLoad" runat="server"></asp:PlaceHolder>
         </div>
     </div>
<%--<table cellspacing ="0" cellpadding="0" style="width:100%">
    <tr>
        <td style="width:200px">
            <uc1:Menu ID="Menu1" runat="server" />
        </td>
        <td style="width:10px">&nbsp</td>
        <td><asp:PlaceHolder ID ="plLoad" runat="server"></asp:PlaceHolder></td>
    </tr>
</table>--%>
    </form>