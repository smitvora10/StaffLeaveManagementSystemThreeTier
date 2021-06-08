<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="LeaveTypeAddEdit.aspx.cs" Inherits="AdminPanel_LeaveType_LeaveTypeAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnLeaveTypeList" runat="Server" Text="Leave Types List" CssClass="btn btn-primary" OnClick="btnLeaveTypeList_Click" />
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
                    <label>Leave Type</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLeaveType" runat="server" placeholder="Enter Leave Type" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLeaveType" runat="server" ErrorMessage="Enter Leave Type"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtLeaveType" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
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
