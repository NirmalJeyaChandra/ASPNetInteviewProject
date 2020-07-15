using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        SendEmail();
    }

    public void SendEmail()
    {
        SmtpClient client = new SmtpClient();
        client.Host = "AAPP1-DM07-MKM.dhltd.corp";
        client.Port = 2500;
        client.EnableSsl = false;
        if (client.EnableSsl)
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress("Felix.George@dh.com");
            //foreach (string address in to.Split(';'))
            message.To.Add(new MailAddress("NirmalJey@yahoo.com"));
            //if (!string.IsNullOrWhiteSpace(cc))
            //foreach (string address in cc.Split(';'))
            //message.CC.Add(new MailAddress(address));
            //if(!string.IsNullOrWhiteSpace(bcc))
            // foreach (string address in bcc.Split(';'))
            //message.Bcc.Add(new MailAddress(address));
            //if (!string.IsNullOrWhiteSpace(replyTo))
            // message.ReplyToList.Add(new MailAddress(replyTo));
            message.Subject = "Hi from nirmal's mail";
            message.Body = "Hi from nirmal's mail";
            //Content here is attachment in byte array format
            //attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(attachment.Content), attachment.FileName));
            //if (attachments != null)
            // foreach (Attachment attachment in attachments)
            // message.Attachments.Add(attachment);
            client.Send(message);
            Response.Write("Mail Sent Successfully");
        }
    }
    /// <summary>
    /// Converts attached file to byte array.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static byte[] GetFileAsByteArray(Stream stream)
    {
        if (stream != null)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }
                return memoryStream.ToArray();
            };
        }
        else
        {
            return null;
        }
    }
}