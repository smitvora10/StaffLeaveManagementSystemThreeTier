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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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

    protected void FillInGridView(SqlInt32 UserID)
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();
        dtState = balState.SelectAllByUserID(UserID);

        if (dtState != null && dtState.Rows.Count > 0)
        {
            gvStateList.DataSource = dtState;
            gvStateList.DataBind();
        }
    }


    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            StateBAL balState = new StateBAL();

            if (balState.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balState.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            StateENT entState = new StateENT();
            StateBAL balState = new StateBAL();
            CountryENT entCountry = new CountryENT();
            CountryBAL balCountry = new CountryBAL();

            entState = balState.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entCountry = balCountry.SelectByPKUserID(entState.CountryID, Convert.ToInt32(Session["UserID"]));

            if (!entState.StateName.IsNull)
            {
                lblStateName.Text = entState.StateName.Value.ToString();
            }


            if (!entCountry.CountryName.IsNull)
            {
                lblCountryName.Text = entCountry.CountryName.ToString().Trim();
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


        }
        #endregion View Record

    }

    #region Button: Add State
    protected void btnAddState_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateAddEdit.aspx");
    }
    #endregion Button: Add State
}