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

public partial class AdminPanel_LeavesTaken_LeavesTakenList : System.Web.UI.Page
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
        LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();
        DataTable dtLeavesTaken = new DataTable();
        dtLeavesTaken = balLeavesTaken.SelectAllByUserID(UserID);

        if (dtLeavesTaken != null && dtLeavesTaken.Rows.Count > 0)
        {
            gvLeavesTakenList.DataSource = dtLeavesTaken;
            gvLeavesTakenList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete LeavesTaken

    protected void gvLeavesTakenList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();

            if (balLeavesTaken.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balLeavesTaken.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            LeavesTakenENT entLeavesTaken = new LeavesTakenENT();
            LeavesTakenBAL balLeavesTaken = new LeavesTakenBAL();
            EmployeeENT entEmployee = new EmployeeENT();
            EmployeeBAL balEmployee = new EmployeeBAL();
            LeaveTypeENT entLeaveType = new LeaveTypeENT();
            LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

            entLeavesTaken = balLeavesTaken.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entEmployee = balEmployee.SelectByPKUserID(entLeavesTaken.EmployeeID, Convert.ToInt32(Session["UserID"]));
            entLeaveType = balLeaveType.SelectByPKUserID(entLeavesTaken.LeaveTypeID, Convert.ToInt32(Session["UserID"]));
            

            if (!entEmployee.EmployeeCode.IsNull)
            {
                lblEmployeeCode.Text = entEmployee.EmployeeCode.Value.ToString();
            }
            if (!entEmployee.EmployeeName.IsNull)
            {
                lblEmployeeName.Text = entEmployee.EmployeeName.Value.ToString();
            }
            if (!entLeaveType.LeaveType.IsNull)
            {
                lblLeaveType.Text = entLeaveType.LeaveType.Value.ToString();
            }
            if (!entLeavesTaken.LeavesRemaining.IsNull)
            {
                lblLeavesRemaining.Text = entLeavesTaken.LeavesRemaining.Value.ToString();
            }
            if (!entLeavesTaken.StartingDayForLeaves.IsNull)
            {
                lblStartingDayForLeaves.Text = entLeavesTaken.StartingDayForLeaves.Value.ToString("dd-MM-yyyy");
            }
            if (!entLeavesTaken.NoOfDays.IsNull)
            {
                lblNoOfDays.Text = entLeavesTaken.NoOfDays.Value.ToString();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }
        #endregion View Record

    }

    #endregion Delete LeavesTaken

    #region Button: Add LeavesTaken
    protected void btnAddLeavesTaken_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeavesTaken/LeavesTakenAddEdit.aspx");
    }
    #endregion Button: Add LeavesTaken
}