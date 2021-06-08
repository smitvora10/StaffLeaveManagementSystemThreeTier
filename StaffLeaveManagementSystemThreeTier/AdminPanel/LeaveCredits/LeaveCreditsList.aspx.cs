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

public partial class AdminPanel_LeaveCredits_LeaveCreditsList : System.Web.UI.Page
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
        LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();
        DataTable dtLeaveCredits = new DataTable();
        dtLeaveCredits = balLeaveCredits.SelectAllByUserID(UserID);

        if (dtLeaveCredits != null && dtLeaveCredits.Rows.Count > 0)
        {
            gvLeaveCreditsList.DataSource = dtLeaveCredits;
            gvLeaveCreditsList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete LeaveCredits

    protected void gvLeaveCreditsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();

            if (balLeaveCredits.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balLeaveCredits.Message;
            }
        }
        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            LeaveCreditsENT entLeaveCredits = new LeaveCreditsENT();
            LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();
            LeaveTypeENT entLeaveType = new LeaveTypeENT();
            LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
            EmployeeENT entEmployee = new EmployeeENT();
            EmployeeBAL balEmployee = new EmployeeBAL();

            entLeaveCredits = balLeaveCredits.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entLeaveType = balLeaveType.SelectByPKUserID(entLeaveCredits.LeaveTypeID, Convert.ToInt32(Session["UserID"]));
            entEmployee = balEmployee.SelectByPKUserID(entLeaveCredits.EmployeeID, Convert.ToInt32(Session["UserID"]));

            if (!entEmployee.EmployeeCode.IsNull)
            {
                lblEmployeeCode.Text = entEmployee.EmployeeCode.Value.ToString();
            }
            if (!entEmployee.EmployeeName.IsNull)
            {
                lblEmployeeName.Text = entEmployee.EmployeeName.Value;
            }
                       
            if (!entLeaveType.LeaveType.IsNull)
            {
                lblLeaveType.Text = entLeaveType.LeaveType.Value.ToString();
            }

            if (!entLeaveCredits.LeavesCredited.IsNull)
            {
                lblLeavesCredited.Text = entLeaveCredits.LeavesCredited.Value.ToString();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);



        }
        #endregion View Record

    }

    #endregion Delete LeaveCredits

    #region Button: Add LeaveCredits
    protected void btnAddLeaveCredits_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsAddEdit.aspx");
    }
    #endregion Button: Add LeaveCredits
}