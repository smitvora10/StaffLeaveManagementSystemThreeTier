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
/// Summary description for CountryDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class CountryDAL : DatabaseConfig
    {
        #region Constructor
        public CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region Insert By UserID Operation

        public Boolean InsertByUserID(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_InsertByUserID";


                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;                       
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@Code", entCountry.Code);
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entCountry.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entCountry.ModificationDate);




                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entCountry.CountryID = Convert.ToInt32(objCmd.Parameters["@CountryID"].Value);                     



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

        public Boolean UpdateByPKUserID(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPKUserID";
                        objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@Code", entCountry.Code);
                        objCmd.Parameters.AddWithValue("@UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entCountry.ModificationDate);

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

        #region  Delete By PK UserID Operation

        public Boolean DeleteByPKUserID(SqlInt32 CountryID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Country_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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

        #region Select All By UserID  Operation
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
                        objCmd.CommandText = "PR_Country_SelectAllByUserID";
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
        public CountryENT ShowCountByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_CountCountryByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["TotalCountries"].Equals(DBNull.Value))
                                {
                                    entCountry.TotalCountries = Convert.ToInt32(objSDR["TotalCountries"]);
                                }
                            }
                            return entCountry;
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
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
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

        #region Select By PK UserID Operation
        public CountryENT SelectByPKUserID(SqlInt32 CountryID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Country_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);
                                }
                                if (!objSDR["Code"].Equals(DBNull.Value))
                                {
                                    entCountry.Code = Convert.ToString(objSDR["Code"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entCountry.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entCountry.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entCountry.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }
                            return entCountry;
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






        #endregion Select Operation
    }

}