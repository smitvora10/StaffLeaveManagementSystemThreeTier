using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveCreditsENT
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class LeaveCreditsENT
    {
        #region Construction
        public LeaveCreditsENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

        #region LeaveCreditsID
        protected SqlInt32 _LeaveCreditsID;

        public SqlInt32 LeaveCreditsID
        {
            get
            {
                return _LeaveCreditsID;
            }
            set
            {
                _LeaveCreditsID = value;
            }
        }
        #endregion LeaveCreditsID

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

        #region LeavesCredited
        protected SqlInt32 _LeavesCredited;

        public SqlInt32 LeavesCredited
        {
            get
            {
                return _LeavesCredited;
            }
            set
            {
                _LeavesCredited = value;
            }
        }
        #endregion LeavesCredited

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