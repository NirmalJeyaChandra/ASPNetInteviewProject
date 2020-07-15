using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccessMasterField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void ButtonMessage_Click(object sender, EventArgs e)
    {
        //Accessing Master Page Label control property
        var userName = Master.UserNameLabel.Text;
        Response.Write("<script>alert('" + userName + "');</script>");
        Master.UserNameLabel.Text = "Jeya Chandra";
        Master.UserNameLabel.ForeColor = Color.DarkRed;
        Response.Write("<script>alert('" + Master.UserName + "');</script>");

    }
}