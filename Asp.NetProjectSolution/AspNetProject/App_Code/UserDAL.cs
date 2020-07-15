using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>
public class UserDAL
{
    public UserDAL()
    { }

    //Gets All Users
    public List<User> GetUsers()
    {
        const string GetUsers = "GetUsers";
        var connection = new SqlConnection();
        //Gets the SqlDataReader object by passing SP name and connection object.
        var sqlDataReader = DBUtility.GetReaderObject(GetUsers, connection);
        if (sqlDataReader != null)
        {
            //Gets DataReader converted to Generic list.
            var userList = GetUserList(sqlDataReader);
            sqlDataReader.Close();
            connection.Close();
            return userList;
        }
        else
        {
            return new List<User>();
        }
    }

    //Gets User By Id
    public User GetUserById(int userId)
    {
        const string GetUserById = "GetUserById";
        var connection = new SqlConnection();
        var parameterList = new List<SqlParameter>();
        parameterList.Add(new SqlParameter("@UserId", userId));
        //Gets the SqlReaderObject by passing SP name, SqlConnection Object and SqlParameter list
        var sqlDataReader = DBUtility.GetReaderObject(GetUserById, connection, parameterList);
        if (sqlDataReader != null)
        {
            //Gets DataReader converted to Generic list.
            var userList = GetUserList(sqlDataReader);
            sqlDataReader.Close();
            connection.Close();
            if (userList.Count > 0)
            {
                return userList[0];
            }
            else
            {
                return new User();
            }
        }
        else
        {
            return new User();
        }
    }

    //Converts the data present inside the SqlDataReader object to Generic List object.
    public List<User> GetUserList(SqlDataReader reader)
    {
        var userList = new List<User>();
        while (reader.Read())
        {
            var user = new User();
            user.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : 0;
            user.FirstName = (reader["FirstName"] != DBNull.Value) ? reader["FirstName"].ToString() : string.Empty;
            user.LastName = (reader["LastName"] != DBNull.Value) ? reader["LastName"].ToString() : string.Empty;
            user.Age = (reader["Age"] != DBNull.Value) ? Convert.ToInt32(reader["Age"].ToString()) : 0;
            user.DateOfBirth = (reader["DateOfBirth"] != DBNull.Value) ? Convert.ToDateTime(reader["DateOfBirth"].ToString()) : new DateTime();
            user.Gender = (reader["Gender"] != DBNull.Value) ? reader["Gender"].ToString() : string.Empty;
            user.MaritalStatus = (reader["MaritalStatus"] != DBNull.Value) ? Convert.ToBoolean(reader["MaritalStatus"].ToString()) : false;
            user.CountryId = (reader["CountryId"] != DBNull.Value) ? Convert.ToInt32(reader["CountryId"].ToString()) : 0;
            user.StateId = (reader["StateId"] != DBNull.Value) ? Convert.ToInt32(reader["StateId"].ToString()) : 0;
            userList.Add(user);
        }
        return userList;
    }

    public int InsertUser(User user)
    {
        const string InsertUser = "InserUser";        
        var connection = new SqlConnection();
        var parameterList = new List<SqlParameter>();
        parameterList.Add(new SqlParameter("@UserId",System.Data.SqlDbType.Int,0,System.Data.ParameterDirection.Output, true, 1, 1, string.Empty,DataRowVersion.Default, null));
        parameterList.Add(new SqlParameter("@FirstName", "Kiran"));
        parameterList.Add(new SqlParameter("@LastName", "Kumar"));
        parameterList.Add(new SqlParameter("@Age", 38));
        parameterList.Add(new SqlParameter("@DateOfBirth", new DateTime(1977, 05, 22)));
        parameterList.Add(new SqlParameter("@Gender", "Male"));
        parameterList.Add(new SqlParameter("@MaritalStatus", true));
        parameterList.Add(new SqlParameter("@CountryId", 2));
        parameterList.Add(new SqlParameter("@StateId", 8));
        //Sents SP name, Connection Object, and SqlParameter list and gets back the newly inserted Identity value.
        var result = DBUtility.InsertObject(InsertUser, connection, parameterList);
        connection.Close();
        return result;
    }

    public int UpdateUser(User user)
    {
        const string UpdateUser = "UpdateUser";
        var connection = new SqlConnection();
        var parameterList = new List<SqlParameter>();
        parameterList.Add(new SqlParameter("@UserId", 30));
        parameterList.Add(new SqlParameter("@FirstName", "Nirmal"));
        parameterList.Add(new SqlParameter("@LastName", "Jeya Chandra"));
        parameterList.Add(new SqlParameter("@Age", 38));
        parameterList.Add(new SqlParameter("@DateOfBirth", new DateTime(1977, 05, 22)));
        parameterList.Add(new SqlParameter("@Gender", "Male"));
        parameterList.Add(new SqlParameter("@MaritalStatus", false));
        parameterList.Add(new SqlParameter("@CountryId", 1));
        parameterList.Add(new SqlParameter("@StateId", 1));
        parameterList.Add(new SqlParameter("@RecordCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, true, 1, 1, string.Empty, DataRowVersion.Default, null));
        //Sents SP name, Connection Object, and SqlParameter list and gets back the affected record count.
        var result = DBUtility.UpdateObject(UpdateUser, connection, parameterList);
        connection.Close();
        return result;
    }

    public int DeleteUser(int userId)
    {
        const string DeleteUser = "DeleteUser";
        var connection = new SqlConnection();
        var parameterList = new List<SqlParameter>();
        parameterList.Add(new SqlParameter("@Age", 38));      
        parameterList.Add(new SqlParameter("@RecordCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output, true, 1, 1, string.Empty, DataRowVersion.Default, null));
        //Sents SP name, Connection Object, and SqlParameter list and gets back the affected record count.
        var result = DBUtility.DeleteRecord(DeleteUser, connection, parameterList);
        connection.Close();
        return result;
    }

    public bool IsUserAvailable(string firstName)
    {
        const string IsRecordAvailable = "IsUserAvailable";
        var connection = new SqlConnection();
        var parameterList = new List<SqlParameter>();
        parameterList.Add(new SqlParameter("@FirstName", "Kankaru"));
        parameterList.Add(new SqlParameter("@IsAvailable", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Output, true, 1, 1, string.Empty, DataRowVersion.Default, null));
        //Sents SP name, Connection Object, and SqlParameter list and gets back the boolean value saying whether the record is available.
        var result = DBUtility.IsObjectAvailable(IsRecordAvailable, connection, parameterList);
        connection.Close();
        return result;
    }

}