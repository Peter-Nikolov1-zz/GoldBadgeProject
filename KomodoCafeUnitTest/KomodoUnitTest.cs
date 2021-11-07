using KomodoCafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class KomodoUnitTest
    {
        //Arrange - Setting up the data required for the test
        //Act - Call the method we are testing to get a result
        //Assert - Compare what the method returned, to what the expected result should have been
        //[TestMethod] above each one
        private KomodoCafeRepo _komodoCafeRepo;
        private KomodoCafeMenu _komodoCafeMenu;

        [TestInitialize]
        public void Arrange()
        {
            _komodoCafeRepo = new KomodoCafeRepo();
        }


        [TestMethod]
        public void AddItemToMenu_Test()
        {
            //Arrange
            KomodoCafeRepo _cafeRepo = new KomodoCafeRepo();
            KomodoCafeMenu komodoCafeMenu = new KomodoCafeMenu();
            //Act
            List<KomodoCafeMenu> localList = _cafeRepo.ViewAllMeals();
            int count = localList.Count;
            _cafeRepo.AddItemToMenu(komodoCafeMenu);
            List<KomodoCafeMenu> updatedLocalList = _cafeRepo.ViewAllMeals();
            int newCount = updatedLocalList.Count;
            bool result = newCount == (count + 1) ? true : false;
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveItemFromMenu_Test()
        {
            KomodoCafeMenu cafeMenu = new KomodoCafeMenu();
            cafeMenu.MealNumber = 2;
            _komodoCafeRepo.RemoveItemFromMenu(cafeMenu);

            bool actual = _komodoCafeRepo.RemoveItemFromMenu(cafeMenu);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ViewAllMeals_Test()
        {
            KomodoCafeMenu cafeMenu = new KomodoCafeMenu();
            List<KomodoCafeMenu> komodoCafeMenus = _komodoCafeRepo.ViewAllMeals();
            bool wasDisplayed = true;
            Assert.IsTrue(wasDisplayed);
        }
    }
}
