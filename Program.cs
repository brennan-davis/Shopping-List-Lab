// Variables
Dictionary<string, decimal> menuItems = new Dictionary<string, decimal>()
{
    { "bacon", 2.99m },
    { "bread", 1.99m },
    { "frozen pizza", 5.99m },
    { "tomato", 0.99m },
    { "milk", 3.59m },
    { "oranges", 4.99m },
    { "carrots", 1.49m },
    { "soda", 4.99m },
    { "apple pie", 8.79m },
    { "orange sherbet", 3.29m },
    { "apples", 4.19m }
};

List<string> shoppingList = new List<string>();

bool continueProgram = true;

decimal listTotal = 0m;

// Program
while (continueProgram)
{
    DrawTables();

    Console.WriteLine("What item would you like to buy? Or type 'Quit' or 'q' to exit the program.");

    string input = Console.ReadLine().ToLower();
    while (string.IsNullOrEmpty(input) || !menuItems.ContainsKey(input))
    {
        if (!menuItems.ContainsKey(input) && (input != "quit" && input != "q"))
        {
            Console.WriteLine("That item does not exist in our menu. Please check your spelling and try again:");
        }
        
        if (input == "quit" || input == "q")
            break;
        
        input = Console.ReadLine().ToLower();
    }
    
    if (input == "quit" || input == "q")
        break;

    shoppingList.Add(input);

    listTotal = GetShoppingListTotal(shoppingList);

    DrawTables();
}

Console.WriteLine("\nThank you for using our program to build your shopping list!");

// Methods
void DrawTables()
{
    Console.Clear();

    DrawMenu(menuItems);

    if (shoppingList.Count > 0)
        DrawShoppingList(shoppingList);
}

void DrawMenu(Dictionary<string, decimal> menuItems)
{
    Console.WriteLine("------- Menu Items --------");
    foreach (var item in menuItems)
    {
        string key = UppercaseFirstLetter(item.Key.ToString());
        Console.WriteLine("| {0,14} - {1,6} |", key, "$" + item.Value);
    }
    Console.WriteLine("---------------------------");
    Console.WriteLine();
}

void DrawShoppingList(List<string> shoppingList)
{
    if (shoppingList.Count > 0)
    {
        Console.WriteLine("------ Shopping List ------");
        foreach (var item in shoppingList)
            Console.WriteLine("| {0,14} - {1,6} |", UppercaseFirstLetter(item), "$" + menuItems[item]);
        Console.WriteLine("---------------------------");
        Console.WriteLine("    {0,14} {1,6}  ", "List Total:", "$" + listTotal);
        Console.WriteLine();
    }
}

string UppercaseFirstLetter(string str) => char.ToUpper(str[0]) + str.Substring(1);


decimal GetShoppingListTotal(List<string> shoppingList)
{
    decimal total = 0m;

    foreach (var item in shoppingList)
        total += menuItems[item];
    
    return total;
}