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

public partial class AdminPanel_Designation_DesignationList : System.Web.UI.Page
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
        DesignationBAL balDesignation = new DesignationBAL();
        DataTable dtDesignation = new DataTable();
        dtDesignation = balDesignation.SelectAllByUserID(UserID);

        if (dtDesignation != null && dtDesignation.Rows.Count > 0)
        {
            gvDesignationList.DataSource = dtDesignation;
            gvDesignationList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete Designation

    protected void gvDesignationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            DesignationBAL balDesignation = new DesignationBAL();

            if (balDesignation.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balDesignation.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            DesignationENT entDesignation = new DesignationENT();
            DesignationBAL balDesignation = new DesignationBAL();

            entDesignation = balDesignation.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));

            
            if (!entDesignation.DesignationName.IsNull)            
                lblDesignationName.Text = entDesignation.DesignationName.Value.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }

    #endregion Delete Designation

    #region Button: Add Designation
    protected void btnAddDesignation_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Designation/DesignationAddEdit.aspx");
    }
    #endregion Button: Add Designation
}