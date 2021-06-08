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

public partial class AdminPanel_Employee_EmployeeList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillInGridView(Convert.ToInt32(Session["UserID"]));
        }
    }
    #endregion Load Event

    #region Fill Grid View
    private void FillInGridView(SqlInt32 UserID)
    {
        EmployeeBAL balEmployee = new EmployeeBAL();
        DataTable dtEmployee = new DataTable();
        dtEmployee = balEmployee.SelectAllByUserID(UserID);

        if (dtEmployee != null && dtEmployee.Rows.Count > 0)
        {
            gvEmployeeList.DataSource = dtEmployee;
            gvEmployeeList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete Employee

    protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            EmployeeBAL balEmployee = new EmployeeBAL();

            if (balEmployee.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balEmployee.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            EmployeeENT entEmployee = new EmployeeENT();
            EmployeeBAL balEmployee = new EmployeeBAL();
            CountryENT entCountry = new CountryENT();
            CountryBAL balCountry = new CountryBAL();
            StateENT entState = new StateENT();
            StateBAL balState = new StateBAL();
            CityENT entCity = new CityENT();
            CityBAL balCity = new CityBAL();
            DepartmentENT entDepartment = new DepartmentENT();
            DepartmentBAL balDepartment = new DepartmentBAL();
            DesignationENT entDesignation = new DesignationENT();
            DesignationBAL balDesignation = new DesignationBAL();

            entEmployee = balEmployee.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entCountry = balCountry.SelectByPKUserID(entEmployee.CountryID, Convert.ToInt32(Session["UserID"]));
            entState = balState.SelectByPKUserID(entEmployee.StateID, Convert.ToInt32(Session["UserID"]));
            entCity = balCity.SelectByPKUserID(entEmployee.CityID, Convert.ToInt32(Session["UserID"]));
            entDepartment = balDepartment.SelectByPKUserID(entEmployee.DepartmentID, Convert.ToInt32(Session["UserID"]));
            entDesignation = balDesignation.SelectByPKUserID(entEmployee.DesignationID, Convert.ToInt32(Session["UserID"]));

            if (!entEmployee.EmployeeName.IsNull)
            {
                lblEmployeeName.Text = entEmployee.EmployeeName.Value.ToString();
            }
            if (!entEmployee.EmployeeCode.IsNull)
            {
                lblEmployeeCode.Text = entEmployee.EmployeeCode.Value.ToString();
            }
            if (!entDepartment.DepartmentName.IsNull)
            {
                lblDepartmentName.Text = entDepartment.DepartmentName.ToString().Trim();
            }
            if (!entDesignation.DesignationName.IsNull)
            {
                lblDesignationName.Text = entDesignation.DesignationName.ToString().Trim();
            }
            if (!entEmployee.EmploymentType.IsNull)
            {
                lblEmploymentType.Text = entEmployee.EmploymentType.Value.ToString();
            }
            if (!entEmployee.Address.IsNull)
            {
                lblAddress.Text = entEmployee.Address.Value.ToString();
            }
            if (!entEmployee.ContactNo.IsNull)
            {
                lblContactNo.Text = entEmployee.ContactNo.Value.ToString();
            }
            if (!entEmployee.JoiningDate.IsNull)
            {
                lblJoiningDate.Text = entEmployee.JoiningDate.Value.ToString("dd/MM/yyyy");
            }
            if (!entEmployee.BirthDate.IsNull)
            {
                lblBirthDate.Text = entEmployee.BirthDate.Value.ToString("dd/MM/yyyy");
            }
            if (!entEmployee.MaritalStatus.IsNull)
            {
                lblMaritalStatus.Text = entEmployee.MaritalStatus.Value.ToString();
            }
            if (!entEmployee.Email.IsNull)
            {
                lblEmail.Text = entEmployee.Email.Value.ToString();
            }
            if (!entCountry.CountryName.IsNull)
            {
                lblCountryName.Text = entCountry.CountryName.ToString().Trim();
            }

            if (!entState.StateName.IsNull)
            {
                lblStateName.Text = entState.StateName.ToString().Trim();
            }

            if (!entCity.CityName.IsNull)
            {
                lblCityName.Text = entCity.CityName.ToString().Trim();
            }



            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }

    #endregion Delete Employee

    #region Button: Add Employee
    protected void btnAddEmployee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Employee/EmployeeAddEdit.aspx");
    }
    #endregion Button: Add Employee
}