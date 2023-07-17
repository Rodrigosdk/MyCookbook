using Dapper;
using Npgsql;
using System.Linq;

namespace MyCookbook.Infrastructure.Migrations;

public static class Database
{
    public static void createDatabase(string databaseConnection,string nameDatabase) 
    {
        using var connection = new NpgsqlConnection(databaseConnection);

        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("name", nameDatabase);

        var registers = connection.Query("SELECT pg_database.datname FROM pg_database WHERE datname = @name", dynamicParameters);

        if (!registers.Any())
        {
            connection.Execute($"CREATE DATABASE {nameDatabase}");
        }
    }
}
