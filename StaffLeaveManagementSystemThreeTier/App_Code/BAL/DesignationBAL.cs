using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DesignationBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class DesignationBAL
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
        public DesignationBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert By UserID Operation
        public Boolean InsertByUserID(DesignationENT entDesignation)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            if (dalDesignation.InsertByUserID(entDesignation))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }
        #endregion Insert By UserID Operation

        #region Delete By UserID Operation
        public Boolean DeleteByPKUserID(SqlInt32 DesignationID, SqlInt32 UserID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();

            if (dalDesignation.DeleteByPKUserID(DesignationID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }


        #endregion Delete By UserID Operation

        #region Update By UserID Operation
        public Boolean UpdateByPKUserID(DesignationENT entDesignation)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            if (dalDesignation.UpdateByPKUserID(entDesignation))
            {
                return true;
            }
            else
            {
                Message = dalDesignation.Message;
                return false;
            }
        }
        #endregion Update By UserID Operation

        #region Select Operation

        #region Select All By UserID
        public DataTable SelectAllByUserID(SqlInt32 UserID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectAllByUserID(UserID);
        }
        #endregion Select All By UserID

        #region Show Count By UserID
        public DesignationENT ShowCountByUserID(SqlInt32 UserID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.ShowCountByUserID(UserID);
        }
        #endregion Show Count By UserID

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region Select By PK UserID
        public DesignationENT SelectByPKUserID(SqlInt32 DesignationID, SqlInt32 UserID)
        {
            DesignationDAL dalDesignation = new DesignationDAL();
            return dalDesignation.SelectByPKUserID(DesignationID, UserID);
        }

        #endregion Select By PK UserID

        #endregion Select Operation
    }
}