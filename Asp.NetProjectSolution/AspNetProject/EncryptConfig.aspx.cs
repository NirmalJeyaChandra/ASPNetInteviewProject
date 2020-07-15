using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EncryptConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        ProtectSection();
    }
    protected void btnUnEncrypt_Click(object sender, EventArgs e)
    {
        UnprotectSection();
    }

    private void UnprotectSection()
    {
        var sectionName = txtEncryptSection.Text.Trim();
        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        ConfigurationSection section = config.GetSection(sectionName);
        section.SectionInformation.UnprotectSection();
        config.Save(ConfigurationSaveMode.Modified);
    }

    private void ProtectSection()
    {
        var sectionName = txtEncryptSection.Text.Trim(); 
        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        ConfigurationSection section = config.GetSection(sectionName);
        section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
        config.Save(ConfigurationSaveMode.Modified);
    }
}