using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }
        public MenuItem() { }
        public MenuItem(int mealNumber, string name, string description, List<string> ingredients, double price)
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public MenuItem(int mealNumber, string name)
        {
            MealNumber = mealNumber;
            Name = name;
        }
    }
}
