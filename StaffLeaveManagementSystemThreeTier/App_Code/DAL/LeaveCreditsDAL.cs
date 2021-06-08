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
/// Summary description for LeaveCreditsDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class LeaveCreditsDAL : DatabaseConfig
    {
        #region Constructor
        public LeaveCreditsDAL()
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

        public Boolean InsertByUserID(LeaveCreditsENT entLeaveCredits)
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
                        objCmd.CommandText = "PR_LeaveCredits_InsertByUserID";


                        objCmd.Parameters.Add("@LeaveCreditsID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@EmployeeID", entLeaveCredits.EmployeeID);
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", entLeaveCredits.LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@LeavesCredited", entLeaveCredits.LeavesCredited);
                        objCmd.Parameters.AddWithValue("@UserID", entLeaveCredits.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entLeaveCredits.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeaveCredits.ModificationDate);




                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entLeaveCredits.LeaveCreditsID = Convert.ToInt32(objCmd.Parameters["@LeaveCreditsID"].Value);



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

        public Boolean UpdateByPKUserID(LeaveCreditsENT entLeaveCredits)
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
                        objCmd.CommandText = "PR_LeaveCredits_UpdateByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveCreditsID", entLeaveCredits.LeaveCreditsID);
                        objCmd.Parameters.AddWithValue("@EmployeeID", entLeaveCredits.EmployeeID);
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", entLeaveCredits.LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@LeavesCredited", entLeaveCredits.LeavesCredited);
                        objCmd.Parameters.AddWithValue("@UserID", entLeaveCredits.UserID);                        
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeaveCredits.ModificationDate);

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

        public Boolean DeleteByPKUserID(SqlInt32 LeaveCreditsID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveCredits_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveCreditsID", LeaveCreditsID);
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
                        objCmd.CommandText = "PR_LeaveCredits_SelectAllByUserID";
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

        #region Select All By LeaveTypeID EmployeeID UserID  Operation
        public DataTable SelectAllByLeaveTypeIDEmployeeIDUserID(SqlInt32 LeaveTypeID, SqlInt32 EmployeeID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveCredits_SelectAllByLeaveTypeIDEmployeeIDUserID";
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
        #endregion Select All By LeaveTypeID EmployeeID UserID Operation

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
                        objCmd.CommandText = "PR_LeaveCredits_SelectForDropDownList";
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
        public LeaveCreditsENT SelectByPKUserID(SqlInt32 LeaveCreditsID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveCredits_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveCreditsID", LeaveCreditsID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        LeaveCreditsENT entLeaveCredits = new LeaveCreditsENT();
                        #region ReadData and Set Controls



                        #endregion ReadData and Set Controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["LeaveCreditsID"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.LeaveCreditsID = Convert.ToInt32(objSDR["LeaveCreditsID"]);
                                }
                                if (!objSDR["EmployeeID"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                }
                                if (!objSDR["LeaveTypeID"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.LeaveTypeID = Convert.ToInt32(objSDR["LeaveTypeID"]);
                                }
                                if (!objSDR["LeavesCredited"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.LeavesCredited = Convert.ToInt32(objSDR["LeavesCredited"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entLeaveCredits.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }
                            }
                            return entLeaveCredits;
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