using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChildClassCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ChildClass1 childClass1 = new ChildClass1();
        ChildClass2 childClass2 = new ChildClass2();
        ChildClass1 childClass3 = new ChildClass1();
        ChildClass2 childClass4 = new ChildClass2();
        ParentClass parentClass=new ParentClass();
        Response.Write("ChildClass count is:" + ParentClass.count);
    }
}