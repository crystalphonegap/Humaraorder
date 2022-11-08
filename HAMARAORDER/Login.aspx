<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HAMARAORDER.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base href="../../../" />
    <meta charset="utf-8" />
    <title>HAMARA ORDER</title>
    <meta name="description" content="Login" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!--begin::Fonts -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />
    <link href="assets/css/pages/login/login-6.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Layout Skins -->
    <link rel="shortcut icon" href="assets/media/logos/favicon.ico" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>

    <style>
        a:hover,
        a:focus {
            text-decoration: none;
            outline: none;
        }

        .tab {
            font-family: 'Montserrat', sans-serif;
        }

            .tab .nav-tabs {
                padding: 0 5px;
                margin: 0;
                border: none;
            }

                .tab .nav-tabs li a {
                    color: #000;
                    background: #fff;
                    font-size: 16px;
                    font-weight: 400;
                    letter-spacing: 0.5px;
                    text-transform: capitalize;
                    text-align: center;
                    padding: 10px 36px;
                    margin: 0 0px 0 0;
                    border-radius: 3px;
                    border: none;
                    position: relative;
                    z-index: 1;
                    transition: all 0.5s ease 0s;
                }

                    .tab .nav-tabs li.active a,
                    .tab .nav-tabs li a:hover,
                    .tab .nav-tabs li.active a:hover {
                        color: #fff;
                        background: transparent;
                        border: none;
                    }

                    .tab .nav-tabs li a:before,
                    .tab .nav-tabs li a:after {
                        content: '';
                        background-color: #044990;
                        height: 100%;
                        width: 100%;
                        transform-origin: left center;
                        transform: scaleX(0);
                        position: absolute;
                        left: 0;
                        top: 0;
                        z-index: -1;
                        transition: all 0.3s ease-out 0s;
                    }

                    .tab .nav-tabs li a:after {
                        background-color: #044990;
                        transform-origin: right center;
                    }

                    .tab .nav-tabs li a:hover:before,
                    .tab .nav-tabs li.active a:before,
                    .tab .nav-tabs li.active a:hover:before,
                    .tab .nav-tabs li a:hover:after,
                    .tab .nav-tabs li.active a:after,
                    .tab .nav-tabs li.active a:hover:after {
                        opacity: 0.7;
                        transform: scaleX(1);
                    }

        .wsss {
            float: left;
        }



        .fade:not(.show) {
            opacity: 1;
        }

        .tab .tab-content {
            color: #555;
            font-size: 13px;
            font-weight: 500;
            letter-spacing: 1px;
            line-height: 25px;
            padding: 1px 20px 10px;
        }

        .login-bg-col {
            background-image: url(assets/media/logos/bg2.png);
            background-size: cover;
            background-repeat: no-repeat;
            width: 100%;
        }


        .login-bg-up {
            background-image: url(assets/media/logos/pdlt.png);
            background-size: cover;
            background-repeat: no-repeat;
            width: 100%;
        }


        @media only screen and (max-width: 479px) {
            .tab .nav-tabs {
                padding: 0;
                margin: 0 0 5px;
            }

                .tab .nav-tabs li {
                    width: 100%;
                    text-align: center;
                    float: left;
                }

                    .tab .nav-tabs li a {
                        margin: 0 0 10px;
                    }
        }


        @media only screen and (min-width: 320px) {
            .tab .nav-tabs {
                padding: 0;
                margin: 0 0 5px;
            }

                .tab .nav-tabs li {
                    width: 100%;
                    text-align: center;
                    float: left;
                }

                    .tab .nav-tabs li a {
                        margin: 0 0 10px;
                    }
        }
    </style>

</head>

