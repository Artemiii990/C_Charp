﻿using System;

public delegate void Deposit(decimal amount);

public delegate void Spend(decimal amount);

public delegate void Changepin(string oldPin, string newPin);


public class CreditCard
{
    public string CardNumber { get; private set; }
    public string OwnerName { get; private set; }
    public string ExpiryDate { get; private set; }
    public string Pin { get; private set; }
    public decimal CreditLimit { get; private set; }
    public decimal Balance { get; private set; }

    
    public CreditCard(string cardNumber, string ownerName, string expiryDate, string pin, decimal creditLimit)
    {
        CardNumber = cardNumber;
        OwnerName = ownerName;
        ExpiryDate = expiryDate;
        Pin = pin;
        CreditLimit = creditLimit;
        Balance = 150;
    }
    
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Счет пополнено на {amount}. Поточный баланс: {Balance}.");
        }
        else
        {
            Console.WriteLine("Сума пополнение должна быть позитивной.");
        }
    }
    
    public void Spend(decimal amount)
    {
        if (amount > 0)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Потрачено {amount}. Поточный баланс: {Balance}.");
            }
            else if (amount <= Balance + CreditLimit)
            {
                decimal creditUsed = amount - Balance;
                Balance = 0;
                Console.WriteLine($"Потрачено {amount} з использованием кредита. Использовано кредитных средств: {creditUsed}.");
            }
            else
            {
                Console.WriteLine("Недостаточно денег на счету и на кредитном лемите.");
            }
        }
        else
        {
            Console.WriteLine("Сума пополнение должна быть позитивной.");
        }
    }
    
    public void ChangePin(string oldPin, string newPin)
    {
        if (oldPin == Pin)
        {
            Pin = newPin;
            Console.WriteLine("PIN-код успешно изменен.");
        }
        else
        {
            Console.WriteLine("Неверный PIN-код.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine("На баллансе ---- " + Balance + "грн");
    }
}

// Приклад використання класу
class Program
{
    static void Main(string[] args)
    {
        CreditCard myCard = new CreditCard("1234 5678 9012 3456", "Иван Олександрович", "12/25", "5241", 1000);
        
        Deposit myDeposit = new Deposit(myCard.Deposit);
        myDeposit(650);
        
        
        Spend mySpend = new Spend(myCard.Spend);
        mySpend(500);
            
        
        Changepin myChangePin = new Changepin(myCard.ChangePin);
        myChangePin("5241", "3145");
        
        myCard.CheckBalance();

    }
}
