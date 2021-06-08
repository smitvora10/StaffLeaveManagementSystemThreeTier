using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
namespace StaffLeaveManagementSystemThreeTier
{
    public class DatabaseConfig
    {
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["SLMSDatabaseConnectionString"].ConnectionString.ToString();

    }
}