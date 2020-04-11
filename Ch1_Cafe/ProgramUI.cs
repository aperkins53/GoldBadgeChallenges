using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_Cafe
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What do you want to do:\n" +
                    "1: Add an item\n" +
                    "2: Delete an item\n" +
                    "3: See items on menu\n" +
                    "4: Exit");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        AddToList();
                        break;
                    case "2":
                        DeleteFromList();
                        break;
                    case "3":
                        PrintMenu();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddToList()
        {
            Menu menu = new Menu();
            Console.Clear();

            Console.WriteLine("Enter the menu number of the meal:");
            menu.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the name of the meal:");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("Enter a description of the meal:");
            menu.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the meal(Seperate ingredients with a comma):");
            string ingredientsAsString = Console.ReadLine();
            menu.Ingredients = ingredientsAsString.Split(',').ToList();
            
            Console.WriteLine("Enter the price of the meal:");
            string priceAsString = Console.ReadLine();
            menu.Price = double.Parse(priceAsString);

            _menuRepo.AddItemToMenu(menu);
        }

        private void DeleteFromList()
        {
            Console.Clear();

            PrintMenu();

            Console.WriteLine("Enter the menu number of the meal you would like to delete from the menu.");
            int response = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted =_menuRepo.DeleteItemFromMenu(response);

            if (wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted.");
            }


        }

        private void PrintMenu()
        {
            Console.Clear();

            List<Menu> menuItems = _menuRepo.GetMenuItems();

            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"Meal number: {item.MealNumber}\n" +
                    $"Meal name: {item.MealName}\n" +
                    $"Description: {item.MealDescription}\n" +
                    $"Ingredients:");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.WriteLine(ingredient);
                }
                Console.WriteLine($"Price: ${item.Price}");

            }
        }
    }
}
