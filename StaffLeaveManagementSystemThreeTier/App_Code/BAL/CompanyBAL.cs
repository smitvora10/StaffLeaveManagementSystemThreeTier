using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class CompanyBAL
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
        public CompanyBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(CompanyENT entCompany)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            if (dalCompany.InsertByUserID(entCompany))
            {
                return true;
            }
            else
            {
                Message = dalCompany.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 CompanyID, SqlInt32 UserID)
        {
            CompanyDAL dalCompany = new CompanyDAL();

            if (dalCompany.DeleteByPKUserID(CompanyID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCompany.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(CompanyENT entCompany)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            if (dalCompany.UpdateByPKUserID(entCompany))
            {
                return true;
            }
            else
            {
                Message = dalCompany.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public CompanyENT ShowCountByUserID(SqlInt32 UserID)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public CompanyENT SelectByPKUserID(SqlInt32 CompanyID, SqlInt32 UserID)
        {
            CompanyDAL dalCompany = new CompanyDAL();
            return dalCompany.SelectByPKUserID(CompanyID, UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}