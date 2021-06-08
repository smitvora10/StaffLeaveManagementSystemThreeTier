<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToList" runat="Server">
    <asp:Button ID="btnCountryList" runat="Server" Text="Country List" CssClass="btn btn-primary" OnClick="btnCountryList_Click" />
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
                <asp:label id="lblErrorMessage" runat="server" text=""></asp:label>
            </div>
        </div>
        <div class="row mb-2">
            <div class="offset-md-4 col-md-4 alert alert-success" id="divSuccess" visible="false" runat="server">
                <asp:label id="lblSuccessMessage" runat="server" text=""></asp:label>
            </div>
        </div>
        <br />
        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Country</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCountryName" runat="server" placeholder="Enter Country Name" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ErrorMessage="Enter Country Name"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtCountryName" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Code</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtCode" runat="server" placeholder="Enter Code" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="Enter Code" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtCode" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-md-1 offset-4">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" ValidationGroup="vgSave" OnClick="btnSave_Click" />
            </div>
            <div>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

