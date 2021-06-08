using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveTypeBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class LeaveTypeBAL
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
        public LeaveTypeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(LeaveTypeENT entLeaveType)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            if (dalLeaveType.InsertByUserID(entLeaveType))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 LeaveTypeID, SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();

            if (dalLeaveType.DeleteByPKUserID(LeaveTypeID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(LeaveTypeENT entLeaveType)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            if (dalLeaveType.UpdateByPKUserID(entLeaveType))
            {
                return true;
            }
            else
            {
                Message = dalLeaveType.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectAllByUserID(UserID);
        }

        public DataTable SelectForLeaveCreditAdd(SqlInt32 EmployeeID, SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectForLeaveCreditAdd(EmployeeID, UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public LeaveTypeENT ShowCountByUserID(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectForDropDownList(UserID);
        }
        #endregion Select For Dropdown List

        #region Select For Dropdown List
        public DataTable LeaveTypeDropDownListByEmployeeID(SqlInt32 EmployeeID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.LeaveTypeDropDownListByEmployeeID(EmployeeID);
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public LeaveTypeENT SelectByPKUserID(SqlInt32 LeaveTypeID, SqlInt32 UserID)
        {
            LeaveTypeDAL dalLeaveType = new LeaveTypeDAL();
            return dalLeaveType.SelectByPKUserID(LeaveTypeID, UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}