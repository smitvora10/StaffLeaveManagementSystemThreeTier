using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountriesENT
/// </summary>
/// 
namespace StaffLeaveManagementSystemThreeTier.ENT
{

    public class CountriesENT
    {
        #region Constructor
        public CountriesENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region ISO_Code
        protected SqlString _ISO_Code;

        public SqlString ISO_Code
        {
            get
            {
                return _ISO_Code;
            }
            set
            {
                _ISO_Code = value;
            }
        }
        #endregion ISO_Code

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

    }
}