<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesOrderRefrel.aspx.cs" Inherits="HAMARAORDER.ViewSalesOrderRefrel" %>

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

        span {
            font-family: "Open Sans Semibold";
        }

        .table th, .table td {
            padding: 13px;
            padding-bottom: 0.4rem;
            color: #fff;
        }

        .table td {
            padding: 13px;
            padding-bottom: 0.4rem;
            color: #000;
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
</head>
<body style="background: url(assets/images/background-new.jpg); background-size: cover; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
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
                                        <li >
                                            <a href="Home.aspx" class="sf-with-ul">Home</a>
                                            <!-- End .megamenu -->
                                        </li>
                                        <li runat="server" id="lstColor">
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
                                        <li runat="server" id="lstRefrel" class="active">
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
        <div class="main">
            <div class="page-content">
                <div class="container" style="box-shadow: 2px 3px 9px #4c85c938; padding: 24px; border-radius: 9px; background: #fff; margin-top: 55px;">
                    <div class="row" style="border-bottom: 2px solid #122364; margin-bottom: 10px;">
                        <div class="col-md-4">
                            <h4 style="color: #151f78;">View Sales Order Referral</h4>
                        </div>
                        <div class="col-md-4" style="text-align: right">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-4">

                            <asp:LinkButton runat="server" ID="btnSearch" CssClass="btn btn-primary"><i class="fa fa-search" style="color:white"> <span>Search</span> </i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click"><i class="fa fa-plus" style="color:white"> <span>Add New</span>  </i></asp:LinkButton>
                        </div>


                    </div>


                    <div class="table-responsive" style="overflow-y: hidden;">

                        <asp:GridView ID="gvSalesOrder" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                            EmptyDataText="No Records Found..!" CssClass="table table-bordered table-hover table-checkable mb-0" AllowPaging="true" PageSize="10"
                            HeaderStyle-BackColor="#026099" HeaderStyle-ForeColor="White"
                            OnRowCommand="gvSalesOrder_RowCommand" OnRowEditing="gvSalesOrder_RowEditing" OnPageIndexChanging="gvSalesOrder_PageIndexChanging">

                            <Columns>


                                <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="50px" HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblsrno" Text='<%#Eval("ROWNUMBER") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Buyer Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblBuyer" Text='<%#Eval("Buyer Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="GSTN" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGSTIN" Text='<%#Eval("GSTN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Name" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblContactName" Text='<%#Eval("Contact_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumber" Text='<%#Eval("Contact_No") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email ID" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLocation" Text='<%#Eval("Location") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PIN Code" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPincode" Text='<%#Eval("PIN_Code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("Id") %>'><i class=" fa fa-edit"></i> </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View" CommandArgument='<%#Eval("Id") %>'><i class=" fa fa-eye"></i> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </div>

                </div>

            </div>

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
                        <li >
                            <a href="index.html">Home</a>
                        </li>
                        <li runat="server" id="lstHColor">
                            <a href="ViewColorMaster.aspx">View Color</a>
                        </li>
                        <li >
                            <a href="ViewOrderList.aspx">View Order</a>
                        </li>
                        <li>
                            <a href="CustomerInfo.aspx">Customer</a>
                        </li>
                        <li runat="server" id="lstHFavList">
                            <a href="AddFavList.aspx">Favourite List</a>
                        </li>
                        <li runat="server" id="lstHRefrel" class="active">
                            <a href="ViewSalesOrderRefrel.aspx">Sales Order Refrel</a>
                        </li>

                    </ul>
                </nav>
                <!-- End .mobile-nav -->


                <!-- End .social-icons -->
            </div>
            <!-- End .mobile-menu-wrapper -->
        </div>

        <footer class="footer footer-2" style="position: absolute;">
            <!-- End .footer-middle -->
            <div class="footer-bottom">
                <div class="container">
                    <p class="footer-copyright">Copyright © 2022 Crystaldata Software Services. All Rights Reserved.</p>
                    <!-- End .footer-copyright -->
                    <ul class="footer-menu">
                        <li><a href="#">Terms Of Use</a></li>
                        <li><a href="#">Privacy Policy</a></li>
                    </ul>
                </div>

            </div>

        </footer>

        <!-- Mobile Menu -->
        <div class="mobile-menu-overlay"></div>
        <!-- End .mobil-menu-overlay -->

        <div class="mobile-menu-container mobile-menu-light">
            <div class="mobile-menu-wrapper">
                <span class="mobile-menu-close"><i class="icon-close"></i></span>



                <nav class="mobile-nav">
                    <ul class="mobile-menu">
                        <li >
                            <a href="Home.aspx">Home</a>


                        </li>
                        <li runat="server" id="LstMColor">
                            <a href="ViewColorMaster.aspx">View Color</a>
                        </li>
                        <li>
                            <a href="ViewOrderList.aspx">View Order</a>
                        </li>
                        <li>
                            <a href="CustomerInfo.aspx">Customer</a>
                        </li>
                        <li runat="server" id="LstMFavList">
                            <a href="AddFavList.aspx">Favourite List</a>
                        </li>
                        <li runat="server" id="lstMRefrel" class="active">
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
</body>
</html>
