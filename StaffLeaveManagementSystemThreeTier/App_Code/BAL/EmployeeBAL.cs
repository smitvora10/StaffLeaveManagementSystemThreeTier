using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class EmployeeBAL
    {
        #region Local Variable
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

        #endregion Local Variable

        #region Constructor
        public EmployeeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if (dalEmployee.InsertByUserID(entEmployee))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 EmployeeID, SqlInt32 UserID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();

            if (dalEmployee.DeleteByPKUserID(EmployeeID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(EmployeeENT entEmployee)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            if (dalEmployee.UpdateByPKUserID(entEmployee))
            {
                return true;
            }
            else
            {
                Message = dalEmployee.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public EmployeeENT ShowCountByUserID(SqlInt32 UserID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List Of Employee Code
        public DataTable SelectForDropDownListOfEmployeeCode()
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectForDropDownListOfEmployeeCode();
        }
        #endregion Select For Dropdown List Of Employee Code

        #region Select For Dropdown List Of Employee Name
        public DataTable SelectForDropDownListOfEmployeeName()
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectForDropDownListOfEmployeeName();
        }
        #endregion Select For Dropdown List Of Employee Name

        #region Select By PK UserID
        public EmployeeENT SelectByPKUserID(SqlInt32 EmployeeID, SqlInt32 UserID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectByPKUserID(EmployeeID, UserID);
        }

        #endregion Select By PK UserID

        #region Select Employee By EmployeeCode UserID
        public EmployeeENT SelectByEmployeeCodeUserID(SqlInt32 EmployeeCode, SqlInt32 UserID)
        {
            EmployeeDAL dalEmployee = new EmployeeDAL();
            return dalEmployee.SelectByEmployeeCodeUserID(EmployeeCode, UserID);
        }
        #endregion Select Employee By EmployeeCode UserID

        #endregion Select Operation
    }
}