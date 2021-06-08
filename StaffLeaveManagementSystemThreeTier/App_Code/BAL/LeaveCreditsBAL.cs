using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveCreditsBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class LeaveCreditsBAL
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
        public LeaveCreditsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(LeaveCreditsENT entLeaveCredits)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            if (dalLeaveCredits.InsertByUserID(entLeaveCredits))
            {
                return true;
            }
            else
            {
                Message = dalLeaveCredits.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 LeaveCreditsID, SqlInt32 UserID)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();

            if (dalLeaveCredits.DeleteByPKUserID(LeaveCreditsID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalLeaveCredits.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(LeaveCreditsENT entLeaveCredits)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            if (dalLeaveCredits.UpdateByPKUserID(entLeaveCredits))
            {
                return true;
            }
            else
            {
                Message = dalLeaveCredits.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            return dalLeaveCredits.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Select All By LeaveTypeID EmployeeID UserID
        public DataTable SelectAllByLeaveTypeIDEmployeeIDUserID(SqlInt32 LeaveTypeID, SqlInt32 EmployeeID, SqlInt32 UserID)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            return dalLeaveCredits.SelectAllByLeaveTypeIDEmployeeIDUserID(LeaveTypeID, EmployeeID,UserID);
        }
        #endregion Select All By LeaveTypeID EmployeeID UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            return dalLeaveCredits.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public LeaveCreditsENT SelectByPKUserID(SqlInt32 LeaveCreditsID, SqlInt32 UserID)
        {
            LeaveCreditsDAL dalLeaveCredits = new LeaveCreditsDAL();
            return dalLeaveCredits.SelectByPKUserID(LeaveCreditsID, UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}