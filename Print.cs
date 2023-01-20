using System;

namespace Console_Application
{
    public class Print
    {
        //Prints the top line for the console GUI.
        public static void TopLine()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════╗");
        }

        //Prints "WELCOME TO SIMPLE BANKING SYSTEM".
        public static void Welcome()
        {
            Console.WriteLine("\t\t|    WELCOME TO SIMPLE BANKING SYSTEM    |");
        }

        //Prints a divider.
        public static void Seperator()
        {
            Console.WriteLine("\t\t|════════════════════════════════════════|");
        }

        //Skips a line.
        public static void EmptyLine()
        {
            Console.WriteLine("\t\t|                                        |");
        }

        //Prints "ENTER THE DETAILS".
        public static void DetailsPrompt()
        {
            Console.WriteLine("\t\t|           ENTER THE DETAILS            |");
        }

        //Prompts the user for their Account Number.
        public static void AccNumPrompt()
        {
            Console.Write("\t\t|    Account Number: ");
        }

        //Prints the remainder of the GUI.
        public static void AccNumRemainLine()
        {
            Console.Write("                    |");
        }

        //Prompts the user for their amount.
        public static void AmountPrompt()
        {
            Console.Write("\n\t\t|    Ammount: ");
        }

        //Prints the remainder of the GUI.
        public static void AmountRemainLine()
        {
            Console.Write("                           |");
            BottomLine();
        }

        //Prints the bottom line of the console GUI.
        public static void BottomLine()
        {
            Console.WriteLine("\n\t\t╚════════════════════════════════════════╝");
        }

        //Prints the account details of the user.
        public static void AccountDetails(int accountNumber, double balance, string firstName, string lastName, string address, int phone, string email)
        {

            Console.WriteLine("\t\t╔════════════════════════════════════════╗");
            Console.WriteLine("\t\t|             ACCOUNT DETAILS            |");
            Console.WriteLine("\t\t|════════════════════════════════════════|");
            Console.WriteLine("\t\t|                                        |");
            Console.WriteLine("\t\t|           ENTER THE DETAILS            |");
            Console.WriteLine("\t\t|                                        |");
            Console.WriteLine($"\t\t|    Account No: {accountNumber}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    Account Balance: ${balance}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    First Name: {firstName}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    Last Name: {lastName}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    Address: {address}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    Phone: {phone}".PadRight(43, ' ') + "|");
            Console.WriteLine($"\t\t|    Email: {email}".PadRight(43, ' ') + "|");
            Console.WriteLine("\t\t╚════════════════════════════════════════╝");
        }
    }
}
