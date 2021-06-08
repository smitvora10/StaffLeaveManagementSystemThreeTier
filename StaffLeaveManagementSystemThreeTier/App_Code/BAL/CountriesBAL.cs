using StaffLeaveManagementSystemThreeTier.DAL;
using StaffLeaveManagementSystemThreeTier.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountriesBAL
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.BAL
{
    public class CountriesBAL
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
        public CountriesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor


        #region Select Operation

        #region Select All
        public DataTable SelectAll()
        {
            CountriesDAL dalCountries = new CountriesDAL();
            return dalCountries.SelectAll();
        }
        #endregion Select All

        #region Select For Dropdown List
        public DataTable SelectForDropDownList()
        {
            CountriesDAL dalCountries = new CountriesDAL();
            return dalCountries.SelectForDropDownList();
        }
        #endregion Select For Dropdown List

        #region SelectByPK
        public CountriesENT SelectByPK(SqlInt32 CountriesID)
        {
            CountriesDAL dalCountries = new CountriesDAL();
            return dalCountries.SelectByPK(CountriesID);
        }

        #endregion SelectByPK

        #endregion Select Operation
    }
}