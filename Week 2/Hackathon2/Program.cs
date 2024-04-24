namespace Hackathon2;

class Program
{
    static void Main(string[] args)
    {
       ﻿string[] options = { "View grocery list", "Add to grocery list", "Exit" };
int currentItems = 0;
string[] groceryList = new string[10];
//bool isPurchased = false;

MainMenu();


void MainMenu()
{

    Console.WriteLine("Please select a number to choose an option: ");
    for (int i = 0; i < options.Count(); i++)
    {
        Console.WriteLine($"{i + 1}. {options[i]}");
    }

    var input = Convert.ToInt32(Console.ReadLine());


    switch (input)
    {
        case 1:
            PrintGroceries();
            break;
        case 2:
            AddGroceries();
            break;
        case 3:
            break;

    }
}

void PrintGroceries()
{
    Console.WriteLine("Here is your grocery list:");
    Console.WriteLine("--------------------------");
    for (int i = 0; i < groceryList.Count(); i++)
    {
        if (groceryList[i] != null)
        {
            Console.WriteLine($"{i + 1}. {groceryList[i]}");
        }
    }
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

void AddGroceries()
{
    bool keepAlive = false;
    do
    {
        Console.Write("Please enter the name of your item: ");
        string input = Console.ReadLine();
        groceryList[currentItems] = input;
        currentItems++;
        Console.Write("Press Y to enter another item: ");
        input = Console.ReadLine();
        if (input.ToLower() == "y")
        {
            keepAlive = true;
        }
        else {keepAlive = false;}
    }
    while (keepAlive);

    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

// string[] UpdateList(string[] groceryList)
// {

//     Console.WriteLine("Which item would you like to mark as purchased?");
//     PrintGroceries();


// }


    }
}
