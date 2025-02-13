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
            public const string InsertIntoEmployees = "InsertIntoEmployees";
            public const string GetEmployees = "GetEmployees";
            public const string UpdateEmployee = "UpdateEmployee";
        }

        public static class Query
        {
            public const string GetOfficeId = "SELECT * FROM Offices WHERE name = @office";
            public const string GetDepartmentId = "SELECT * FROM Departments WHERE name = @department";
            public const string DeleteEmployee = "Delete from Employees where id = @id";
            public const string GetDepartmentsandCount = @"Select count(e.department) as 'Value' , d.name as 'Key' from Employees e right join Departments d on e.department = d.id group by d.name;";
            public const string GetOfficesandCount = @"Select count(e.office)as 'Value' , o.name as 'Key' from Employees e
right join offices o on e.office = o.id group by o.name";
            public const string GetJobTitleandCount = @"select jobTitle as 'Key', count(jobTitle) as 'Value' from Employees group by jobTitle;";
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

        public static string EmployeeAddedSuccess = "Employee added to the db successfully";
        public static string EmployeeUpdateSuccess = "Employee updating Succeed";
        public static string EmployeeDeleteSuccess = "Employee deletion Succeed";
    }
}
