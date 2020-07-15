using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControlLog : System.Web.UI.UserControl
{
    //Event handler syntax
    public delegate void LoginEventHandler(bool isAllowed);

    // This is our custom event to subscribe to
    public event LoginEventHandler userValidated;

    protected void Page_Load(object sender, EventArgs e)
    {}

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        if ((string.Compare(TxtUserName.Text, "Nirmal") == 0) && (string.Compare(TxtPassword.Text, "Christ") == 0))
        {
            userValidated(true);
        }
        else
        {
            userValidated(false);
        }
    }
}