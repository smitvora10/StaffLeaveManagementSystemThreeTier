using StaffLeaveManagementSystemThreeTier.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace StaffLeaveManagementSystemThreeTier
{
    public class CommonFillMethods
    {
        #region Constructor
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Fill State DropDownList
        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill State DropDownList

        #region Fill City DropDownList
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill City DropDownList

        #region Fill Country DropDownList
        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropDownList();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        #endregion Fill Country DropDownList

        #region Fill Countries DropDownList
        public static void FillDropDownListCountries(DropDownList ddl)
        {
            CountriesBAL balCountries = new CountriesBAL();
            ddl.DataSource = balCountries.SelectForDropDownList();
            ddl.DataValueField = "CountriesID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        #endregion Fill Countries DropDownList

        #region Fill LeaveType DropDownList
        public static void FillDropDownListLeaveType(DropDownList ddl,SqlInt32 UserID)
        {
            LeaveTypeBAL balLeaveType = new LeaveTypeBAL();
            ddl.DataSource = balLeaveType.SelectForDropDownList(UserID);
            ddl.DataValueField = "LeaveTypeID";
            ddl.DataTextField = "LeaveType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select LeaveType", "-1"));
        }
        #endregion Fill LeaveType DropDownList

        #region Fill Department DropDownList
        public static void FillDropDownListDepartment(DropDownList ddl)
        {
            DepartmentBAL balDepartment = new DepartmentBAL();
            ddl.DataSource = balDepartment.SelectForDropDownList();
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Department", "-1"));
        }
        #endregion Fill Department DropDownList

        #region Fill Designation DropDownList
        public static void FillDropDownListDesignation(DropDownList ddl)
        {
            DesignationBAL balDesignation = new DesignationBAL();
            ddl.DataSource = balDesignation.SelectForDropDownList();
            ddl.DataValueField = "DesignationID";
            ddl.DataTextField = "DesignationName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Designation", "-1"));
        }
        #endregion Fill Designation DropDownList

        #region Fill Employee DropDownList Of Employee Code
        public static void FillDropDownListEmployeeOfEmployeeCode(DropDownList ddl)
        {
            EmployeeBAL balEmployee = new EmployeeBAL();
            ddl.DataSource = balEmployee.SelectForDropDownListOfEmployeeCode();
            ddl.DataValueField = "EmployeeID";
            ddl.DataTextField = "EmployeeCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Employee", "-1"));
        }
        #endregion Fill Employee DropDownList Of Employee Code

        #region Fill LeaveType DropDownList By EmployeeID
        public static void FillDropDownListLeaveTypeByEmployeeID(DropDownList ddl, SqlInt32 EmployeeID)
        {
            LeaveTypeBAL balLeaveType= new LeaveTypeBAL();
            ddl.DataSource = balLeaveType.LeaveTypeDropDownListByEmployeeID(EmployeeID);
            ddl.DataValueField = "LeaveTypeID";
            ddl.DataTextField = "LeaveType";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select LeaveType", "-1"));
        }
        #endregion Fill LeaveType DropDownList By EmployeeID

        #region Fill Employee DropDownList Of Employee Name
        public static void FillDropDownListEmployeeOfEmployeeName(DropDownList ddl)
        {
            EmployeeBAL balEmployee = new EmployeeBAL();
            ddl.DataSource = balEmployee.SelectForDropDownListOfEmployeeName();
            ddl.DataValueField = "EmployeeID";
            ddl.DataTextField = "EmployeeName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Employee", "-1"));
        }
        #endregion Fill Employee DropDownList Of Employee Name




        #region Fill State DropDownList By CountryID
        public static void FillDropDownListStateByCountryID(DropDownList ddl, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownListByCountryID(CountryID);
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion Fill State DropDownList By CountryID

        #region Fill City DropDownList By StateID
        public static void FillDropDownListCityByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownListByStateID(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion Fill City DropDownList By StateID

        #region Fill Empty DropDownList
        public static void FillEmptyDropDownList(DropDownList ddl, String TableName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select " + TableName, "-1"));
        }
        #endregion Fill Empty DropDownList
    }
}