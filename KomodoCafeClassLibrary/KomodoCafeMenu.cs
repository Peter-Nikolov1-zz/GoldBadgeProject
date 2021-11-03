using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeClassLibrary
{
    
    public class KomodoCafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } 
        public double MealPrice { get; set; }

        public KomodoCafeMenu()
        {

        }
        public KomodoCafeMenu(int mealNumber, string mealName, string description, string ingredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            MealPrice = mealPrice;
        }
    }

}
