using StaffLeaveManagementSystemThreeTier;
using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Employee_EmployeeAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillDropDownLists();
            if (Request.QueryString["EmployeeID"] == null)
            {
                lblPageHeaderText.Text = "Add Employee";


            }
            if (Request.QueryString["EmployeeID"] != null)
            {
                lblPageHeaderText.Text = "Edit Employee";                
                FillControls(Convert.ToInt32(Request.QueryString["EmployeeID"]), Convert.ToInt32(Session["UserID"]));

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtEmployeeName.Text.Trim() == "")
            strErrorMessage += " - Enter Employee Name<br />";

        if (txtEmployeeCode.Text.Trim() == "")
            strErrorMessage += " - Enter Employee Name<br />";

        if (ddlDepartmentName.SelectedIndex == 0)
            strErrorMessage += " - Select Department <br />";

        if (ddlDesignationName.SelectedIndex == 0)
            strErrorMessage += " - Select Designation <br />";

        if (ddlEmploymentType.SelectedIndex == 0)
            strErrorMessage += " - Enter Employment Type<br />";

        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += " - Enter Contact No.<br />";

        if (txtJoiningDate.Text.Trim() == "")
            strErrorMessage += " - Enter Joining Date<br />";

        if (txtBirthDate.Text.Trim() == "")
            strErrorMessage += " - Enter Birth Date<br />";

        if (txtEmail.Text.Trim() == "")
            strErrorMessage += " - Enter Email<br />";

        if (ddlCountryName.SelectedIndex == 0)
            strErrorMessage += " - Select Country <br />";

        if (ddlStateName.SelectedIndex == 0)
            strErrorMessage += " - Select State <br />";

        if (ddlCityName.SelectedIndex == 0)
            strErrorMessage += " - Select City <br />";



        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        EmployeeENT entEmployee = new EmployeeENT();

        if (txtEmployeeName.Text.Trim() != "")
            entEmployee.EmployeeName = txtEmployeeName.Text.Trim();

        if (txtEmployeeCode.Text.Trim() != "")
            entEmployee.EmployeeCode = Convert.ToInt32(txtEmployeeCode.Text.Trim());

        if (ddlDepartmentName.SelectedIndex > 0)
            entEmployee.DepartmentID = Convert.ToInt32(ddlDepartmentName.SelectedValue);

        if (ddlDesignationName.SelectedIndex > 0)
            entEmployee.DesignationID = Convert.ToInt32(ddlDesignationName.SelectedValue);

        if (ddlEmploymentType.SelectedIndex > 0)
            entEmployee.EmploymentType = ddlEmploymentType.SelectedItem.Text;

        if (txtAddress.Text.Trim() != "")
            entEmployee.Address = txtAddress.Text.Trim();

        if (txtContactNo.Text.Trim() != "")
            entEmployee.ContactNo = txtContactNo.Text.Trim();

        if (txtJoiningDate.Text.Trim() != "")
            entEmployee.JoiningDate = Convert.ToDateTime(txtJoiningDate.Text.Trim());

        if (txtBirthDate.Text.Trim() != "")
            entEmployee.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

        if (ddlMaritalStatus.SelectedIndex > 0)
            entEmployee.MaritalStatus = ddlMaritalStatus.SelectedItem.Text;

        if (txtEmail.Text.Trim() != "")
            entEmployee.Email = txtEmail.Text.Trim();

        if (ddlCountryName.SelectedIndex > 0)
            entEmployee.CountryID = Convert.ToInt32(ddlCountryName.SelectedValue);

        if (ddlStateName.SelectedIndex > 0)
            entEmployee.StateID = Convert.ToInt32(ddlStateName.SelectedValue);

        if (ddlCityName.SelectedIndex > 0)
            entEmployee.CityID = Convert.ToInt32(ddlCityName.SelectedValue);

        if (Session["UserID"] != null)
            entEmployee.UserID = Convert.ToInt32(Session["UserID"]);

        entEmployee.CreationDate = DateTime.Now;
        entEmployee.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        EmployeeBAL balEmployee = new EmployeeBAL();

        if (Request.QueryString["EmployeeID"] == null)
        {
            if (balEmployee.InsertByUserID(entEmployee))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balEmployee.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entEmployee.EmployeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);
            if (balEmployee.UpdateByPKUserID(entEmployee))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Employee/EmployeeList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balEmployee.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region FillDropDownLists

    private void FillDropDownLists()
    {
        CommonFillMethods.FillDropDownListDepartment(ddlDepartmentName);
        CommonFillMethods.FillDropDownListDesignation(ddlDesignationName);       
        CommonFillMethods.FillDropDownListCountry(ddlCountryName);
        

    }

    #region Cascading DropDownLists

    #region State By CountryID
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListStateByCountryID(ddlStateName, Convert.ToInt32(ddlCountryName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlStateName, "State");
            CommonFillMethods.FillEmptyDropDownList(ddlCityName, "City");
        }
    }
    #endregion State By CountryID

    #region City By StateID
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListCityByStateID(ddlCityName, Convert.ToInt32(ddlStateName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlCityName, "City");
        }
    }
    #endregion City By StateID

    #endregion Cascading DropDownLists

    #endregion FillDropDownList

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Employee/EmployeeList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtEmployeeName.Text = "";
        txtEmployeeCode.Text = "";
        ddlDepartmentName.SelectedIndex = 0;
        ddlDesignationName.SelectedIndex = 0;
        ddlEmploymentType.SelectedIndex = 0;
        txtAddress.Text = "";
        txtContactNo.Text = "";
        txtJoiningDate.Text = "";
        txtBirthDate.Text = "";
        ddlMaritalStatus.SelectedIndex = 0;
        txtEmail.Text = "";
        ddlCountryName.SelectedIndex = 0;
        ddlStateName.SelectedIndex = 0;
        ddlCityName.SelectedIndex = 0;

        txtEmployeeName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 EmployeeID, SqlInt32 UserID)
    {
        EmployeeENT entEmployee = new EmployeeENT();
        EmployeeBAL balEmployee = new EmployeeBAL();

        entEmployee = balEmployee.SelectByPKUserID(EmployeeID, UserID);

        if (!entEmployee.EmployeeName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmployeeName.Value.ToString();
        }
        if (!entEmployee.EmployeeCode.IsNull)
        {
            txtEmployeeCode.Text = entEmployee.EmployeeCode.Value.ToString();
        }
        if (!entEmployee.DepartmentID.IsNull)
        {
            ddlDepartmentName.SelectedValue = entEmployee.DepartmentID.Value.ToString();
        }
        if (!entEmployee.DesignationID.IsNull)
        {
            ddlDesignationName.SelectedValue = entEmployee.DesignationID.Value.ToString();
        }
        if (!entEmployee.EmploymentType.IsNull)
        {
            ddlEmploymentType.SelectedItem.Text = entEmployee.EmploymentType.Value.ToString();
        }
        if (!entEmployee.Address.IsNull)
        {
            txtAddress.Text = entEmployee.Address.Value.ToString();
        }
        if (!entEmployee.ContactNo.IsNull)
        {
            txtContactNo.Text = entEmployee.ContactNo.Value.ToString();
        }
        if (!entEmployee.JoiningDate.IsNull)
        {
            txtJoiningDate.Text = entEmployee.JoiningDate.Value.ToString("dd/MM/yyyy");
        }
        if (!entEmployee.BirthDate.IsNull)
        {
            txtBirthDate.Text = entEmployee.BirthDate.Value.ToString("dd/MM/yyyy");
        }
        if (!entEmployee.MaritalStatus.IsNull)
        {
            ddlMaritalStatus.SelectedItem.Text = entEmployee.MaritalStatus.Value.ToString();
        }
        if (!entEmployee.Email.IsNull)
        {
            txtEmail.Text = entEmployee.Email.Value.ToString();
        }
        if (!entEmployee.CountryID.IsNull)
        {
            ddlCountryName.SelectedValue = entEmployee.CountryID.Value.ToString();
            CommonFillMethods.FillDropDownListStateByCountryID(ddlStateName, Convert.ToInt32(ddlCountryName.SelectedValue));
        }
        if (!entEmployee.StateID.IsNull)
        {
            ddlStateName.SelectedValue = entEmployee.StateID.Value.ToString();
            CommonFillMethods.FillDropDownListCityByStateID(ddlCityName, Convert.ToInt32(ddlStateName.SelectedValue));

        }
        if (!entEmployee.CityID.IsNull)
        {
            ddlCityName.SelectedValue = entEmployee.CityID.Value.ToString();
        }


    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnEmployeeList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Employee/EmployeeList.aspx");
    }
    #endregion Redirects Links
}
