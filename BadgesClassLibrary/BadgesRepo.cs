using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesClassLibrary
{
    public class BadgesRepo
    {
        public Dictionary<int, List<string>> _badgesDictionary = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> SeeAllBadges()
        {
            return _badgesDictionary;
        }
        public void RemoveDoorFromBadge(int oldBadgeID, string newBadgesDoor)
        {
            _badgesDictionary[oldBadgeID].Remove(newBadgesDoor);
        }
        public void AddDoorToBadge(int oldBadgeID, string newBadgesDoor)
        {
            _badgesDictionary[oldBadgeID].Add(newBadgesDoor);
        }
        public bool AddBadgeToList(Badges badges)
        {
            int startingCount = _badgesDictionary.Count;
            _badgesDictionary.Add(badges.BadgeID, badges.ListOfDoorNames);
            bool wasAdded = _badgesDictionary.Count > startingCount ? true : false;
            return wasAdded;
        }
        public List<string> GetBadgeByID(int id)
        {
            return _badgesDictionary[id];
        }
    }
}
