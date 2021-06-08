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
/// Summary description for LeavesTakenDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class LeavesTakenDAL : DatabaseConfig
    {
        #region Constructor
        public LeavesTakenDAL()
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

        public Boolean InsertByUserID(LeavesTakenENT entLeavesTaken)
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
                        objCmd.CommandText = "PR_LeavesTaken_InsertByUserID";


                        objCmd.Parameters.Add("@LeavesTakenID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@EmployeeID", entLeavesTaken.EmployeeID);
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", entLeavesTaken.LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@LeavesRemaining", entLeavesTaken.LeavesRemaining);
                        objCmd.Parameters.AddWithValue("@StartingDayForLeaves", entLeavesTaken.StartingDayForLeaves);
                        objCmd.Parameters.AddWithValue("@NoOfDays", entLeavesTaken.NoOfDays);
                        objCmd.Parameters.AddWithValue("@UserID", entLeavesTaken.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entLeavesTaken.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeavesTaken.ModificationDate);




                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entLeavesTaken.LeavesTakenID = Convert.ToInt32(objCmd.Parameters["@LeavesTakenID"].Value);



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

        public Boolean UpdateByPKUserID(LeavesTakenENT entLeavesTaken)
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
                        objCmd.CommandText = "PR_LeavesTaken_UpdateByPKUserID";

                        objCmd.Parameters.AddWithValue("@LeavesTakenID", entLeavesTaken.LeavesTakenID);
                        objCmd.Parameters.AddWithValue("@EmployeeID", entLeavesTaken.EmployeeID);
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", entLeavesTaken.LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@LeavesRemaining", entLeavesTaken.LeavesRemaining);
                        objCmd.Parameters.AddWithValue("@StartingDayForLeaves", entLeavesTaken.StartingDayForLeaves);
                        objCmd.Parameters.AddWithValue("@NoOfDays", entLeavesTaken.NoOfDays);
                        objCmd.Parameters.AddWithValue("@UserID", entLeavesTaken.UserID);                       
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeavesTaken.ModificationDate);

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

        public Boolean DeleteByPKUserID(SqlInt32 LeavesTakenID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeavesTaken_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeavesTakenID", LeavesTakenID);
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
                        objCmd.CommandText = "PR_LeavesTaken_SelectAllByUserID";
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


        #region Select For Duplicate By EmployeeCode UserID  Operation
        public DataTable SelectForDuplicateByEmployeeCodeUserID(SqlInt32 EmployeeID,SqlDateTime StartingDayForLeaves,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeavesTaken_SelectForDuplicateByEmployeeCodeUserID";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        objCmd.Parameters.AddWithValue("@StartingDayForLeaves", StartingDayForLeaves);
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
        #endregion Select For Duplicate By EmployeeCode UserID Operation



        #region Leaves Remaining Table By UserID  Operation
        public DataTable LeavesRemainingTableByUserID(SqlInt32 EmployeeID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeavesRemainingTableByUserID";
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
        #endregion Leaves Remaining Table By UserID Operation

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
                        objCmd.CommandText = "PR_LeavesTaken_SelectForDropDownList";
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
        public LeavesTakenENT SelectByPKUserID(SqlInt32 LeavesTakenID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeavesTaken_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeavesTakenID", LeavesTakenID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        LeavesTakenENT entLeavesTaken = new LeavesTakenENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["LeavesTakenID"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.LeavesTakenID = Convert.ToInt32(objSDR["LeavesTakenID"]);
                                }
                                if (!objSDR["EmployeeID"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                }
                                if (!objSDR["LeaveTypeID"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.LeaveTypeID = Convert.ToInt32(objSDR["LeaveTypeID"]);
                                }
                                if (!objSDR["LeavesRemaining"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.LeavesRemaining = Convert.ToInt32(objSDR["LeavesRemaining"]);
                                }
                                if (!objSDR["StartingDayForLeaves"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.StartingDayForLeaves = Convert.ToDateTime(objSDR["StartingDayForLeaves"]);
                                }
                                if (!objSDR["NoOfDays"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.NoOfDays = Convert.ToDecimal(objSDR["NoOfDays"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entLeavesTaken.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }
                            return entLeavesTaken;
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