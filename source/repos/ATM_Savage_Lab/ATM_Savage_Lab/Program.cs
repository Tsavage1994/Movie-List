using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ATM_Savage_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var newATM = new ATM();
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"What would you like to do?\n[1]Create Account\n[2]Login");
                var usersInputer = Console.ReadLine();
                var usersSelection = int.Parse(usersInputer);
                if (usersSelection == 1)
                {
                    Console.WriteLine($"Please enter your user login and password.");
                    var userName = Console.ReadLine();
                    var userPassword = Console.ReadLine();
                    newATM.Register(userName, userPassword);
                }
                else
                {
                    Console.WriteLine($"Please enter your user login and password.");
                    var userName = Console.ReadLine();
                    var userPassword = Console.ReadLine();
                    newATM.Login(userName, userPassword);
                }
            }
            Console.WriteLine($"Please enter the option you would like:\n[1]Deposit\n" +
                $"[2]Withdraw\n[3]Check Balance\n[4]Logout");
            int.TryParse(Console.ReadLine(), out int userSelection);
            switch (userSelection)
            {
                case 1: 
                    Console.WriteLine("Please enter an amount you'd like to deposit.");
                    int.TryParse(Console.ReadLine(), out int depositAmount);
                    newATM.Deposit(depositAmount);
                    Console.WriteLine($"Your deposit of ${depositAmount} was successful!");
                    break;
                case 2:
                    Console.WriteLine("Please enter an amount you'd like to withdraw.");
                    int.TryParse(Console.ReadLine(), out int withdrawAmount);
                    newATM.Withdraw(withdrawAmount);
                    Console.WriteLine($"Your withdraw of ${withdrawAmount} was successful!");
                    break;
                case 3:
                    newATM.CheckBalance();
                    break;
                case 4:
                    newATM.Logout();
                    break;
                default:
                    Console.WriteLine("Goodbye");
                    break;
            }
        } 
    }

    class ATM
    {
        public ATM()
        {
            var ListOfAccounts = new List<Account>();
            Accounts = ListOfAccounts;
        }
        public List<Account> Accounts { get; set; }
        public Account CurrentAccount { get; set; }
        public void Register(string name, string password)
        {
            Console.WriteLine("Registering.....");
            var account = new Account(name, password);
            Accounts.Add(account);
            CurrentAccount = account;
        }
        public void Login(string name, string password)
        {
            if(CurrentAccount == null)
            {
                foreach (var account in Accounts)
                {
                    if (account.Name == name && account.Password == password)
                    {
                        Console.WriteLine("Logging in....");
                        CurrentAccount = account;
                    }
                }
            }
        }
        public void Logout()
        {
            CurrentAccount = null;
        }
        public void CheckBalance()
        {
            Console.WriteLine(CurrentAccount.Balance);
        }
        public void Deposit(int deposit)
        {
            var newBalance = deposit + CurrentAccount.Balance;
            CurrentAccount.Balance = newBalance;
        }
        public void Withdraw(int withdraw)
        {
            var newBalance = withdraw - CurrentAccount.Balance;
            CurrentAccount.Balance = newBalance;
        }
    }
    public class Account
    {
        public Account(string name, string password, int balance)
        {
            var _name = name;
            Name = _name;

            var _password = password;
            Password = _password;

            var _balance = balance;
            Balance = _balance;
        }
        public Account(string name, string password)
        {
            Name = name;
            Password = password;
         // still need to define balance even though it's not in the parameters.
            Balance = 0;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
    }
}
