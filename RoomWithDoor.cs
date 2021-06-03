using Hide_and_Seek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Application
{
    class RoomWithDoor:RoomWithHidingPlace, IHasExteriorDoor
    {
        private string doorDescription;

        public RoomWithDoor (string name, string decoration,string hidingplace, string doorDescription)
            : base(name, decoration, hidingplace)
        {
            this.doorDescription = doorDescription;

        }

        public string DoorDescription 
        {
            get
            {
                return doorDescription;
            }
        }

        private Location doorLocation;
        public Location DoorLocation 
        {
            get
            {
                return doorLocation;
            }
            set
            {
                doorLocation = value;
            }
        }
        public override string Description
        {
            get
            {
                return base.Description + " Вы видите " + doorDescription + " .";
            }
        }
    }
}
