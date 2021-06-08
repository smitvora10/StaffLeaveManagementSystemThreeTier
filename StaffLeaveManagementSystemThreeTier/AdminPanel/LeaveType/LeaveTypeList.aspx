<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="LeaveTypeList.aspx.cs" Inherits="AdminPanel_LeaveType_LeaveTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnAddLeaveType" runat="Server" Text="Add Leave Types" CssClass="btn btn-primary" OnClick="btnAddLeaveType_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">Leave Types List</h2>
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
                <asp:GridView ID="gvLeaveTypeList" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false" OnRowCommand="gvLeaveTypeList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:LinkButton ID="btnView" Text="<i class='fas fa-eye mr-2'></i>View" CssClass="btn btn-outline-primary" CommandName="ViewRecord" CommandArgument='<%# Eval("LeaveTypeID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="<i class='fas fa-trash-alt'></i> Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("LeaveTypeID") %>' runat="server"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="<i class='far fa-edit'></i> Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/LeaveType/LeaveTypeAddEdit.aspx?LeaveTypeID=" + Eval("LeaveTypeID").ToString() %>'>
                                    
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
                                <h4 class="modal-title">Leave Type Details</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                LeaveType :
                        <asp:Label ID="lblLeaveType" runat="server"></asp:Label>
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

