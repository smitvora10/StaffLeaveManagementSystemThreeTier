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

public partial class AdminPanel_Designation_DesignationAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DesignationID"] == null)
            {
                lblPageHeaderText.Text = "Add Designation";

            }
            if (Request.QueryString["DesignationID"] != null)
            {
                lblPageHeaderText.Text = "Edit Designation";
                FillControls(Convert.ToInt32(Request.QueryString["DesignationID"]), Convert.ToInt32(Session["UserID"]));

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtDesignationName.Text.Trim() == "")
            strErrorMessage += " - Enter Designation Name<br />";


        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation
        #region Collect Form Data

        DesignationENT entDesignation = new DesignationENT();

        if (txtDesignationName.Text.Trim() != "")
            entDesignation.DesignationName = txtDesignationName.Text.Trim();


        if (Session["UserID"] != null)
            entDesignation.UserID = Convert.ToInt32(Session["UserID"]);

        entDesignation.CreationDate = DateTime.Now;
        entDesignation.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        DesignationBAL balDesignation = new DesignationBAL();

        if (Request.QueryString["DesignationID"] == null)
        {
            if (balDesignation.InsertByUserID(entDesignation))
            {
                ClearControls();
                lblSuccessMessage.Text = "Data Inserted Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balDesignation.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        else
        {
            entDesignation.DesignationID = Convert.ToInt32(Request.QueryString["DesignationID"]);
            if (balDesignation.UpdateByPKUserID(entDesignation))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Designation/DesignationList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balDesignation.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }


    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Designation/DesignationList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        txtDesignationName.Text = "";
        txtDesignationName.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 DesignationID, SqlInt32 UserID)
    {
        DesignationENT entDesignation = new DesignationENT();
        DesignationBAL balDesignation = new DesignationBAL();

        entDesignation = balDesignation.SelectByPKUserID(DesignationID, UserID);

        if (!entDesignation.DesignationName.IsNull)
        {
            txtDesignationName.Text = entDesignation.DesignationName.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Redirects Links
    protected void btnDesignationList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Designation/DesignationList.aspx");
    }
    #endregion Redirects Links
}