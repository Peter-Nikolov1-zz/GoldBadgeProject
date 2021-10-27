using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeProject
{
    //Manager wants a console app where can create new menu items, delete menu items and display a list of all items on the menu.

    //Menu will have 5 meal options starting off, Seeding the menu. 
    //Meal names:
        //#1 Bacon Egg and Cheese Bagel
        //#2 Cheeseburger 
        //#3 Buffalo Chicken Dip
        //#4 Chicken Tacos
        //#5 Double Pep Pizza
    //Description for each meal
    //Ingredients for each meal
    //Price of each meal


    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
            Console.ReadKey();
        }
    }
}
