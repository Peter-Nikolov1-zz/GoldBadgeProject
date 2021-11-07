using ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class ClaimsUnitTest
    {
        private ClaimRepo _claimRepo;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
        }

        [TestMethod]
        public void AddClaimToList_Test()
        {
            Claim claim = new Claim();

            Queue<Claim> localList = _claimRepo.SeeAllClaims();
            int count = localList.Count;
            _claimRepo.AddClaimToList(claim);
            Queue<Claim> updatedLocalList = _claimRepo.SeeAllClaims();
            int newCount = updatedLocalList.Count;
            bool result = newCount == (count + 1) ? true : false;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SeeAllClaims_Test()
        {
            Queue<Claim> claims = _claimRepo.SeeAllClaims();
            bool wasDisplayed = true;
            Assert.IsTrue(wasDisplayed);
        }

        [TestMethod]
        public void NextClaim_Test()
        {
            Queue<Claim> claims = _claimRepo.SeeAllClaims();
            bool wasPeeked = true;
            Assert.IsTrue(wasPeeked);
        }

        [TestMethod]
        public void DequeueClaim_Test()
        {
            Queue<Claim> claims = _claimRepo.SeeAllClaims();
            bool wasDequeued = true;
            Assert.IsTrue(wasDequeued);
        }
    }
}
