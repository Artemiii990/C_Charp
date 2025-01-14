using System;

public class Money
{
    public int Dollar { get; set; }
    public int FractionalPart { get; set; }
    public string Currency { get; set; } // Додано поле для назви валюти

    public Money(int Dollar, int fractionalPart, string currency)
    {
        Dollar = Dollar;
        FractionalPart = fractionalPart;
        Currency = currency;
    }


    public void PrintAmount()
    {
        Console.WriteLine($"{Dollar}.{FractionalPart:D2} {Currency}");
    }

    public void SetAmount(int Dollar, int fractionalPart)
    {
        Dollar = Dollar;
        FractionalPart = fractionalPart;
        //Перевірка на коректність значень
        if (FractionalPart >= 100) {
            Dollar += FractionalPart / 100;
            FractionalPart %= 100;
        }
        if (FractionalPart < 0) {
            int temp = Math.Abs(FractionalPart);
            if (Dollar >= temp / 100) {
                Dollar -= temp / 100;
                FractionalPart = 100 - (temp % 100);
            }
            else{
                FractionalPart = Math.Abs(FractionalPart);
            }
            
        }
        
    }


    public Money Add(Money other) {
        int newWhole = this.Dollar + other.Dollar;
        int newFrac = this.FractionalPart + other.FractionalPart;

        if (newFrac >= 100) {
            newWhole++;
            newFrac -= 100;
        }

        return new Money(newWhole, newFrac, this.Currency);
    }
    public Money Subtract(Money other) {
        int newWhole = this.Dollar - other.Dollar;
        int newFrac = this.FractionalPart - other.FractionalPart;

        if (newFrac < 0) {
            newWhole--;
            newFrac += 100;
        }

        return new Money(newWhole, newFrac, this.Currency);
    }
}

public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void ReducePrice(Money reduction)
    {
        if (Price.Subtract(reduction).Dollar < 0) {
            throw new ArgumentException("Неможливо зменшити ціну на таку суму.");
        }
        Price = Price.Subtract(reduction);
    }

    public void PrintProductInfo() {
        Console.WriteLine($"Назва продукту: {Name}");
        Console.Write($"Ціна: ");
        Price.PrintAmount();
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Money price1 = new Money(15, 150, "USD");
        price1.PrintAmount(); // Виведе 10.50 USD

        price1.SetAmount(15, 250); // Змінює ціну на 17.25
        price1.PrintAmount(); // Виведе 17.25 USD

        Money price2 = new Money(5, 75, "USD");
        Money sum = price1.Add(price2);
        Console.Write("Сума: ");
        sum.PrintAmount();

        Money diff = price1.Subtract(price2);
        Console.Write("Різниця: ");
        diff.PrintAmount();


        Product product1 = new Product("Телефон", new Money(1000, 0, "UAH"));
        product1.PrintProductInfo();

        try
        {
            product1.ReducePrice(new Money(100,0, "UAH"));
            product1.PrintProductInfo();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
    }
}
