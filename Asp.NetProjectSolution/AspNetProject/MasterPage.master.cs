using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //Master Page's Label control defined as property
    public Label UserNameLabel
    {
        get
        {
            return LabelUserName;
        }
        set
        {
            LabelUserName = value;
        }

    }

    //Master Page's Label control text field defined as property
    public string UserName
    {
        get
        {
            return LabelUserName.Text;
        }
        set
        {
            LabelUserName.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelUserName.Text = "Nirmal Jeya Chandra";
    }
}
