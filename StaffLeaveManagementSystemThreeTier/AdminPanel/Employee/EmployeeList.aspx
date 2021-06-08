<%@ Page Title="" Language="C#" MasterPageFile="~/Content/SLMSAdminPanel.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="AdminPanel_Employee_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphScriptBlock" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTolist" runat="Server">
    <asp:Button ID="btnAddEmployee" runat="Server" Text="Add Employee" CssClass="btn btn-primary" OnClick="btnAddEmployee_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTitle" runat="Server">
    <div>
        <h2 style="font-family: 'Berlin Sans FB Demi'; font-weight: bold;">Employee List</h2>
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
            <div class="col-md-12 table-responsive">
                <asp:GridView ID="gvEmployeeList" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false" OnRowCommand="gvEmployeeList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee" />
                        <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                        <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                        <asp:BoundField DataField="EmploymentType" HeaderText="Employment Type" />
                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo." />                        
                        <asp:BoundField DataField="CityName" HeaderText="City" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" Text="<i class='fas fa-eye mr-2'></i>View" CssClass="btn btn-outline-primary" CommandName="ViewRecord" CommandArgument='<%# Eval("EmployeeID") %>' runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="<i class='fas fa-trash-alt'></i> Delete" CssClass="btn btn-outline-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("EmployeeID") %>' runat="server"></asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="<i class='far fa-edit'></i> Edit" CssClass="btn btn-outline-dark"
                                    NavigateUrl='<%#"~/AdminPanel/Employee/EmployeeAddEdit.aspx?EmployeeID=" + Eval("EmployeeID").ToString() %>'>
                                    
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
                                <h4 class="modal-title">Employee Details</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                EmployeeName :
                        <asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
                                <br />
                                EmployeeCode :
                        <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label>
                                <br />
                                DepartmentName :
                        <asp:Label ID="lblDepartmentName" runat="server"></asp:Label>
                                <br />
                                DesignationName :
                        <asp:Label ID="lblDesignationName" runat="server"></asp:Label>
                                <br />
                                EmploymentType :
                        <asp:Label ID="lblEmploymentType" runat="server"></asp:Label>
                                <br />
                                Address :
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                <br />
                                ContactNo. :
                        <asp:Label ID="lblContactNo" runat="server"></asp:Label>
                                <br />
                                JoiningDate :
                        <asp:Label ID="lblJoiningDate" runat="server"></asp:Label>
                                <br />
                                BirthDate :
                        <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                                <br />
                                MaritalStatus :
                        <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                                <br />
                                Email :
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                <br />
                                CountryName :
                        <asp:Label ID="lblCountryName" runat="server"></asp:Label>
                                <br />
                                StateName :
                        <asp:Label ID="lblStateName" runat="server"></asp:Label>
                                <br />
                                CityName :
                        <asp:Label ID="lblCityName" runat="server"></asp:Label>
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
