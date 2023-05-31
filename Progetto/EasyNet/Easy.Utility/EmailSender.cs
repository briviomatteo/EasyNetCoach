﻿using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using MimeKit.Utils;

namespace Easy.Utility
{
	public class EmailSender : IEmailSender
	{
		private readonly EmailSenderoptions _emailSenderOptions;
		public EmailSender(IOptions<EmailSenderoptions> emailSenderOptions)
		{
			_emailSenderOptions = emailSenderOptions.Value;
		}
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var emailToSend = new MimeMessage();
			emailToSend.From.Add(new MailboxAddress(_emailSenderOptions.EmailSenderName, _emailSenderOptions.EmailFrom));
			emailToSend.To.Add(MailboxAddress.Parse(email + " <" + email + ">"));
			emailToSend.Subject = subject;
			emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
			emailToSend.MessageId = MimeUtils.GenerateMessageId(_emailSenderOptions.GenerateMessageIdFrom);

			//send email
			using (var emailClient = new SmtpClient())
			{
				emailClient.Connect(_emailSenderOptions.SmtpHost, _emailSenderOptions.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
				emailClient.Authenticate(_emailSenderOptions.SmtpUser, _emailSenderOptions.SmtpPass);
				emailClient.Send(emailToSend);
				emailClient.Disconnect(true);
			}
			return Task.CompletedTask;
		}
	}
}
