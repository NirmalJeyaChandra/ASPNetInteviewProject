using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBUtility
/// </summary>
public static class DBUtility
{
    //Gets the connection string from the web.config file.
    static string connectionString = ConfigurationManager.ConnectionStrings["InterviewProjectConnectionString"].ConnectionString;

    //Executes the Retrieval SP and sends back the SqlReader Object
    public static SqlDataReader GetReaderObject(string spName, SqlConnection connection, List<SqlParameter> parameterCollection = null)
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        var command = new SqlCommand(spName, connection);
        command.CommandType = CommandType.StoredProcedure;
        if (parameterCollection != null)
        {
            foreach (var parameter in parameterCollection)
            {
                command.Parameters.Add(parameter);
            }
        }
        var reader = command.ExecuteReader();
        return reader;
    }

    //Executes the Insert SP and sends back the Identity value.
    public static int InsertObject(string spName, SqlConnection connection, List<SqlParameter> parameterCollection)
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        var command = new SqlCommand(spName, connection);
        command.CommandType = CommandType.StoredProcedure;
        if (parameterCollection != null)
        {
            foreach (var parameter in parameterCollection)
            {
                command.Parameters.Add(parameter);
            }
        }
        command.ExecuteNonQuery();
        var result= Convert.ToInt32(command.Parameters["@UserId"].Value);
        return result;
    }

    //Executes the Updating SP and sends back the record count 
    public static int UpdateObject(string spName, SqlConnection connection, List<SqlParameter> parameterCollection)
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        var command = new SqlCommand(spName, connection);
        command.CommandType = CommandType.StoredProcedure;
        if (parameterCollection != null)
        {
            foreach (var parameter in parameterCollection)
            {
                command.Parameters.Add(parameter);
            }
        }
        command.ExecuteNonQuery();
        var result = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
        return result;
    }

    //Executes the Deleting SP and sends back the record count 
    public static int DeleteRecord(string spName, SqlConnection connection, List<SqlParameter> parameterCollection)
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        var command = new SqlCommand(spName, connection);
        command.CommandType = CommandType.StoredProcedure;
        if (parameterCollection != null)
        {
            foreach (var parameter in parameterCollection)
            {
                command.Parameters.Add(parameter);
            }
        }
        command.ExecuteNonQuery();
        var result = Convert.ToInt32(command.Parameters["@RecordCount"].Value);
        return result;
    }

    //Executes the Data Checking SP and sends back the bool value saying whether the record is available.
    public static bool IsObjectAvailable(string spName, SqlConnection connection, List<SqlParameter> parameterCollection)
    {
        connection.ConnectionString = connectionString;
        connection.Open();
        var command = new SqlCommand(spName, connection);
        command.CommandType = CommandType.StoredProcedure;
        if (parameterCollection != null)
        {
            foreach (var parameter in parameterCollection)
            {
                command.Parameters.Add(parameter);
            }
        }
        command.ExecuteScalar();
        var result = Convert.ToBoolean(command.Parameters["@IsAvailable"].Value);
        return result;
    }
}