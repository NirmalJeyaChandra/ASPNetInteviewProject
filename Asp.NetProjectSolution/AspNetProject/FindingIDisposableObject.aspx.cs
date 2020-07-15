using AspNetProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindingIDisposableObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection();
        //Checks whether the connection object Implements Idisposable.
        if (IsIDisposable(connection))        
            Response.Write("connection Object Implements IDisposable" + "<br/>");        
        else
            Response.Write("connection Object does not Implement IDisposable" + "<br/>");

        Country country = new Country();
        //Checks whether the country object Implements Idisposable.
        if (country is IDisposable)
            Response.Write("country Object Implements IDisposable" + "<br/>");
        else
            Response.Write("country Object does not Implement IDisposable" + "<br/>");
    }

    //Checks whether the object Implements Idisposable.
    public bool IsIDisposable(Object obj)
    {
        if (obj is IDisposable)       
            return true;        
        else
            return false;
    }
}