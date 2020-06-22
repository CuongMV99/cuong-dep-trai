<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductControl.ascx.cs" Inherits="WebBanHoa.Admin.Product.ProductControls" %>

<div class="row wrapper border-bottom white-bg page-heading" style="margin-bottom:10px;">
                <div class="col-lg-9">
                    <h2>Sản Phẩm</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="index.html">Home</a>
                        </li>
                        <li class="active">
                            <strong><asp:Label runat="server" ID="lbTitle"></asp:Label></strong>
                        </li>
                    </ol>
                </div>
            </div>

<div><a href="?f=product&fs=danhmucsanpham" class="buttonXoa">Danh Mục Sản Phẩm</a>&nbsp; &nbsp<a href="?f=product&fs=chitietsanpham" class="buttonXoa">Chi Tiết Sản Phẩm</a></div>