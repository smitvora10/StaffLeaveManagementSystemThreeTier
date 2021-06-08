<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Login_LoginPage" %>

<!DOCTYPE html>
  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Leave Management System</title>
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
                    <h2 class="text-center">Staff Leave Management System <br /><br /></h2>
                    <span class="login100-form-title">Account Login
                    </span>
                    <asp:Label ID="lblErrorMessage" CssClass="form-control text-center border-0 text-danger" runat="server"></asp:Label>
                    <asp:Label ID="lblSuccessMessage" CssClass="form-control text-center border-0 text-success" runat="server"></asp:Label>
                    <div class="wrap-input100 validate-input">
                        <asp:TextBox runat="server" ID="txtUsername" CssClass="input100" placeholder="Username"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Enter Username" CssClass="text-danger" ControlToValidate="txtUsername" Display="Dynamic" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                    </div>

                    <div class="wrap-input100 rs1 validate-input" data-validate="Password is required">
                        <asp:TextBox runat="server" CssClass="input100" type="password" ID="txtPassword" placeholder="Password"></asp:TextBox>
                        <span class="focus-input100-1"></span>
                        <span class="focus-input100-2"></span>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter the Password" CssClass="text-danger" ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                    </div>

                    <div class="container-login100-form-btn m-t-20">
                        <asp:Button runat="server" CssClass="login100-form-btn"  ValidationGroup="vgLogin" Text="Login" ID="btnLogin" OnClick="btnLogin_Click" />
                    </div>

                    <div class="text-center p-t-45 p-b-4">
                        <asp:LinkButton runat="server" Enabled="false" CssClass="txt1" Text="Don't Have An Account?"></asp:LinkButton>
                        <asp:LinkButton runat="server" Enabled="true" ID="lbSignUp" OnClick="lbSignUp_Click" CssClass="txt2 hov1" Text="Sign up"></asp:LinkButton>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
