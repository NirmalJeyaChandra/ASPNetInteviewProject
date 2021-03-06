﻿using AspNetProject.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUpDown : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable fileList = FileUtilities.GetFileList();
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // Although I put only one http file control on the aspx page,
        // the following code can handle multiple file controls in a single aspx page.
        HttpFileCollection files = Request.Files;
        foreach (string fileTagName in files)
        {
            HttpPostedFile file = Request.Files[fileTagName];
            if (file.ContentLength > 0)
            {
                // Due to the limit of the max for a int type, the largest file can be
                // uploaded is 2147483647, which is very large anyway.
                int size = file.ContentLength;
                string name = file.FileName;
                int position = name.LastIndexOf("\\");
                name = name.Substring(position + 1);
                string contentType = file.ContentType;
                byte[] fileData = new byte[size];
                file.InputStream.Read(fileData, 0, size);

                FileUtilities.SaveFile(name, contentType, size, fileData);
            }
        }

        DataTable fileList = FileUtilities.GetFileList();
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();
    }
}