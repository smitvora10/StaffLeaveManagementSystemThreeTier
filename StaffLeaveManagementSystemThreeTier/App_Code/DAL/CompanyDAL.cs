using StaffLeaveManagementSystemThreeTier;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyDAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class CompanyDAL : DatabaseConfig
    {
        #region Local variables

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local variables

        #region Constructor
        public CompanyDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation

        public Boolean InsertByUserID(CompanyENT entCompany)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_InsertByUserID";

                        objCmd.Parameters.Add("@CompanyID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CompanyName", entCompany.CompanyName);
                        objCmd.Parameters.AddWithValue("@GSTNo", entCompany.GSTNo);
                        objCmd.Parameters.AddWithValue("@Landmark", entCompany.Landmark);
                        objCmd.Parameters.AddWithValue("@Pincode", entCompany.Pincode);
                        objCmd.Parameters.AddWithValue("@CountryID", entCompany.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entCompany.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entCompany.CityID);
                        objCmd.Parameters.AddWithValue("@ContactNo", entCompany.ContactNo);
                        objCmd.Parameters.AddWithValue("@Email", entCompany.Email);
                        objCmd.Parameters.AddWithValue("@Website", entCompany.Website);
                        objCmd.Parameters.AddWithValue("@UserID", entCompany.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entCompany.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entCompany.ModificationDate);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCompany.CompanyID = Convert.ToInt32(objCmd.Parameters["@CompanyID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Insert By UserID Operation

        #region Update By PK UserID Operation

        public Boolean UpdateByPKUserID(CompanyENT entCompany)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_UpdateByPKUserID";

                        objCmd.Parameters.AddWithValue("@CompanyID", entCompany.CompanyID);
                        objCmd.Parameters.AddWithValue("@CompanyName", entCompany.CompanyName);
                        objCmd.Parameters.AddWithValue("@GSTNo", entCompany.GSTNo);
                        objCmd.Parameters.AddWithValue("@Landmark", entCompany.Landmark);
                        objCmd.Parameters.AddWithValue("@Pincode", entCompany.Pincode);
                        objCmd.Parameters.AddWithValue("@CountryID", entCompany.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entCompany.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entCompany.CityID);
                        objCmd.Parameters.AddWithValue("@ContactNo", entCompany.ContactNo);
                        objCmd.Parameters.AddWithValue("@Email", entCompany.Email);
                        objCmd.Parameters.AddWithValue("@Website", entCompany.Website);
                        objCmd.Parameters.AddWithValue("@UserID", entCompany.UserID);                       
                        objCmd.Parameters.AddWithValue("@ModificationDate", entCompany.ModificationDate);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }

                }
            }
        }

        #endregion Update By PK UserID Operation

        #region Delete By PK UserID Operation

        public Boolean DeleteByPKUserID(SqlInt32 CompanyID,SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion Delete By PK UserID Operation

        #region Select Operation

        #region Select All By UserID Operation
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_SelectAllByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select All By UserID Operation

        #region Show Count By UserID Operation
        public CompanyENT ShowCountByUserID(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CountCompanyByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        CompanyENT entCompany = new CompanyENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["TotalCompanies"].Equals(DBNull.Value))
                                {
                                    entCompany.TotalCompanies = Convert.ToInt32(objSDR["TotalCompanies"]);
                                }
                            }
                            return entCompany;
                        }


                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Show Count By UserID Operation

        #region Select By PK UserID Operation
        public CompanyENT SelectByPKUserID(SqlInt32 CompanyID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        CompanyENT entCompany = new CompanyENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CompanyID"].Equals(DBNull.Value))
                                {
                                    entCompany.CompanyID = Convert.ToInt32(objSDR["CompanyID"]);
                                }
                                if (!objSDR["CompanyName"].Equals(DBNull.Value))
                                {
                                    entCompany.CompanyName = Convert.ToString(objSDR["CompanyName"]);
                                }
                                if (!objSDR["GSTNo"].Equals(DBNull.Value))
                                {
                                    entCompany.GSTNo = Convert.ToString(objSDR["GSTNo"]);
                                }
                                if (!objSDR["Landmark"].Equals(DBNull.Value))
                                {
                                    entCompany.Landmark = Convert.ToString(objSDR["Landmark"]);
                                }
                                if (!objSDR["Pincode"].Equals(DBNull.Value))
                                {
                                    entCompany.Pincode = Convert.ToString(objSDR["Pincode"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entCompany.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entCompany.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entCompany.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entCompany.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entCompany.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["Website"].Equals(DBNull.Value))
                                {
                                    entCompany.Website = Convert.ToString(objSDR["Website"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entCompany.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entCompany.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entCompany.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                            return entCompany;
                        }

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion Select By PK UserID Operation

        #region Select For Dropdownlist Operation
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Company_SelectForDropDownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }

                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }

                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }

        #endregion Select For Dropdownlist Operation

        #endregion Select Operation

    }
}