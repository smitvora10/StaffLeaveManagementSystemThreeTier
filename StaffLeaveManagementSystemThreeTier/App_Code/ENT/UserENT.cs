using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.ENT
{
    public class UserENT
    {
        #region Construction
        public UserENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Construction

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

        #region Username
        protected SqlString _Username;

        public SqlString Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }
        #endregion Username

        #region Password
        protected SqlString _Password;

        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        #endregion Password

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

        #region CountriesID
        protected SqlInt32 _CountriesID;

        public SqlInt32 CountriesID
        {
            get
            {
                return _CountriesID;
            }
            set
            {
                _CountriesID = value;
            }
        }
        #endregion CountriesID

        #region UserPhoto
        protected SqlString _UserPhoto;

        public SqlString UserPhoto
        {
            get
            {
                return _UserPhoto;
            }
            set
            {
                _UserPhoto = value;
            }
        }
        #endregion UserPhoto

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