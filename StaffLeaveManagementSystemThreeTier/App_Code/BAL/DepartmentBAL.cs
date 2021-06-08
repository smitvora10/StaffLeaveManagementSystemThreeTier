using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class DepartmentBAL
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
        public DepartmentBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            if (dalDepartment.InsertByUserID(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 DepartmentID, SqlInt32 UserID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();

            if (dalDepartment.DeleteByPKUserID(DepartmentID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(DepartmentENT entDepartment)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            if (dalDepartment.UpdateByPKUserID(entDepartment))
            {
                return true;
            }
            else
            {
                Message = dalDepartment.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public DepartmentENT ShowCountByUserID(SqlInt32 UserID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public DepartmentENT SelectByPKUserID(SqlInt32 DepartmentID, SqlInt32 UserID)
        {
            DepartmentDAL dalDepartment = new DepartmentDAL();
            return dalDepartment.SelectByPKUserID(DepartmentID, UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}