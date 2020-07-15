using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using System.Xml.Linq;

public partial class ResourceFileDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        //Accessing a Message from Resource File
        lblPasswordError.Text = Resources.MessageResources.PasswordError;
        if (!Page.IsPostBack)
        {
            LoadData(); 
        }       
    }

    private void LoadData()
    {

        string path = Server.MapPath("App_GlobalResources/MessageResources.resx");
        //Loading the XML Resource file using the Load method of XElement. 
        XElement resourceElements = XElement.Load(path);
        //LINQ to load the resource items Name, Value, and Comment fields into the Grid
        gvResourceEditor.DataSource = (from resElem in resourceElements.Elements("data")
                                       select new
                                       {
                                           Key = resElem.Attribute("name").Value,
                                           Value = HttpUtility.HtmlEncode(resElem.Element("value").Value),
                                           Comment = resElem.Element("comment") != null ?
                                                HttpUtility.HtmlEncode(resElem.Element("comment").Value) : string.Empty
                                       });
        gvResourceEditor.DataBind();
    }

    //Updating a particular message into the Resource File from the Grid
    protected void gvResourceEditor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string theFileName = Server.MapPath("App_GlobalResources/MessageResources.resx");
        Label lblKey = gvResourceEditor.Rows[e.RowIndex].FindControl("lblKey") as Label;
        TextBox txtValue = gvResourceEditor.Rows[e.RowIndex].FindControl("txtValue") as TextBox;
        TextBox txtComment = gvResourceEditor.Rows[e.RowIndex].FindControl("txtComment") as TextBox;
        //Loading the Resource file as an XML. 
        XDocument xDoc = XDocument.Load(theFileName);
        //Filtering out key which matches currently updated record. 
        var elementToBeEdited = from xle in xDoc.Element("root").Elements("data") where xle.Attribute("name").Value == lblKey.Text select xle;

        if (elementToBeEdited != null && elementToBeEdited.Count() > 0)
        {
            //Updating the new value 
            elementToBeEdited.First().SetElementValue("value", HttpUtility.HtmlDecode(txtValue.Text));

            //Checking if there is a comment node, if no then adding a new comment node. 
            if (elementToBeEdited.First().Element("comment") == null && !string.IsNullOrEmpty(txtComment.Text))
            {
                elementToBeEdited.First().Add(new XElement("comment", HttpUtility.HtmlDecode(txtComment.Text)));
            }
            else if (elementToBeEdited.First().Element("comment") != null && !string.IsNullOrEmpty(txtComment.Text))
            {
                //If comment node is present then updating the comment node. 
                elementToBeEdited.First().SetElementValue("comment", HttpUtility.HtmlDecode(txtComment.Text));
            }
            //Finally saving the Resource file. 
            xDoc.Save(theFileName);
        }

        gvResourceEditor.EditIndex = -1;
        LoadData();
    }

    protected void gvResourceEditor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvResourceEditor.EditIndex = e.NewEditIndex;
        LoadData();
    }

    protected void gvResourceEditor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvResourceEditor.EditIndex = -1;
        LoadData();
    }
}