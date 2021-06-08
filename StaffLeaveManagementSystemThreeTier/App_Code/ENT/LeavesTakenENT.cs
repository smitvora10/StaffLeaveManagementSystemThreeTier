using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeavesTakenENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class LeavesTakenENT
    {
        #region Construction
        public LeavesTakenENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

        #region LeavesTakenID
        protected SqlInt32 _LeavesTakenID;

        public SqlInt32 LeavesTakenID
        {
            get
            {
                return _LeavesTakenID;
            }
            set
            {
                _LeavesTakenID = value;
            }
        }
        #endregion LeavesTakenID

        #region EmployeeID
        protected SqlInt32 _EmployeeID;

        public SqlInt32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        #endregion EmployeeID

        #region LeaveTypeID
        protected SqlInt32 _LeaveTypeID;

        public SqlInt32 LeaveTypeID
        {
            get
            {
                return _LeaveTypeID;
            }
            set
            {
                _LeaveTypeID = value;
            }
        }
        #endregion LeaveTypeID

        #region LeavesRemaining
        protected SqlInt32 _LeavesRemaining;

        public SqlInt32 LeavesRemaining
        {
            get
            {
                return _LeavesRemaining;
            }
            set
            {
                _LeavesRemaining = value;
            }
        }
        #endregion LeavesRemaining

        #region StartingDayForLeaves
        protected SqlDateTime _StartingDayForLeaves;

        public SqlDateTime StartingDayForLeaves
        {
            get
            {
                return _StartingDayForLeaves;
            }
            set
            {
                _StartingDayForLeaves = value;
            }
        }
        #endregion StartingDayForLeaves

        #region NoOfDays
        protected SqlDecimal _NoOfDays;

        public SqlDecimal NoOfDays
        {
            get
            {
                return _NoOfDays;
            }
            set
            {
                _NoOfDays = value;
            }
        }
        #endregion NoOfDays

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion UserID

        #region CreationDate
        protected SqlDateTime _CreationDate;

        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }
        #endregion CreationDate

        #region ModificationDate
        protected SqlDateTime _ModificationDate;

        public SqlDateTime ModificationDate
        {
            get
            {
                return _ModificationDate;
            }
            set
            {
                _ModificationDate = value;
            }
        }
        #endregion ModificationDate




    }
}