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
        }
    }
}
