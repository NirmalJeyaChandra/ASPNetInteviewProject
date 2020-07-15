using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaticVariable : System.Web.UI.Page
{
    static int StaticCount;    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["Message"] = "Message from View State variable Hi from Nirmal...";
        }        
    }

    protected void BtnViewState_Click(object sender, EventArgs e)
    {
        if (ViewState["Message"] != null)
        {
            var message = ViewState["Message"].ToString();
            var i = 0;
        }
    }
    protected void btnAssignValue_Click(object sender, EventArgs e)
    {
        StaticCount = Convert.ToInt32(txtValue.Text);
    }

    protected void btnAssignMess_Click(object sender, EventArgs e)
    {
        StaticClass.Message = txtMessage.Text;
    }

    protected void btnMessage_Click(object sender, EventArgs e)
    {
        Response.Write("Message is : " + StaticClass.Message + "<br/>");  
    }

    protected void btnShowValue_Click(object sender, EventArgs e)
    {
        Response.Write("Static Count is : " + StaticCount + "<br/>");  
    }
    protected void btnIncre_Click(object sender, EventArgs e)
    {
        StaticCount++;
    }
}

static class StaticClass
{
    static StaticClass()
    { }

    public static string Message { get; set; }    
}