using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class RegularExp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Regex obj = new Regex("[a-z]{10}");
        Regex obj = new Regex("^[a-zA-Z] [0-9]{50}$");
        Response.Write(obj.IsMatch("shivkoirala").ToString());
        Response.Write("<br/>");
        Response.Write(obj.IsMatch("shiv5koirala").ToString());

    }
}