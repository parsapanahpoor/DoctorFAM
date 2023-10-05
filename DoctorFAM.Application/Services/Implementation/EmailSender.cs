using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.SiteSetting;
using System.Net.Mail;

namespace BusinessPortal.Application.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        #region Ctor

        

        #endregion

        public async Task<bool> SendEmail(string to, string subject, string body)
        {
            try
            {
                var defaultSiteEmail = await GetDefaultEmailSetting();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(defaultSiteEmail.Smtp);

                mail.From = new MailAddress(defaultSiteEmail.From, defaultSiteEmail.DisplayName);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                if (defaultSiteEmail.Port != 0)
                {
                    SmtpServer.Port = defaultSiteEmail.Port;
                    SmtpServer.EnableSsl = defaultSiteEmail.EnableSsL;
                }

                SmtpServer.Credentials = new System.Net.NetworkCredential(defaultSiteEmail.From, defaultSiteEmail.Password);
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async Task<EmailSetting> GetDefaultEmailSetting()
        {
            return null; //_context.EmailSettings.FirstOrDefaultAsync(s => !s.IsDelete && s.IsDefaultEmail);
        }
    }

}
