<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOrderRefrel.aspx.cs" Inherits="HAMARAORDER.SalesOrderRefrel" %>

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
    <link rel="stylesheet" href="assets/css/stylebundle.css" />
    <link rel="stylesheet" href="assets/css/style.css" />
    <link rel="stylesheet" href="assets/css/skins/skin-demo-2.css" />
    <link rel="stylesheet" href="assets/css/demos/demo-2.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

    <style>
        body {
            font-family: "Open Sans Semibold" !important;
        }


        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 700;
            padding-left: 0px;
            padding-top: 4px;
            font-weight: normal;
            font-weight: normal;
            font-family: "Open Sans Semibold";
        }

        .row-box {
            background: #fff;
            padding: 15px;
            border-radius: 8px;
            box-shadow: 3px 5px 7px #cccccc3d;
        }

        span {
            font-family: "Open Sans Semibold";
        }
    </style>



    <script language="Javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

    </script>

</head>
<body >  <%--style="background: url(assets/images/background-new.jpg); background-size: cover; background-repeat: no-repeat;"--%>
    <form id="form1" runat="server">
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
                                                                            <img src='https://www.crystaldatainc.com/pidilite-img/<%# Eval("ImageName") %>' onerror="imgError2(this)" alt="Product image" class="product-image" style="max-height: 150px">
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
                                        <li>
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
                                        <li runat="server" id="lstRefrel" class="megamenu-container active">
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

            <div class="main">
                <div class="page-content">
                    <div class="container" style="box-shadow: 2px 3px 9px #4c85c938; padding: 24px; border-radius: 9px; background: #fff; margin-top: 55px;">


                        <div class="row" style="border-bottom: 2px solid #122364; margin-bottom: 10px;">
                            <asp:Label runat="server" ID="lblId" Text="" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblHexaCode" Text="" Style="display: none"></asp:Label>
                            <asp:Label runat="server" ID="lblUserName" Text="" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblUserCode" Text="" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblUserType" Text="" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblUserEmail" Text="" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblUserId" Text="" Visible="false"></asp:Label>



                            <div class="col-md-10">
                                <h4 style="color: #151f78;">Add Order Referral</h4>
                            </div>
                            <div class="col-md-2" style="text-align: right;">
                                <asp:LinkButton runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click"><i class="fa fa-eye" style="color:white"> <span class="ml-3">View Order Refrel</span></i></asp:LinkButton>
                                <%--<a href="ViewColorMaster.aspx" class="btn btn-primary"><i class="fa fa-eye" style="color: white"><span>View Color</span></i></a>--%>
                            </div>

                        </div>
                        <div class="row rowMargin">

                            <div class="col-md-4">
                                <label class="lableclass2">Name </label>
                                <asp:TextBox ID="txtName" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Please Enter a Name" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">Buyer Name </label>
                                <asp:TextBox ID="txtBuyerName" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBuyerName"
                                    ErrorMessage="Please Enter a Buyer Name" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">GSTN </label>
                                <asp:TextBox ID="txtGSTN" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGSTN"
                                    ErrorMessage="Please Enter a GSTN" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">Contact Name </label>
                                <asp:TextBox ID="txtContact_Name" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContact_Name"
                                    ErrorMessage="Please Enter a Conatct Name" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">Contact No </label>
                                <asp:TextBox ID="txtContact_No" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContact_No"
                                    ErrorMessage="Please Enter a Contact No" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">Email_ID</label>
                                <asp:TextBox ID="txtEmail_ID" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail_ID"
                                    ErrorMessage="Please Enter a Email Id" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">City </label>
                                <asp:TextBox ID="txtCity" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="Please Enter a City" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="Label8" Text="" Style="display: none;"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">Location </label>
                                <asp:TextBox ID="txtLocation" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLocation"
                                    ErrorMessage="Please Enter a Location" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-4">
                                <label class="lableclass2">PIN Code</label>
                                <asp:TextBox ID="txtPIN_Code" runat="server" Text="" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPIN_Code"
                                    ErrorMessage="Please Enter a PinCode" Display="None" ValidationGroup="Valid1"></asp:RequiredFieldValidator>

                            </div>



                            <br />
                            <div class="col-md-12 rowMargin" style="text-align: left; margin-top: 20px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Valid1" ShowMessageBox="true" ShowSummary="false" />
                                <asp:Button runat="server" ID="btnAdd" Text="Save" CssClass="btn btn-primary" ValidationGroup="Valid1" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>

                        </div>
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
                        <li>
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
                        <li runat="server" id="lstMRefrel" class="megamenu-container active">
                            <a href="ViewSalesOrderRefrel.aspx">Sales Order Refrel</a>
                        </li>

                    </ul>
                </nav>
                <!-- End .mobile-nav -->

                <%--<div class="social-icons">
                    <a href="#" class="social-icon" target="_blank" title="Facebook"><i class="icon-facebook-f"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Twitter"><i class="icon-twitter"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Instagram"><i class="icon-instagram"></i></a>
                    <a href="#" class="social-icon" target="_blank" title="Youtube"><i class="icon-youtube"></i></a>
                </div>--%>
                <!-- End .social-icons -->
            </div>
            <!-- End .mobile-menu-wrapper -->
        </div>

        <footer class="footer footer-2" style="position: absolute; bottom: 0;">

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
                        <li>
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
                        <li runat="server" id="lstHRefrel" class="megamenu-container active">
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
