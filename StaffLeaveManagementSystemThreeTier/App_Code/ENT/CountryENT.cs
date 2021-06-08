using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryENT
/// </summary>
/// 

namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class CountryENT
    {
        #region Construction
        public CountryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

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

        #region CountryName
        protected SqlString _CountryName;

        public SqlString CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }
        #endregion CountryName

        #region Code
        protected SqlString _Code;

        public SqlString Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
        #endregion Code

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

        #region TotalCountries
        protected SqlInt32 _TotalCountries;

        public SqlInt32 TotalCountries
        {
            get
            {
                return _TotalCountries;
            }
            set
            {
                _TotalCountries = value;
            }
        }
        #endregion TotalCountries

    }
}
