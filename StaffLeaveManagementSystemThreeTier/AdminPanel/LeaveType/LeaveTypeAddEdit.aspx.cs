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

public partial class AdminPanel_LeaveType_LeaveTypeAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["LeaveTypeID"] == null)
            {
                lblPageHeaderText.Text = "Add Leave Type";

            }
            if (Request.QueryString["LeaveTypeID"] != null)
            {
                lblPageHeaderText.Text = "Edit LeaveType";
                FillControls(Convert.ToInt32(Request.QueryString["LeaveTypeID"]), Convert.ToInt32(Session["UserID"]));

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtLeaveType.Text.Trim() == "")
            strErrorMessage += " - Enter Leave Type Name<br />";


        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        LeaveTypeENT entLeaveType = new LeaveTypeENT();

        if (txtLeaveType.Text.Trim() != "")
            entLeaveType.LeaveType = txtLeaveType.Text.Trim();


        if (Session["UserID"] != null)
            entLeaveType.UserID = Convert.ToInt32(Session["UserID"]);

        entLeaveType.CreationDate = DateTime.Now;
        entLeaveType.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        if (Request.QueryString["LeaveTypeID"] == null)
        {
            if (balLeaveType.InsertByUserID(entLeaveType))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balLeaveType.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entLeaveType.LeaveTypeID = Convert.ToInt32(Request.QueryString["LeaveTypeID"]);
            if (balLeaveType.UpdateByPKUserID(entLeaveType))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/LeaveType/LeaveTypeList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balLeaveType.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveType/LeaveTypeList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtLeaveType.Text = "";
        txtLeaveType.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 LeaveTypeID, SqlInt32 UserID)
    {
        LeaveTypeENT entLeaveType = new LeaveTypeENT();
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

        entLeaveType = balLeaveType.SelectByPKUserID(LeaveTypeID, UserID);

        if (!entLeaveType.LeaveType.IsNull)
        {
            txtLeaveType.Text = entLeaveType.LeaveType.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnLeaveTypeList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveType/LeaveTypeList.aspx");
    }
    #endregion Redirects Links
}