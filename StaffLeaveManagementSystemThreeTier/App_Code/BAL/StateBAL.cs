using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class StateBAL
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
        public StateBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.InsertByUserID(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By PK UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.DeleteByPKUserID(StateID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion Delete By PK UserID Operation

        #region Update By PK UserID Operation
        public Boolean UpdateByPKUserID(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.UpdateByPKUserID(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Update By PK UserID Operation

        #region Select Operation

        #region Select State DropDown List By CountryID
        public DataTable SelectForDropDownListByCountryID(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownListByCountryID(CountryID);
        }
        #endregion Select State DropDown List By CountryID

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public StateENT ShowCountByUserID(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public StateENT SelectByPKUserID(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPKUserID(StateID, UserID);
        }

        #endregion SelectByPKUserID

        #endregion Select Operation
    }
}