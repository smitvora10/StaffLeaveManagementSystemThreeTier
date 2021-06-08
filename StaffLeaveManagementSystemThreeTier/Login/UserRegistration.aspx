<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="Login_UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="icon" type="image/png" href="~/Login/images/icons/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="~/Login/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Login/css/util.css" />
    <link rel="stylesheet" type="text/css" href="~/Login/css/main.css" />

</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-50">

                <form id="Form1" runat="server" class="login100-form validate-form">
                    <h2 class="text-center">Staff Leave Management System<br />
                        <br />

                    </h2>
                    <span class="login100-form-title">Account Sign Up
                    </span>
                    <br />
                    <div class="row mb-4">
                        <div class="offset-md-4 col-md-6 alert alert-danger" id="divError" visible="false" runat="server">
                            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="offset-md-4 col-md-6 alert alert-success" id="divSuccess" visible="false" runat="server">
                            <asp:Label ID="lblSuccessMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="wrap-input100 validate-input">
                        <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true" OnClick="txtUsername_TextChanged" CssClass="form-control input100" placeholder="Username"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="Username" ValidationGroup="vgSignUp" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                    </div>



                    <div class="wrap-input100 validate-input">
                        <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control input100" placeholder="Contact No."></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Enter Contact No." ControlToValidate="txtContactNo" CssClass="text-danger" Display="Dynamic" ValidationGroup="vgSignUp"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Enter Correct Contact No." ControlToValidate="txtContactNo" CssClass="text-danger" Display="Dynamic" ValidationExpression="[0-9]{10}" ValidationGroup="vgSignUp"></asp:RegularExpressionValidator>
                    </div>

                    <div class="wrap-input100 validate-input">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control input100" placeholder="Email"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtEmail" CssClass="text-danger" Display="Dynamic" ValidationGroup="vgSignUp"></asp:RequiredFieldValidator>

                    </div>

                    <div class="wrap-input100 validate-input">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control input100" placeholder="Address"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>

                    </div>

                    <div class="wrap-input100 validate-input">
                        <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control input100" Height="70px">
                        </asp:DropDownList>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:CompareValidator ID="cvCountries" runat="server" ErrorMessage="Select Countries"
                            Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlCountries"
                            Operator="NotEqual" ValidationGroup="vgSignUp" ValueToCompare="-1">
                        </asp:CompareValidator>
                    </div>

                    <div class="wrap-input100 validate-input">
                        <asp:FileUpload ID="fuUserPhoto" runat="server" Text="Upload Photo" CssClass="form-control"/>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>

                    </div>

                    <div class="wrap-input100 rs1 validate-input" data-validate="Password is required">
                        <asp:TextBox runat="server" CssClass="input100" type="password" ID="txtPassword" placeholder="Password"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="text-danger" Display="Dynamic" ErrorMessage="Enter the Password" ValidationGroup="vgSignUp" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    </div>
                    <div class="wrap-input100 rs1 validate-input" data-validate="Password is required">
                        <asp:TextBox runat="server" CssClass="input100" type="Password" ID="txtRePassword" placeholder="ReType Password"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:CompareValidator ID="cvRePassword" runat="server" ErrorMessage="Password Do not Match" CssClass="text-danger" ControlToValidate="txtRePassword" ControlToCompare="txtPassword" Display="Dynamic" ValidationGroup="vgSignUp"></asp:CompareValidator>
                    </div>

                    <div class="container-login100-form-btn m-t-20">
                        <asp:Button runat="server" ValidationGroup="vgSignUp" CssClass="login100-form-btn" OnClick="btnSignUp_Click" Text="Sign Up" ID="btnSignUp" />
                    </div>

                    <div class="text-center p-t-45 p-b-4">
                        <asp:LinkButton runat="server" Enabled="false" CssClass="txt1" Text="Had an account?"></asp:LinkButton>
                        <asp:LinkButton runat="server" Enabled="true" OnClick="lbLogin_Click" ID="lbLogin" CssClass="txt2 hov1" Text="Login"></asp:LinkButton>
                    </div>
                </form>

            </div>
        </div>
    </div>
</body>
</html>
