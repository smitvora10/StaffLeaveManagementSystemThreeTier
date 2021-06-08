using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class DepartmentENT
    {
        #region Construction
        public DepartmentENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

        #region DepartmentID
        protected SqlInt32 _DepartmentID;

        public SqlInt32 DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }
        #endregion DepartmentID

        #region DepartmentName
        protected SqlString _DepartmentName;

        public SqlString DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }
        #endregion DepartmentName

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

        #region TotalDepartments
        protected SqlInt32 _TotalDepartments;

        public SqlInt32 TotalDepartments
        {
            get
            {
                return _TotalDepartments;
            }
            set
            {
                _TotalDepartments = value;
            }
        }
        #endregion TotalDepartments

    }
}