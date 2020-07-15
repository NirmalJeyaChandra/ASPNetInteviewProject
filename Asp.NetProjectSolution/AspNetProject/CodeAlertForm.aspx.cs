using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodeAlertForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}

    protected void ButtonAlert_Click(object sender, EventArgs e)
    {
        var message = "This is a Java Script alert raised through Server-side code....";       
        Response.Write("<Script>alert('" + message + "');</Script>");
    }
}