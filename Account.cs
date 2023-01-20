namespace Console_Application
{
	public class Account
	{
		private string firstName, lastName, address, email;
		private int accountNumber, phone;
		private double balance;

		public Account(int accountNumber, double balance, string firstName, string lastName, string address, int phone, string email)
		{
			this.accountNumber = accountNumber;
			this.balance = balance;
			this.firstName = firstName;
			this.lastName = lastName;
			this.address = address;
			this.phone = phone;
			this.email = email;
		}

		public int GetAccountNumber
        {
			get => accountNumber;
        }

		public double GetBalance
        {
			get => balance;
			set => balance = value;
        }

		public string GetFirstName
        {
			get => firstName;
        }

		public string GetLastName
        {
			get => lastName;
        }

		public string GetAddress
        {
			get => address;
        }

		public int GetPhone
        {
			get => phone;
        }

		public string GetEmail
        {
			get => email;
        }

		public void Deposit(double amount)
        {
			balance += amount;
        }

		public void Withdraw(double amount)
        {
			balance -= amount;
        }

		//Updates the account.
		public void UpdateAccount(int n, double b, string f, string l, string a, int p, string e)
        {
			accountNumber = n;
			balance = b;
			firstName = f;
			lastName = l;
			address = a;
			phone = p;
			email = e;
        }
	}
}
