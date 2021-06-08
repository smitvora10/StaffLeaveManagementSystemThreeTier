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
/// Summary description for LeaveTypeDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class LeaveTypeDAL : DatabaseConfig
    {
        #region Constructor
        public LeaveTypeDAL()
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

        public Boolean InsertByUserID(LeaveTypeENT entLeaveType)
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
                        objCmd.CommandText = "PR_LeaveType_InsertByUserID";


                        objCmd.Parameters.Add("@LeaveTypeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@LeaveType", entLeaveType.LeaveType);
                        objCmd.Parameters.AddWithValue("@UserID", entLeaveType.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entLeaveType.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeaveType.ModificationDate);




                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entLeaveType.LeaveTypeID = Convert.ToInt32(objCmd.Parameters["@LeaveTypeID"].Value);



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

        public Boolean UpdateByPKUserID(LeaveTypeENT entLeaveType)
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
                        objCmd.CommandText = "PR_LeaveType_UpdateByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", entLeaveType.LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@LeaveType", entLeaveType.LeaveType);
                        objCmd.Parameters.AddWithValue("@UserID", entLeaveType.UserID);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entLeaveType.ModificationDate);

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

        public Boolean DeleteByPKUserID(SqlInt32 LeaveTypeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveType_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", LeaveTypeID);
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
                        objCmd.CommandText = "PR_LeaveType_SelectAllByUserID";
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

        public DataTable SelectForLeaveCreditAdd(SqlInt32 EmployeeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveType_SelectForLeaveCreditAdd";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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
        public LeaveTypeENT ShowCountByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_CountLeaveTypeByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        LeaveTypeENT entLeaveType = new LeaveTypeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["TotalLeaveTypes"].Equals(DBNull.Value))
                                {
                                    entLeaveType.TotalLeaveTypes = Convert.ToInt32(objSDR["TotalLeaveTypes"]);
                                }
                            }
                            return entLeaveType;
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
        public DataTable SelectForDropDownList(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveType_SelectForDropDownList";
                        objCmd.Parameters.AddWithValue("@UserID",UserID);

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

        #region LeaveType DropDownList By EmployeeID  Operation
        public DataTable LeaveTypeDropDownListByEmployeeID(SqlInt32 EmployeeID)
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
                        objCmd.CommandText = "PR_LeaveType_SelectForDropDownListByEmployeeID";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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
        #endregion LeaveType DropDownList By EmployeeID Operation

        #region Select By PK UserID Operation
        public LeaveTypeENT SelectByPKUserID(SqlInt32 LeaveTypeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_LeaveType_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@LeaveTypeID", LeaveTypeID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        LeaveTypeENT entLeaveType = new LeaveTypeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["LeaveTypeID"].Equals(DBNull.Value))
                                {
                                    entLeaveType.LeaveTypeID = Convert.ToInt32(objSDR["LeaveTypeID"]);
                                }
                                if (!objSDR["LeaveType"].Equals(DBNull.Value))
                                {
                                    entLeaveType.LeaveType = Convert.ToString(objSDR["LeaveType"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entLeaveType.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entLeaveType.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entLeaveType.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }
                            return entLeaveType;
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