using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StructureForm : System.Web.UI.Page
{
    public struct Student
    {
       
        public int Age { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Student student = new Student { Age=39, Designation="Software", Name="Nirmal" };

    }
}