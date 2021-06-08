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
        if(!Page.IsPostBack)
        {
            txtUsername.Focus();
        }
    }
    #endregion Load Event

    #region Delete User
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region Local Variables
        string strErrorMessage = "";
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
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

        #region Read Form Value
        if (txtUsername.Text != String.Empty)
        {
            strUsername = txtUsername.Text.Trim();
        }
        if (txtPassword.Text != String.Empty)
        {
            strPassword = txtPassword.Text.Trim();
        }
        #endregion Read Form Value

        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_User_SelectByUsernamePassword";
                    objCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = strUsername;
                    objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = strPassword;
                    #endregion Prepare Command

                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    DeleteContactByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteBloodGrouptByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteContactCategoryByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteCityByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteStateByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteCountryByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                    DeleteUserByUserID(Convert.ToInt32(objSDR["UserID"].ToString().Trim()));
                                }
                                
                                lblSuccessMessage.Text = "Deleted SuccessFully";
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if(objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }

    private void DeleteContactByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteCityByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteBloodGrouptByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteContactCategoryByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteStateByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteCountryByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Contact_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
    private void DeleteUserByUserID(SqlInt32 UserID)
    {
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_User_DeleteByUserID";
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
    }

    #endregion Delete User

    protected void lbSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login/UserRegistration.aspx");
    }
}