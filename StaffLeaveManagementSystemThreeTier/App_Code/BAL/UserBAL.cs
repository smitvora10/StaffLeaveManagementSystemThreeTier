using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class UserBAL
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
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.InsertByUserID(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By PK Operation
        public Boolean DeleteByPK(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.DeleteByPK(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion Delete By PK Operation

        #region Update By UserID Operation
        public Boolean UpdateByUserID(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.UpdateByUserID(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectAllByUserID();
        }
        #endregion Select All By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By Username Password
        public UserENT SelectByUsernamePassword(SqlString Username, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUsernamePassword(Username,Password);
        }

        #endregion Select By Username Password

        #region Select By Username Password
        public UserENT SelectByPK(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByPK(UserID);
        }

        #endregion Select By Username Password


        #endregion Select Operation
    }
}