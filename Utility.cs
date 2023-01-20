using System;
using System.Net;
using System.Net.Mail;

namespace Console_Application
{
    public class Utility
    {
        //Clears the line within the console app.
        public static void ClearConsoleLine()
        {
            int line = Console.CursorTop;
            Console.SetCursorPosition(37, Console.CursorTop);

            for (int i = 0; i < 20; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(37, line);
        }

        //Clears the whole line outside the console app.
        public static void ClearWholeLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        //Clears invalid phone or/and email screen inputs.
        public static void ClearPhoneOrEmail()
        {
            int line = Console.CursorTop;
            Console.SetCursorPosition(28, Console.CursorTop);

            for (int i = 0; i < 29; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(28, line);
        }

        //Emails the user with their details.
        public static void EmailDetails(string subject, string body, string email)
        {
            MailAddress from = new MailAddress("applicationsdevelopmentdotnet@gmail.com");
            MailAddress to = new MailAddress(email);
            string password = "lldaejhfsxmhqbrq";
            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, password)
            };
            using MailMessage mailMessage = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
        };
            smtpClient.Send(mailMessage);
        }
    }
}
