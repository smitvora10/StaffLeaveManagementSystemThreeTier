<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="AdminPanel_User_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords"
        content="wrappixel, admin dashboard, html css dashboard, web dashboard, bootstrap 4 admin, bootstrap 4, css3 dashboard, bootstrap 4 dashboard, Ample lite admin bootstrap 4 dashboard, frontend, responsive bootstrap 4 admin template, Ample admin lite dashboard bootstrap 4 dashboard template">
    <meta name="description"
        content="Ample Admin Lite is powerful and clean admin dashboard template, inpired from Bootstrap Framework">
    <meta name="robots" content="noindex,nofollow">
    <title>Ample Admin Lite Template by WrapPixel</title>
    <link rel="canonical" href="https://www.wrappixel.com/templates/ample-admin-lite/" />
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png">
    <!-- Custom CSS -->
    <link href="css/style.min.css" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">User Profile</h2>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphToList" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <div class="container-fluid">
        <!-- ============================================================== -->
        <!-- Start Page Content -->
        <!-- ============================================================== -->
        <br />
        <div class="row mb-2">
            <div class="offset-md-4 col-md-4 alert alert-danger" id="divError" visible="false" runat="server">
                <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-4 col-md-4 alert alert-success" id="divSuccess" visible="false" runat="server">
                <asp:Label ID="lblSuccessMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <!-- Row -->
        <div class="row">
            <!-- Column -->
            <div class="col-lg-4 col-xlg-3 col-md-12">
                <div class="white-box">
                    <div class="user-bg">
                        <asp:Image ID="imgUserPhoto1" Width="100%" Height="100%" runat="server" ImageUrl="" />
                        <div class="overlay-box">
                            <div class="user-content">
                                <a href="javascript:void(0)">
                                    <asp:Image ID="imgUserPhoto" CssClass="rounded-circle" Width="170px" Height="150px" runat="server" ImageUrl="" />
                                </a>

                            </div>
                        </div>
                    </div>
                    <div class="user-btm-box mt-5 d-md-flex">
                        <div class="col-md-12 col-sm-12 text-center">
                            <h1>Admin</h1>
                            <br />
                            <h4>Username : 
                                    <asp:Label ID="lblUsername" runat="server" Style="text-transform: uppercase"></asp:Label></h4>
                            <h5>Email :
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label></h5>
                        </div>

                    </div>
                </div>
            </div>
            <!-- Column -->
            <!-- Column -->
            <div class="col-lg-8 col-xlg-9 col-md-12">
                <div class="card">
                    <div class="card-body">

                        <div class="form-group mb-4">
                            <label class="col-md-12 p-0">User Name</label>
                            <div class="col-md-12 border-bottom p-0">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Add Username"
                                    class="form-control p-0 border-0"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group mb-4">
                            <label for="example-email" class="col-md-12 p-0">Email</label>
                            <div class="col-md-12 border-bottom p-0">
                                <asp:TextBox ID="txtEmail" runat="server" type="email" CssClass="form-control" placeholder="eg:johnathan@admin.com"
                                    class="form-control p-0 border-0"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group mb-4">
                            <label class="col-md-12 p-0">Contact No.</label>
                            <div class="col-md-12 border-bottom p-0">
                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" placeholder="eg:+123 345 678"
                                    class="form-control p-0 border-0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group mb-4">
                            <label class="col-md-12 p-0">Address</label>
                            <div class="col-md-12 border-bottom p-0">
                                <asp:TextBox ID="txtAddress" runat="server" type="email" CssClass="form-control" TextMode="MultiLine" Rows="5"
                                    class="form-control p-0 border-0"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group mb-4">
                            <label class="col-sm-12">Select Country</label>
                            <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control">
                            </asp:DropDownList>

                            <asp:CompareValidator ID="cvCountries" runat="server" ErrorMessage="Select Countries"
                                Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlCountries"
                                Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                            </asp:CompareValidator>

                        </div>
                        <div class="row">
                            <div class="col-md-10">
                                <asp:Label runat="server" Text="Update Your BookCover Photo (Optional)" CssClass="form-control" Font-Bold="True"></asp:Label>
                                <div class="input-group input-group-merge input-group-alternative">


                                    <asp:FileUpload CssClass="form-control custom-file-label" ID="fuUserPhoto" runat="server" />
                                    <asp:Label CssClass="text-danger" ID="lblFileUploadMessge" runat="server"></asp:Label>
                                </div>
                                <asp:RegularExpressionValidator ID="revFileUpload" runat="server" ErrorMessage="Upload Only (.jpeg or .png) File" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.PNG|.jpg|.JPG|.jpeg|.JPEG)$" ForeColor="Red" Display="Dynamic" ValidationGroup="vgUpdate" Font-Size="Small" ControlToValidate="fuUserPhoto"></asp:RegularExpressionValidator>
                            </div>


                        </div>
                        <br />
                        <div class="row">
                            <div class=" form-group col-md-2">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" ValidationGroup="vgSave" OnClick="btnSave_Click" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- Column -->
        </div>
        <!-- Row -->
        <!-- ============================================================== -->
        <!-- End PAge Content -->
        <!-- ============================================================== -->

    </div>

    <!-- All Jquery -->
    <!-- ============================================================== -->
    <script src="plugins/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="plugins/bower_components/popper.js/dist/umd/popper.min.js"></script>
    <script src="bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="js/app-style-switcher.js"></script>
    <!--Wave Effects -->
    <script src="js/waves.js"></script>
    <!--Menu sidebar -->
    <script src="js/sidebarmenu.js"></script>
    <!--Custom JavaScript -->
    <script src="js/custom.js"></script>

</asp:Content>

