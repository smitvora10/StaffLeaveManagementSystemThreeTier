using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class CityBAL
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
        public CityBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation

        public Boolean InsertByUserID(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.InsertByUserID(entCity))
            {
                return true;
            }

            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Insert By UserID Operation

        #region Update By PK UserID Operation

        public Boolean UpdateByPKUserID(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.UpdateByPKUserID(entCity))
            {
                return true;
            }

            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Update By PK UserID Operation

        #region Delete By PK UserID  Operation

        public Boolean DeleteByPKUserID(SqlInt32 CityID,SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.DeleteByPKUserID(CityID,UserID))
            {
                return true;
            }

            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Delete By PK UserID  Operation

        #region Select Operation

        #region Select For Dropdown List By StateID
        public DataTable SelectForDropDownListByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownListByStateID(StateID);
        }
        #endregion Select For Dropdown List By StateID

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public CityENT ShowCountByUserID(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region Select By PK UserID
        public CityENT SelectByPKUserID(SqlInt32 CityID, SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPKUserID(CityID, UserID);
        }
        #endregion Select By PK UserID

        #endregion Select Operation

    }
}