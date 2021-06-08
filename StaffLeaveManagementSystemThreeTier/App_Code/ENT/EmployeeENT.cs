using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class EmployeeENT
    {
        #region Construction
        public EmployeeENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

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

        #region EmployeeName
        protected SqlString _EmployeeName;

        public SqlString EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        #endregion EmployeeName

        #region EmployeeCode
        protected SqlInt32 _EmployeeCode;

        public SqlInt32 EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }
        #endregion EmployeeCode

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

        #region DesignationID
        protected SqlInt32 _DesignationID;

        public SqlInt32 DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
            }
        }
        #endregion DesignationID

        #region EmploymentType
        protected SqlString _EmploymentType;

        public SqlString EmploymentType
        {
            get
            {
                return _EmploymentType;
            }
            set
            {
                _EmploymentType = value;
            }
        }
        #endregion EmploymentType

        #region Address
        protected SqlString _Address;

        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion Address

        #region ContactNo
        protected SqlString _ContactNo;

        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }
        #endregion ContactNo

        #region JoiningDate
        protected SqlDateTime _JoiningDate;

        public SqlDateTime JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }
        #endregion JoiningDate

        #region BirthDate
        protected SqlDateTime _BirthDate;

        public SqlDateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }
        #endregion BirthDate

        #region MaritalStatus
        protected SqlString _MaritalStatus;

        public SqlString MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                _MaritalStatus = value;
            }
        }
        #endregion MaritalStatus

        #region Email
        protected SqlString _Email;

        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        #endregion Email

        #region CountryID
        protected SqlInt32 _CountryID;

        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }
        #endregion CountryID

        #region StateID
        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        #endregion StateID

        #region CityID
        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion CityID

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

        #region TotalEmployees
        protected SqlInt32 _TotalEmployees;

        public SqlInt32 TotalEmployees
        {
            get
            {
                return _TotalEmployees;
            }
            set
            {
                _TotalEmployees = value;
            }
        }
        #endregion TotalEmployees





    }
}