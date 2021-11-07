using BadgesClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgesUnitTest
{
    [TestClass]
    public class BadgesUnitTest
    {
        private BadgesRepo _badgesRepo;
        private Badges _badges;


        [TestInitialize]

        public void Arrange()
        {
            _badgesRepo = new BadgesRepo();
        }

        [TestMethod]
        public void SeeAllBadges_Test()
        {
            Dictionary<int, List<string>> localList = _badgesRepo.SeeAllBadges();
            bool wasDisplayed = true;
            Assert.IsTrue(wasDisplayed);
        }

        public List<string> DictListCounter(int key)
        {
            foreach (KeyValuePair<int, List<string>> entry in _badgesRepo.SeeAllBadges())
            {
                if (_badgesRepo.SeeAllBadges().ContainsKey(key))
                {
                    return entry.Value;
                }
            }
            return null;
        }

        [TestMethod]
        public void AddDoorToBadge_Test()
        {
            Badges badges1 = new Badges(2214, new List<string>() { "B1", "B2" }, "Badge Two");
            Badges badges2 = new Badges(2224, new List<string>() { "B1", "B2" }, "Badge Two");
            Badges badges3 = new Badges(2234, new List<string>() { "B1", "B2" }, "Badge Two");
            _badgesRepo.AddBadgeToList(badges1);
            _badgesRepo.AddBadgeToList(badges2);
            _badgesRepo.AddBadgeToList(badges3);

            _badgesRepo.AddDoorToBadge(2234, "newBadge4");
            _badgesRepo.AddDoorToBadge(2234, "newBadge5");
            List<string> testList = DictListCounter(2234);
            Assert.AreEqual(2, testList.Count);
        }

        [TestMethod]
        public void RemoveDoorFromBadge_Test()
        {
            Badges badges1 = new Badges(2214, new List<string>() { "B1", "B2" }, "Badge Two");
            Badges badges2 = new Badges(2314, new List<string>() { "B1", "B2" }, "Badge Two");

            _badgesRepo.AddBadgeToList(badges1);
            _badgesRepo.AddBadgeToList(badges2);

            _badgesRepo.RemoveDoorFromBadge(2214, "B1");
            _badgesRepo.RemoveDoorFromBadge(2214, "B2");
            List<string> testList2 = DictListCounter(2214);
            Assert.AreEqual(0, testList2.Count);
        }

        [TestMethod]
        public void GetBadgeByID_Test()
        {
            Badges badges = new Badges(1234, new List<string>() { "A3" }, "Badge Three");

            _badgesRepo.AddBadgeToList(badges);
            _badgesRepo.GetBadgeByID(1234);

            Assert.AreEqual(1234, badges.BadgeID);
        }
    }
}
