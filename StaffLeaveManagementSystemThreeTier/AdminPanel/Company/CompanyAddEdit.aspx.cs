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

public partial class AdminPanel_Company_CompanyAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillDropDownLists();
            if (Request.QueryString["CompanyID"] == null)
            {
                lblPageHeaderText.Text = "Add Company";
                                    
            }
            if (Request.QueryString["CompanyID"] != null)
            {
                lblPageHeaderText.Text = "Edit Company";                
                FillControls(Convert.ToInt32(Request.QueryString["CompanyID"]), Convert.ToInt32(Session["UserID"]));

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtCompanyName.Text.Trim() == "")
            strErrorMessage += " - Enter Company Name<br />";

        if (txtGSTNO.Text.Trim() == "")
            strErrorMessage += " - Enter GST No.<br />";

        if (ddlCountryName.SelectedIndex ==0)
            strErrorMessage += " - Select Country<br />";

        if (ddlStateName.SelectedIndex == 0)
            strErrorMessage += " - Select State<br />";

        if (ddlCityName.SelectedIndex == 0)
            strErrorMessage += " - Select City<br />";

        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += " - Enter Company Contact No.<br />";

        if (txtEmail.Text.Trim() == "")
            strErrorMessage += " - Enter Company Email<br />";




        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        CompanyENT entCompany = new CompanyENT();

        if (txtCompanyName.Text.Trim() != "")
            entCompany.CompanyName = txtCompanyName.Text.Trim();

        if (txtGSTNO.Text.Trim() != "")
            entCompany.GSTNo = txtGSTNO.Text.Trim();

        if (txtLandmark.Text.Trim() != "")
            entCompany.Landmark = txtLandmark.Text.Trim();

        if (txtPincode.Text.Trim() != "")
            entCompany.Pincode = txtPincode.Text.Trim();

        if (ddlCountryName.SelectedIndex > 0)
            entCompany.CountryID = Convert.ToInt32(ddlCountryName.SelectedValue);
            

        if (ddlStateName.SelectedIndex > 0)           
            entCompany.StateID = Convert.ToInt32(ddlStateName.SelectedValue);
            

        if (ddlCityName.SelectedIndex > 0)
            entCompany.CityID = Convert.ToInt32(ddlCityName.SelectedValue);

        if (txtContactNo.Text.Trim() != "")
            entCompany.ContactNo = txtContactNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entCompany.Email = txtEmail.Text.Trim();

        if (txtWebsite.Text.Trim() != "")
            entCompany.Website= txtWebsite.Text.Trim();


        if (Session["UserID"] != null)
            entCompany.UserID = Convert.ToInt32(Session["UserID"]);

        entCompany.CreationDate = DateTime.Now;
        entCompany.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        CompanyBAL balCompany = new CompanyBAL();

        if (Request.QueryString["CompanyID"] == null)
        {
            if (balCompany.InsertByUserID(entCompany))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCompany.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entCompany.CompanyID = Convert.ToInt32(Request.QueryString["CompanyID"]);
            if (balCompany.UpdateByPKUserID(entCompany))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Company/CompanyList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCompany.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region FillDropDownLists

    private void FillDropDownLists()
    {

        CommonFillMethods.FillDropDownListCountry(ddlCountryName);

    }

    #region Cascading DropDownLists

    #region State By CountryID
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListStateByCountryID(ddlStateName, Convert.ToInt32(ddlCountryName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlStateName, "State");
            CommonFillMethods.FillEmptyDropDownList(ddlCityName, "City");
        }
    }
    #endregion State By CountryID

    #region City By StateID
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateName.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListCityByStateID(ddlCityName, Convert.ToInt32(ddlStateName.SelectedValue));
        }
        else
        {
            CommonFillMethods.FillEmptyDropDownList(ddlCityName, "City");
        }
    }
    #endregion City By StateID

    #endregion Cascading DropDownLists

    #endregion FillDropDownList

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Company/CompanyList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtCompanyName.Text = "";
        txtGSTNO.Text = "";
        txtLandmark.Text = "";
        txtPincode.Text = "";
        ddlCountryName.SelectedIndex = 0;
        ddlStateName.SelectedIndex = 0;
        ddlCityName.SelectedIndex = 0;
        txtContactNo.Text = "";
        txtEmail.Text = "";
        txtWebsite.Text = "";

        txtCompanyName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 CompanyID, SqlInt32 UserID)
    {
        CompanyENT entCompany = new CompanyENT();
        CompanyBAL balCompany = new CompanyBAL();

        entCompany = balCompany.SelectByPKUserID(CompanyID, UserID);

        if (!entCompany.CompanyName.IsNull)
        {
            txtCompanyName.Text = entCompany.CompanyName.Value.ToString();
        }
        if (!entCompany.GSTNo.IsNull)
        {
            txtGSTNO.Text = entCompany.GSTNo.Value.ToString();
        }
        if (!entCompany.Landmark.IsNull)
        {
            txtLandmark.Text = entCompany.Landmark.Value.ToString();
        }
        if (!entCompany.Pincode.IsNull)
        {
            txtPincode.Text = entCompany.Pincode.Value.ToString();
        }
        if (!entCompany.CountryID.IsNull)
        {
            ddlCountryName.SelectedValue = entCompany.CountryID.Value.ToString();
            CommonFillMethods.FillDropDownListStateByCountryID(ddlStateName, Convert.ToInt32(ddlCountryName.SelectedValue));

        }
        if (!entCompany.StateID.IsNull)
        {
            ddlStateName.SelectedValue = entCompany.StateID.Value.ToString();
            CommonFillMethods.FillDropDownListCityByStateID(ddlCityName, Convert.ToInt32(ddlStateName.SelectedValue));

        }
        if (!entCompany.CityID.IsNull)
        {
            ddlCityName.SelectedValue = entCompany.CityID.Value.ToString();
        }
        if (!entCompany.ContactNo.IsNull)
        {
            txtContactNo.Text = entCompany.ContactNo.Value.ToString();
        }
        if (!entCompany.Email.IsNull)
        {
            txtEmail.Text = entCompany.Email.Value.ToString();
        }
        if (!entCompany.Website.IsNull)
        {
            txtWebsite.Text = entCompany.Website.Value.ToString();
        }


    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnCompanyList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Company/CompanyList.aspx");
    }
    #endregion Redirects Links
}