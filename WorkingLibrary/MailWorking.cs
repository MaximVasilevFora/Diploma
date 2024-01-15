using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WorkingLibrary
{
	public class MailWorking
	{
		public static bool CheckMail(string value)
		{
			if (!string.IsNullOrEmpty(value?.Trim()))
			{
				const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
				var email = value.Trim().ToLowerInvariant();

				if (Regex.Match(email, pattern).Success)
				{
					return true;
				}
			}

			return false;
		}

		public static void SendPasswordMessage(string mail, string login, string password)
		{
			var fromAddress = new MailAddress("justc1ean@mail.ru", "JustClean");
			var toAddress = new MailAddress(mail, login);
			var message = new MailMessage(fromAddress, toAddress);

			message.Body = "Новый пароль для входа в приложение: " + password;
			message.Subject = "Восстановление пароля";

			var smtpClient = new SmtpClient();
			smtpClient.Host = "smtp.mail.ru";
			smtpClient.Port = 587;
			smtpClient.EnableSsl = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(fromAddress.Address, "z7vDhc24d0vA1zmFpMMu");

			smtpClient.Send(message);
		}
	}
}
