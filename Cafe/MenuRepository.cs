using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuDirectory = new List<MenuItem>();

        public int GetDirectoryCount()
        {
            return _menuDirectory.Count;
        }
        public MenuItem GetItemByIndex(int i)
        {
            return _menuDirectory[i];
        }
        public List<string> AddIngredients()
        {
            List<string> ingredients = new List<string>();
            bool addingIngredients = true;
            Console.Write("Please enter an ingredient: ");
            ingredients.Add(Console.ReadLine().ToLower());
            while(addingIngredients)
            {
                Console.Write("Do you have another ingredient to add? Enter y/n: ");
                string response = Console.ReadLine().ToLower();
                switch (response)
                {
                    case "y":
                    case "yes":
                        Console.Write("Please enter an ingredient: ");
                        ingredients.Add(Console.ReadLine().ToLower());
                        break;
                    default:
                        addingIngredients = false;
                        break;
                }
            }
            return ingredients;
        }
        public bool AddToDirectory(MenuItem itemToAdd)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(itemToAdd);

            return _menuDirectory.Count > startingCount;
        }
        public void RemoveItemByNumber()
        {
            Console.Write("Do you know which number to delete? Enter y/n: ");
            string response = Console.ReadLine().ToLower();
            switch(response)
            {
                case "y":
                case "yes":
                    break;
                default:
                    foreach(MenuItem item in _menuDirectory)
                    {
                        Console.WriteLine($"{item.MealNumber} | {item.Name}");
                    }
                    break;
            }
            Console.WriteLine("Select which number to delete or enter 'exit' to cancel.");
            response = Console.ReadLine().ToLower();
            if(response == "exit")
            {
                Console.Clear();
            }
            else
            {
                int i = Convert.ToInt32(response);
                foreach(MenuItem item in _menuDirectory)
                {
                    if (i == item.MealNumber)
                    {
                        RemoveFromDirectory(item);
                        break;
                    }
                }
                Console.Clear();
            }
        }
        public void RemoveItemByName()
        {
            Console.Write("Do you know the name of the item to delet? Enter y/n: ");
            string response = Console.ReadLine().ToLower();
            switch(response)
            {
                case "y":
                case "yes":
                    break;
                default:
                    foreach(MenuItem item in _menuDirectory)
                    {
                        Console.WriteLine(item.Name);
                    }
                    break;
            }
            Console.WriteLine("Enter the name of the item you would like to delete, or enter 'exit' to cancel.");
            response = Console.ReadLine().ToLower();
            switch(response)
            {
                case "exit":
                    Console.Clear();
                    break;
                default:
                    foreach (MenuItem item in _menuDirectory)
                    {
                        if(response == item.Name)
                        {
                            RemoveFromDirectory(item);
                            break;
                        }
                    }
                    Console.Clear();
                    break;
            }
        }
        public bool RemoveFromDirectory(MenuItem itemToRemove)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Remove(itemToRemove);

            return _menuDirectory.Count < startingCount;
        }
        public void ListAllItems()
        {
            foreach(MenuItem item in _menuDirectory)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"  Name: {item.Name}");
            }
            Console.ReadLine();
        }
    }
}
