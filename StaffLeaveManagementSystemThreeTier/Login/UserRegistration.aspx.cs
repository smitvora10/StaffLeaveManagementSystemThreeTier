using StaffLeaveManagementSystemThreeTier;
using StaffLeaveManagementSystemThreeTier.BAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFillMethods.FillDropDownListCountries(ddlCountries);
        }

    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {

        #region Server Side Validation
        String strErrorMessage = "";

        if (txtUsername.Text.Trim() == "")
        {
            strErrorMessage += "Enter Username " + "<br/>";
        }

        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "Enter Email" + "<br/>";
        }
        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "Enter Contact No " + "<br/>";
        }

        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "Enter Password " + "<br/>";
        }

        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            divError.Visible = true;
            divSuccess.Visible = false;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        UserENT entUser = new UserENT();
        if (txtUsername.Text.Trim() != "")
        {
            entUser.Username = txtUsername.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            entUser.Password = txtPassword.Text.Trim();
        }
        if (txtEmail.Text.Trim() != "")
        {
            entUser.Email = txtEmail.Text.Trim();
            
        }
        if (txtAddress.Text.Trim() != "")
        {
            entUser.Address = txtAddress.Text.Trim();
        }
        if (ddlCountries.SelectedIndex > 0)
        {
            entUser.CountriesID = Convert.ToInt32(ddlCountries.SelectedValue);
        }
        if (txtContactNo.Text.Trim() != "")
        {
            entUser.ContactNo = txtContactNo.Text.Trim();
        }
        if(fuUserPhoto.HasFiles)
        {
            String strPhotoLocation = "~/Content/assets/plugins/images/users/";
            
            String strPhysicalPath = "";
            strPhotoLocation += fuUserPhoto.FileName;
            strPhysicalPath = Server.MapPath(strPhotoLocation);
            if(File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuUserPhoto.SaveAs(strPhysicalPath);
            entUser.UserPhoto = strPhotoLocation;
        }
        
        //if (Session["UserID"] != null)
        //{
        //    entUser.UserID = Convert.ToInt32(Session["UserID"]);
        //}
            

        entUser.CreationDate = DateTime.Now;
        entUser.ModificationDate = DateTime.Now;

        #endregion Collect Form Data

        UserBAL balUser = new UserBAL();

        if (Request.QueryString["UserID"] == null)
        {
            if (balUser.InsertByUserID(entUser))
            {
                ClearControls();
                lblSuccessMessage.Text = "User Signed Up Successfully";
                divError.Visible = false;
                divSuccess.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = balUser.Message;
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }

    }






    #region Clear Controls

    private void ClearControls()
    {
        lblErrorMessage.Text = "";
        txtUsername.Text = "";
        txtContactNo.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtPassword.Text = "";
        txtRePassword.Text = "";
        
        txtUsername.Focus();

    }

    #endregion Clear Controls


    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {

       
        String strErrorMessage = "";

        if (txtUsername.Text.Trim() == "")
        {
            strErrorMessage += "Enter User Name " + "<br/>";
        }

        UserENT entUser = new UserENT();

        if (txtUsername.Text.Trim() != "")
        {
            entUser.Username = txtUsername.Text.Trim();
        }

        UserBAL balUser = new UserBAL();
        DataTable dtUser = new DataTable();

        dtUser = balUser.SelectAllByUserID();



        

      
    }

    #region Login Page

    protected void lbLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/LoginPage.aspx");
    }
    #endregion Login Page
}