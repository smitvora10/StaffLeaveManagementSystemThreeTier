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

public partial class AdminPanel_Department_DepartmentAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DepartmentID"] == null)
            {
                lblPageHeaderText.Text = "Add Department";

            }
            if (Request.QueryString["DepartmentID"] != null)
            {
                lblPageHeaderText.Text = "Edit Department";
                FillControls(Convert.ToInt32(Request.QueryString["DepartmentID"]), Convert.ToInt32(Session["UserID"]));

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtDepartmentName.Text.Trim() == "")
            strErrorMessage += " - Enter Department Name<br />";


        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        DepartmentENT entDepartment = new DepartmentENT();

        if (txtDepartmentName.Text.Trim() != "")
            entDepartment.DepartmentName = txtDepartmentName.Text.Trim();


        if (Session["UserID"] != null)
            entDepartment.UserID = Convert.ToInt32(Session["UserID"]);

        entDepartment.CreationDate = DateTime.Now;
        entDepartment.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        DepartmentBAL balDepartment = new DepartmentBAL();

        if (Request.QueryString["DepartmentID"] == null)
        {
            if (balDepartment.InsertByUserID(entDepartment))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entDepartment.DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            if (balDepartment.UpdateByPKUserID(entDepartment))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balDepartment.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtDepartmentName.Text = "";        
        txtDepartmentName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 DepartmentID, SqlInt32 UserID)
    {
        DepartmentENT entDepartment = new DepartmentENT();
        DepartmentBAL balDepartment = new DepartmentBAL();

        entDepartment = balDepartment.SelectByPKUserID(DepartmentID, UserID);

        if (!entDepartment.DepartmentName.IsNull)
        {
            txtDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnDepartmentList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Department/DepartmentList.aspx");
    }
    #endregion Redirects Links
}