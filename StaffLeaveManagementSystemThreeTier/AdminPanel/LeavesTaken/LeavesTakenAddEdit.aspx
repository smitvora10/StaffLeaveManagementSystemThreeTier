<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="LeavesTakenAddEdit.aspx.cs" Inherits="AdminPanel_LeavesTaken_LeavesTakenAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnLeavesTakenList" runat="Server" Text="Leaves Taken List" CssClass="btn btn-primary" OnClick="btnLeavesTakenList_Click" />
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
            <div class="col-md-3 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Employee Code</label>
                </span>
            </div>
            <div class="col-md-7">
                <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEmployeeCode_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CompareValidator ID="cvEmployeeCode" runat="server" ErrorMessage="Select Employee Code"
                    Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlEmployeeCode"
                    Operator="NotEqual" ValidationGroup="vgSave" ValueToCompare="-1">
                </asp:CompareValidator>
            </div>
        </div>


        <br />

        <div class="row">
            <div class="col-md-3 text-right">
                <span class="font-weight-bold">

                    <label>Employee Name</label>
                </span>
            </div>
            <div class="col-md-7">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

            </div>
        </div>

        <br />
        <div class="row">
            <div class="col-md-3 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Leave Type</label>
                </span>
            </div>
            <div class="col-md-7">
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
            <div class="col-md-3 text-left offset-md-3">
                <span class="font-weight-bold">
                    <asp:CheckBox ID="cbHalfDay" runat="server" AutoPostBack="true" OnCheckedChanged="cbHalfDay_CheckedChanged" Text="&nbsp;Half Day"/>
                </span>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-3 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>Starting Day of Leaves</label>
                </span>
            </div>
            <div class="col-md-7">
                <asp:TextBox ID="txtStartingDayForLeaves" runat="server" placeholder="Enter Starting Day of Leaves" CssClass="form-control" type="date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLeavesCredited" runat="server" ErrorMessage="Enter Starting Day of Leaves"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtStartingDayForLeaves" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br />

        <div class="row align-center">
            <div class="col-md-3 text-right">
                <span class="font-weight-bold">
                    <span style="color: red">*</span>
                    <label>No. Of Days</label>
                </span>
            </div>
            <div class="col-md-7">
                <asp:TextBox ID="txtNoOfDays" runat="server" placeholder="Enter No. Of Days" type="number" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfDays" runat="server" ErrorMessage="Enter No. Of Days"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtNoOfDays" ValidationGroup="vgSave"></asp:RequiredFieldValidator>
           
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-md-8 offset-2">
                <asp:GridView ID="gvLeavesTakenList" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                        <asp:BoundField DataField="LeavesRemaining" HeaderText="Leaves Remaining" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-2">
            </div>
            <div class="col-md-2 text-right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" ValidationGroup="vgSave" OnClick="btnSave_Click" />
            </div>
            <div>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>

