using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class KomodoUnitTest
    {
        [TestMethod]
        public bool AddItemToMenu(KomodoCafeMenu komodoCafeMenu)
        {
            int beginningCount = _cafeMenu.Count;
            _cafeMenu.Add(komodoCafeMenu);
            bool wasAdded = _cafeMenu.Count > beginningCount ? true : false;
            return wasAdded;
        }
    }
}
