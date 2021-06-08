using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier;
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

public partial class AdminPanel_LeaveCredits_LeaveCreditsAddEdit : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Page.IsPostBack)
        {
            CommonFillMethods.FillDropDownListEmployeeOfEmployeeCode(ddlEmployeeCode);
            if (Request.QueryString["LeaveCreditsID"] == null)
            {
                lblPageHeaderText.Text = "Add Leave Credits";

            }
            if (Request.QueryString["LeaveCreditsID"] != null)
            {
                Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsEdit.aspx");

            }
        }


    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlEmployeeCode.SelectedIndex == 0)
            strErrorMessage += " Select EmployeeCode<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        LeaveCreditsENT entLeaveCredits = new LeaveCreditsENT();

        if (ddlEmployeeCode.SelectedIndex > 0)
            entLeaveCredits.EmployeeID = Convert.ToInt32(ddlEmployeeCode.SelectedValue);

        if (Session["UserID"] != null)
            entLeaveCredits.UserID = Convert.ToInt32(Session["UserID"]);

        entLeaveCredits.CreationDate = DateTime.Now;
        entLeaveCredits.ModificationDate = DateTime.Now;
        #endregion Collect Form Data

        LeaveCreditsBAL balLeaveCredits = new LeaveCreditsBAL();


        #region Collect Repeater Data
       
        
            foreach (RepeaterItem item in rpLeaveCredit.Items)
            {
                TextBox txtLeaveCredits = (TextBox)item.FindControl("txtLeaveCredits");
                HiddenField hfLeaveTypeID = (HiddenField)item.FindControl("hfLeaveTypeID");


                if (txtLeaveCredits.Text != String.Empty)
                {
                    entLeaveCredits.LeaveTypeID = Convert.ToInt32(hfLeaveTypeID.Value);
                    entLeaveCredits.LeavesCredited = Convert.ToInt32(txtLeaveCredits.Text);
                    balLeaveCredits.InsertByUserID(entLeaveCredits);
                }
            }
            ddlEmployeeCode_SelectedIndexChanged(ddlEmployeeCode, EventArgs.Empty);
            lblSuccessMessage.Text = "Data Inserted Successfully";
            divError.Visible = false;
            divSuccess.Visible = true;

        

        #endregion Collect Repeater Data



        //if (Request.QueryString["LeaveCreditsID"] == null)
        //{
        //    if (balLeaveCredits.InsertByUserID(entLeaveCredits))
        //    {
        //        ClearControls();
        //        lblSuccessMessage.Text = "Data Inserted Successfully";
        //        divError.Visible = false;
        //        divSuccess.Visible = true;
        //    }
        //    else
        //    {
        //        lblErrorMessage.Text = balLeaveCredits.Message;
        //        divError.Visible = true;
        //        divSuccess.Visible = false;
        //    }
        //}


    }
    #endregion Button : Save

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsList.aspx");
    }
    #endregion Cancel Button

    #region Clear Controls

    private void ClearControls()
    {
        ddlEmployeeCode.SelectedIndex = 0;
        txtEmployeeName.Text = "";
        ddlEmployeeCode.Focus();
        
    }

    #endregion Clear Controls

    

    #region Redirects Links
    protected void btnLeaveCreditsList_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/LeaveCredits/LeaveCreditsList.aspx");
    }
    #endregion Redirects Links

    protected void ddlEmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        EmployeeBAL balEmployee = new EmployeeBAL();
        EmployeeENT entEmployee = new EmployeeENT();
        entEmployee = balEmployee.SelectByPKUserID(Convert.ToInt32(ddlEmployeeCode.SelectedValue), Convert.ToInt32(Session["UserID"]));
        if (!entEmployee.EmployeeName.IsNull)
        {
            txtEmployeeName.Text = entEmployee.EmployeeName.Value;
        }
        
        if (!entEmployee.EmployeeID.IsNull)
        {
            BindRepeater(entEmployee.EmployeeID.Value);
        }

    }



    #region Bind Repeater 
    private void BindRepeater(SqlInt32 EmployeeID)
    {
        LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
        DataTable dt = balLeaveType.SelectForLeaveCreditAdd(EmployeeID, Convert.ToInt32(Session["UserID"]));
        rpLeaveCredit.DataSource = dt;
        rpLeaveCredit.DataBind();
    }
    #endregion Bind Repeater
}