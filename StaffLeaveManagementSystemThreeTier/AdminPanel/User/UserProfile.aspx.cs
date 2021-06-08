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

public partial class AdminPanel_User_UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            CommonFillMethods.FillDropDownListCountries(ddlCountries);
            FillControls(Convert.ToInt32(Session["UserID"]));
            if (Session["Username"] != null)
            {
                lblUsername.Text =Session["Username"].ToString().Trim();
            }
            if (Session["Email"] != null)
            {
                lblEmail.Text = Session["Email"].ToString().Trim();
            }

        }
    }

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtUsername.Text.Trim() == "")
            strErrorMessage += " - Enter Username <br />";

        if (txtEmail.Text.Trim() == "")
            strErrorMessage += " - Enter Email <br />";

        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += " - Enter ContactNo. <br />";

        if (strErrorMessage != "")
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
            entUser.Username = txtUsername.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entUser.Email = txtEmail.Text.Trim();

        if (txtContactNo.Text.Trim() != "")
            entUser.ContactNo = txtContactNo.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            entUser.Address = txtAddress.Text.Trim();

        if (ddlCountries.SelectedIndex > 0)
            entUser.CountriesID = Convert.ToInt32(ddlCountries.SelectedValue);

        if(fuUserPhoto.HasFiles)
        {
            String strPhotoLocation = "~/Content/assets/plugins/images/users/";

            String strPhysicalPath = "";
            strPhotoLocation += fuUserPhoto.FileName;
            strPhysicalPath = Server.MapPath(strPhotoLocation);
            if (File.Exists(strPhysicalPath))
            {
                File.Delete(strPhysicalPath);
            }
            fuUserPhoto.SaveAs(strPhysicalPath);
            entUser.UserPhoto = strPhotoLocation;
            
        }


        if (Session["UserID"] != null)
        {
            entUser.UserID = Convert.ToInt32(Session["UserID"]);
        }

        entUser.CreationDate = DateTime.Now;
        entUser.ModificationDate = DateTime.Now;
        #endregion Collect Form Data


        UserBAL balUser = new UserBAL();
        
        
        entUser.UserID = Convert.ToInt32(Session["UserID"]);
        if (balUser.UpdateByUserID(entUser))
        {
            ClearControls();
            lblSuccessMessage.Text = "Data Updated Successfully";
            divSuccess.Visible = true;
            divError.Visible = false;
        }
        else
        {
            lblErrorMessage.Text = balUser.Message;
            divError.Visible = true;
            divSuccess.Visible = false;

        }
        




    }
    #endregion Button : Save

    #region Clear Controls

    private void ClearControls()
    {
        txtUsername.Text = "";
        txtEmail.Text = "";
        txtContactNo.Text = "";
        txtAddress.Text = "";
        ddlCountries.SelectedIndex = 0;
        txtUsername.Focus();

    }

    #endregion Clear Controls

    #region Fill Controls
    private void FillControls(SqlInt32 UserID)
    {
        UserENT entUser = new UserENT();
        UserBAL balUser = new UserBAL();

        entUser = balUser.SelectByPK(Convert.ToInt32(Session["UserID"]));

        if (!entUser.Username.IsNull)
        {
            txtUsername.Text = entUser.Username.Value.ToString();
        }
        if (!entUser.Email.IsNull)
        {
            txtEmail.Text = entUser.Email.Value.ToString();
            Session["Email"] = entUser.Email.Value.ToString();
        }
        if (!entUser.ContactNo.IsNull)
        {
            txtContactNo.Text = entUser.ContactNo.Value.ToString();
        }
        if (!entUser.Address.IsNull)
        {
            txtAddress.Text = entUser.Address.Value.ToString();
        }

        if (!entUser.CountriesID.IsNull)
        { 
            ddlCountries.SelectedValue = entUser.CountriesID.Value.ToString();
        }
        if (!entUser.UserPhoto.IsNull)
        {
            imgUserPhoto.ImageUrl = entUser.UserPhoto.Value.ToString();
            imgUserPhoto1.ImageUrl = entUser.UserPhoto.Value.ToString();
        }

    }

    #endregion Fill Controls

    #region Cancel Button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Cancel Button


}