using KomodoCafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeUnitTest
{
    [TestClass]
    public class KomodoUnitTest
    {
        //Arrange - Setting up the data required for the test
        //Act - Call the method we are testing to get a result
        //Assert - Compare what the method returned, to what the expected result should have been
        //[TestMethod] above each one
        KomodoCafeRepo _komodoCafeRepo;
        KomodoCafeMenu _komodoCafeMenu;

        [TestInitialize] //Attributes help your computer know what to do with the code below it
        public void Arrange()
        {
            _komodoCafeRepo = new KomodoCafeRepo();
        }

        [TestMethod]
        public void AddItemToMenu_Test()
        {
            //Arrange
            KomodoCafeMenu komodoCafeMenu = new KomodoCafeMenu();
            //Act
            bool result = _komodoCafeRepo.AddItemToMenu(komodoCafeMenu);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
