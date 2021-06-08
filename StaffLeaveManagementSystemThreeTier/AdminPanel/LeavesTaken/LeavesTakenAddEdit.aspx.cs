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


public partial class AdminPanel_LeavesTaken_LeavesTakenAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            FillDropDownLists();
            if (Request.QueryString["LeavesTakenID"] == null)
            {
                lblPageHeaderText.Text = "Add LeavesTaken";
            }
            else
            {
                lblPageHeaderText.Text = "Edit Leaves Taken";
                ddlEmployeeCode.Enabled = false;
                FillControls(Convert.ToInt32(Request.QueryString["LeavesTakenID"]), Convert.ToInt32(Session["UserID"]));


            }
        }

    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlEmployeeCode.SelectedIndex == 0)
            strErrorMessage += " - Select Employee Code <br />";

        if (ddlLeaveType.SelectedIndex == 0)
            strErrorMessage += "- Select Leave Type <br />";

        if (txtStartingDayForLeaves.Text.Trim() == "")
            strErrorMessage += "Enter Starting Day Of Leaves <br />";

        if (txtNoOfDays.Text.Trim() == "")
            strErrorMessage += "Enter No. Of Days <br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        LeavesTakenENT entLeavesTaken = new LeavesTakenENT();

        if (ddlEmployeeCode.SelectedIndex > 0)
            entLeavesTaken.EmployeeID = Convert.ToInt32(ddlEmployeeCode.SelectedValue);

        if (ddlLeaveType.SelectedIndex > 0)
            entLeavesTaken.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);

        if (txtStartingDayForLeaves.Text.Trim() != "")
            entLeavesTaken.StartingDayForLeaves = Convert.ToDateTime(txtStartingDayForLeaves.Text.Trim());

        if (cbHalfDay.Checked)
        {
            entLeavesTaken.NoOfDays = Convert.ToDecimal("0.5");
        }
        else
        {
            if (txtNoOfDays.Text.Trim() != "")
                entLeavesTaken.NoOfDays = Convert.ToDecimal(txtNoOfDays.Text.Trim());
        }
        

        if (Session["UserID"] != null)
            entLeavesTaken.UserID = Convert.ToInt32(Session["UserID"]);

        entLeavesTaken.CreationDate = DateTime.Now;
        entLeavesTaken.ModificationDate = DateTime.Now;
        #endregion Collect Form Data


        LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();
        DataTable dtLeavesTaken = balLeavesTaken.SelectForDuplicateByEmployeeCodeUserID(Convert.ToInt32(ddlEmployeeCode.SelectedValue), entLeavesTaken.StartingDayForLeaves, Convert.ToInt32(Session["UserID"]));
        if(dtLeavesTaken.Rows.Count>0)
        {
            lblErrorMessage.Text = "Leave is Already taken for this date";
            divError.Visible = true;
            divSuccess.Visible = false;
            ClearControls();
            return;
            
        }

        else
        {
            if (Request.QueryString["LeavesTakenID"] == null)
            {
                if (balLeavesTaken.InsertByUserID(entLeavesTaken))
                {
                    ClearControls();
                    lblSuccessMessage.Text = "Data Inserted Successfully";
                    divSuccess.Visible = true;
                    divError.Visible = false;
                }

                else
                {
                    lblErrorMessage.Text = balLeavesTaken.Message;
                    divError.Visible = true;
                    divSuccess.Visible = false;

                }
            }

            else
            {
                entLeavesTaken.LeavesTakenID = Convert.ToInt32(Request.QueryString["LeavesTakenID"]);
                if (balLeavesTaken.UpdateByPKUserID(entLeavesTaken))
                {
                    ClearControls();
                    Response.Redirect("~/AdminPanel/LeavesTaken/LeavesTakenList.aspx");
                }
                else
                {
                    lblErrorMessage.Text = balLeavesTaken.Message;
                    divError.Visible = true;
                    divSuccess.Visible = false;

                }
            }
        }


    }
    #endregion Button : Save
    
    #region Fill  DropDownLists
    private void FillDropDownLists()
    {
        CommonFillMethods.FillDropDownListEmployeeOfEmployeeCode(ddlEmployeeCode);        
        
    }

    #endregion Fill  DropDownLists

    #region Clear Controls

    private void ClearControls()
    {
        ddlEmployeeCode.SelectedIndex = 0;
        ddlEmployeeCode.SelectedIndex = 0;
        txtEmployeeName.Text = "";
        txtStartingDayForLeaves.Text = "";
        txtNoOfDays.Text = "";
        ddlEmployeeCode.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 LeavesTakenID, SqlInt32 UserID)
    {
        LeavesTakenENT entLeavesTaken = new LeavesTakenENT();
        LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();
        EmployeeENT entEmployee = new EmployeeENT();
        EmployeeBAL balEmployee = new EmployeeBAL();

        entLeavesTaken = balLeavesTaken.SelectByPKUserID(LeavesTakenID, UserID);
        entEmployee = balEmployee.SelectByPKUserID(entLeavesTaken.EmployeeID, UserID);

        if (!entLeavesTaken.EmployeeID.IsNull)
        {
            ddlEmployeeCode.SelectedValue = entLeavesTaken.EmployeeID.Value.ToString();
            CommonFillMethods.FillDropDownListLeaveTypeByEmployeeID(ddlLeaveType, Convert.ToInt32(ddlEmployeeCode.SelectedValue));
        }
        if (!entEmployee.EmployeeName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmployeeName.Value;
        }

        DataTable dtLeavesTaken = new DataTable();

        dtLeavesTaken = balLeavesTaken.LeavesRemainingTableByUserID(Convert.ToInt32(ddlEmployeeCode.SelectedValue), Convert.ToInt32(Session["UserID"]));

        if (dtLeavesTaken != null && dtLeavesTaken.Rows.Count > 0)
        {
            gvLeavesTakenList.DataSource = dtLeavesTaken;
            gvLeavesTakenList.DataBind();
        }

        if (!entLeavesTaken.LeaveTypeID.IsNull)
        {
            ddlLeaveType.SelectedValue = entLeavesTaken.LeaveTypeID.Value.ToString();
           
        }

        if (!entLeavesTaken.StartingDayForLeaves.IsNull)
        {
            txtStartingDayForLeaves.Text = entLeavesTaken.StartingDayForLeaves.Value.ToString("yyyy/MM/dd");
        }

        if (!entLeavesTaken.NoOfDays.IsNull)
        {
            if (entLeavesTaken.NoOfDays.Value.ToString() == "0.50")
            {
                cbHalfDay.Checked = true;
                cbHalfDay_CheckedChanged(this, null);
            }
            else
                txtNoOfDays.Text = entLeavesTaken.NoOfDays.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeavesTaken/LeavesTakenList.aspx");
    }
    #endregion Cancel Button

    #region Redirects Links
    protected void btnLeavesTakenList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeavesTaken/LeavesTakenList.aspx");
    }
    #endregion Redirects Links

    protected void ddlEmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        EmployeeBAL balEmployee = new EmployeeBAL();
        EmployeeENT entEmployee = new EmployeeENT();

        entEmployee = balEmployee.SelectByPKUserID(Convert.ToInt32(ddlEmployeeCode.SelectedValue), Convert.ToInt32(Session["UserID"]));
        if (!entEmployee.EmployeeName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmployeeName.Value;
        }

        if (ddlEmployeeCode.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListLeaveTypeByEmployeeID(ddlLeaveType, Convert.ToInt32(ddlEmployeeCode.SelectedValue));
        }


        LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();
        DataTable dtLeavesTaken = new DataTable();

        dtLeavesTaken = balLeavesTaken.LeavesRemainingTableByUserID(Convert.ToInt32(ddlEmployeeCode.SelectedValue),Convert.ToInt32(Session["UserID"]));

        if (dtLeavesTaken != null && dtLeavesTaken.Rows.Count > 0)
        {
            gvLeavesTakenList.DataSource = dtLeavesTaken;
            gvLeavesTakenList.DataBind();
        }

    }

    protected void cbHalfDay_CheckedChanged(object sender, EventArgs e)
    {
        if(cbHalfDay.Checked)
        {         
            
            txtNoOfDays.Text = "0.5";
            txtNoOfDays.Enabled = false;
        }
        else
        {            
            txtNoOfDays.Enabled = true;
        }
    }
}