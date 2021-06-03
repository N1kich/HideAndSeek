using House_Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide_and_Seek
{
    class Opponent
    {
        private Location myLocation;
        private Random random;
        public Opponent(Location position)
        {
            myLocation = position;
            random = new Random();
        }

        public Location Mylocation { get { return myLocation; } }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor doorThrough = myLocation as IHasExteriorDoor;
                if (random.Next(2) == 1)
                {
                    myLocation = doorThrough.DoorLocation;
                }
            }
            bool hidden = false;
            while (!hidden)
            {
                int rand = random.Next(myLocation.Exists.Length);
                myLocation = myLocation.Exists[rand];
                if (myLocation is IHidingPlace)
                {
                    hidden = true;
                }
            }
        }
        public bool Check (Location PlayerLocation)
        {
            if (PlayerLocation == myLocation)
            {
                return true;
            }
            else
                return false;
        }
    }
}
