<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="EmployeeAddEdit.aspx.cs" Inherits="AdminPanel_Employee_EmployeeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnEmployeeList" runat="Server" Text="Employee List" CssClass="btn btn-primary" OnClick="btnEmployeeList_Click"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">
            <asp:Label ID="lblPageHeaderText" runat="server">
            </asp:Label></h2>
    </div>
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
                    <label>Employee Name</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmployeeName" runat="server" placeholder="Enter Employee Name" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ErrorMessage="Enter Employee Name" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtEmployeeName" ValidationGroup="vgSave"></asp:RequiredFieldValidator>

            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Employee Code</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmployeeCode" runat="server" placeholder="Enter Employee Code" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmployeeCode" runat="server" ErrorMessage="Enter Employee Code" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmployeeCode" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Department</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlDepartmentName" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvDepartmentName" runat="server" ErrorMessage="Select Department"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlDepartmentName"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>

            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Designation</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlDesignationName" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvDesignationName" runat="server" ErrorMessage="Select Designation"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlDesignationName"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>

            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Employment Type</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlEmploymentType" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Employment Type" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Permanent Employee" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Casual Employee" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Apprentice Employee" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Labour Hire" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Contractor Or Subtractor" Value="5"></asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="cvEmploymentType" runat="server" ErrorMessage="Select Employment Type"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlEmploymentType"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>

            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Address</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" TextMode="MultiLine" CssClass="form-control" Rows="4"></asp:TextBox>
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
                <asp:RequiredFieldValidator ID="rvContactNo" runat="server" ErrorMessage="Enter Contact No."
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactNo" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Joining Date</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtJoiningDate" runat="server" placeholder="Enter Joining Date" CssClass="form-control" type="date"  ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvJoiningDate" runat="server" ErrorMessage="Enter Joining Date" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtJoiningDate" ValidationGroup="vgSave"></asp:RequiredFieldValidator>


            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Birth Date</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtBirthDate" runat="server" placeholder="Enter Birth Date" CssClass="form-control" type="date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ErrorMessage="Enter Birth Date" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtBirthDate" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
              
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    
                    <label>Marital Status</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Marital Status" Value="0"></asp:ListItem>
                    <asp:ListItem Value="1">Married</asp:ListItem>
                    <asp:ListItem Value="2">Unmarried</asp:ListItem>
                </asp:DropDownList>
                

            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Email</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvEmail" runat="server" ErrorMessage="Enter Email"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
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
                <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged">
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
                <asp:DropDownList ID="ddlStateName" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged">
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

        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" ValidationGroup="vgSave" OnClick="btnSave_Click" />
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger"  OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>

