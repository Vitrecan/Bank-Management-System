using System;
using System.IO;
using System.Linq;

namespace Console_Application
{
    public class Screen
    {
        public static void LoginMenu(Accounts accounts)
        {
            int userNamePosY, userNamePosX, passwordPosY, passwordPosX;
            string userName, password;
            ConsoleKey key;
            string[] loginLines = File.ReadAllLines("login.txt");
            bool validCredentials = false;

            Print.TopLine();
            Print.Welcome();
            Print.Seperator();
            Console.WriteLine("\t\t|            LOGIN TO START              |");
            Print.EmptyLine();
            Console.Write("\t\t|    User Name: ");
            userNamePosY = Console.CursorLeft;
            userNamePosX = Console.CursorTop;
            Console.Write("                         |");
            Console.Write("\n\t\t|    Password: ");
            passwordPosY = Console.CursorLeft;
            passwordPosX = Console.CursorTop;
            Console.Write("                          |");
            Print.BottomLine();
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
                        MainMenu(accounts);
                    }
                }
            }
            if (validCredentials == false)
            {
                Console.WriteLine("\n\n\n\t\tInvalid credentials!... Try again");

                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    LoginMenu(accounts);
                }
            }
        }

        public static void MainMenu(Accounts accounts)
        {
            int choiceInputPosY, choiceInputPosX;
            ConsoleKey key;

            Print.TopLine();
            Print.Welcome();
            Print.Seperator();
            Console.WriteLine("\t\t|    1. Create a new account             |");
            Console.WriteLine("\t\t|    2. Search for an account            |");
            Console.WriteLine("\t\t|    3. Deposit                          |");
            Console.WriteLine("\t\t|    4. Withdraw                         |");
            Console.WriteLine("\t\t|    5. A/C statement                    |");
            Console.WriteLine("\t\t|    6. Delete account                   |");
            Console.WriteLine("\t\t|    7. Exit                             |");
            Print.BottomLine();
            Console.Write("\t\t|  Enter your choice (1-7): ");
            choiceInputPosY = Console.CursorLeft;
            choiceInputPosX = Console.CursorTop;
            Console.Write("             |");
            Print.BottomLine();
            Console.SetCursorPosition(choiceInputPosY, choiceInputPosX);
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    AccountCreation(accounts);
                    break;
                case ConsoleKey.D2:
                    AccountSearch(accounts);
                    break;
                case ConsoleKey.D3:
                    Deposit(accounts);
                    break;
                case ConsoleKey.D4:
                    Withdraw(accounts);
                    break;
                case ConsoleKey.D5:
                    AccountStatement(accounts);
                    break;
                case ConsoleKey.D6:
                    DeleteAccount(accounts);
                    break;
                case ConsoleKey.D7:
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu(accounts);
                    break;
            }
        }

        private static void AccountCreation(Accounts accounts)
        {
            int firstNamePosY, firstNamePosX, lastNamePosY, lastNamePosX, addressPosY, addressPosX, phonePosY, phonePosX, emailPosY, emailPosX;
            string firstName, lastName, address, email;
            int phone, accountNumber;
            Random random = new Random();
            ConsoleKey key;
            string subject, body;

            Print.TopLine();
            Console.WriteLine("\t\t|          CREATE A NEW ACCOUNT          |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Console.Write("\t\t|    First Name: ");
            firstNamePosY = Console.CursorLeft;
            firstNamePosX = Console.CursorTop;
            Console.Write("                        |");
            Console.Write("\n\t\t|    Last Name: ");
            lastNamePosY = Console.CursorLeft;
            lastNamePosX = Console.CursorTop;
            Console.Write("                         |");
            Console.Write("\n\t\t|    Address: ");
            addressPosY = Console.CursorLeft;
            addressPosX = Console.CursorTop;
            Console.Write("                           |");
            Console.Write("\n\t\t|    Phone: ");
            phonePosY = Console.CursorLeft;
            phonePosX = Console.CursorTop;
            Console.Write("                             |");
            Console.Write("\n\t\t|    Email: ");
            emailPosY = Console.CursorLeft;
            emailPosX = Console.CursorTop;
            Console.Write("                             |");
            Print.BottomLine();
            Console.SetCursorPosition(firstNamePosY, firstNamePosX);
            firstName = Console.ReadLine();
            Console.SetCursorPosition(lastNamePosY, lastNamePosX);
            lastName = Console.ReadLine();
            Console.SetCursorPosition(addressPosY, addressPosX);
            address = Console.ReadLine();
            Console.SetCursorPosition(phonePosY, phonePosX);

            try
            {
                phone = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\n\t\tPhone number should not be more than 10 characters!");
                Console.SetCursorPosition(phonePosY, phonePosX);
                Utility.ClearPhoneOrEmail();
                phone = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\n\t\tPhone number must be an integer!");
                Console.SetCursorPosition(phonePosY, phonePosX);
                Utility.ClearPhoneOrEmail();
                phone = Convert.ToInt32(Console.ReadLine());
            }

            Console.SetCursorPosition(emailPosY, emailPosX);
            email = Console.ReadLine();

            if (!(email.Contains('@') && (email.Contains("gmail.com") || email.Contains("outlook.com") || email.Contains("uts.edu.au") || email.Contains(""))))
            {
                Console.WriteLine("\n\n\t\tEmail should contain '@'!");
                Console.SetCursorPosition(emailPosY, emailPosX);
                Utility.ClearPhoneOrEmail();
                email = Console.ReadLine();
            }

            Console.WriteLine("\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tIs the information correct (y/n)?");
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Y)
            {
                accountNumber = random.Next(100000, 99999999);

                while (File.Exists($"{accountNumber}.txt"))
                {
                    accountNumber = random.Next(100000, 99999999);
                }
                Console.WriteLine("\n\n\t\tAccount Created! Details will be provided via email.");
                Console.WriteLine("\n\t\tAccount number is {0}", accountNumber);
                accounts.Add(new Account(accountNumber, 0, firstName, lastName, address, phone, email));
                File.WriteAllText($"{accountNumber}.txt", $"{accountNumber}\n{firstName}\n{lastName}\n{address}\n{phone}\n{email}");
                subject = "Account Details";
                body = $"AccountNo|{accountNumber}\nFirst Name|{firstName}\nLast Name|{lastName}\nAddress|{address}\nPhone|{phone}\nEmail|{email}";
                Utility.EmailDetails(subject, body, email);
                MainMenu(accounts);
            }
            AccountCreation(accounts);
        }

        private static void AccountSearch(Accounts accounts)
        {
            int accountNumberPosY, accountNumberPosX;
            int accountNumber;
            ConsoleKey key;

            Print.TopLine();
            Console.WriteLine("\t\t|         SEARCH FOR AN ACCOUNT          |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Print.AccNumPrompt();
            accountNumberPosY = Console.CursorLeft;
            accountNumberPosX = Console.CursorTop;
            Print.AccNumRemainLine();
            Print.BottomLine();
            Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);

            try
            {
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\t\tAccount Number should not be more than 10 characters!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\t\tAccount Number must be an integer!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            foreach (Account account in accounts.GetAccounts().ToList())
            {
                if (account.GetAccountNumber.Equals(accountNumber))
                {
                    Console.WriteLine("\n");
                    Utility.ClearWholeLine();
                    Console.WriteLine("\t\tAccount found!");
                    Print.AccountDetails(Convert.ToInt32(accountNumber), account.GetBalance, account.GetFirstName, account.GetLastName, account.GetAddress, account.GetPhone, account.GetEmail);
                    Console.WriteLine("\n\t\tCheck another account (y/n)?");
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Y)
                    {
                        AccountSearch(accounts);
                    }
                    MainMenu(accounts);
                }
            }
            Console.WriteLine("\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tAccount not found!");
            Console.WriteLine("\t\tCheck another account (y/n)?");
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Y)
            {
                AccountSearch(accounts);
            }
            MainMenu(accounts);
        }

        private static void Deposit(Accounts accounts)
        {
            int accountNumberPosY, accountNumberPosX, amountPosY, amountPosX;
            int accountNumber, amount;
            ConsoleKey key;

            Print.TopLine();
            Console.WriteLine("\t\t|                DEPOSIT                 |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Print.AccNumPrompt();
            accountNumberPosY = Console.CursorLeft;
            accountNumberPosX = Console.CursorTop;
            Print.AccNumRemainLine();
            Print.AmountPrompt();
            amountPosY = Console.CursorLeft;
            amountPosX = Console.CursorTop;
            Print.AmountRemainLine();
            Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
            try
            {
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\n\t\tAccount Number should not be more than 10 characters!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\n\t\tAccount Number must be an integer!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            if (File.Exists($"{accountNumber}.txt"))
            {
                Console.WriteLine("\n\n\t\tAccount found! Enter the amount...");
                Utility.ClearWholeLine();
                Console.SetCursorPosition(amountPosY, amountPosX);
                amount = Convert.ToInt32(Console.ReadLine());
                foreach (Account account in accounts.GetAccounts().ToList())
                {
                    if (account.GetAccountNumber.Equals(accountNumber))
                    {
                        account.Deposit(amount);
                        account.UpdateAccount(accountNumber, account.GetBalance, account.GetFirstName, account.GetLastName, account.GetAddress, account.GetPhone, account.GetEmail);
                        File.WriteAllText($"{accountNumber}.txt", $"Account Name|{accountNumber}\nBalance|{account.GetBalance}\nFirst Name|{account.GetFirstName}\nLast Name|{account.GetLastName}\nAddress|{account.GetAddress}\nPhone|{account.GetPhone}\nEmail|{account.GetEmail}");
                    }
                }
                Console.WriteLine("");
                Utility.ClearWholeLine();
                Console.WriteLine("");
                Utility.ClearWholeLine();
                Console.WriteLine("\t\tDeposit successfull!");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    MainMenu(accounts);
                }
            }
            Console.WriteLine("\n\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tAccount not found!");
            Console.WriteLine("\t\tRetry (y/n)?");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                Deposit(accounts);
            }
            MainMenu(accounts);
        }

        private static void Withdraw(Accounts accounts)
        {
            int accountNumberPosY, accountNumberPosX, amountPosY, amountPosX;
            int accountNumber, amount;
            ConsoleKey key;

            Print.TopLine();
            Console.WriteLine("\t\t|               WITHDRAW                 |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Print.AccNumPrompt();
            accountNumberPosY = Console.CursorLeft;
            accountNumberPosX = Console.CursorTop;
            Print.AccNumRemainLine();
            Print.AmountPrompt();
            amountPosY = Console.CursorLeft;
            amountPosX = Console.CursorTop;
            Print.AmountRemainLine();
            Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
            try
            {
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\n\t\tAccount Number should not be more than 10 characters!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\n\t\tAccount Number must be an integer!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            if (File.Exists($"{accountNumber}.txt"))
            {
                Console.WriteLine("\n\n\t\tAccount found! Enter the amount...");
                Utility.ClearWholeLine();
                Console.SetCursorPosition(amountPosY, amountPosX);
                amount = Convert.ToInt32(Console.ReadLine());
                foreach (Account account in accounts.GetAccounts().ToList())
                {
                    if (account.GetAccountNumber.Equals(accountNumber))
                    {
                        double currentBalance = account.GetBalance;
                        account.Withdraw(amount);
                        if (account.GetBalance < 0)
                        {
                            Console.WriteLine("");
                            Utility.ClearWholeLine();
                            Console.WriteLine("\t\tInsufficient funds!");
                            account.GetBalance = currentBalance;
                            Console.WriteLine("\t\tEnter the amount...");
                            Console.SetCursorPosition(amountPosY, amountPosX);
                            amount = Convert.ToInt32(Console.ReadLine());
                        }
                        account.UpdateAccount(accountNumber, account.GetBalance, account.GetFirstName, account.GetLastName, account.GetAddress, account.GetPhone, account.GetEmail);
                        File.WriteAllText($"{accountNumber}.txt", $"Account Number|{accountNumber}\nBalance|{account.GetBalance}\nFirst Name|{account.GetFirstName}\nLast Name|{account.GetLastName}\nAddress|{account.GetAddress}\nPhone|{account.GetPhone}\nEmail|{account.GetEmail}");
                    }
                }
                Console.WriteLine("");
                Utility.ClearWholeLine();
                Console.WriteLine("");
                Utility.ClearWholeLine();
                Console.WriteLine("\t\tWithdraw successfull!");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    MainMenu(accounts);
                }
            }
            Console.WriteLine("\n\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tAccount not found!");
            Console.WriteLine("\t\tRetry (y/n)?");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                Withdraw(accounts);
            }
            MainMenu(accounts);
        }

        private static void AccountStatement(Accounts accounts)
        {
            int accountNumberPosY, accountNumberPosX;
            int accountNumber;
            ConsoleKey key;
            string subject, body;

            Print.TopLine();
            Console.WriteLine("\t\t|               STATEMENT                |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Print.AccNumPrompt();
            accountNumberPosY = Console.CursorLeft;
            accountNumberPosX = Console.CursorTop;
            Print.AccNumRemainLine();
            Print.BottomLine();
            Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);

            try
            {
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\t\tAccount Number should not be more than 10 characters!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\t\tAccount Number must be an integer!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            if (File.Exists($"{accountNumber}.txt"))
            {
                foreach (Account account in accounts.GetAccounts().ToList())
                {
                    Console.WriteLine("\n\n\t\tAccount found! The statement is displayed below...");
                    Print.TopLine();
                    Print.Welcome();
                    Print.Seperator();
                    Print.DetailsPrompt();
                    Console.WriteLine("\t\t|    Account Statement                   |");
                    Print.EmptyLine();
                    Console.WriteLine($"\t\t|    Account No: {accountNumber}".PadRight(43, ' ') + "|");
                    Console.WriteLine($"\t\t|    Account Balance: ${account.GetBalance}".PadRight(43, ' ') + "|");
                    Console.WriteLine($"\t\t|    First Name: {account.GetFirstName}".PadRight(43, ' ') + "|");
                    Console.WriteLine($"\t\t|    Last Name: {account.GetLastName}".PadRight(43, ' ') + "|");
                    Console.WriteLine($"\t\t|    Address: {account.GetAddress}".PadRight(43, ' ') + "|");
                    Console.WriteLine($"\t\t|    Phone: {account.GetPhone}".PadRight(43, ' ') + "|");
                    Console.Write($"\t\t|    Email: {account.GetEmail}".PadRight(43, ' ') + "|");
                    Print.BottomLine();
                    Console.WriteLine("\n\t\tEmail statement (y/n)?");
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Y)
                    {
                        subject = "Account Statement";
                        body = $"First Name|{account.GetFirstName}\nLast Name|{account.GetLastName}\nAddress|{account.GetAddress}\nPhone|{account.GetPhone}\nEmail|{account.GetEmail}\nAccountNo|{accountNumber}\nBalance|{account.GetBalance}\n";
                        Utility.EmailDetails(subject, body, account.GetEmail);
                        Console.WriteLine("\n\t\tEmail sent successfully!...");
                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            MainMenu(accounts);
                        }
                    }
                    MainMenu(accounts);
                }
            }
            Console.WriteLine("\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tAccount not found!");
            Console.WriteLine("\t\tRetry (y/n)?");
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Y)
            {
                AccountStatement(accounts);
            }
            MainMenu(accounts);

        }

        private static void DeleteAccount(Accounts accounts)
        {
            int accountNumberPosY, accountNumberPosX;
            int accountNumber;
            ConsoleKey key;

            Print.TopLine();
            Console.WriteLine("\t\t|          DELETE AN ACCOUNT             |");
            Print.Seperator();
            Print.DetailsPrompt();
            Print.EmptyLine();
            Print.AccNumPrompt();
            accountNumberPosY = Console.CursorLeft;
            accountNumberPosX = Console.CursorTop;
            Print.AccNumRemainLine();
            Print.BottomLine();
            Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);

            try
            {
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\n\n\t\tAccount Number should not be more than 10 characters!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("\n\n\t\tAccount Number must be an integer!");
                Console.SetCursorPosition(accountNumberPosY, accountNumberPosX);
                Utility.ClearConsoleLine();
                accountNumber = Convert.ToInt32(Console.ReadLine());
            }
            if (File.Exists($"{accountNumber}.txt"))
            {
                Console.WriteLine("\n\n\t\tAccount found! Details displayed below...");
                foreach (Account account in accounts.GetAccounts().ToList())
                {
                    Print.AccountDetails(accountNumber, account.GetBalance, account.GetFirstName, account.GetLastName, account.GetAddress, account.GetPhone, account.GetEmail);
                    Console.WriteLine("\n\t\tDelete (y/n)?");
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Y)
                    {
                        if (account.GetAccountNumber.Equals(accountNumber))
                        {
                            accounts.GetAccounts().Remove(account);
                            File.Delete($"{accountNumber}.txt");
                            Console.WriteLine("\n\t\tAccount Deleted!");
                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                            {
                                MainMenu(accounts);
                            }
                        }
                    }
                    MainMenu(accounts);
                }
            }
            Console.WriteLine("\n");
            Utility.ClearWholeLine();
            Console.WriteLine("\t\tAccount not found!");
            Console.WriteLine("\t\tRetry (y/n)?");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                DeleteAccount(accounts);
            }
            MainMenu(accounts);
        }
    }
}
