using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddModifyDataTableDB : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;
    DataTable technologyDataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetTechnologies();
            gridViewTechnologies.DataSource = technologyDataTable;
            gridViewTechnologies.DataBind();
            ViewState["Technologies"] = technologyDataTable;
        }

    }

    private void GetTechnologies()
    {
        var con = new SqlConnection(connectionString);
        con.Open();
        var adapter = new SqlDataAdapter("Select * from Technologies", con);
        var dataSet = new DataSet();
        adapter.Fill(technologyDataTable);       
        con.Close();
    }

    protected void UpdateDb_Click(object sender, EventArgs e)
    {
        var con = new SqlConnection(connectionString);
        con.Open();
        var adapter = new SqlDataAdapter("Select * from Technologies", con);
        var dataSet = new DataSet();
        var dbDataTable = new DataTable();

        adapter.Fill(dbDataTable);
        //Adding Rows
        for (int counter = 3; counter < 5; counter++)
        {
            DataRow row = dbDataTable.NewRow();
            row["Name"] = "EF" + counter;
            dbDataTable.Rows.Add(row);
        }
        //Row Modification
        foreach (DataRow row in dbDataTable.Rows)
        {
            if (row["Name"].ToString() == "C#")
                row["Name"] = "AnsiC";
            if (row["Name"].ToString() == "C")
                row["Name"] = "JAVA";
        }
        //Deleting Rows
        foreach (DataRow row in dbDataTable.Rows)
        {
            if (row["TechnologyId"] != DBNull.Value)
            {
                var techId = Convert.ToInt32(row["TechnologyId"]);
                if ((techId > 7) && (techId < 12))
                    row.Delete();
            }
        }
        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
        adapter = commandBuilder.DataAdapter;//Automatically generates the Insert/Update/Delete statements for a single table.
        DataTable modifiedTable = dbDataTable.GetChanges();//Gets only the Added/Deleted/Modified rows from the DataTable.
        adapter.Update(modifiedTable);
        adapter.Dispose();
        con.Close();
    }

    protected void gridViewTechnologies_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GetTechnologies();
        gridViewTechnologies.EditIndex = e.NewEditIndex;
        gridViewTechnologies.DataSource = technologyDataTable;
        gridViewTechnologies.DataBind();
        //ViewState["Technologies"] as DataTable;
    }
    protected void gridViewTechnologies_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GetTechnologies();
        gridViewTechnologies.EditIndex = -1;
        gridViewTechnologies.DataSource = technologyDataTable;
        gridViewTechnologies.DataBind();
    }


    protected void gridViewTechnologies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GetTechnologies();
        gridViewTechnologies.EditIndex = -1;
        gridViewTechnologies.DataSource = technologyDataTable;
        gridViewTechnologies.DataBind();
    }
    protected void gridViewTechnologies_RowCommand(object sender, GridViewCommandEventArgs e)
    {       

        if (e.CommandName.ToString() == "Update")
        {
            GridViewRow row = (GridViewRow)gridViewTechnologies.Rows[Convert.ToInt32(e.CommandArgument)];
            
            TextBox textBoxName = row.FindControl("textBoxName") as TextBox;
            var name = textBoxName.Text;
            int i = 0;
        }
        else if (e.CommandName.ToString() == "Delete")
        {
            var rowIndex = Convert.ToInt32(e.CommandArgument);
            var technologyId = Convert.ToInt32((sender as GridView).DataKeys[rowIndex].Value);
            int i = 0;
        
        }


    }
    protected void gridViewTechnologies_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GetTechnologies();
        
        gridViewTechnologies.DataSource = technologyDataTable;
        gridViewTechnologies.DataBind();
    }
}

