using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class MultiRecordSetType2 : System.Web.UI.Page
{
    //Retrieving connection string from the web.config file.
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;

    static SqlDataReader dataReader; //Declared as static inorder to make the data available even after page postback.

    protected void Page_Load(object sender, EventArgs e)
    {}

    protected void Table1_Click(object sender, EventArgs e)
    {
        var con = new SqlConnection(connectionString);
        var command = new SqlCommand("MultiRecordSet", con);
        command.CommandType = CommandType.StoredProcedure;
        con.Open();
        dataReader = command.ExecuteReader();
        //Retrieves the First record set
        GridViewRecordSet1.DataSource = dataReader;
        GridViewRecordSet1.DataBind();
    }

    protected void Table2_Click(object sender, EventArgs e)
    {
        //Retrieves the next record set
        if (dataReader.NextResult())
        {
            GridViewRecordSet1.DataSource = dataReader;
            GridViewRecordSet1.DataBind();
        }
    }

    protected void Table3_Click(object sender, EventArgs e)
    {
        //Retrieves the next record set
        dataReader.NextResult();
        GridViewRecordSet1.DataSource = dataReader;
        GridViewRecordSet1.DataBind();
    }
}