<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="AdminPanel_Dashboard_Dashboard" %>

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

    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png">
    <!-- Custom CSS -->
    <link href="plugins/bower_components/chartist/dist/chartist.min.css" rel="stylesheet">
    <link rel="stylesheet" href="plugins/bower_components/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.css">
    <!-- Custom CSS -->
    <link href="css/style.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">Dashboard</h2>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphToList" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" runat="Server">
    <!-- Container fluid  -->
    <!-- ============================================================== -->
    <div class="container-fluid">
        <!-- ============================================================== -->
        <!-- Three charts -->
        <!-- ============================================================== -->
        <style type="text/css">
            .hover-item:hover {
                /*transition: 0.3s ease-out;*/
                /*box-shadow: 0px 4px 8px rgba(238, 238, 238, 0.4);*/
                /*top: -4px;*/
                /*border: 1px solid #cccccc;*/
                box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);
                background-color: #F3F3F3;
            }
        </style>
        <div class="row justify-content-center">
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../Country/CountryList.aspx"><span style="color: black;">Countries</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-flag" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-success">
                            <asp:Label ID="lblCountries" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../State/StateList.aspx"><span style="color: black;">States</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-industry" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-purple">
                            <asp:Label ID="lblStates" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../City/CityList.aspx"><span style="color: black;">Cities</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-home" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-info">
                            <asp:Label ID="lblCities" runat="server" Text="Label"></asp:Label></span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../Company/CompanyList.aspx"><span style="color: black;">Companies</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-building" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-purple">
                            <asp:Label ID="lblCompanies" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../Employee/EmployeeList.aspx"><span style="color: black;">Employees</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-male" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-danger">
                            <asp:Label ID="lblEmployees" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../Department/DepartmentList.aspx"><span style="color: black;">Departments</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-users" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-info">
                            <asp:Label ID="lblDepartments" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>

        </div>
        <div class="row justify-content-center">
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../Designation/DesignationList.aspx"><span style="color: black;">Designations</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-id-card" style="font-size: 30px" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-success">
                            <asp:Label ID="lblDesignations" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-4 col-sm-6 col-xs-12">
                <div style="box-shadow: 0 0 0.5rem 0 rgba(136, 152, 170, .60);" class="white-box analytics-info rounded hover-item">
                    <h3 class="box-title"><a href="../LeaveType/LeaveTypeList.aspx"><span style="color: black;">Leave Types</span></a></h3>
                    <ul class="list-inline two-part d-flex align-items-center mb-0">
                        <li>
                            <i class="fas fa-sign-out-alt" style="font-size: 30px" aria-hidden="true"></i>
                            <i class="fa fa-user" aria-hidden="true"></i>
                        </li>
                        <li class="ml-auto"><span class="counter text-purple">
                            <asp:Label ID="lblLeaveTypes" runat="server" Text="Label"></asp:Label></span></li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
    <!-- ============================================================== -->
    <!-- End Container fluid  -->
    <!-- ============================================================== -->


    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- All Jquery -->
    <!-- ============================================================== -->
    <script src="plugins/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="plugins/bower_components/popper.js/dist/umd/popper.min.js"></script>
    <script src="bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="js/app-style-switcher.js"></script>
    <script src="plugins/bower_components/jquery-sparkline/jquery.sparkline.min.js"></script>
    <!--Wave Effects -->
    <script src="js/waves.js"></script>
    <!--Menu sidebar -->
    <script src="js/sidebarmenu.js"></script>
    <!--Custom JavaScript -->
    <script src="js/custom.js"></script>
    <!--This page JavaScript -->
    <!--chartis chart-->
    <script src="plugins/bower_components/chartist/dist/chartist.min.js"></script>
    <script src="plugins/bower_components/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.min.js"></script>
    <script src="js/pages/dashboards/dashboard1.js"></script>
</asp:Content>





