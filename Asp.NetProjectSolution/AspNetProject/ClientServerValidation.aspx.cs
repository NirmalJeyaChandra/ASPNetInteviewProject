using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientServerValidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //if adding validation controls throws an Error message as 
        //"WebForms UnobtrusiveValidationMode requires a ScriptResourceMapping for 'jquery'. Please add a ScriptResourceMapping named jquery(case-sensitive)."
        //For the above said issue add the following to the web.config file 
        //<appSettings>
        //    <add key="ValidationSettings:UnobtrusiveValidationMode" value="None" />
        //</appSettings>


        //If EnableClientScript is set to false in validation control client-side validation does n't happen for that particular
        //Control. Instead it takes a round-trip to the server and the validation happens in the server-side by itself without any coding.
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        var isValid = Page.IsValid;//Can be called only inside the control where CausesValidation is set to true.
        var i = 0;
    }
}