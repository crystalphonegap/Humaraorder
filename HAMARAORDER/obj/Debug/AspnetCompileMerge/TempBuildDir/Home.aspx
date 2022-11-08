<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HAMARAORDER.Home" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Hamara Order</title>
    <meta name="keywords" content="HTML5 Template" />
    <meta name="description" content="Molla - Bootstrap eCommerce Template" />
    <meta name="author" content="p-themes" />
    <!-- Favicon -->
    <link rel="apple-touch-icon" sizes="180x180" href="assets/images/icons/apple-touch-icon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="assets/images/logo.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="assets/images/logo.png" />
    <link rel="manifest" href="assets/images/icons/site.html" />
    <link rel="mask-icon" href="assets/images/icons/safari-pinned-tab.svg" color="#666666" />
    <link rel="shortcut icon" href="assets/images/icons/favicon.ico" />
    <meta name="apple-mobile-web-app-title" content="Molla" />
    <meta name="application-name" content="Molla" />
    <meta name="msapplication-TileColor" content="#cc9966" />
    <meta name="msapplication-config" content="assets/images/icons/browserconfig.xml" />
    <meta name="theme-color" content="#ffffff" />
    <link rel="stylesheet" href="assets/vendor/line-awesome/line-awesome/line-awesome/css/line-awesome.min.css" />

    <!-- Plugins CSS File -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/css/plugins/owl-carousel/owl.carousel.css" />
    <link rel="stylesheet" href="assets/css/plugins/magnific-popup/magnific-popup.css" />
    <link rel="stylesheet" href="assets/css/plugins/jquery.countdown.css" />
    <!-- Main CSS File -->
    <link rel="stylesheet" href="assets/css/style.css" />
    <link rel="stylesheet" href="assets/css/skins/skin-demo-2.css" />
    <link rel="stylesheet" href="assets/css/demos/demo-2.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>


    <style>
        * {
            box-sizing: border-box;
        }

        .mySlides {
            display: none;
        }

        img {
            vertical-align: middle;
        }
        /* Slideshow container */

        .slideshow-container {
            /* max-width: 1000px; */
            position: relative;
            margin: auto;
        }
        /* Caption text */

        .text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }
        /* Number text (1/3 etc) */

        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }
        /* The dots/bullets/indicators */

        .dot {
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

        .active1 {
            background-color: #717171;
        }
        /* Fading animation */

        .fade {
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @keyframes fade {
            from {
                opacity: .4
            }

            to {
                opacity: 1
            }
        }
        /* On smaller screens, decrease text size */

        @media only screen and (max-width: 300px) {
            .text {
                font-size: 11px
            }
        }
    </style>

    <script>
        $(document).ready(function () {
            $("#hide").click(function () {
                $("a").hide();
            });
            $("#show").click(function () {
                $("a").show();
            });
        });
    </script>
    <script>
        function imgError(me) {
            // place here the alternative image
            var AlterNativeImg = "images/no-image.jpg";
            // to avoid the case that even the alternative fails        
            if (AlterNativeImg != me.src)
                me.src = AlterNativeImg;
        }
    </script>
    <script>
        function imgError2(me) {
            // place here the alternative image
            var AlterNativeImg = "images/no-image.jpg";
            // to avoid the case that even the alternative fails        
            if (AlterNativeImg != me.src)
                me.src = AlterNativeImg;
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">

        <asp:Label runat="server" ID="lblcountAll" Text="0" Visible="false"></asp:Label>
        <asp:ScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManger1"></asp:ScriptManager>
        <div class="page-wrapper" style="position: sticky !important; top: 0; background: #fff; z-index: 1; border-bottom: 5px solid #133690;">
            <header class="header header-2 header-intro-clearance">


                <!---New Mneu Start-->

                <div class="row" style="background: #fff;">
                    <div class="col-md-2" style="background: #133690;">
                        <div class="header-left">
                            <button class="mobile-menu-toggler">
                                <span class="sr-only">Toggle mobile menu</span>
                                <i class="icon-bars"></i>
                            </button>

                            <a href="Home.aspx" class="logo">

                                <img src="assets/media/logos/hamaraorder1.png" />

                            </a>

                            <a href="Home.aspx" class="logo-phone">
                                <img src="assets/media/logos/logo-icon.png" width="75" height="80" />
                            </a>



                        </div>
                    </div>

                    <div class="col-md-10">
                        <div class="header-col-in row">

                            <div class="profile row" style="margin-left: 6px; padding: 10px;">

                                <div class="col-md-3" style="padding: 5px;">
                                    <img src="assets/media/logos/user.png" width="105" />
                                </div>
                                <div class="col-md-9">
                                    <span style="font-size: 16px;">Welcome</span><br />
                                    <span style="font-size: 14px;">
                                        <asp:Label runat="server" ID="lblLoginUserName" Text=""></asp:Label>
                                    </span>
                                    <br />
                                    <span style="font-size: 12px;">Last Login :
                                    <asp:Label runat="server" ID="loginDatetime" Text=""></asp:Label></span>
                                </div>

                            </div>

                            <div class="header-right">

                                <!-- End .compare-dropdown -->
                                <div style="margin-right: 30px; margin-top: 14px;">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="dropdown cart-dropdown" style="float: left; margin-right: 40px;">
                                                <a href="ViewCart.aspx" class="dropdown-toggle" role="button" >
                                                   <%-- data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"--%>
                                                    <div class="icon">
                                                        <i class="icon-shopping-cart"></i>
                                                        <span class="cart-count">
                                                            <asp:Label runat="server" ID="lblCount"></asp:Label></span>
                                                    </div>
                                                    <p>Cart</p>
                                                </a>
                                                <div class="dropdown-menu dropdown-menu-right">
                                                    <div class="dropdown-cart-products" style="height: 300px; overflow: auto;">
                                                        <asp:Repeater ID="rptCartProduct" runat="server">
                                                            <ItemTemplate>

                                                                <div class="product">
                                                                    <div class="product-cart-details">
                                                                        <h4 class="product-title">
                                                                            <a href="#"><%# Eval("ProductCode")%> -<%# Eval("ProductName")%></a>
                                                                        </h4>

                                                                    </div>
                                                                    <!-- End .product-cart-details -->

                                                                    <figure class="product-image-container">
                                                                        <a href="product.html" class="product-image">
                                                                            <img src='Img/Product/<%# Eval("ImageName") %>' onerror="imgError2(this)" alt="Product image" class="product-image" style="max-height: 150px">
                                                                        </a>
                                                                    </figure>
                                                                    <%--  <a href="#" class="btn-remove" title="Remove Product"><i class="icon-close"></i></a>--%>
                                                                </div>

                                                                <!-- End .product -->

                                                            </ItemTemplate>
                                                        </asp:Repeater>


                                                    </div>
                                                    <div class="dropdown-cart-action">
                                                        <a href="ViewCart.aspx" class="btn btn-primary">View Cart</a>
                                                        <a href="Checkout.aspx" class="btn btn-primary1">Checkout -></a>
                                                        <%--<a href="Checkout.aspx" class="btn btn-primary">Checkout<i class="icon-long-arrow-right"></i></a>--%>
                                                    </div>
                                                </div>


                                                <!-- End .dropdown-menu -->
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>



                                </div>
                                <div class="dropdown cart-dropdown">
                                    <a href="Login.aspx">
                                        <div class="icon">
                                            <i class="fa fa-sign-out"></i>
                                        </div>
                                        <p>Logout</p>
                                    </a>
                                </div>

                                <!-- End .cart-dropdown -->
                            </div>


                        </div>
                        <div class="row" style="height: 40px; background-image: linear-gradient(to right top, #183a6d, #185990, #117ab3, #089dd3, #10c1f2);">

                            <div class="col-md-12">
                                <nav class="main-nav">
                                    <ul class="menu sf-arrows">
                                        <li class="megamenu-container active">
                                            <a href="Home.aspx" class="sf-with-ul">Home</a>
                                            <!-- End .megamenu -->
                                        </li>
                                        <li runat="server" id="lstcolor">
                                            <a href="ViewColorMaster.aspx">View Color</a>
                                        </li>
                                        <li>
                                            <a href="ViewOrderList.aspx">View Order</a>
                                        </li>
                                        <li>
                                            <a href="CustomerInfo.aspx">Customer</a>
                                        </li>
                                        <li runat="server" id="lstFavList">
                                            <a href="AddFavList.aspx">Favourite List</a>
                                        </li>
                                        <li runat="server" id="lstRefrel">
                                            <a href="ViewSalesOrderRefrel.aspx">Sales Order Refrel</a>
                                        </li>

                                    </ul>
                                    <!-- End .menu -->
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>

                <!---New Mneu END-->


            </header>




            <!-- End .header -->

            <!-- End .main -->


            <!-- End .footer -->
        </div>

        <div>


            <main class="main">

                <!-- End .intro-slider-container -->

                <div class="slideshow-container">

                    <div class="mySlides fade">
                        <div class="numbertext">1 / 3</div>
                        <img src="assets/images/demos/demo-2/slider/slide-1.jpg" style="width: 100%; height: 250px" />
                        <!-- <div class="text">Caption Text</div> -->
                    </div>

                    <div class="mySlides fade">
                        <div class="numbertext">2 / 3</div>
                        <img src="assets/images/demos/demo-2/slider/slide-2.jpg" style="width: 100%; height: 250px" />
                        <!-- <div class="text">Caption Two</div> -->
                    </div>

                    <div class="mySlides fade">
                        <div class="numbertext">3 / 3</div>
                        <img src="assets/images/demos/demo-2/slider/slide-3.jpg" style="width: 100%; height: 250px" />
                        <!-- <div class="text">Caption Three</div> -->
                    </div>

                </div>


                <div style="text-align: center">
                    <span class="dot"></span>
                    <span class="dot"></span>
                    <span class="dot"></span>
                </div>




                <!-- End .owl-carousel -->

                <%--<div class="mb-3 mb-lg-5"></div>--%>
                <!-- End .mb-3 mb-lg-5 -->

                <main class="main">

                    <div class="page-content1 ">
                        <div class="container">
                            <div class="toolbox">
                                <div class="toolbox-left">
                                    <a href="#" class="sidebar-toggler"><i class="fa fa-bars"></i>Filters</a>
                                </div>
                                <!-- End .toolbox-left -->


                                <!-- End .toolbox-center -->


                                <!-- End .toolbox-right -->
                            </div>
                            <!-- End .toolbox -->


                            <!-- End .products -->

                            <div class="sidebar-filter-overlay"></div>
                            <!-- End .sidebar-filter-overlay -->
                            <aside class="sidebar-shop sidebar-filter">
                                <div class="sidebar-filter-wrapper">
                                    <div class="widget widget-clean">
                                        <label><i class="icon-close"></i>Filters</label>
                                        <a href="#" class="sidebar-filter-clear">Clean All</a>
                                    </div>
                                    <!-- End .widget -->

                                    <div class="widget widget-collapsible">
                                        <h3 class="widget-title">
                                            <a data-toggle="collapse" href="#widget-5" role="button" aria-expanded="true" aria-controls="widget-5">Size
                                            </a>
                                        </h3>
                                        <!-- End .widget-title -->

                                        <div class="collapse in" id="widget-5">
                                            <div class="widget-body">
                                                <div class="filter-items">

                                                    <asp:Repeater ID="rptMSize" runat="server">
                                                        <ItemTemplate>
                                                            <div class="filter-item">
                                                                <div class="custom-control custom-checkbox">

                                                                    <asp:CheckBox runat="server" ID="chkboxUnit" OnCheckedChanged="chkMcolorBox_CheckedChanged" AutoPostBack="true" />
                                                                    <asp:Label runat="server" ID="lblUOM" Text='<%# Eval("ProductGroup5Description") %>'></asp:Label>
                                                                    <asp:Label runat="server" ID="lblCatName" Text='<%# Eval("NAME") %>' Visible="false"></asp:Label>
                                                                </div>
                                                                <!-- End .custom-checkbox -->

                                                            </div>
                                                        </ItemTemplate>

                                                    </asp:Repeater>

                                                    <!-- End .filter-item -->
                                                </div>
                                                <!-- End .filter-items -->
                                            </div>
                                            <!-- End .widget-body -->
                                        </div>
                                        <!-- End .collapse -->
                                    </div>

                                    <div class="widget widget-collapsible">
                                        <h3 class="widget-title">
                                            <a data-toggle="collapse" href="#widget-4" role="button" aria-expanded="true" aria-controls="widget-4">Category
                                            </a>
                                        </h3>
                                        <!-- End .widget-title -->

                                        <div class="collapse in" id="widget-4">
                                            <div class="widget-body">
                                                <div class="filter-items filter-items-count" style="height: 200px; overflow: auto;">
                                                    <%--                                                    <asp:TextBox ID="searchcategory" runat="server" AutoPostBack="true" OnTextChanged="searchcategory_TextChanged"></asp:TextBox>--%>
                                                    <asp:Repeater ID="rptMCalegory" runat="server">
                                                        <ItemTemplate>
                                                            <div class="filter-item">
                                                                <div class="custom-control custom-checkbox">
                                                                    <asp:CheckBox runat="server" ID="chkCategorybox" AutoPostBack="true" OnCheckedChanged="chkMcolorBox_CheckedChanged" />
                                                                    <asp:Label runat="server" ID="lblCatName" Text='<%# Eval("Name") %>'></asp:Label>
                                                                    <asp:Label runat="server" ID="lblcode" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
                                                                </div>
                                                                <!-- End .custom-checkbox -->

                                                            </div>
                                                        </ItemTemplate>

                                                    </asp:Repeater>

                                                    <!-- End .filter-item -->

                                                    <!-- End .custom-checkbox -->

                                                </div>
                                                <!-- End .filter-item -->
                                            </div>
                                            <!-- End .filter-items -->
                                        </div>
                                        <!-- End .collapse -->
                                    </div>
                                    <!-- End .widget -->


                                    <!-- End .widget -->

                                    <div class="widget widget-collapsible">
                                        <%--  <h3 class="widget-title">
                                            <a data-toggle="collapse" href="#widget-6" role="button" aria-expanded="true" aria-controls="widget-6">Colour
                                            </a>
                                        </h3>--%>
                                        <!-- End .widget-title -->

                                        <div class="collapse show" id="widget-6">
                                            <div class="widget-body">

                                                <asp:Repeater ID="rptmColor" runat="server" OnItemDataBound="rptmColor_ItemDataBound" Visible="false">

                                                    <ItemTemplate>
                                                        <div class="filter-item">
                                                            <div class="custom-control custom-checkbox">
                                                                <asp:CheckBox runat="server" ID="chkcolorBox" OnCheckedChanged="chkMcolorBox_CheckedChanged" AutoPostBack="true" />
                                                                <asp:Label runat="server" ID="lblHexa1" Text='<%# Eval("Hexadecimal") %>' Visible="false"></asp:Label>
                                                                <asp:Label runat="server" ID="lblColorName" Text='<%# Eval("ColorName") %>' Visible="false"></asp:Label>
                                                                <asp:Label runat="server" ID="lblHexa" Text="CL" Style="border-radius: 20px; font-size: 18px"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>

                                                </asp:Repeater>

                                                <!-- End .filter-colors -->
                                            </div>
                                            <!-- End .widget-body -->
                                        </div>
                                        <!-- End .collapse -->
                                    </div>
                                    <!-- End .widget -->


                                </div>
                                <!-- End .sidebar-filter-wrapper -->
                            </aside>
                            <!-- End .sidebar-filter -->
                        </div>
                        <!-- End .container -->
                    </div>

                    <div class="page-content">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-10">
                                    <div class="toolbox">
                                        <div class="toolbox-left">

                                            <!-- End .toolbox-info -->
                                        </div>
                                        <!-- End .toolbox-left -->

                                        <div class="toolbox-right">

                                            <!-- End .toolbox-sort -->

                                            <!-- End .toolbox-layout -->
                                        </div>
                                        <!-- End .toolbox-right -->
                                    </div>
                                    <!-- End .toolbox -->

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="products">
                                                <div class="row">

                                                    <div class="col-md-12" style="padding-right: 77px;">
                                                        <asp:TextBox runat="server" ID="txtsearch" CssClass="form-control" placeholder="Search Product Name" OnTextChanged="btnlinksearchProduct_Click" AutoPostBack="true"> </asp:TextBox>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:LinkButton runat="server" ID="btnlinksearchProduct" OnClick="btnlinksearchProduct_Click" CssClass="btn btn-primary" Visible="false"> Search</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="products">
                                                <div class="row">

                                                    <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound">
                                                        <ItemTemplate>

                                                            <div class="col-6 col-md-3 col-lg-3 col-xl-3 mt-3">

                                                                <div class="product">
                                                                    <figure class="product-media">

                                                                        <asp:Label runat="server" ID="lblimage" Text='<%# Eval("ImageName") %>' Visible="false"></asp:Label>

                                                                        <img src="Img/Product/<%# Eval("ImageName") %>" onerror="imgError(this)" alt="Product image" class="product-image">


                                                                    <%--    <div class="product-action-vertical">
                                                                            <a href="#" class="btn-product-icon btn-wishlist btn-expandable"><span>add to wishlist</span></a>
                                                                        </div>--%>

                                                                    </figure>
                                                                    <!-- End .product-media -->

                                                                    <div class="product-body">
                                                                        <div class="product-cat">
                                                                            <a href="#">SKU :
                                                                <asp:Label runat="server" ID="lblMcode" Text='<%# Eval("MaterialCode") %>'></asp:Label>
                                                                            </a>
                                                                        </div>
                                                                        <!-- End .product-cat -->
                                                                        <h3 class="product-title" style="height: 45px;"><%# Eval("MaterialDescription") %></h3>
                                                                        <!-- End .product-title -->

                                                                        <div class="row">

                                                                            <div class="col-md-6 details-filter-row details-row-size">
                                                                                <label for="qty">Unit:</label>
                                                                                <div class="product-details-quantity">
                                                                                    <asp:DropDownList runat="server" ID="dropUom" CssClass="form-control">
                                                                                        <asp:ListItem Value="CS">CS</asp:ListItem>
                                                                                        <asp:ListItem Value="EA">EA</asp:ListItem>
                                                                                        <%--<asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                        <asp:ListItem Value="LT">LT</asp:ListItem>
                                                                                        <asp:ListItem Value="DR">DR</asp:ListItem>--%>
                                                                                    </asp:DropDownList>

                                                                                </div>
                                                                                <!-- End .product-details-quantity -->
                                                                            </div>

                                                                            <div class="col-md-6 details-filter-row details-row-size">
                                                                                <label for="qty">Qty:</label>
                                                                                <div class="product-details-quantity">
                                                                                    <asp:TextBox runat="server" ID="txtQty" CssClass="form-control" TextMode="Number" Text="0"></asp:TextBox>
                                                                                </div>
                                                                                <!-- End .product-details-quantity -->
                                                                            </div>
                                                                        </div>
                                                                        <!-- End .product-price -->

                                                                        <!-- End .rating-container -->
                                                                        <asp:UpdatePanel runat="server" ID="UpdatedPanel" UpdateMode="Always">
                                                                            <ContentTemplate>
                                                                                <div class="product-action1">
                                                                                    <asp:LinkButton runat="server" ID="btncart" class="btn-product btn-cart" OnClick="btncart_Click" autopostback="false"><span>Add Cart</span></asp:LinkButton>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="btncart" EventName="Click" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>

                                                                        <!-- End .product-nav -->
                                                                    </div>
                                                                    <!-- End .product-body -->
                                                                </div>

                                                                <!-- End .product -->
                                                            </div>

                                                        </ItemTemplate>
                                                    </asp:Repeater>



                                                </div>
                                                <!-- End .row -->

                                                <!-- End .load-more-container -->
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnlinksearchProduct" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <asp:Repeater ID="rptPager" runat="server" OnItemCommand="rptPager_ItemCommand">
                                        <ItemTemplate>


                                            <%--  <asp:LinkButton ID="lnkPage"
                                                    Style="padding: 8px; margin: 2px; background: lightgray; border: solid 1px #666; color: black; font-weight: bold"
                                                    CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                                </asp:LinkButton>--%>

                                            <%--<asp:LinkButton ID="lbPrevious" runat="server" Enabled="false">Previous page</asp:LinkButton>
                                            <asp:LinkButton ID="lbNext" runat="server">Next page</asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div style="margin-top: 29px;">
                                        <asp:LinkButton ID="lbtnPrev" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Text") %>'
                                            OnClick="Page_Changed" Visible="false" Text="Previous Page" ToolTip="Previous"
                                            Font-Bold="true" Style="font-weight: bold; padding: 8px 16px; background-color: #3D6DB4; color: #fff; float: left;">
                                        </asp:LinkButton>


                                        <asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false" OnClick="Page_Changed"
                                            ToolTip="Next" CommandArgument='<%# Eval("Text") %>' Text="Next Page" Font-Bold="true" Style="font-weight: bold; padding: 8px 16px; background-color: #3D6DB4; color: #fff; float: right;">
                                        </asp:LinkButton>
                                    </div>


                                    <!-- End .products -->

                                </div>
                                <!-- End .col-lg-9 -->

                                <aside1 class="col-lg-2 order-lg-first">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                        <ContentTemplate>
                                            <div class="sidebar sidebar-shop">
                                                <div class="widget widget-clean">
                                                    <label>Filters:</label>
                                                    <a href="#" class="sidebar-filter-clear">Clean All</a>
                                                </div>
                                                <!-- End .widget widget-clean -->
                                                <div class="widget widget-collapsible">
                                                    <h3 class="widget-title">
                                                        <a data-toggle="collapse" href="#widget-2" role="button" aria-expanded="true" aria-controls="widget-2">Size
                                                        </a>
                                                    </h3>
                                                    <!-- End .widget-title -->

                                                    <div class="collapse show in" id="widget-2" style="height: 250px !important; overflow: auto;">
                                                        <asp:TextBox runat="server" ID="txtsizesearch" placeholder="Search Size" CssClass="form-control" OnTextChanged="txtsizesearch_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                                                        <%--   <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServiceMethod="Searchsize"
                                                        MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                        TargetControlID="txtsizesearch" FirstRowSelected="false">
                                                    </cc1:AutoCompleteExtender>--%>

                                                        <div class="widget-body" style="height: 250px !important; overflow: auto;">
                                                            <div class="filter-items">

                                                                <asp:Repeater ID="rptUnit" runat="server">
                                                                    <ItemTemplate>
                                                                        <div class="filter-item">
                                                                            <div class="custom-control custom-checkbox">

                                                                                <asp:CheckBox runat="server" ID="chkboxUnit" OnCheckedChanged="chkbox_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:Label runat="server" ID="lblUOM" Text='<%# Eval("ProductGroup5Description") %>'></asp:Label>
                                                                                <asp:Label runat="server" ID="lblCatName" Text='<%# Eval("NAME") %>' Visible="false"></asp:Label>
                                                                            </div>
                                                                            <!-- End .custom-checkbox -->

                                                                        </div>
                                                                    </ItemTemplate>

                                                                </asp:Repeater>

                                                                <!-- End .filter-item -->
                                                            </div>
                                                            <!-- End .filter-items -->
                                                        </div>
                                                        <!-- End .widget-body -->
                                                    </div>
                                                    <!-- End .collapse -->
                                                </div>

                                                <!-- End .collapse -->
                                            </div>
                                            <!-- End .widget -->
                                            <div class="widget widget-collapsible">
                                                <h3 class="widget-title">
                                                    <a data-toggle="collapse" href="#widget-1" role="button" aria-expanded="true" aria-controls="widget-1">Category
                                                    </a>
                                                </h3>

                                                <!-- End .widget-title -->

                                                <div class="collapse show in " id="widget-1">
                                                    <asp:TextBox runat="server" ID="txtcategorySearch" placeholder="Search Category" CssClass="form-control" OnTextChanged="txtcategorySearch_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                                                    <%--    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServiceMethod="SearchCategory"
                                                            MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                            TargetControlID="txtcategorySearch" FirstRowSelected="false">
                                                        </cc1:AutoCompleteExtender>--%>
                                                    <div class="widget-body">
                                                        <div class="filter-items filter-items-count" style="height: 200px; overflow: auto;">
                                                            <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="filter-item">
                                                                        <div class="custom-control custom-checkbox">
                                                                            <asp:CheckBox runat="server" ID="chkCategorybox" AutoPostBack="true" OnCheckedChanged="chkCategorybox_CheckedChanged" />
                                                                            <asp:Label runat="server" ID="lblCatName" Text='<%# Eval("Name") %>'></asp:Label>
                                                                            <asp:Label runat="server" ID="lblcode" Text='<%# Eval("Code") %>' Visible="false"></asp:Label>
                                                                        </div>
                                                                        <!-- End .custom-checkbox -->

                                                                    </div>
                                                                </ItemTemplate>

                                                            </asp:Repeater>

                                                            <!-- End .filter-item -->

                                                            <!-- End .custom-checkbox -->

                                                        </div>
                                                        <!-- End .filter-item -->
                                                    </div>
                                                    <!-- End .filter-items -->
                                                </div>
                                                <!-- End .widget-body -->
                                            </div>
                                            <!-- End .widget -->
                                            <div class="widget widget-collapsible">
                                                <%-- <h3 class="widget-title">
                                                    <a data-toggle="collapse" href="#widget-3" role="button" aria-expanded="true" aria-controls="widget-3">Colour
                                                    </a>
                                                </h3>--%>
                                                <div class="collapse show" id="widget-3">
                                                    <div class="widget-body">

                                                        <asp:Repeater ID="RptColorantDetails" runat="server" OnItemDataBound="RptColorantDetails_ItemDataBound" Visible="false">

                                                            <ItemTemplate>
                                                                <div class="filter-item">
                                                                    <div class="custom-control custom-checkbox">
                                                                        <asp:CheckBox runat="server" ID="chkcolorBox" OnCheckedChanged="chkcolorBox_CheckedChanged" AutoPostBack="true" />
                                                                        <asp:Label runat="server" ID="lblHexa1" Text='<%# Eval("Hexadecimal") %>' Visible="false"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblColorName" Text='<%# Eval("ColorName") %>' Visible="false"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblColorCode" Text='<%# Eval("ColorCode") %>' Visible="false"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblHexa" Text="CL" Style="border-radius: 20px; font-size: 18px"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>

                                                        </asp:Repeater>

                                                        <!-- End .filter-colors -->
                                                    </div>
                                                    <!-- End .widget-body -->
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </aside1>



                                <!-- End .col-lg-3 -->
                            </div>
                            <!-- End .row -->
                        </div>
                        <!-- End .container -->
                    </div>
                    <!-- End .container -->

                    <!-- End .page-content -->
                </main>
                <!-- End .main -->



            </main>

        </div>

        <div class="mobile-menu-overlay"></div>
        <!-- End .mobil-menu-overlay -->

        <div class="mobile-menu-container mobile-menu-light">
            <div class="mobile-menu-wrapper">
                <span class="mobile-menu-close"><i class="icon-close"></i></span>


                <label for="mobile-search" class="sr-only">Search</label>

                <button class="btn btn-primary" type="submit"><i class="icon-search"></i></button>


                <nav class="mobile-nav">
                    <ul class="mobile-menu">
                        <li class="active">
                            <a href="Home.aspx">Home</a>


                        </li>
                        <li runat="server" id="lstMViewColor">
                            <a href="ViewColorMaster.aspx">View Color</a>
                        </li>
                        <li>
                            <a href="ViewOrderList.aspx">View Order</a>
                        </li>
                        <li>
                            <a href="CustomerInfo.aspx">Customer</a>
                        </li>
                        <li runat="server" id="lstMFavList">
                            <a href="AddFavList.aspx">Favourite List</a>
                        </li>
                        <li runat="server" id="lstMRefrel">
                            <a href="ViewSalesOrderRefrel.aspx">Sales Order Refrel</a>
                        </li>
                    </ul>
                </nav>
                <!-- End .mobile-nav -->

                <%-- <div class="social-icons">
                    <a href="#" class="social-icon" target="_blank" title="Facebook"><i class="icon-facebook-f"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Twitter"><i class="icon-twitter"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Instagram"><i class="icon-instagram"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Youtube"><i class="icon-youtube"></i></a>
                </div>--%>
                <!-- End .social-icons -->
            </div>
            <!-- End .mobile-menu-wrapper -->
        </div>

        <footer class="footer footer-2" style="position: absolute;">

            <!-- End .icon-boxes-container -->


            <!-- End .footer-newsletter bg-image -->


            <!-- End .footer-middle -->

            <div class="footer-bottom">
                <div class="container">
                    <p class="footer-copyright">Copyright © 2022 Crystaldata Software Services. All Rights Reserved.</p>
                    <!-- End .footer-copyright -->
                    <ul class="footer-menu">
                        <li><a href="#">Terms Of Use</a></li>
                        <li><a href="#">Privacy Policy</a></li>
                    </ul>
                    <!-- End .footer-menu -->

                    <%--<div class="social-icons social-icons-color">
                        <span class="social-label">Social Media</span>
                        <a href="#" class="social-icon social-facebook" title="Facebook" target="_blank"><i class="icon-facebook-f"></i></a>
                        <a href="#" class="social-icon social-twitter" title="Twitter" target="_blank"><i class="icon-twitter"></i></a>
                        <a href="#" class="social-icon social-instagram" title="Instagram" target="_blank"><i class="icon-instagram"></i></a>
                        <a href="#" class="social-icon social-youtube" title="Youtube" target="_blank"><i class="icon-youtube"></i></a>
                        <a href="#" class="social-icon social-pinterest" title="Pinterest" target="_blank"><i class="icon-pinterest"></i></a>
                    </div>--%>
                    <!-- End .soial-icons -->
                </div>
                <!-- End .container -->
            </div>
            <!-- End .footer-bottom -->
        </footer>

        <!-- Mobile Menu -->
        <div class="mobile-menu-overlay"></div>
        <!-- End .mobil-menu-overlay -->

        <div class="mobile-menu-container mobile-menu-light">
            <div class="mobile-menu-wrapper">
                <span class="mobile-menu-close"><i class="icon-close"></i></span>
                <nav class="mobile-nav">
                    <ul class="mobile-menu">
                        <li class="active">
                            <a href="Home.aspx">Home</a>
                        </li>

                        <li runat="server" id="lstHColor">
                            <a href="ViewColorMaster.aspx">View Color</a>
                        </li>
                        <li>
                            <a href="ViewOrderList.aspx">View Order</a>
                        </li>
                        <li>
                            <a href="CustomerInfo.aspx">Customer</a>
                        </li>
                        <li runat="server" id="lstHFavList">
                            <a href="AddFavList.aspx">Favourite List</a>
                        </li>
                        <li runat="server" id="lstHRefrel">
                            <a href="ViewSalesOrderRefrel.aspx">Sales Order Refrel</a>
                        </li>

                    </ul>
                </nav>
                <!-- End .mobile-nav -->

                <div class="social-icons">
                    <a href="#" class="social-icon" target="_blank" title="Facebook"><i class="icon-facebook-f"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Twitter"><i class="icon-twitter"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Instagram"><i class="icon-instagram"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Youtube"><i class="icon-youtube"></i></a>
                </div>
                <!-- End .social-icons -->
            </div>
            <!-- End .mobile-menu-wrapper -->
        </div>
        <!-- End .mobile-menu-container -->
    </form>
    <div class="loading" align="center">
        <img src="images/amw.gif" width="100" />
    </div>



    <!-- Plugins JS File -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/jquery.hoverIntent.min.js"></script>
    <script src="assets/js/jquery.waypoints.min.js"></script>
    <script src="assets/js/superfish.min.js"></script>
    <script src="assets/js/owl.carousel.min.js"></script>
    <script src="assets/js/jquery.plugin.min.js"></script>
    <script src="assets/js/jquery.magnific-popup.min.js"></script>
    <script src="assets/js/jquery.countdown.min.js"></script>
    <!-- Main JS File -->
    <script src="assets/js/main.js"></script>
    <script src="assets/js/demos/demo-2.js"></script>
    <script>
        let slideIndex = 0;
        showSlides();

        function showSlides() {
            let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) {
                slideIndex = 1
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace("active1", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active1";
            setTimeout(showSlides, 1600); // Change image every 2 seconds
        }
    </script>

    <script type="text/javascript">
        var modal, loading;
        function ShowProgress() {
            modal = document.createElement("DIV");
            modal.className = "modal";
            document.body.appendChild(modal);
            loading = document.getElementsByClassName("loading")[0];
            loading.style.display = "block";
            var top = Math.max(window.innerHeight / 2 - loading.offsetHeight / 2, 0);
            var left = Math.max(window.innerWidth / 2 - loading.offsetWidth / 2, 0);


        };
        ShowProgress();
    </script>

    <script type="text/javascript">
        window.onload = function () {
            setTimeout(function () {
                document.body.removeChild(modal);
                loading.style.display = "none";
            }, 200); //Delay just used for example and must be set to 0.
        };
    </script>

    <style type="text/css">
        .loading {
            position: fixed;
            left: 0%;
            top: 50%;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background-color: white;
            opacity: .8;
            zoom: 1;
        }
    </style>

</body>
</html>
