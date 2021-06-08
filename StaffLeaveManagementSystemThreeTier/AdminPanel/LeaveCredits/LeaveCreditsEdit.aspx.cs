using StaffLeaveManagementSystemThreeTier;
using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_LeaveCredits_LeaveCreditsEdit : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {

            CommonFillMethods.FillDropDownListEmployeeOfEmployeeCode(ddlEmployeeCode);
            CommonFillMethods.FillDropDownListLeaveType(ddlLeaveType);
            lblPageHeaderText.Text = "Edit Leave Credits";
            FillControls(Convert.ToInt32(Request.QueryString["LeaveCreditsID"]), Convert.ToInt32(Session["UserID"]));


        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlLeaveType.SelectedIndex == 0)
            strErrorMessage += " Select Leave Type<br />";

        if (txtLeavesCredited.Text == "")
            strErrorMessage += " Enter Leaves To Be Credited<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        LeaveCreditsENT entLeaveCredits = new LeaveCreditsENT();

        if (ddlEmployeeCode.SelectedIndex > 0)
            entLeaveCredits.EmployeeID = Convert.ToInt32(ddlEmployeeCode.SelectedValue);

        if (ddlLeaveType.SelectedIndex > 0)
            entLeaveCredits.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);

        if (txtLeavesCredited.Text != null)
            entLeaveCredits.LeavesCredited = Convert.ToInt32(txtLeavesCredited.Text);


        if (Session["UserID"] != null)
            entLeaveCredits.UserID = Convert.ToInt32(Session["UserID"]);

        entLeaveCredits.CreationDate = DateTime.Now;
        entLeaveCredits.ModificationDate = DateTime.Now;
        #endregion Collect Form Data

        LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();



        if (Request.QueryString["LeaveCreditsID"] != null)
        {
            entLeaveCredits.LeaveCreditsID = Convert.ToInt32(Request.QueryString["LeaveCreditsID"]);
            if (balLeaveCredits.UpdateByPKUserID(entLeaveCredits))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balLeaveCredits.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        ddlEmployeeCode.SelectedIndex = 0;
        txtEmployeeName.Text = "";
        txtLeavesCredited.Text = "";
        ddlLeaveType.SelectedIndex = 0;
        ddlEmployeeCode.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 LeaveCreditsID, SqlInt32 UserID)
    {
        LeaveCreditsENT entLeaveCredits = new LeaveCreditsENT();
        LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();
        EmployeeBAL balEmployee = new EmployeeBAL();
        EmployeeENT entEmployee = new EmployeeENT();
        entLeaveCredits = balLeaveCredits.SelectByPKUserID(LeaveCreditsID, UserID);
        entEmployee = balEmployee.SelectByPKUserID(entLeaveCredits.EmployeeID, UserID);


        if (!entLeaveCredits.EmployeeID.IsNull)
        {
            ddlEmployeeCode.SelectedValue = entLeaveCredits.EmployeeID.Value.ToString();
        }

        if (!entEmployee.EmployeeName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmployeeName.Value;
        }

        if (!entLeaveCredits.LeavesCredited.IsNull)
        {
            txtLeavesCredited.Text = entLeaveCredits.LeavesCredited.Value.ToString();
        }

        if (!entLeaveCredits.LeaveTypeID.IsNull)
        {
            ddlLeaveType.SelectedValue = entLeaveCredits.LeaveTypeID.Value.ToString();
        }


    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnLeaveCreditsList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsList.aspx");
    }
    #endregion Redirects Links






}