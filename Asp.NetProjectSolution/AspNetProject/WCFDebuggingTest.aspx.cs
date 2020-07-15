using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfHttpsService;

public partial class WCFDebuggingTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}      

    protected void HttpsService_Click(object sender, EventArgs e)
    {
        //Https Service With Transport Secuity. From WCFSSLService Project
        var httpsService = new SSLServiceClient();
        Response.Write(httpsService.GetData());
    }

    protected void btnShowValue_Click(object sender, EventArgs e)
    {
        //This is the local service present in the same solution.
        WCFDebugServiceRef.Service1Client wcfRef = new WCFDebugServiceRef.Service1Client();
        Response.Write(wcfRef.GetData(Convert.ToInt32(TextBoxNum.Text)));
    }
}