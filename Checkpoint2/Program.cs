// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
Console.WriteLine("Checkpoint 2");
List<Item> itemsList = new List<Item>();

//To add stuff, for debugging
Item temp = new Item("food", "strawberry", 90);
Item temp2 = new Item("food", "lemon", 70);
Item temp3 = new Item("food", "Menthol", 60);
itemsList.Add(temp);
itemsList.Add(temp2);
itemsList.Add(temp3);
 
MainMenu();

void MainMenu()
{
    Console.Clear();
    while (true)
    {
        Console.WriteLine("1)Enter a new product \n4) Print all lists \n5) Search \nQuit: q");
       // Console.WriteLine("1) Category \n2) Product Name \n3) Price \n4) Print all lists \n5) Search \nQuit: q");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "q")
            break;
        Option(answer);
    }
    printLists();
    Console.WriteLine("Would you like to add more products to the list? y/n");
    string answer_2 = Console.ReadLine();
    if(answer_2 == "y")
    {
        MainMenu();
    }
    
}

void Option(string answer)
{
    if (answer == null)
    {
        MainMenu();
    }else if (answer =="1")
    {
        EnterANewCategory();

    }
    else if (answer == "4")
    {
        printLists();
    }
    else
    {
        Console.WriteLine("Answer: " + answer + " is not valid");
    }

}

void EnterANewCategory()
{
    Console.WriteLine("Enter a name for your category:");
    string answer = Console.ReadLine();
    
    Console.WriteLine("Enter a product: ");
    string temp = Console.ReadLine();
    
    Console.WriteLine("Enter a price: ");
    int priceAnswer = Convert.ToInt32(Console.ReadLine());

    Item itemTemp = new Item(answer, temp, priceAnswer);

    itemsList.Add(itemTemp);
     
    MainMenu();
    
}



void printLists()
{
    itemsList = itemsList.OrderBy(p => p.Price).ToList();
    double totalPrize = 0;
    foreach (Item item in itemsList)
    {
        Console.WriteLine(" Category: " + item.CategoryName + " , Product: " + item.ProductName + " , Price: " + item.Price);
        totalPrize = totalPrize + item.Price;
    }
    Console.WriteLine("Total price: " + totalPrize);
    Console.ReadKey();
   //MainMenu();
}


class Item
{
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Item(string categoryName, string productName, double price )
    {
        CategoryName = categoryName;
        ProductName = productName;
        Price = price;

    }

}

