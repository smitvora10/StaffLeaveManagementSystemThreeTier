<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="LeavesTakenList.aspx.cs" Inherits="AdminPanel_LeavesTaken_LeavesTakenList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnAddLeavesTaken" runat="Server" Text="Add LeavesTaken" CssClass="btn btn-primary" OnClick="btnAddLeavesTaken_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">Leaves Taken List</h2>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphBreadCrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <div class="container">

        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvLeavesTakenList" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false" OnRowCommand="gvLeavesTakenList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                        <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />                        
                        <asp:BoundField DataField="StartingDayForLeaves" HeaderText="StartingDay For Leaves" />
                        <asp:BoundField DataField="NoOfDays" HeaderText="No. Of Days" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" Text="<i class='fas fa-eye mr-2'></i>View" CssClass="btn btn-outline-primary" CommandName="ViewRecord" CommandArgument='<%# Eval("LeavesTakenID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="<i class='fas fa-trash-alt'></i> Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("LeavesTakenID") %>' runat="server"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="<i class='far fa-edit'></i> Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/LeavesTaken/LeavesTakenAddEdit.aspx?LeavesTakenID=" + Eval("LeavesTakenID").ToString() %>'>
                                    
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <!-- Modal -->
                <div class="modal fade" id="mymodal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">Leaves Taken Details</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                EmployeeCode :
                                <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label>
                                <br />
                                EmployeeName :
                                <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                                <br />
                                LeaveType :
                                <asp:Label ID="lblLeaveType" runat="server"></asp:Label>
                                <br />
                                LeavesRemaining :
                                <asp:Label ID="lblLeavesRemaining" runat="server"></asp:Label>
                                <br />
                                StartingDayForLeaves :
                                <asp:Label ID="lblStartingDayForLeaves" runat="server"></asp:Label>
                                <br />
                                NoOfDays :
                                <asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
                                <br />

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
