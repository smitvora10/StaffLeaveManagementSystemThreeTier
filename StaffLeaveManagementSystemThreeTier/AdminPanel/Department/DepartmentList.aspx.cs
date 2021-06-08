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

public partial class AdminPanel_Department_DepartmentList : System.Web.UI.Page
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
        DepartmentBAL balDepartment = new DepartmentBAL();
        DataTable dtDepartment = new DataTable();
        dtDepartment = balDepartment.SelectAllByUserID(UserID);

        if (dtDepartment != null && dtDepartment.Rows.Count > 0)
        {
            gvDepartmentList.DataSource = dtDepartment;
            gvDepartmentList.DataBind();
        }


    }
    #endregion Fill Grid View   

    #region Delete Department

    protected void gvDepartmentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            DepartmentBAL balDepartment = new DepartmentBAL();

            if (balDepartment.DeleteByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"])))
            {
                FillInGridView(Convert.ToInt32(Session["UserID"]));
            }

            else
            {
                lblErrorMessage.Text = balDepartment.Message;
            }
        }

        #region View Record
        if (e.CommandName == "ViewRecord")
        {
            DepartmentENT entDepartment = new DepartmentENT();
            DepartmentBAL balDepartment = new DepartmentBAL();

            entDepartment = balDepartment.SelectByPKUserID(Convert.ToInt32(e.CommandArgument.ToString().Trim()), Convert.ToInt32(Session["UserID"]));

            if (!entDepartment.DepartmentName.IsNull)
            {
                lblDepartmentName.Text = entDepartment.DepartmentName.Value.ToString();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }
        #endregion View Record

    }

    #endregion Delete Department

    #region Button: Add Department
    protected void btnAddDepartment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Department/DepartmentAddEdit.aspx");
    }
    #endregion Button: Add Department
}