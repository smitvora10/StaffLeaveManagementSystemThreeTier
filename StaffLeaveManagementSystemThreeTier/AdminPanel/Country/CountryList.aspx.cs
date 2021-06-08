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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();
        dtCountry = balCountry.SelectAllByUserID(UserID);

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountryList.DataSource = dtCountry;
            gvCountryList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete Country

    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            CountryBAL balCountry = new CountryBAL();            

            if (balCountry.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balCountry.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            CountryENT entCountry = new CountryENT();
            CountryBAL balCountry = new CountryBAL();

            entCountry = balCountry.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));


            if (!entCountry.CountryName.IsNull)
                lblCountryName.Text = entCountry.CountryName.Value.ToString();

            if (!entCountry.Code.IsNull)
                lblCode.Text = entCountry.Code.Value.ToString();


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }

    #endregion Delete Country

    #region Button: Add Country
    protected void btnAddCountry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryAddEdit.aspx");
    }
    #endregion Button: Add Country
}