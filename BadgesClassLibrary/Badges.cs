using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesClassLibrary
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoorNames { get; set; }
        public string BadgeName { get; set; }

        public Badges()
        {
            ListOfDoorNames = new List<string>();
        }
        public Badges(int badgeID, List<string> listOfDoorNames, string badgeName)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listOfDoorNames;
            BadgeName = badgeName;
        }
    }
}
