using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class CountryBAL
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
        public CountryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.InsertByUserID(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.DeleteByPKUserID(CountryID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.UpdateByPKUserID(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public CountryENT ShowCountByUserID(SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public CountryENT SelectByPKUserID(SqlInt32 CountryID,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPKUserID(CountryID,UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}