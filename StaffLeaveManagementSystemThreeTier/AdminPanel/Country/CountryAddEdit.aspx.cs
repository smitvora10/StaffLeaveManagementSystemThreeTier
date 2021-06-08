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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] == null)
            {
                lblPageHeaderText.Text = "Add Country";
               
            }
            if (Request.QueryString["CountryID"] != null)
            {
                lblPageHeaderText.Text = "Edit Country";
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]), Convert.ToInt32(Session["UserID"]));
                
            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
            strErrorMessage += " - Enter Country Name<br />";

        if (txtCode.Text.Trim() == "")
            strErrorMessage += " - Enter Country Code<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCode.Text.Trim() != "")
            entCountry.Code = txtCode.Text.Trim();

        if (Session["UserID"] != null)
            entCountry.UserID = Convert.ToInt32(Session["UserID"]);

        entCountry.CreationDate = DateTime.Now;
        entCountry.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.InsertByUserID(entCountry))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balCountry.UpdateByPKUserID(entCountry))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCode.Text = "";
        txtCountryName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID, SqlInt32 UserID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPKUserID(CountryID, UserID);

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }

        if (!entCountry.Code.IsNull)
        {
            txtCode.Text = entCountry.Code.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnCountryList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Redirects Links
}