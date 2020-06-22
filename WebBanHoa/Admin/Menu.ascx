

<%--<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="WebBanHoa.Admin.Menu" %>--%>

<nav class="navbar-default navbar-static-side" role="navigation">
        <div class="sidebar-collapse">
            <ul class="nav" id="side-menu">
                <li class="nav-header">
                    <div class="dropdown profile-element"> <span>
                            <img alt="image" class="img-circle" src="img/profile_small.jpg" />
                             </span>
                        <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                            <span class="clear"> <span class="block m-t-xs"> <strong class="font-bold"><%=Session("username") %></strong>
                             </span> <span class="text-muted text-xs block">Art Director <b class="caret"></b></span> </span> </a>
                        <ul class="dropdown-menu animated fadeInRight m-t-xs">
                            <li><a href="profile.html">Profile</a></li>
                            <li><a href="contacts.html">Contacts</a></li>
                            <li><a href="mailbox.html">Mailbox</a></li>
                            <li class="divider"></li>
                            <li><a href="login.html">Logout</a></li>
                        </ul>
                    </div>
                    <div class="logo-element">
                        IN+
                    </div>
                </li>
                <li>
                    <a href="/"><span class="nav-label">Trang Chủ</span></a>
                </li>
                <li>
                    <a href="../Administrator.aspx"><span class="nav-label">Trang Quản trị</span></a>
                </li>
                <li>
                    <a href="administrator.aspx?f=news"><span class="nav-label">Trang Tin Tức</span></a>
                </li>
                <li>
                    <a href="administrator.aspx?f=product"><span class="nav-label">Trang Sản Phẩm</span></a>
                </li>
            </ul>

        </div>
    </nav>

<%--<div><a href="/">Trang Chủ</a></div>

<div><a href="../Administrator.aspx">Trang Quản Trị</a></div>

<div><a href="administrator.aspx?f=news">Trang Tin Tức</a></div>

<div><a href="administrator.aspx?f=product">Trang Sản Phẩm</a></div>

<div><a href="administrator.aspx?f=user">Trang Tài Khoản</a></div>

<div><a href="administrator.aspx?f=contact">Trang Liên Hệ</a></div>--%>