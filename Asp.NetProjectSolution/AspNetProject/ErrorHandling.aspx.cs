using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CodeLevelErrorLogging();
        DataTable dt = new DataTable();
        dt.Columns.Add("ProductName");
        dt.Columns.Add("ProductDate");
        dt.Rows.Add();
        dt.Rows.Add();
        dt.Rows.Add();
        dt.Rows[0]["ProductName"] = "Watches";
        dt.Rows[1]["ProductName"] = "Bags";
        dt.Rows[2]["ProductName"] = "Shirts";
        GridView1.DataSource = dt;
        GridView1.DataBind();

        throw new InvalidOperationException("An InvalidOperationException " +      "occurred in the Page_Load handler on the Default.aspx page.");
    }

    //Handling exception within the method
    public void CodeLevelErrorLogging()
    {
        try
        {
            throw new InvalidOperationException("An InvalidOperationException " +
         "occurred in the Page_Load handler on the Default.aspx page.");
        }
        catch (Exception ex)
        {
            ExceptionUtility.LogException(ex, "From Code Level Error Loggging function of Default.aspx.cs");
        }
        finally {
        }
    }

    //Handling Exceptions raised from this page
    private void Page_Error(object sender, EventArgs e)
    {
        // Get last error from the server.
        //Exception exc = Server.GetLastError();

        //// Handle specific exception.
        //if (exc is InvalidOperationException)
        //{
        //    // Pass the error on to the error page.
        //    Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
        //        true);
        //}
    }
}