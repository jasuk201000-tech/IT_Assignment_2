using System;
using System.Collections.Generic;
using System.Text;

namespace IT_Assignment_2.Data
{
    internal class DatabaseHelper
    {
        // implement database connection and connection string management.
        public const string Server = @"amaneposserversoutheast.database.windows.net";
        public const string Database = "amaneposdb";
        public const string User = "sqladmin";
        public const string Password = "Tribune2020!";

        public static string ConnectionString =>
       $"Server={Server};Database={Database};User ID={User};Password={Password};Encrypt=True;TrustServerCertificate=False;";

    } 
}
