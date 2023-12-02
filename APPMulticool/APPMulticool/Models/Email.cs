using System;
using System.Collections.Generic;
using System.Net.Mail;
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
                    MailMessage email = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    email.From = new MailAddress("ejemplopractempr@gmail.com");
                    email.To.Add(SendTo);
                    email.Subject = Subject;
                    email.Body = Message;
                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("ejemplopractempr@gmail.com",
                        "rematxgojezgzook");
                    SmtpServer.Send(email);
                    R = true;

                    //System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage
                    //{
                    //    From = new System.Net.Mail.MailAddress("ejemplopractempr@gmail.com"),
                    //    Subject = Subject,
                    //    Body = Message
                    //};
                    //email.To.Add(SendTo);
                    //email.IsBodyHtml = false;
                    //System.Net.Mail.SmtpClient server = new System.Net.Mail.SmtpClient
                    //{
                    //    Host = "smtp.gmail.com",
                    //    Port = 587,
                    //    EnableSsl = true,
                    //    UseDefaultCredentials = false,
                    //    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    //    Credentials = new System.Net.NetworkCredential(
                    //    "ejemplopractempr@gmail.com",
                    //    //"ejemplopracticaempresarialmulticool1423")
                    //    "rematxgojezgzook")
                    //};
                    //server.Send(email);
                    //R = true;
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
