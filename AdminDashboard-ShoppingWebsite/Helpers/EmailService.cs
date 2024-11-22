﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace AdminDashboard_ShoppingWebsite.Helpers
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "your email";
        private readonly string _smtpPassword = "your password smtp";

        public void SendEmail(string to, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage(_smtpUsername, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                smtpClient.Send(mailMessage);
            }
        }
    }
}