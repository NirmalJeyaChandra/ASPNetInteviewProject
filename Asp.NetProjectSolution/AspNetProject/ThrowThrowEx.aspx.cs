using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThrowThrowEx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var val = 0;
        try
        {
            ThrowError();
        }
        catch (Exception ex)
        {
            throw ex;
            //throw;
        }
        try
        {
            CatchTheEX();
        }
        catch (Exception ex)
        {
            throw ex;
            //throw ex;
        }

    }

    private void CatchTheEX()
    {
        try
        {
            var x = 0;
        }
        catch (Exception ex)
        {
            throw ex;
            //throw;
        }
    }

    public void ThrowError()
    {
        try
        {
            throw new InvalidOperationException("Invalid Execution");
        }
        catch (Exception ex)
        {
            throw ex;
            //throw;
        }
    }
}