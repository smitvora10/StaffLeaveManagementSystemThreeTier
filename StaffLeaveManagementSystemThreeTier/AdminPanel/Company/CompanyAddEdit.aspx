<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="CompanyAddEdit.aspx.cs" Inherits="AdminPanel_Company_CompanyAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnCompanyList" runat="Server" Text="Company List" CssClass="btn btn-primary" OnClick="btnCompanyList_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTitle" runat="Server">
    <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">
        <asp:Label ID="lblPageHeaderText" runat="server">
        </asp:Label></h2>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <div class="container">
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
        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Company Name</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Enter Company Name" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="Enter Company Name" Display="Dynamic" ForeColor="Red" ControlToValidate="txtCompanyName" ValidationGroup="vgSave"></asp:RequiredFieldValidator>

            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>GST NO.</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtGSTNO" runat="server" placeholder="Enter GST NO." CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvGSTNO" runat="server" ErrorMessage="Enter GST No."
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtGSTNO" ValidationGroup="vgSave"></asp:RequiredFieldValidator>

            </div>
        </div>
        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Landmark</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLandmark" runat="server" placeholder="Enter Landmark" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Pincode</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPincode" runat="server" placeholder="Enter Pincode" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ErrorMessage="Enter Correct Pincode" Display="Dynamic"
                    ValidationExpression="[0-9]{6}" ForeColor="Red" ControlToValidate="txtPincode" ValidationGroup="vgSave"></asp:RegularExpressionValidator>

            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Country</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvCountryName" runat="server" ErrorMessage="Select Country"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlCountryName"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>

            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>State</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlStateName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvStateName" runat="server" ErrorMessage="Select State"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlStateName"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>City</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCityName" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvCityName" runat="server" ErrorMessage="Select City"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlCityName"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Contact No.</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactNo" runat="server" placeholder="Enter Contact No." CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Enter Contact No."
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactNo" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ErrorMessage="Enter Correct Contact NO."
                    ValidationExpression="[0-9]{10}" ForeColor="Red" ControlToValidate="txtContactNo" ValidationGroup="vgSave"></asp:RegularExpressionValidator>

            </div>
        </div>



        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Email</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Email"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Website</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtWebsite" runat="server" placeholder="Enter Website" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-md-1 offset-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" ValidationGroup="vgSave" OnClick="btnSave_Click" />
            </div>
            <div>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>

</asp:Content>

