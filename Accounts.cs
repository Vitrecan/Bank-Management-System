using System.Collections.Generic;

namespace Console_Application
{
    public class Accounts
    {
        private List<Account> accounts;

        public Accounts()
        {
            accounts = new List<Account>();
        }

        //Adds a new account to the list of accounts.
        public void Add(Account account)
        {
            accounts.Add(account);
        }

        //Getter method for Accounts.
        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
