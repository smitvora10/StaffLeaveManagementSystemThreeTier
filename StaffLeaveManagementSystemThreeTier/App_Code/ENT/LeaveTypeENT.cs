using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LeaveTypeENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class LeaveTypeENT
    {
        #region Construction
        public LeaveTypeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

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

        #region LeaveType
        protected SqlString _LeaveType;

        public SqlString LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                _LeaveType = value;
            }
        }
        #endregion LeaveType

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

        #region TotalLeaveTypes
        protected SqlInt32 _TotalLeaveTypes;

        public SqlInt32 TotalLeaveTypes
        {
            get
            {
                return _TotalLeaveTypes;
            }
            set
            {
                _TotalLeaveTypes = value;
            }
        }
        #endregion TotalLeaveTypes


    }
}