using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUploadForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}

    //Uploading a selected file to the local Destination Folder
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/Upload/") + filename);
                StatusLabel.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }

    //Downloading the specified file
    protected void ButtonDownload_Click(object sender, EventArgs e)
    {
        Response.ContentType = "text/HTML";
        Response.AppendHeader("Content-Disposition", "attachment; filename=mail.txt");
        Response.TransmitFile(Server.MapPath("~/Upload/mail.txt"));
        Response.End();
    }
}