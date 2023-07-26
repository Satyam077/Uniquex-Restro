//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
//using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Abby.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
   
            return Task.CompletedTask;
            
        }
    }
}
