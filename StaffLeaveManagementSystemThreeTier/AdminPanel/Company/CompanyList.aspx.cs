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

public partial class AdminPanel_Company_CompanyList : System.Web.UI.Page
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
        CompanyBAL balCompany = new CompanyBAL();
        DataTable dtCompany = new DataTable();
        dtCompany = balCompany.SelectAllByUserID(UserID);

        if (dtCompany != null && dtCompany.Rows.Count > 0)
        {
            gvCompanyList.DataSource = dtCompany;
            gvCompanyList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete Company

    protected void gvCompanyList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            CompanyBAL balCompany = new CompanyBAL();

            if (balCompany.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balCompany.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            CompanyENT entCompany = new CompanyENT();
            CompanyBAL balCompany = new CompanyBAL();
            CountryENT entCountry = new CountryENT();
            CountryBAL balCountry = new CountryBAL();
            StateENT entState = new StateENT();
            StateBAL balState = new StateBAL();
            CityENT entCity = new CityENT();
            CityBAL balCity = new CityBAL();


            entCompany = balCompany.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entCountry = balCountry.SelectByPKUserID(entCompany.CountryID, Convert.ToInt32(Session["UserID"]));
            entState = balState.SelectByPKUserID(entCompany.StateID, Convert.ToInt32(Session["UserID"]));
            entCity = balCity.SelectByPKUserID(entCompany.CityID, Convert.ToInt32(Session["UserID"]));

            if (!entCompany.CompanyName.IsNull)
            {
                lblCompanyName.Text = entCompany.CompanyName.Value.ToString();
            }
            if (!entCompany.GSTNo.IsNull)
            {
                lblGSTNO.Text = entCompany.GSTNo.Value.ToString();
            }
            if (!entCompany.Landmark.IsNull)
            {
                lblLandmark.Text = entCompany.Landmark.Value.ToString();
            }
            if (!entCompany.Pincode.IsNull)
            {
                lblPincode.Text = entCompany.Pincode.Value.ToString();
            }
            if (!entCountry.CountryName.IsNull)
            {
                lblCountryName.Text = entCountry.CountryName.ToString().Trim();
            }

            if (!entState.StateName.IsNull)
            {
                lblStateName.Text = entState.StateName.ToString().Trim();
            }

            if (!entCity.CityName.IsNull)
            {
                lblCityName.Text = entCity.CityName.ToString().Trim();
            }

            if (!entCompany.ContactNo.IsNull)
            {
                lblContactNo.Text = entCompany.ContactNo.Value.ToString();
            }
            if (!entCompany.Email.IsNull)
            {
                lblEmail.Text = entCompany.Email.Value.ToString();
            }
            if (!entCompany.Website.IsNull)
            {
                lblWebsite.Text = entCompany.Website.Value.ToString();
            }



            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }

    #endregion Delete Company

    #region Button: Add Company
    protected void btnAddCompany_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Company/CompanyAddEdit.aspx");
    }
    #endregion Button: Add Company
}