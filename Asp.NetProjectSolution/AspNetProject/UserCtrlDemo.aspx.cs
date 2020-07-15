using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCtrlDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}
   
    protected void loginUserCtrl_Validated(bool IsAllowed)
    {
        if (IsAllowed)
        {
            //Java Script alert from C# code
            Response.Write("<Script>alert('Valid User')</Script>");
            //Server.Transfer("StaticVariable.aspx");
        }
        else
        {
            //Server.Transfer("AutoEventWireUpForm.aspx");
            Response.Write("<Script>alert('InValid User Credentials')</Script>");
        }
    }
}