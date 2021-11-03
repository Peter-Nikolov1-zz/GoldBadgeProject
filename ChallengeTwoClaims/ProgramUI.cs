using ClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClaims
{
    public class ProgramUI
    {
        private readonly ClaimRepo claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("CLAIMS MENU \n" +
                    "--------------------------- \n" +
                    "1. See All Claims \n" +
                    "2. Take Care Of Next Claim \n" +
                    "3. Enter A New Claim \n" +
                    "4. Exit Menu");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        WorkNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        ExitMenu();
                        continueToRun = false;
                        break;
                }
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = claimRepo.SeeAllClaims();
            Console.WriteLine("ClaimID\tType\tDescription\t\tAmount\tDateOfAccident\t\tDateOfClaim\t\tIsValid \n");
            foreach (Claim claim in claims)
            {
                DisplayClaim(claim);
            }
            Console.ReadKey();
        }
        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}\t{claim.ClaimAmount}\t{claim.DateOfAccident.ToString("MM/dd/yyyy")}\t\t{claim.DateOfClaim.ToString("MM/dd/yyyy")}\t\t{claim.IsValid} \n");
        }
        private void WorkNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:\n" +
                "---------------------------------------------------------");
            Claim claimReturn = claimRepo.NextClaim();
            Console.WriteLine($"ClaimID: {claimReturn.ClaimID} \n" +
                $"\n" +
                $"Type: {claimReturn.ClaimType} \n" +
                $"\n" +
                $"Description: {claimReturn.Description} \n" +
                $"\n" +
                $"Amount: {claimReturn.ClaimAmount} \n" +
                $"\n" +
                $"DateOfAccident: {claimReturn.DateOfAccident} \n" +
                $"\n" +
                $"DateOfClaim: {claimReturn.DateOfClaim} \n" +
                $"\n" +
                $"IsValid: {claimReturn.IsValid}\n");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                claimRepo.DequeueClaim();
            }
            else
            {
                RunMenu();
            }
        }

        private void CreateNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Please enter the ClaimID associated with this new claim:");
            string claimID = Console.ReadLine();
            claim.ClaimID = int.Parse(claimID);

            Console.WriteLine("Please select the ClaimType: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                case "Car":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                case "Home":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                case "Theft":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid ClaimType.");
                    break;
            }

            Console.WriteLine("Now please provide a simple description of the claim:");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Now the damage amount:");
            string claimAmount = Console.ReadLine();
            try
            {
                claim.ClaimAmount = double.Parse(claimAmount);
            }
            catch
            {
                Console.WriteLine("Please enter a valid amount.");
            }

            Console.WriteLine("Next is the DateOfAccident. Please enter in MM/DD/YY format.");
            string dateOfAccident = Console.ReadLine();
            DateTime dateTime;
            while (!DateTime.TryParseExact(dateOfAccident, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("Invalid date, please retry");
                dateOfAccident = Console.ReadLine();
            }

            Console.WriteLine("Now the DateOfClaim");
            string dateOfClaim = Console.ReadLine();
            DateTime dateTime1;
            while (!DateTime.TryParseExact(dateOfClaim, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dateTime1))
            {
                Console.WriteLine("Invalid date, please try again");
                dateOfClaim = Console.ReadLine();
            }
            claimRepo.AddClaimToList(claim);
        }
        private void SeedClaimList()
        {

            Claim claim = new Claim(1, ClaimType.Car, "Car Accident on 465E.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim1 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim2 = new Claim(3, ClaimType.Theft, "Stolen pancakes\t", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));
            claimRepo.AddClaimToList(claim);
            claimRepo.AddClaimToList(claim1);
            claimRepo.AddClaimToList(claim2);
        }

        private void ExitMenu()
        {
            Environment.Exit(0);
        }
    }
}
