using System;
using System.Collections.Generic;
using System.Text;

namespace APPMulticool.Models
{
    public class Email
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool SendEmail()
        {
            bool R = false;
            try
            {
                if (!string.IsNullOrEmpty(SendTo) && !string.IsNullOrEmpty(Subject)
                    && !string.IsNullOrEmpty(Message))
                {
                    System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                    email.From = new System.Net.Mail.MailAddress("");
                    email.Subject = Subject;
                    email.Body = Message;
                    email.To.Add(SendTo);
                    email.IsBodyHtml = false;
                    System.Net.Mail.SmtpClient server = new System.Net.Mail.SmtpClient();
                    server.Host = "smtp.gmail.com";
                    server.Port = 587;
                    server.EnableSsl = true;
                    server.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    server.Credentials = new System.Net.NetworkCredential("", "");
                    server.Send(email);
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
            return R;
        }
    }
}
