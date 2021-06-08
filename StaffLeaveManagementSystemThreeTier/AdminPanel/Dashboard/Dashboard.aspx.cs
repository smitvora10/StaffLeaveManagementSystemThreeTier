using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Dashboard_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillLabels(Convert.ToInt32(Session["UserID"]));
        }
    }

    #region Fill Labels
    private void FillLabels(SqlInt32 UserID)
    {
        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = new CountryENT();

        entCountry = balCountry.ShowCountByUserID(UserID);

        if (!entCountry.TotalCountries.IsNull)
        {
            lblCountries.Text = entCountry.TotalCountries.Value.ToString();
        }

        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();

        entState = balState.ShowCountByUserID(UserID);

        if (!entState.TotalStates.IsNull)
        {
            lblStates.Text = entState.TotalStates.Value.ToString();
        }

        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        entCity = balCity.ShowCountByUserID(UserID);

        if (!entCity.TotalCities.IsNull)
        {
            lblCities.Text = entCity.TotalCities.Value.ToString();
        }

        CompanyBAL balCompany = new CompanyBAL();
        CompanyENT entCompany = new CompanyENT();

        entCompany = balCompany.ShowCountByUserID(UserID);

        if (!entCompany.TotalCompanies.IsNull)
        {
            lblCompanies.Text = entCompany.TotalCompanies.Value.ToString();
        }

        DepartmentBAL balDepartment = new DepartmentBAL();
        DepartmentENT entDepartment = new DepartmentENT();

        entDepartment = balDepartment.ShowCountByUserID(UserID);

        if (!entDepartment.TotalDepartments.IsNull)
        {
            lblDepartments.Text = entDepartment.TotalDepartments.Value.ToString();
        }

        DesignationBAL balDesignation = new DesignationBAL();
        DesignationENT entDesignation = new DesignationENT();

        entDesignation = balDesignation.ShowCountByUserID(UserID);

        if (!entDesignation.TotalDesignations.IsNull)
        {
            lblDesignations.Text = entDesignation.TotalDesignations.Value.ToString();
        }

        EmployeeBAL balEmployee = new EmployeeBAL();
        EmployeeENT entEmployee = new EmployeeENT();

        entEmployee = balEmployee.ShowCountByUserID(UserID);

        if (!entEmployee.TotalEmployees.IsNull)
        {
            lblEmployees.Text = entEmployee.TotalEmployees.Value.ToString();
        }

        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        LeaveTypeENT entLeaveType = new LeaveTypeENT();

        entLeaveType = balLeaveType.ShowCountByUserID(UserID);

        if (!entLeaveType.TotalLeaveTypes.IsNull)
        {
            lblLeaveTypes.Text = entLeaveType.TotalLeaveTypes.Value.ToString();
        }

    }
    #endregion Fill Labels



}