using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var userDal = new UserDAL();
        //For Testing 3-tier with DBUtility common database access class
        var isAvailable = userDal.IsUserAvailable("David");
    }
}