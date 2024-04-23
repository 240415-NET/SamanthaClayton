namespace Hackathon2;

class Program
{
    static void Main(string[] args)
    {
        ﻿string[] menuOptions =
{ "View grocery list", "Add to grocery list",
"Remove from grocery List", "Exit" };
bool keepAlive = true;
GroceryList groceryList = new GroceryList();

do
{
    MainMenu();
}
while (keepAlive);

void MainMenu()
{
    bool isValid = false;
    int selection = 0;
    do
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Please select a number to choose an option: ");
        for (int i = 0; i < menuOptions.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {menuOptions[i]}");
        }
        Console.ResetColor();
        string input = Console.ReadLine();
        isValid = int.TryParse(input, out selection);
        isValid = Validator.ValidateMenuInput(selection, menuOptions);

        if (!isValid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid selection");
            Console.ResetColor();
            Console.ReadKey();
        }
        else { MenuSelection(selection);}
    }
    while (!isValid);


}

void MenuSelection (int selection)
{
    switch (selection)
    {
        case 1:
            groceryList.PrintGroceries();
            Console.ReadKey();
            break;
        case 2:
            AddGroceries();
            break;
        case 3:
            RemoveGroceries();
            Console.ReadKey();
            break;
        case 4:
            keepAlive = false;
            break;

    }
}


void AddGroceries()
{
    bool addItems = false;
    do
    {
        Console.Write("Please enter the name of your item, or press Enter to return to the main menu: ");
        string? input = Console.ReadLine();
        if (input.ToLower() != "")
        {
            addItems = true;
            groceryList.AddItem(input);
        }
        else { addItems = false; }
    }
    while (addItems);
}


void RemoveGroceries()
{
    bool keepRemovingItems = false;
    bool isValid = true;
    int selection = 0;
    groceryList.PrintGroceries();
    do
    {
        Console.WriteLine
        ("Please select the number of the item you want to remove," +
        "or press enter to return to the Main Menu.");

        string input = Console.ReadLine().Trim();

        if (input == "")
        {
            keepRemovingItems = false;
        }
        else
        {
            isValid = int.TryParse(input, out selection);
            isValid = Validator.ValidateGroceryInput(selection, groceryList);
            Console.WriteLine($"{groceryList.GetItem(selection - 1)} was removed.");
            groceryList.RemoveItem(selection - 1);
        }

    }
    while (keepRemovingItems && !isValid);

}


    }
}
