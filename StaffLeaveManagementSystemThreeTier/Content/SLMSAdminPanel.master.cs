using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SLMSAdminPanel_SLMSAdminPanel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/LoginPage.aspx");
        }
        #endregion Check Valid User

        #region Using username as label
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                lblUsername.Text = "Hi " + Session["Username"].ToString().Trim();
            }
            FillControls(Convert.ToInt32(Session["UserID"]));

        }
        #endregion Using username as label
    }

    #region Fill Controls
    private void FillControls(SqlInt32 UserID)
    {
        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectByPK(Convert.ToInt32(Session["UserID"]));


        if (!entUser.UserPhoto.IsNull)
        {            
            imgUserPhoto1.ImageUrl = entUser.UserPhoto.Value.ToString();
        }
        else
        {
            imgUserPhoto1.ImageUrl = "~/Content/assets/plugins/images/users/user-icon.jpg";
        }

    }

    #endregion Fill Controls

    protected void hlbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login/LoginPage.aspx");

    }
}
