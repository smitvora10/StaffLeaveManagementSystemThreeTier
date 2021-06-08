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


public partial class AdminPanel_LeaveType_LeaveTypeList : System.Web.UI.Page
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
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        DataTable dtLeaveType = new DataTable();
        dtLeaveType = balLeaveType.SelectAllByUserID(UserID);

        if (dtLeaveType != null && dtLeaveType.Rows.Count > 0)
        {
            gvLeaveTypeList.DataSource = dtLeaveType;
            gvLeaveTypeList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete LeaveType

    protected void gvLeaveTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

            if (balLeaveType.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balLeaveType.Message;
            }
        }
        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            LeaveTypeENT entLeaveType = new LeaveTypeENT();
            LeaveTypeBAL balLeaveType = new LeaveTypeBAL();

            entLeaveType = balLeaveType.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));


            if (!entLeaveType.LeaveType.IsNull)
                lblLeaveType.Text = entLeaveType.LeaveType.Value.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }

    #endregion Delete LeaveType

    #region Button: Add LeaveType
    protected void btnAddLeaveType_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveType/LeaveTypeAddEdit.aspx");
    }
    #endregion Button: Add LeaveType
}