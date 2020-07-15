using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class MultiRecordSetSQL : System.Web.UI.Page
{
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;

    static DataSet dataset = new DataSet();
    
    //Retrieving more than one table from DB using DataSet
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            dataset.Clear();
            var con = new SqlConnection(connectionString);
            var command = new SqlCommand("MultiRecordSet", con);
            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(dataset);
            con.Close();
            if (dataset.Tables.Count > 0)
            {
                GridViewRecordSet.DataSource = dataset.Tables[0];
                GridViewRecordSet.DataBind();
            }
            else
            {
                Response.Write("No table found");
            }            
        }
    }

    protected void Table1_Click(object sender, EventArgs e)
    {        
        GridViewRecordSet.DataSource = dataset.Tables[0];
        GridViewRecordSet.DataBind();        
    }

    protected void Table2_Click(object sender, EventArgs e)
    {
        GridViewRecordSet.DataSource = dataset.Tables[1];
        GridViewRecordSet.DataBind();        
    }

    protected void Table3_Click(object sender, EventArgs e)
    {        
        GridViewRecordSet.DataSource = dataset.Tables[2];
        GridViewRecordSet.DataBind();        
    }
}