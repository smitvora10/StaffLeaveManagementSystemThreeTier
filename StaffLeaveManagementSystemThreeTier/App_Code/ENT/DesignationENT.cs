using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DesignationENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class DesignationENT
    {
        #region Construction
        public DesignationENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

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

        #region DesignationName
        protected SqlString _DesignationName;

        public SqlString DesignationName
        {
            get
            {
                return _DesignationName;
            }
            set
            {
                _DesignationName = value;
            }
        }
        #endregion DesignationName

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

        #region TotalDesignations
        protected SqlInt32 _TotalDesignations;

        public SqlInt32 TotalDesignations
        {
            get
            {
                return _TotalDesignations;
            }
            set
            {
                _TotalDesignations = value;
            }
        }
        #endregion TotalDesignations

    }
}