<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrderList.aspx.cs" Inherits="HAMARAORDER.ViewOrderList" %>

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


    <link rel="stylesheet" href="assets/css/datepicker.css" type="text/css" />

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
    <%-- <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>--%>


    <style>
        * {
            box-sizing: border-box;
        }

        table th {
            color: #000 !important;
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
            font-family: none !important;
        }

        .fa, .far, .fas {
            /*font-family: "Font Awesome 5 Free";*/
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
<body>
    <form id="form1" runat="server">

        <div class="page-wrapper" style="position: sticky !important; top: 0; background: #fff; z-index: 1; border-bottom: 5px solid #133690;">
            <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

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
                                        <li runat="server" id="LstMColor">
                                            <a href="ViewColorMaster.aspx">View Color</a>
                                        </li>
                                        <li class="megamenu-container active">
                                            <a href="ViewOrderList.aspx">View Order</a>
                                        </li>
                                        <li>
                                            <a href="CustomerInfo.aspx">Customer</a>
                                        </li>
                                        <li runat="server" id="LstMFavList">
                                            <a href="AddFavList.aspx">Favourite List</a>
                                        </li>
                                        <li runat="server" id="lstMRefrel">
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

        <div class="main" style="margin-top: 5%;">
            <div class="page-content">
                <div class="container" style="box-shadow: 2px 3px 9px #4c85c938; padding: 24px; border-radius: 9px; background: #fff; margin-top: 55px;">
                    <div class=" cardMargin">

                        <div style="margin-bottom: 0px!important">
                            <div class="row" style="border-bottom: 2px solid #122364; margin-bottom: 20px;">
                                <div class="col-md-4">
                                    <h4>View Order</h4>
                                </div>
                            </div>

                            <div class="row" style="border: 1px solid #b0b0b0de; border-radius: 7px; margin-bottom: 25px;">
                                <div class="col-md-4">
                                    <label>From Date</label>
                                    <asp:TextBox runat="server" ID="txtfromDate" Text="" CssClass="form-control Newdate" Placeholder="From Date"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>To Date</label>
                                    <asp:TextBox runat="server" ID="txtTodate" Text="" CssClass="form-control Newdate" Placeholder="To Date"></asp:TextBox>
                                </div>

                                <div class="col-md-4" style="padding-top: 42px; margin-bottom: 25px;">
                                    <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_Click" Style="padding: 10px; border: 1px solid #3179c6; background: #3179c6; margin-right: 10px; color: #fff;"><i class="fa fa-search" style="color:white"></i> <span>Search</span> </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkButton2" OnClick="btnExport_Click" Style="padding: 10px; border: 1px solid #3179c6; background: #3179c6; color: #fff;"><i class="fa fa-file-excel-o" style="color:white; padding-right: 7px;"></i><span>Export To Excel</span> </asp:LinkButton>
                                </div>
                            </div>

                            <div class="container">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="tab" role="tabpanel">
                                            <!-- Nav tabs -->
                                            <ul class="nav nav-tabs" role="tablist">
                                                <li role="presentation" class="" runat="server" id="lstAll">
                                                    <asp:LinkButton runat="server" ID="btnsection1" OnClick="btnsection1_Click" autopostback="true">ALL</asp:LinkButton>
                                                </li>
                                                <li role="presentation" class="" runat="server" id="lstPending">
                                                    <asp:LinkButton runat="server" ID="bntSection2" OnClick="bntSection2_Click" autopostback="true">PENDING</asp:LinkButton></li>
                                                <li role="presentation" class="" runat="server" id="lstcomplete">
                                                    <asp:LinkButton runat="server" ID="btnsection3" OnClick="btnsection3_Click" autopostback="true">COMPLETE</asp:LinkButton></li>
                                            </ul>
                                            <!-- Tab panes -->
                                            <div class="tab-content tabs">

                                                <div role="tabpanel" class="tab-pane active" id="Section1" runat="server">

                                                    <div class="row  rowMargin table-responsive">
                                                        <asp:GridView ID="grdAHeader" runat="server" DataKeyNames="Id"
                                                            AutoGenerateColumns="false" OnRowDataBound="gvHeader_RowDataBound" OnRowCommand="grdAHeader_RowCommand" Width="100%" HeaderStyle-BackColor="#bfe3f9" HeaderStyle-Height="20px" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <a href="JavaScript:divexpandcollapse('div<%# Eval("Id") %>');">
                                                                            <img id="imgdiv<%# Eval("Id") %>" style="width: 30px" border="0" src="images/Plus.png" />

                                                                        </a>
                                                                        <asp:Label runat="server" ID="lblid" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="OrderNumber" HeaderText="Order Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToParty" HeaderText="ShipTo Party" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToPlant" HeaderText="ShipTo Plant" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />


                                                                <asp:BoundField DataField="SalesGroup" HeaderText="Sales Group" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="LPONumber" HeaderText="LPO Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:BoundField DataField="SiteName" HeaderText="Site Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:TemplateField HeaderText="DeliveryDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lbldeliveryDate" Text='<%# Eval("DeliveryDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Name" HeaderText="REFERAL" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="SAP_NUMBER" HeaderText="SAP Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderType" HeaderText="Order Type" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderValue" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="SAPStatus" HeaderText="SAPStatus" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="FStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:TemplateField HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="btnedit" CommandArgument='<%# Eval("Id") %>' CommandName="lnkDownload"  Text='<%# Eval("Filename") %>' ToolTip="Download Attachment" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td colspan="999">
                                                                                <div id="div<%# Eval("Id") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                                    <asp:GridView ID="grdADetails" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#bfe3f9" EditRowStyle-Height="20px">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ProductCode" HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductQty" HeaderText="Qty" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="UOM" HeaderText="UOM" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ORD_VAL" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="SAPSTAUST" HeaderText="SAP Status" HeaderStyle-HorizontalAlign="Left" />

                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                </div>

                                                <div role="tabpanel" class="tab-pane active" id="Section2" runat="server">

                                                    <div class="row  rowMargin table-responsive">
                                                        <asp:GridView ID="grdHPending" runat="server" DataKeyNames="Id"
                                                            AutoGenerateColumns="false" OnRowDataBound="grdHPending_RowDataBound" OnRowCommand="grdHPending_RowCommand" Width="100%" HeaderStyle-BackColor="#bfe3f9" HeaderStyle-Height="20px" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                                            <Columns>
                                                                <asp:TemplateField>

                                                                    <HeaderTemplate>

                                                                        <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />

                                                                    </HeaderTemplate>

                                                                    <ItemTemplate>

                                                                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="Check_Click(this)" />


                                                                    </ItemTemplate>

                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <a href="JavaScript:divexpandcollapse2('Pdiv<%# Eval("Id") %>');">
                                                                            <img id="imgPdiv<%# Eval("Id") %>" style="width: 30px" border="0" src="images/Plus.png" />

                                                                        </a>
                                                                        <asp:Label runat="server" ID="lblid" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="OrderNumber" HeaderText="Order Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToParty" HeaderText="ShipTo Party" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToPlant" HeaderText="ShipTo Plant" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:BoundField DataField="SalesGroup" HeaderText="Sales Group" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="LPONumber" HeaderText="LPO Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:BoundField DataField="SiteName" HeaderText="Site Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lbldeliveryDate" Text='<%# Eval("DeliveryDate") %>'></asp:Label>
                                                                          <asp:Label runat="server" ID="lblAddedBy" Text='<%# Eval("AddedBy") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Name" HeaderText="REFERAL" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="SAP_NUMBER" HeaderText="SAP Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderType" HeaderText="Order Type" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderValue" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="IStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="FStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:TemplateField HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="btnedit" CommandArgument='<%# Eval("Id") %>' CommandName="lnkDownload"  Text='<%# Eval("Filename") %>' ToolTip="Download Attachment" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td colspan="999">
                                                                                <div id="Pdiv<%# Eval("Id") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                                    <asp:GridView ID="grdDPending" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#026099" EditRowStyle-Height="20px">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ProductCode" HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductQty" HeaderText="Qty" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="UOM" HeaderText="UOM" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ORD_VAL" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="SAPSTAUST" HeaderText="SAP Status" HeaderStyle-HorizontalAlign="Left" />

                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        <div class="col-md-12" style="margin-top: 20px">
                                                            <asp:Button runat="server" ID="btnSubmit" Text="Approve" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>

                                                </div>

                                                <div role="tabpanel" class="tab-pane active" id="Section3" runat="server">

                                                    <div class="row  rowMargin table-responsive">
                                                        <asp:GridView ID="grdHComplete" runat="server" DataKeyNames="Id"
                                                            AutoGenerateColumns="false" OnRowDataBound="grdHComplete_RowDataBound" OnRowCommand="grdHComplete_RowCommand" Width="100%" HeaderStyle-BackColor="#bfe3f9" HeaderStyle-Height="20px" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <a href="JavaScript:divexpandcollapse3('Cdiv<%# Eval("Id") %>');">
                                                                            <img id="imgCdiv<%# Eval("Id") %>" style="width: 30px" border="0" src="images/Plus.png" />

                                                                        </a>
                                                                        <asp:Label runat="server" ID="lblid" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="OrderNumber" HeaderText="Order Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerCode" HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToParty" HeaderText="ShipTo Party" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="ShipToPlant" HeaderText="ShipTo Plant" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:BoundField DataField="SalesGroup" HeaderText="Sales Group" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="LPONumber" HeaderText="LPO Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:BoundField DataField="SiteName" HeaderText="Site Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lbldeliveryDate" Text='<%# Eval("DeliveryDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Name" HeaderText="REFERAL" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="SAP_NUMBER" HeaderText="SAP Number" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderType" HeaderText="Order Type" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="OrderValue" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="IStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:BoundField DataField="FStatus" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" ControlStyle-ForeColor="White" />
                                                                <asp:TemplateField HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="btnedit" CommandArgument='<%# Eval("Id") %>' CommandName="lnkDownload"  Text='<%# Eval("Filename") %>' ToolTip="Download Attachment" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td colspan="999">
                                                                                <div id="Cdiv<%# Eval("Id") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                                    <asp:GridView ID="grdDComplete" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-BackColor="#026099" EditRowStyle-Height="20px">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ProductCode" HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ProductQty" HeaderText="Qty" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="UOM" HeaderText="UOM" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="ORD_VAL" HeaderText="Order Value" HeaderStyle-HorizontalAlign="Left" />
                                                                                            <asp:BoundField DataField="SAPSTAUST" HeaderText="SAP Status" HeaderStyle-HorizontalAlign="Left" />

                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                        <li runat="server" id="lstColor">
                            <a href="ViewColorMaster.aspx">View Color</a>
                        </li>
                        <li class="megamenu-container active">
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
                </nav>
                <!-- End .mobile-nav -->


                <!-- End .social-icons -->
            </div>
            <!-- End .mobile-menu-wrapper -->
        </div>

        <footer class="footer footer-2">

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
                        <li class="megamenu-container active">
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


    <style>
        .row-box {
            background: #fff;
            padding: 15px;
            border-radius: 8px;
            box-shadow: 3px 5px 7px #cccccc3d;
        }

        th {
            text-align: left;
            height: 20px;
            padding: 17px;
            color: #000;
            text-align: center;
        }

        td {
            text-align: center;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "images/minus.jpg";
            } else {
                div.style.display = "none";
                img.src = "images/Plus.png";
            }
        }
        function divexpandcollapse2(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "images/minus.jpg";
            } else {
                div.style.display = "none";
                img.src = "images/Plus.png";
            }
        }
        function divexpandcollapse3(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('Cimg' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "images/minus.jpg";
            } else {
                div.style.display = "none";
                img.src = "images/Plus.png";
            }
        }
    </script>

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
    <script type="text/javascript">
        $(function () {
            $('.Newdate').datepicker({
                format: "dd/mm/yyyy"
            });
        });
    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>


   

    <script type="text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }

                    else {
                        inputList[i].checked = false;
                    }

                }

            }

        }
        function Check_Click(objRef) {

            //Get the Row based on checkbox

            var row = objRef.parentNode.parentNode;
            //Get the reference of GridView
            var GridView = row.parentNode;
            //Get all input elements in Gridview

            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {

                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;

                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }
    </script>


</body>
</html>
