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


public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            FillDropDownListCountry();
            if (Request.QueryString["StateID"] == null)
            {
                lblPageHeaderText.Text = "Add State";
            }
            else
            {
                lblPageHeaderText.Text = "Edit State";
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]), Convert.ToInt32(Session["UserID"]));


            }
        }

    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtStateName.Text.Trim() == "")
            strErrorMessage += " - Enter State Name <br />";

        if (ddlCountryName.SelectedIndex == 0)
            strErrorMessage += "- Select Country <br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        StateENT entState = new StateENT();

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (ddlCountryName.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountryName.SelectedValue);

        if (Session["UserID"] != null)
            entState.UserID = Convert.ToInt32(Session["UserID"]);

        entState.CreationDate = DateTime.Now;
        entState.ModificationDate = DateTime.Now;
        #endregion Collect Form Data

        StateBAL balState = new StateBAL();

        if(Request.QueryString["StateID"] == null)
        {
            if(balState.InsertByUserID(entState))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divSuccess.Visible = true;
                divError.Visible = false;
            }

            else
            {
                lblErrorMessage.Text = balState.Message;
                divError.Visible = true;
                divSuccess.Visible = false;

            }
        }

        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if(balState.UpdateByPKUserID(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balState.Message;
                divError.Visible = true;
                divSuccess.Visible = false;

            }
        }

    }
    #endregion Button : Save

    #region Fill Country DropDownList
    private void FillDropDownListCountry()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryName);
    }

    #endregion Fill Country DropDownList

    #region Clear Controls

    private void ClearControls()
    {
        txtStateName.Text = "";
        ddlCountryName.SelectedIndex = 0;
        txtStateName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 StateID, SqlInt32 UserID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPKUserID(StateID, UserID);

        if (!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.Value.ToString();
        }

        if (!entState.CountryID.IsNull)
        {
            ddlCountryName.SelectedValue = entState.CountryID.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Cancel Button

    #region Redirects Links
    protected void btnStateList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Redirects Links
}
