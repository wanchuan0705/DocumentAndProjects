using System;
using System.Net;
using System.Net.Mail;

namespace ContactUsProject
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SendEmail(object sender, EventArgs e)
        {
            string fromName = txtName.Text;
            string fromEmail = txtEmail.Text;
            string subject = txtSubject.Text;
            string message = txtMessage.Text;

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("web@reasonables.com", "Web Sender");
                mail.Sender = new MailAddress("web@reasonables.com", "Web Sender");
                mail.To.Add("hr@reasonables.com");
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.ReplyToList.Add(new MailAddress("web@reasonables.com"));
                mail.Headers.Add("Return-Path", "web@reasonables.com");
                mail.Headers.Add("From", $"{fromName}<{fromEmail}>");

                SmtpClient smtp = new SmtpClient("192.168.196.1", 25);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("web@reasonables.com", "Wan12345");

                smtp.Send(mail);

                Response.Write("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Response.Write("Error sending email: " + ex.Message);
            }
        }
    }
}