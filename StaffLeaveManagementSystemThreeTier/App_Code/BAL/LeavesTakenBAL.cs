using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeavesTakenBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class LeavesTakenBAL
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
        public LeavesTakenBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(LeavesTakenENT entLeavesTaken)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            if (dalLeavesTaken.InsertByUserID(entLeavesTaken))
            {
                return true;
            }
            else
            {
                Message = dalLeavesTaken.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 LeavesTakenID, SqlInt32 UserID)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();

            if (dalLeavesTaken.DeleteByPKUserID(LeavesTakenID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeavesTaken.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(LeavesTakenENT entLeavesTaken)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            if (dalLeavesTaken.UpdateByPKUserID(entLeavesTaken))
            {
                return true;
            }
            else
            {
                Message = dalLeavesTaken.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            return dalLeavesTaken.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Select All By UserID
        public DataTable SelectForDuplicateByEmployeeCodeUserID(SqlInt32 EmployeeID, SqlDateTime StartingDayForLeaves, SqlInt32 UserID)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            return dalLeavesTaken.SelectForDuplicateByEmployeeCodeUserID(EmployeeID, StartingDayForLeaves, UserID);
        }
        #endregion Select All By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            return dalLeavesTaken.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public LeavesTakenENT SelectByPKUserID(SqlInt32 LeavesTakenID, SqlInt32 UserID)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            return dalLeavesTaken.SelectByPKUserID(LeavesTakenID, UserID);
        }

        #endregion Select By PK UserID

        #region Leaves Remaining By Table UserID 
        public DataTable LeavesRemainingTableByUserID(SqlInt32 EmployeeID, SqlInt32 UserID)
        {
            LeavesTakenDAL dalLeavesTaken = new LeavesTakenDAL();
            return dalLeavesTaken.LeavesRemainingTableByUserID(EmployeeID, UserID);
        }

        #endregion Leaves Remaining Table By UserID 

        #endregion Select Operation
    }
}