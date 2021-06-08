<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="LeaveCreditsAddEdit.aspx.cs" Inherits="AdminPanel_LeaveCredits_LeaveCreditsAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnLeaveCreditsList" runat="Server" Text="Leave Credits List" CssClass="btn btn-primary" OnClick="btnLeaveCreditsList_Click" />
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
        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <label>Employee Code</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlEmployeeCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeCode_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvEmployeeCode" runat="server" ErrorMessage="Select Employee Code"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlEmployeeCode"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">

                    <label>Employee Name</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>

        <br />

        <%--<div class="row">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Leave Type</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvLeaveType" runat="server" ErrorMessage="Select Leave Type"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlLeaveType"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-4 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Leaves Credited</label>
                </span>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLeavesCredited" runat="server" placeholder="Enter Leaves Credited" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLeavesCredited" runat="server" ErrorMessage="Enter Leaves Credited"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtLeavesCredited" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revLeavesCredited" runat="server" ErrorMessage="Enter Correct Leaves Credited"
                    ValidationExpression="[0-9]{2}" ForeColor="Red" ControlToValidate="txtLeavesCredited" ValidationGroup="vgSave"></asp:RegularExpressionValidator>

            </div>
        </div>

        <br />--%>
        <div class="row">
            <div class="col-md-8 offset-md-1 table-responsive">
                <table class="table table-bordered table-hover" style="color:black;">
                    <thead class="bold">
                        <th>Sr no.</th>
                        <th>Leave Type</th>
                        <th>Credits</th>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rpLeaveCredit" runat="server">
                            <ItemTemplate>
                                <tr>                         
                                    <asp:HiddenField ID="hfLeaveTypeID" Value='<%#Eval("LeaveTypeID") %>' runat="server"/>
                                    <td><%#Eval("RowNo") %></td>
                                    <td><%#Eval("LeaveType") %></td>
                                    <td><asp:TextBox ID="txtLeaveCredits" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

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

