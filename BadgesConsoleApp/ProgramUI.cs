using BadgesClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsoleApp
{
    public class ProgramUI
    {
        public readonly BadgesRepo badgesRepo = new BadgesRepo();

        public void Run()
        {
            SeedBadgeList();
            RunMenu();
        }

        private void SeedBadgeList()
        {
            Badges badges = new Badges(1234, new List<string>() { "A2" }, "Badge One");
            Badges badges1 = new Badges(2234, new List<string>() { "B1", "B2" }, "Badge Two");
            Badges badges2 = new Badges(3234, new List<string>() { "B1", "C1", "C2" }, "Badge Three");
            badgesRepo.AddBadgeToList(badges);
            badgesRepo.AddBadgeToList(badges1);
            badgesRepo.AddBadgeToList(badges2);
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu \n" +
                    "\tHello Security Admin, what would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        ExitMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option (1-4)");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddABadge()
        {
            Console.WriteLine("ADDING A BADGE\n" +
                "-----------------------------------");
            Console.Clear();
            Badges badges = new Badges();
            Console.WriteLine("What is the number on the badge: ");
            string badgeID = Console.ReadLine();
            badges.BadgeID = int.Parse(badgeID);

            Console.WriteLine("List a door that it needs access to: ");
            string doorName = Console.ReadLine();
            badges.ListOfDoorNames.Add(doorName);

            Console.WriteLine("Any other doors(y/n)?");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine("List a door that it needs access to: ");
                string doorName2 = Console.ReadLine();
                badges.ListOfDoorNames.Add(doorName2);
            }
            else
            {
                Console.WriteLine("Press any key to return to the menu.");
            }
            badgesRepo.AddBadgeToList(badges);
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("UPDATING A BADGE \n" +
                "------------------------------------------------------");
            Console.WriteLine("What is the badge number you'd like to update? \n");
            string badgeIDString = Console.ReadLine();
            int badgeID = int.Parse(badgeIDString);
            List<string> doorNames = badgesRepo.GetBadgeByID(badgeID);
            string doorNamesSingleLine = "";
            foreach (string doorName in doorNames)
            {
                if (doorNamesSingleLine == "")
                {
                    doorNamesSingleLine = doorName;
                }
                else
                {
                    doorNamesSingleLine = $"{doorNamesSingleLine} & {doorName}";
                }
            }
            Console.WriteLine($"{badgeIDString} has access to doors {doorNamesSingleLine} \n");
            //Console.ReadLine();
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door");
            string userInput = Console.ReadLine();
            Console.WriteLine("");
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string doorInput = Console.ReadLine();
                    DoorRemoved(badgeID, doorInput);
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string doorInput2 = Console.ReadLine();
                    AddDoor(badgeID, doorInput2);
                    break;
            }
        }

        private void AddDoor(int badgeID, string doorName)
        {
            Console.Clear();
            badgesRepo.AddDoorToBadge(badgeID, doorName);
            Console.WriteLine($"Door {doorName} has been added.");
            Console.WriteLine("Press enter to return to the menu...");
            Console.ReadLine();
            RunMenu();
        }

        private void DoorRemoved(int badgeID, string doorName)
        {
            Console.Clear();
            badgesRepo.RemoveDoorFromBadge(badgeID, doorName);
            Console.WriteLine($"Door {doorName} has been remove.");
            Console.WriteLine("Press enter to return to the main menu...");
            Console.ReadLine();
            RunMenu();
        }
        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgesDictionary = badgesRepo.SeeAllBadges();
            Console.WriteLine("Badge # \t Door Access \n");
            foreach (KeyValuePair<int, List<string>> kvp in badgesDictionary)
            {
                DisplayBadges(kvp.Key, kvp.Value);
            }
            Console.ReadKey();
        }
        private void DisplayBadges(int key, List<string> value)
        {
            Console.WriteLine($"{key}\t\t {String.Join(",", value)}");
        }
        private void ExitMenu()
        {
            Environment.Exit(0);
        }
    }
}
