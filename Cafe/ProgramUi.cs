using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void RunMenu()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("Please select a number:\n" +
                    "1. View Menu Items\n" +
                    "2. Add Menu Item\n" +
                    "3. Remove Menu Item\n" +
                    "4. Exit\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        Console.Clear();
                        _menuRepo.ListAllItems();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        AddMenuItem();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveMenuItem();
                        Console.Clear();
                        break;
                    case "4":
                        menuRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddMenuItem()
        {
            Console.Write("Would you like to add a new menu item? Enter y/n: ");
            string response = Console.ReadLine().ToLower();
            switch (response)
            {
                case "y":
                case "yes":
                    MenuItem newItem = new MenuItem();
                    bool validNumber = false;
                    Console.Write("Please enter a meal number (1-50, no duplicates allowed): ");
                    int newNumber = Convert.ToInt32(Console.ReadLine());
                    while (!validNumber)
                    {
                        if (newNumber >= 1 && newNumber <= 50)
                        {
                            validNumber = true;
                            for (int i = 0; i < _menuRepo.GetDirectoryCount(); i++)
                            {
                                MenuItem item = _menuRepo.GetItemByIndex(i);
                                if (newNumber == item.MealNumber) { validNumber = false; }
                            }
                        }
                        if (!validNumber) { Console.WriteLine("Not a valid number. Please try again."); }
                    }
                    newItem.MealNumber = newNumber;
                    Console.Clear();
                    Console.Write("Please enter a name for this meal: ");
                    newItem.Name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Please enter a brief description of this meal");
                    newItem.Description = Console.ReadLine();
                    Console.Clear();
                    newItem.Ingredients = _menuRepo.AddIngredients();
                    Console.Clear();
                    Console.Write("Please enter a price ($XX.XX): ");
                    newItem.Price = Convert.ToDouble(Console.ReadLine());
                    _menuRepo.AddToDirectory(newItem);
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public void RemoveMenuItem()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("Please select a numbern:\n" +
                    "1. Remove by number\n" +
                    "2. Remove by name\n" +
                    "3. Exit\n");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        _menuRepo.RemoveItemByNumber();
                        break;
                    case "2":
                        _menuRepo.RemoveItemByName();
                        break;
                    case "3":
                        menuRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
