using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AutoEventWireUpForm : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        this.Load += Page_Load; //Handler binded explicitly since Autoeventwireup is set to false.
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("From Manually binded Page_Load Event");
       // var i = 0;
    }
}