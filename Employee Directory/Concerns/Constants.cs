namespace Employee_Directory.Concerns
{
    public class Constants
    {
        public static class ConnectionStrings
        {
            public const string ConnectionString = "DefaultConnection";
        }
        public static class StoredProcedures
        {
            public const string InsertIntoEmployees = "sp_InsertIntoEmployees";
            public const string GetEmployees = "sp_GetEmployees";
            public const string UpdateEmployee = "sp_UpdateEmployee";
            public const string DeleteEmployee = "sp_DeleteEmployee";
        }

        public static class Query
        {
            public const string GetOfficeId = "SELECT * FROM Offices WHERE name = @office";
            public const string GetDepartmentId = "SELECT * FROM Departments WHERE name = @department";
            public const string GetDepartmentsandCount = "SELECT * FROM vw_GetDepartmentsandCount;";
            public const string GetOfficesandCount = @"SELECT * FROM  vw_GetOfficesandCount;";
            public const string GetJobTitleandCount = @"SELECT * FROM vw_GetJobTitleandCount";
        }

        public static class Errors
        {
            public const string ErrorFetchingDepratmentID = "Error occured while fetching the department id";
            public const string UnableToFetchDepartmentID = "Unable to fetch Department Id";
            public const string UnableToConnectToDB = "Unable to Connect to the database,";
            public const string UnableToFetchDepartment = "Unable to Fetch Departments and Their Count";
            public const string UnableToFetchOffices = "Unable to Fetch Offices and Their Count";
            public const string UnabletToFetchJobTitles = "Unable to Fetch JobTitles and Their Count";
            public const string EmployeeAddingFailure = "Unable to Add Employee";
            public const string EmployeeUpdateFailure = "Unable to update Employee";
            public const string EmployeeDeletionFailure = "Unable to Delete Employee";
        }

        public static class Routes
        {
            public const string employee = "employee";
            public const string GetDepartments = "get-departments";
            public const string jobTitlesCount = "jobTitles-count";
            public const string OfficeCount = "get-offices";
        }

        public static string EmployeeAddedSuccess = "Employee added to the db successfully";
        public static string EmployeeUpdateSuccess = "Employee updating Succeed";
        public static string EmployeeDeleteSuccess = "Employee deletion Succeed";
    }
}
