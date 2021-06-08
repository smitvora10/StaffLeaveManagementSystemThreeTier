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
/// Summary description for UserDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class UserDAL : DatabaseConfig
    {
        #region Constructor
        public UserDAL()
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

        public Boolean InsertByUserID(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_InsertByUserID";


                        objCmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@Username", entUser.Username);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@ContactNo", entUser.ContactNo);
                        objCmd.Parameters.AddWithValue("@Email", entUser.Email);
                        objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                        objCmd.Parameters.AddWithValue("@CountriesID", entUser.CountriesID);
                        objCmd.Parameters.AddWithValue("@UserPhoto", entUser.UserPhoto);
                        objCmd.Parameters.AddWithValue("@CreationDate", entUser.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entUser.ModificationDate);



                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entUser.UserID = Convert.ToInt32(objCmd.Parameters["@UserID"].Value);



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

        #region Update By  UserID Operation

        public Boolean UpdateByUserID(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_UpdateByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", entUser.UserID);
                        objCmd.Parameters.AddWithValue("@Username", entUser.Username);
                        objCmd.Parameters.AddWithValue("@ContactNo", entUser.ContactNo);
                        objCmd.Parameters.AddWithValue("@Email", entUser.Email);
                        objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                        objCmd.Parameters.AddWithValue("@CountriesID", entUser.CountriesID);
                        objCmd.Parameters.AddWithValue("@UserPhoto", entUser.UserPhoto);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entUser.ModificationDate);

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

        #endregion Update By  UserID Operation

        #region  Delete By PK  Operation

        public Boolean DeleteByPK(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_DeleteByPK";
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

        #endregion Delete By PK  Operation

        #region Select Operation

        #region Select All By UserID  Operation
        public DataTable SelectAllByUserID()
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
                        objCmd.CommandText = "PR_User_SelectAllByUserID";

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
        #endregion Select All By UserID  Operation

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
                        objCmd.CommandText = "PR_User_SelectForDropDownList";
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

        #region Select By Username Password Operation
        public UserENT SelectByUsernamePassword(SqlString Username, SqlString Password)
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
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("@Username", Username);
                        objCmd.Parameters.AddWithValue("@Password", Password);


                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {

                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["Username"].Equals(DBNull.Value))
                                {
                                    entUser.Username = Convert.ToString(objSDR["Username"]);
                                }
                                if (!objSDR["Password"].Equals(DBNull.Value))
                                {
                                    entUser.Password = Convert.ToString(objSDR["Password"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entUser.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entUser.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entUser.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entUser.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entUser.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }



                            return entUser;
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
        #endregion Select By Username Password Operation

        #region Select By PK Operation
        public UserENT SelectByPK(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_SelectByPK";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["Username"].Equals(DBNull.Value))
                                {
                                    entUser.Username = Convert.ToString(objSDR["Username"]);
                                }
                                if (!objSDR["Password"].Equals(DBNull.Value))
                                {
                                    entUser.Password = Convert.ToString(objSDR["Password"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entUser.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entUser.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entUser.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["CountriesID"].Equals(DBNull.Value))
                                {
                                    entUser.CountriesID = Convert.ToInt32(objSDR["CountriesID"]);
                                }
                                if (!objSDR["UserPhoto"].Equals(DBNull.Value))
                                {
                                    entUser.UserPhoto = Convert.ToString(objSDR["UserPhoto"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entUser.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entUser.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                            return entUser;
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
        #endregion Select By PK Operation




        #endregion Select Operation
    }

}