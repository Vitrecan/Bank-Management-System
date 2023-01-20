using System;
using System.IO;
namespace Console_Application
{
    public class Session
    {
        Accounts accounts;
        public Session()
        {
            accounts = new Accounts();
        }
        static void Main(string[] args)
        {
            new Session().LoginMenu();
        }
        private void LoginMenu()
        {
            int userNamePosY, userNamePosX, passwordPosY, passwordPosX;
            string userName, password;
            ConsoleKey key;
            string[] loginLines = File.ReadAllLines("login.txt");
            bool validCredentials = false;
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════╗");
            Console.WriteLine("\t\t|    WELCOME TO SIMPLE BANKING SYSTEM    |");
            Console.WriteLine("\t\t|════════════════════════════════════════|");
            Console.WriteLine("\t\t|            LOGIN TO START              |");
            Console.WriteLine("\t\t|                                        |");
            Console.Write("\t\t|    User Name: ");
            userNamePosY = Console.CursorLeft;
            userNamePosX = Console.CursorTop;
            Console.Write("                         |");
            Console.Write("\n\t\t|    Password: ");
            passwordPosY = Console.CursorLeft;
            passwordPosX = Console.CursorTop;
            Console.Write("                          |");
            Console.WriteLine("\n\t\t╚════════════════════════════════════════╝");
            Console.SetCursorPosition(userNamePosY, userNamePosX);
            userName = Console.ReadLine();
            Console.SetCursorPosition(passwordPosY, passwordPosX);
            password = "";
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
                if (password.Length > 0 && key == ConsoleKey.Backspace)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            for (int i = 0; i < loginLines.Length; i++)
            {
                string[] loginCredentials = loginLines[i].Split('|');
                if (userName == loginCredentials[0] && password == loginCredentials[1])
                {
                    validCredentials = true;
                    Console.WriteLine("\n\n\n\t\tValid credentials!... Please enter");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        Screen.MainMenu(accounts);
                    }
                }
            }
            if (validCredentials == false)
            {
                Console.WriteLine("\n\n\n\t\tInvalid credentials!... Try again");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    LoginMenu();
                }
            }
        }
    }
}
