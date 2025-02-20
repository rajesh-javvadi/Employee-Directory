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
            public const string PageEmployeeData = "sp_PageEmployeeData";
            public const string InsertIntoUsers = "sp_InsertIntoUsers";
        }

        public static class Query
        {
            public const string GetOfficeId = "SELECT * FROM Offices WHERE name = @office";
            public const string GetDepartmentId = "SELECT * FROM Departments WHERE name = @department";
            public const string GetDepartmentsandCount = "SELECT * FROM vw_GetDepartmentsandCount;";
            public const string GetOfficesandCount = @"SELECT * FROM  vw_GetOfficesandCount;";
            public const string GetJobTitleandCount = @"SELECT * FROM vw_GetJobTitleandCount";
            public const string EmployeeCount = "SELECT COUNT(ID) FROM Employees;";
            public const string GetUser = "SELECT * FROM Users WHERE Email = @Email";
            public const string GetUserById = "SELECT * FROM Users WHERE Id = @Id";
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
            public const string UserDoesNotExist = "User Doesnot Exist Check your Credentials";
        }

        public static class Routes
        {
            public const string employee = "employee";
            public const string GetDepartments = "get-departments";
            public const string jobTitlesCount = "jobTitles-count";
            public const string OfficeCount = "get-offices";
            public const string DeleteEmployee = "employee/{id}";
            public const string Registration = "Registration";
            public const string Login = "Login";
        }

        public const string EmployeeAddedSuccess = "Employee added to the db successfully";
        public const string EmployeeUpdateSuccess = "Employee updating Succeed";
        public const string EmployeeDeleteSuccess = "Employee deletion Succeed";
        public const string UserAddedSuccess = "User Added Successfully";

        public const string Email = "Email";

        public const string InvalidCredentials = "Invalid Credentials";
        public const string UserNotFound = "User Not Found";


        public static class Jwt
        {
            public const string Key = "Jwt:Key";
            public const string Issuer = "Jwt:Issuer";
            public const string Audience = "Jwt:Audience";
            public const string Subject = "Jwt:Subject";
        }
    }
}
