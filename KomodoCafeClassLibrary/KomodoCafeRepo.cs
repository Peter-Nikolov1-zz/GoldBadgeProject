using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeClassLibrary
{
    public class KomodoCafeRepo
    {
        protected readonly List<KomodoCafeMenu> _cafeMenu = new List<KomodoCafeMenu>();
        public bool AddItemToMenu(KomodoCafeMenu komodoCafeMenu)
        {
            int beginningCount = _cafeMenu.Count;
            _cafeMenu.Add(komodoCafeMenu);
            bool wasAdded = _cafeMenu.Count > beginningCount ? true : false;
            return wasAdded;
        }

        public List<KomodoCafeMenu> ViewAllMeals()
        {
            return _cafeMenu;
        }

        public bool RemoveItemFromMenu(KomodoCafeMenu komodoCafeMenu)
        {
            bool deletedItem = _cafeMenu.Remove(komodoCafeMenu);
            return deletedItem;
        }
    }
}
