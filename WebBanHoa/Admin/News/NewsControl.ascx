<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsControl.ascx.cs" Inherits="WebBanHoa.Admin.News.NewsControl" %>


<div class="row wrapper border-bottom white-bg page-heading" style="margin-bottom:10px; max-width:100%;}">
                <div class="col-lg-9">
                    <h2>Tin Tức</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="index.html">Home</a>
                        </li>
                        <li class="active">
                            <strong><asp:Label ID="lbTitleTinTuc" runat="server"></asp:Label></strong>
                        </li>
                    </ol>
                </div>
            </div>

<div><a href="?f=news&fs=cate" class="buttonXoa">New Category</a>&nbsp; &nbsp;<a href="?f=news&fs=des" class="buttonXoa">News Detail</a></div>