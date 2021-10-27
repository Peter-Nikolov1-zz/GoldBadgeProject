using KomodoCafeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeProject
{
    public class ProgramUI
    {
        private readonly KomodoCafeRepo komodoCafeRepo = new KomodoCafeRepo();

        public void Run()
        {
            SeedMenuItem();
            RunMenu();
        }
        public void SeedMenuItem()
        {

            KomodoCafeMenu komodoCafeMenu = new KomodoCafeMenu
            {
                MealNumber = 1,
                MealName = "Bacon Egg and Cheese Bagel",
                Description = "Fill your belly with our delicious BECB, fresh ingredients on the daily.",
                Ingredients = "Toasted bagel with butter, thick-cut Applewood smoked bacon, a fluffy folded egg, and two slices of melty American cheese.",
                MealPrice = 6.99
            };
            komodoCafeRepo.AddItemToMenu(komodoCafeMenu);

            KomodoCafeMenu komodoCafeMenu1 = new KomodoCafeMenu
            {
                MealNumber = 2,
                MealName = "Cheeseburger",
                Description = "Savory cheeseburger made fresh anyway you want it. Gordon Ramsay even loves this burger.",
                Ingredients = "Pure angus beef, American Cheese, fresh onion, secret hamburger seasoning, topped with a brioche bun.",
                MealPrice = 9.00
            };
            komodoCafeRepo.AddItemToMenu(komodoCafeMenu1);

            KomodoCafeMenu komodoCafeMenu2 = new KomodoCafeMenu
            {
                MealNumber = 3,
                MealName = "Buffalo Chicken Dip",
                Description = "You'll be begging for more of this dip after you're finished with it, FoodTimes rates it a 10/10! ",
                Ingredients = "Shredded chicken, Mexican cheese, fresh chips made in house, cream cheese and topped off with Franks Red Hot.",
                MealPrice = 10.99
            };
            komodoCafeRepo.AddItemToMenu(komodoCafeMenu2);

            KomodoCafeMenu komodoCafeMenu3 = new KomodoCafeMenu
            {
                MealNumber = 4,
                MealName = "Chicken Tacos",
                Description = "These Shredded Chicken Tacos are epic!  They are quick, easy, healthy, flavorful and everything you love about tacos",
                Ingredients = "Mini flour tortillas, pico de gallo, avacado, adobo chicken, fresh cilantro, dried oregeno.",
                MealPrice = 9.95
            };
            komodoCafeRepo.AddItemToMenu(komodoCafeMenu3);

            KomodoCafeMenu komodoCafeMenu4 = new KomodoCafeMenu
            {
                MealNumber = 5,
                MealName = "Double Pep Pizza",
                Description = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, and tons of pepperoni.",
                Ingredients = "Fresh pizza dough, red pizza sauce, 20 pepperonis, mozzarella, black pepper, fresh oregano.",
                MealPrice = 10.99
            };
            komodoCafeRepo.AddItemToMenu(komodoCafeMenu4);
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Komodo Cafe \n" +
                    "What would you like to do? \n" +
                    "-------------------------------- \n" +
                    "1. Add a meal to your menu \n" +
                    "2. Remove a meal from the menu \n" +
                    "3. View all meals on menu \n" +
                    "4. Exit the menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        ViewAllMenuItems();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option. (1-4)");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            KomodoCafeMenu komodoCafeMenu = new KomodoCafeMenu();

            Console.WriteLine("Lets exapand that menu a little! \n" +
                "Please enter the Meal Number people will use to order by:");
            string mealNumber = Console.ReadLine();
            komodoCafeMenu.MealNumber = int.Parse(mealNumber);

            Console.WriteLine("Okay, now give me the name of the meal:");
            komodoCafeMenu.MealName = Console.ReadLine();

            Console.WriteLine("Sounds tasty... now the description:");
            komodoCafeMenu.Description = Console.ReadLine();

            Console.WriteLine("Now the ingredients:");
            komodoCafeMenu.Ingredients = Console.ReadLine();

            Console.WriteLine("Finally, the price:");
            string mealPrice = Console.ReadLine();
            komodoCafeMenu.MealPrice = int.Parse(mealPrice);
            try
            {
                komodoCafeMenu.MealPrice = double.Parse(mealPrice);
            }
            catch
            {
                Console.WriteLine("Please enter a valid price.");
            }

            komodoCafeRepo.AddItemToMenu(komodoCafeMenu);
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which meal would you like removed?");
            List<KomodoCafeMenu> komodoCafeMenu = komodoCafeRepo.ViewAllMeals();
            int count = 0;
            foreach (KomodoCafeMenu komodoCafeMenu1 in komodoCafeMenu)
            {
                count++;
                Console.WriteLine($"{count}. {komodoCafeMenu1.MealName}");
            }

            int mealID = int.Parse(Console.ReadLine());
            int mealIndex = mealID - 1;
            if (mealIndex >= 0 && mealIndex < komodoCafeMenu.Count)
            {
                KomodoCafeMenu desiredMeal = komodoCafeMenu[mealIndex];
                if (komodoCafeRepo.RemoveItemFromMenu(desiredMeal))
                {
                    Console.WriteLine($"{desiredMeal.MealName} has been removed.");
                }
                else
                {
                    Console.WriteLine("Sorry, action not completed.");
                }
            }
            else
            {
                Console.WriteLine("There isn't a meal by that number.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<KomodoCafeMenu> listOfMenuItems = komodoCafeRepo.ViewAllMeals();

            foreach (KomodoCafeMenu menuVariable in listOfMenuItems)
            {
                ViewAllMeals(menuVariable);
                Console.WriteLine("---------------------------------------------");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        private void ViewAllMeals(KomodoCafeMenu komodoCafeMenu)
        {
            Console.WriteLine($"Meal Number: {komodoCafeMenu.MealNumber}");
            Console.WriteLine($"Meal Name: {komodoCafeMenu.MealName}");
            Console.WriteLine($"Description: {komodoCafeMenu.Description}");
            Console.WriteLine($"Ingredients: {komodoCafeMenu.Ingredients}");
            Console.WriteLine($"Price: {komodoCafeMenu.MealPrice}");
        }

    }
}
