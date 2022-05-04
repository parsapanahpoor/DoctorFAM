using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Utils
{
    public class SendEmail
    {
        public static bool Send(string to, string subject, string body)
        {
            /*MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient($"{EmailInfo.SaitEnglishName}");
            mail.From = new MailAddress($"{EmailInfo.EmailAddress}", $"{EmailInfo.SaitPersianName}");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            if (EmailInfo.Port != 0)
            {
                SmtpServer.Port = EmailInfo.Port;
            }

            SmtpServer.Credentials = new System.Net.NetworkCredential($"{EmailInfo.EmailAddress}", $"{EmailInfo.Password}");
            SmtpServer.Send(mail);*/

            try
            {
                var mail = new MailMessage();

                var SmtpServer = new SmtpClient("maghsoudlou.reza@gmail.com");

                mail.From = new MailAddress("maghsoudlou.reza@gmail.com", " DoctorFAM");

                mail.To.Add(to);

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = true;

                // System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;

                SmtpServer.Credentials = new System.Net.NetworkCredential("maghsoudlou.reza@gmail.com", "Reza@83040697");

                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
