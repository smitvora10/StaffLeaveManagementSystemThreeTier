using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class CompanyENT
    {
        #region Construction
        public CompanyENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

        #region CompanyID
        protected SqlInt32 _CompanyID;

        public SqlInt32 CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }
        #endregion CompanyID

        #region CompanyName
        protected SqlString _CompanyName;

        public SqlString CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        #endregion CompanyName

        #region GSTNo
        protected SqlString _GSTNo;

        public SqlString GSTNo
        {
            get
            {
                return _GSTNo;
            }
            set
            {
                _GSTNo = value;
            }
        }
        #endregion GSTNo

        #region Landmark
        protected SqlString _Landmark;

        public SqlString Landmark
        {
            get
            {
                return _Landmark;
            }
            set
            {
                _Landmark = value;
            }
        }
        #endregion Landmark

        #region Pincode
        protected SqlString _Pincode;

        public SqlString Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }
        #endregion Pincode

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

        #region Website
        protected SqlString _Website;

        public SqlString Website
        {
            get
            {
                return _Website;
            }
            set
            {
                _Website = value;
            }
        }
        #endregion Website

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

        #region TotalCompanies
        protected SqlInt32 _TotalCompanies;

        public SqlInt32 TotalCompanies
        {
            get
            {
                return _TotalCompanies;
            }
            set
            {
                _TotalCompanies = value;
            }
        }
        #endregion TotalCompanies





    }
}