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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            FillDropDownListState();

            if (Request.QueryString["CityID"] != null)
            {
                lblPageHeaderText.Text = "City Edit";                
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]), Convert.ToInt32(Session["UserID"]));
            }
            else
            {
                lblPageHeaderText.Text = "City Add";
                
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlStateName.SelectedIndex == 0)
            strErrorMessage += "- Select State<br />";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += " - Enter City Name<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        CityENT entCity = new CityENT();

        if (ddlStateName.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateName.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtPincode.Text.Trim() != "")
            entCity.Pincode = txtPincode.Text.Trim();

        if (Session["UserID"] != null)
            entCity.UserID = Convert.ToInt32(Session["UserID"]);

        entCity.CreationDate = DateTime.Now;
        entCity.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.InsertByUserID(entCity))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.UpdateByPKUserID(entCity))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList

    private void FillDropDownListState()
    {
        CommonFillMethods.FillDropDownListState(ddlStateName);
    }

    #endregion FillDropDownList

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        ddlStateName.SelectedIndex = 0;
        txtCityName.Text = "";
        txtPincode.Text = "";
        ddlStateName.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 CityID, SqlInt32 UserID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPKUserID(CityID,UserID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

        if (!entCity.Pincode.IsNull)
            txtPincode.Text = entCity.Pincode.Value.ToString();

        if (!entCity.StateID.IsNull)
            ddlStateName.SelectedValue = entCity.StateID.Value.ToString();
    }

    #endregion FillControls

    #region Redirects Links
    protected void btnCityList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Redirects Links
}