<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--transparent kt-aside--enabled kt-aside--fixed kt-page--loading">

    <form id="form1" runat="server" class="kt-grid kt-grid--ver kt-grid--root kt-page">

        <asp:Label runat="server" ID="lblPasswordEncry" Text="" Visible="false"></asp:Label>
        <!-- begin:: Page -->
        <asp:ScriptManager runat="server" EnablePartialRendering="true" ID="ScriptManger1"></asp:ScriptManager>
        <div class="kt-grid kt-grid--hor kt-grid--root  kt-login kt-login--v6 kt-login--signin" id="kt_login">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--desktop kt-grid--ver-desktop kt-grid--hor-tablet-and-mobile login-bg-col">
                <div class="kt-grid__item kt-grid__item--fluid kt-grid__item--center kt-grid kt-grid--ver kt-login__content login-bg-up ">
                    <div class="kt-login__section">
                        <div class="kt-login__block" style="margin-top: 25%; border-left: 10px solid #3fffff;">
                            <h3 class="kt-login__title">Connecting Customers</h3>





                        </div>
                    </div>


                </div>
                <div class="kt-grid__item  kt-grid__item--order-tablet-and-mobile-2  kt-grid kt-grid--hor kt-login__aside" style="background: linear-gradient(178deg, #dde8f9, white);">
                    <div class="kt-login__wrapper">
                        <div class="kt-login__container">
                            <div class="kt-login__body">


                                <div class="kt-login__head mb-5">
                                    <h3 class="kt-login__title">
                                        <img src="assets/media/logos/hamaraorder.png" width="100%" /></h3>
                                </div>

                                <div style="margin-left: 30px;">
                                    <ul class="nav nav-tabs float_left" role="tablist">
                                        <li class="wsss " runat="server" id="list1">
                                            <asp:LinkButton runat="server" ID="lnkSection1" OnClick="lnkSection1_Click">User Code</asp:LinkButton>
                                        </li>
                                        <li class="wsss" runat="server" id="list2">
                                            <asp:LinkButton runat="server" ID="lnkBtnSection2" OnClick="lnkBtnSection2_Click">Email Id</asp:LinkButton></li>
                                    </ul>
                                </div>
                                <div class="tab" role="tabpanel">
                                    <!-- Nav tabs -->
                                    <!-- Tab panes -->
                                    <div class="tab-content tabs">
                                        <div id="Section1" runat="server">

                                            <div class="kt-login__signin">

                                                <div class="kt-login__form" id="divotp">
                                                    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                                    <div class="kt-form" style="padding: 10px;">
                                                        <div class="form-group mb-4">
                                                            <lable style="font-size: 14px;">Enter User Code</lable>
                                                            <asp:TextBox ID="txtUsercode" Style="border: 1px solid #388bb8; border-radius: 7px; padding: 5px; background: #fff;" CssClass="form-control" runat="server" placeholder="Enter User Code" name="email" autocomplete="off"></asp:TextBox>
                                                        </div>
                                                        <div class="" style="text-align: right; float: right; font-weight: bold;">
                                                            <asp:LinkButton runat="server" ID="LinkButton1" OnClick="btnGenerateOTP_Click2">Generate OTP</asp:LinkButton>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <lable style="font-size: 14px;">Enter Password</lable>
                                                            <asp:TextBox ID="txtPassword" Style="border: 1px solid #388bb8; border-radius: 7px; padding: 5px; background: #fff;" CssClass="form-control" runat="server" TextMode="Password" placeholder="Enter Password" autocomplete="off" OnTextChanged="txtPassword_TextChanged" AutoPostBack="false"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblSuccess2" Text="OTP generated successfully" Style="color: green; font-weight: bold"></asp:Label>

                                                            <asp:Label runat="server" ID="lblInvalid2" Text="Invalid credentials" Style="color: red; font-weight: bold"></asp:Label>
                                                        </div>

                                                        <div class="kt-login__actions">
                                                            <asp:Button ID="Button1" CssClass="btn btn-brand  btn-elevate row" runat="server" Text="Login" OnClick="BtnLogin_Click" Style="width: 100%; border-radius: 7px;" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <div id="Section2" runat="server">


                                            <div class="kt-login__signin">

                                                <div class="kt-login__form" id="divotp1">
                                                    <asp:Label runat="server"></asp:Label>
                                                    <div class="kt-form" style="padding: 10px;">
                                                        <div class="form-group mb-4">
                                                            <lable style="font-size: 14px;">Email</lable>
                                                            <asp:TextBox Style="border: 1px solid #388bb8; border-radius: 7px; padding: 5px; background: #fff;" CssClass="form-control" runat="server" placeholder="Enter Email" name="email" autocomplete="off" ID="txtEmail"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group" style="text-align: right; float: right; font-weight: bold;">
                                                            <asp:LinkButton runat="server" ID="btnGenerateOTP" OnClick="btnGenerateOTP_Click">Generate OTP</asp:LinkButton>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <lable style="font-size: 14px;">Password/OTP</lable>
                                                            <asp:TextBox runat="server" ID="txtEpass" Style="border: 1px solid #388bb8; border-radius: 7px; padding: 5px; background: #fff;" CssClass="form-control" TextMode="Password" placeholder="Enter Password" MaxLength="10" autocomplete="off" OnTextChanged="txtEpass_TextChanged" AutoPostBack="false"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblSuccess" Text="OTP generated successfully" Style="color: green; font-weight: bold"></asp:Label>
                                                            <asp:Label runat="server" ID="lblInvalid" Text="Invalid credentials" Style="color: red; font-weight: bold"></asp:Label>

                                                        </div>

                                                        <div class="kt-login__actions">
                                                            <asp:Button ID="btnEmailLogin" CssClass="btn btn-brand  btn-elevate row" runat="server" Text="Login" OnClick="btnEmailLogin_Click" Style="width: 100%; border-radius: 7px;" />

                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="kt-login__forgot">
                                        <div class="kt-login__head">
                                            <h3 class="kt-login__title">Forgotten Password ?</h3>
                                            <div class="kt-login__desc">Enter your email to reset your password:</div>
                                        </div>
                                        <div class="kt-login__form">
                                            <div class="kt-form">
                                                <div class="form-group">
                                                    <input class="form-control" type="text" placeholder="Email" name="email" id="kt_email" autocomplete="off" />
                                                </div>
                                                <div class="kt-login__actions">
                                                    <button id="kt_login_forgot_submit" class="btn btn-brand btn-pill btn-elevate">Request</button>
                                                    <button id="kt_login_forgot_cancel1" class="btn btn-outline-brand btn-pill">Cancel</button>
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

            <!-- end:: Page -->
        </div>
    </form>

    <script src="assets/plugins/global/plugins.bundle.js" type="text/javascript"></script>
    <script src="assets/js/pages/custom/login/login-general.js" type="text/javascript"></script>

    <script>
        document.addEventListener('contextmenu', (e) => {
            e.preventDefault();
        }
        );
        document.onkeydown = function (e) {
            if (event.keyCode == 123) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)) {
                return false;
            }
        }
    </script>
</body>
</html>
