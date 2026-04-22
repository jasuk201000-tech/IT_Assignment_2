using Microsoft.Data.SqlClient;

namespace AmaneRetailPOS.Data;

public static class DatabaseHelper
{
    // sql connection details
    private const string Server = @"amaneposserversoutheast.database.windows.net";
    private const string Database = "amaneposdb";
    private const string User = "sqladmin";
    private const string Password = "Tribune2020!";
    

    public static string ConnectionString =>
        $"Server={Server};Database={Database};User ID={User};Password={Password};Encrypt=True;TrustServerCertificate=False;";

    // connection method
    public static SqlConnection GetConnection()
    {
        var conn = new SqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }
}