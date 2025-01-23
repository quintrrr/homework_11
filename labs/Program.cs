#define DEBUG_ACCOUNT
using System;
using System.Reflection;
using BankLibrary.BankAccountLibrary;
using labs.Classes;
using DeveloperInfoAttribute = BankLibrary.BankAccountLibrary.DeveloperInfoAttribute;

class Program
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
    }

    public static void Task1()
    {
        Console.WriteLine("Домашнее задание 13.1");
        Building building = new(10, 3, 120, 4);
        Console.WriteLine($"Высота: {building.Height}");
        Console.WriteLine($"Количество этажей: {building.Floors}");
        Console.WriteLine($"Количество квартир: {building.Apartments}");
        Console.WriteLine($"Количество подъездов: {building.Entrances}");
    }

    public static void Task2()
    {
        Console.WriteLine("\nУпражнение 14.1");
        BankAccountFactory factory = new BankAccountFactory(); 
        BankAccount account1 = (BankAccount)factory.GetAccount(factory.CreateAccount(1000, AccountType.Savings, "Arina Gomza"));
        account1.DumpToScreen();
    }

    public static void Task3()
    {
        Console.WriteLine("\nДомашнее задание 14.1");
        Type type = typeof(BankAccount);
        
        var attributes = type.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);

        foreach (DeveloperInfoAttribute attribute in attributes)
        {
            Console.WriteLine(attribute);
        }
    }
}