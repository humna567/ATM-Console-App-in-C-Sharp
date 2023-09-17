using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public int getpin()
    {
        return pin;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("        Welcome to MyATM");
            Console.WriteLine("====================================");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.WriteLine("====================================");
        }

        void Deposit(CardHolder currentUser)
        {
            Console.Write("Enter the deposit amount: $");
            double depositAmount = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + depositAmount);
            Console.WriteLine($"Deposited: ${depositAmount}");
            Console.WriteLine($"New Balance: ${currentUser.getBalance():F2}");
        }

        void Withdraw(CardHolder currentUser)
        {
            Console.Write("Enter the withdrawal amount: $");
            double withdrawalAmount = double.Parse(Console.ReadLine());

            if (currentUser.getBalance() < withdrawalAmount)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawalAmount);
                Console.WriteLine($"Withdrawn: ${withdrawalAmount}");
                Console.WriteLine($"New Balance: ${currentUser.getBalance():F2}");
            }
        }

        void ShowBalance(CardHolder currentUser)
        {
            Console.WriteLine($"Current Balance: ${currentUser.getBalance():F2}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("453222737737673777", 1234, "Humna", "Ghaffar", 120.76));
        cardHolders.Add(new CardHolder("672899254275266627", 8900, "Shabahat", "Ali", 120.76));
        cardHolders.Add(new CardHolder("453222737737673777", 8876, "Fatima", "Khan", 120.76));
        cardHolders.Add(new CardHolder("453222737737673777", 8765, "Aimal", "Salman", 120.76));

        Console.WriteLine("====================================");
        Console.Write("Please insert your debit card number: ");
        string debitCardNum = " ";
        CardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again."); }
        }

        Console.Write("Please enter your PIN: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getpin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect PIN. Please try again."); }
        }

        Console.WriteLine($"Welcome, {currentUser.firstName}!");
        Console.WriteLine("====================================");

        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdraw(currentUser); }
            else if (option == 3) { ShowBalance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);

        Console.WriteLine("====================================");
        Console.WriteLine("Thank you! Have a nice day :)");
        Console.WriteLine("====================================");
    }
}
