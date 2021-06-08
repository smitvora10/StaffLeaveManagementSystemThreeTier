using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAllByUserID(UserID);

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCityList.DataSource = dtCity;
            gvCityList.DataBind();
        }

    }
    #endregion Fill Grid View

    #region Delete Row Command
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            CityBAL balCity = new CityBAL();

            if (balCity.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()),Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            CityENT entCity = new CityENT();
            CityBAL balCity = new CityBAL();
            StateENT entState = new StateENT();
            StateBAL balState = new StateBAL();

            entCity = balCity.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));
            entState = balState.SelectByPKUserID(entCity.StateID, Convert.ToInt32(Session["UserID"]));
            
            if (!entCity.CityName.IsNull)            
                lblCityName.Text = entCity.CityName.Value.ToString();
            
            if (!entCity.Pincode.IsNull)
                lblPincode.Text = entCity.Pincode.Value.ToString();

            if (!entState.StateName.IsNull)
                lblStateName.Text = entState.StateName.ToString().Trim();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        #endregion View Record

    }
    #endregion Delete Row Command

    #region Button: Add City
    protected void btnAddCity_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityAddEdit.aspx");
    }
    #endregion Button: Add City



}