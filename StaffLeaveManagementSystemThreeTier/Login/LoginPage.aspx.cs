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

public partial class Login_LoginPage : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Event

    #region Login Event
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string strErrorMessage = "";

        #endregion Local Variables

        #region Server Side validation
        if(txtUsername.Text == String.Empty)
        {
            strErrorMessage += "Enter Username <br />";
        }
        if (txtPassword.Text == String.Empty)
        {
            strErrorMessage += "Enter Password <br />";
        }
        if(strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side validation

        UserENT entUser = new UserENT();

        #region Read Form Value
        if (txtUsername.Text != String.Empty)
        {
            entUser.Username = txtUsername.Text.Trim();
        }
        if (txtPassword.Text != String.Empty)
        {
            entUser.Password = txtPassword.Text.Trim();
        }
        #endregion Read Form Value

        FillControls(entUser.Username, entUser.Password);

    }

    #region Fill Controls
    private void FillControls(SqlString Username, SqlString Password)
    {
        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectByUsernamePassword(Username, Password);


        if (!entUser.UserID.IsNull)
        {
            Session["UserID"] = Convert.ToInt32(entUser.UserID.Value);
        }

        else
        {
            lblErrorMessage.Text = "Invalid Username or Password";
            return;
        }

        if (!entUser.Username.IsNull)
        {
            Session["Username"] = entUser.Username.Value.ToString();           
        }

        Response.Redirect("~/AdminPanel/Dashboard/Dashboard.aspx");

    }

    #endregion Fill Controls

    #endregion Login Event


    protected void lbSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/UserRegistration.aspx");
    }
}