using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_Cafe
{
    public class Menu
    {
        //properties, constructors, and fields go here
        //add a field

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

        //empty constructor
        public Menu() { }

        //overloaded constructor
        public Menu(int mealNumber, string mealName, string mealDescription, List<string> ingredients, double price) 
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
