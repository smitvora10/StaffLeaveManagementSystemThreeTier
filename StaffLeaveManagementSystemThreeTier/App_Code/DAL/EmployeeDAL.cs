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
/// Summary description for EmployeeDAL
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.DAL
{
    public class EmployeeDAL : DatabaseConfig
    {
        #region Constructor
        public EmployeeDAL()
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

        public Boolean InsertByUserID(EmployeeENT entEmployee)
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
                        objCmd.CommandText = "PR_Employee_InsertByUserID";


                        objCmd.Parameters.Add("@EmployeeID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@EmployeeCode", entEmployee.EmployeeCode);
                        objCmd.Parameters.AddWithValue("@DepartmentID", entEmployee.DepartmentID);
                        objCmd.Parameters.AddWithValue("@DesignationID", entEmployee.DesignationID);
                        objCmd.Parameters.AddWithValue("@EmploymentType", entEmployee.EmploymentType);
                        objCmd.Parameters.AddWithValue("@Address", entEmployee.Address);
                        objCmd.Parameters.AddWithValue("@ContactNo", entEmployee.ContactNo);
                        objCmd.Parameters.AddWithValue("@JoiningDate", entEmployee.JoiningDate);
                        objCmd.Parameters.AddWithValue("@BirthDate", entEmployee.BirthDate);
                        objCmd.Parameters.AddWithValue("@MaritalStatus", entEmployee.MaritalStatus);
                        objCmd.Parameters.AddWithValue("@Email", entEmployee.Email);
                        objCmd.Parameters.AddWithValue("@CountryID", entEmployee.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entEmployee.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entEmployee.CityID);
                        objCmd.Parameters.AddWithValue("@UserID", entEmployee.UserID);
                        objCmd.Parameters.AddWithValue("@CreationDate", entEmployee.CreationDate);
                        objCmd.Parameters.AddWithValue("@ModificationDate", entEmployee.ModificationDate);




                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        entEmployee.EmployeeID = Convert.ToInt32(objCmd.Parameters["@EmployeeID"].Value);



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

        public Boolean UpdateByPKUserID(EmployeeENT entEmployee)
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
                        objCmd.CommandText = "PR_Employee_UpdateByPKUserID";

                        objCmd.Parameters.AddWithValue("@EmployeeID", entEmployee.EmployeeID);
                        objCmd.Parameters.AddWithValue("@EmployeeName", entEmployee.EmployeeName);
                        objCmd.Parameters.AddWithValue("@EmployeeCode", entEmployee.EmployeeCode);
                        objCmd.Parameters.AddWithValue("@DepartmentID", entEmployee.DepartmentID);
                        objCmd.Parameters.AddWithValue("@DesignationID", entEmployee.DesignationID);
                        objCmd.Parameters.AddWithValue("@EmploymentType", entEmployee.EmploymentType);
                        objCmd.Parameters.AddWithValue("@Address", entEmployee.Address);
                        objCmd.Parameters.AddWithValue("@ContactNo", entEmployee.ContactNo);
                        objCmd.Parameters.AddWithValue("@JoiningDate", entEmployee.JoiningDate);
                        objCmd.Parameters.AddWithValue("@BirthDate", entEmployee.BirthDate);
                        objCmd.Parameters.AddWithValue("@MaritalStatus", entEmployee.MaritalStatus);
                        objCmd.Parameters.AddWithValue("@Email", entEmployee.Email);
                        objCmd.Parameters.AddWithValue("@CountryID", entEmployee.CountryID);
                        objCmd.Parameters.AddWithValue("@StateID", entEmployee.StateID);
                        objCmd.Parameters.AddWithValue("@CityID", entEmployee.CityID);
                        objCmd.Parameters.AddWithValue("@UserID", entEmployee.UserID);                       
                        objCmd.Parameters.AddWithValue("@ModificationDate", entEmployee.ModificationDate);

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

        public Boolean DeleteByPKUserID(SqlInt32 EmployeeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Employee_DeleteByPKUserID";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
                        objCmd.CommandText = "PR_Employee_SelectAllByUserID";
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
        public EmployeeENT ShowCountByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_CountEmployeeByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        EmployeeENT entEmployee = new EmployeeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["TotalEmployees"].Equals(DBNull.Value))
                                {
                                    entEmployee.TotalEmployees = Convert.ToInt32(objSDR["TotalEmployees"]);
                                }
                            }
                            return entEmployee;
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



        #region Select For Dropdownlist Of Employee Code Operation
        public DataTable SelectForDropDownListOfEmployeeCode()
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
                        objCmd.CommandText = "PR_Employee_SelectForDropDownListOfEmployeeCode";
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

        #endregion Select For Dropdownlist Of Employee Code Operation

        #region Select For Dropdownlist Of Employee Name Operation
        public DataTable SelectForDropDownListOfEmployeeName()
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
                        objCmd.CommandText = "PR_Employee_SelectForDropDownListOfEmployeeName";
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

        #endregion Select For Dropdownlist Of Employee Name Operation

        #region Select By PK UserID Operation
        public EmployeeENT SelectByPKUserID(SqlInt32 EmployeeID, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Employee_SelectByPKUserID";
                        objCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        EmployeeENT entEmployee = new EmployeeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["EmployeeID"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                }
                                if (!objSDR["EmployeeName"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeName = Convert.ToString(objSDR["EmployeeName"]);
                                }
                                if (!objSDR["EmployeeCode"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeCode = Convert.ToInt32(objSDR["EmployeeCode"]);
                                }
                                if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                {
                                    entEmployee.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);
                                }
                                if (!objSDR["DesignationID"].Equals(DBNull.Value))
                                {
                                    entEmployee.DesignationID = Convert.ToInt32(objSDR["DesignationID"]);
                                }
                                if (!objSDR["EmploymentType"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmploymentType = Convert.ToString(objSDR["EmploymentType"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entEmployee.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entEmployee.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["JoiningDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.JoiningDate = Convert.ToDateTime(objSDR["JoiningDate"]);
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                }
                                if (!objSDR["MaritalStatus"].Equals(DBNull.Value))
                                {
                                    entEmployee.MaritalStatus = Convert.ToString(objSDR["MaritalStatus"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entEmployee.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entEmployee.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entEmployee.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entEmployee.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entEmployee.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }
                            return entEmployee;
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

        #region Select By Employee Code UserID
        public EmployeeENT SelectByEmployeeCodeUserID(SqlInt32 EmployeeCode, SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Employee_SelectByEmployeeCodeUserID";
                        objCmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        EmployeeENT entEmployee = new EmployeeENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["EmployeeID"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeID = Convert.ToInt32(objSDR["EmployeeID"]);
                                }
                                if (!objSDR["EmployeeName"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeName = Convert.ToString(objSDR["EmployeeName"]);
                                }
                                if (!objSDR["EmployeeCode"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmployeeCode = Convert.ToInt32(objSDR["EmployeeCode"]);
                                }
                                if (!objSDR["DepartmentID"].Equals(DBNull.Value))
                                {
                                    entEmployee.DepartmentID = Convert.ToInt32(objSDR["DepartmentID"]);
                                }
                                if (!objSDR["DesignationID"].Equals(DBNull.Value))
                                {
                                    entEmployee.DesignationID = Convert.ToInt32(objSDR["DesignationID"]);
                                }
                                if (!objSDR["EmploymentType"].Equals(DBNull.Value))
                                {
                                    entEmployee.EmploymentType = Convert.ToString(objSDR["EmploymentType"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entEmployee.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                {
                                    entEmployee.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                }
                                if (!objSDR["JoiningDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.JoiningDate = Convert.ToDateTime(objSDR["JoiningDate"]);
                                }
                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.BirthDate = Convert.ToDateTime(objSDR["BirthDate"]);
                                }
                                if (!objSDR["MaritalStatus"].Equals(DBNull.Value))
                                {
                                    entEmployee.MaritalStatus = Convert.ToString(objSDR["MaritalStatus"]);
                                }
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                {
                                    entEmployee.Email = Convert.ToString(objSDR["Email"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entEmployee.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entEmployee.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entEmployee.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entEmployee.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.CreationDate = Convert.ToDateTime(objSDR["CreationDate"]);
                                }
                                if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                {
                                    entEmployee.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"]);
                                }

                            }
                            return entEmployee;
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
        #endregion Select By Employee Code

        #endregion Select Operation
    }

}