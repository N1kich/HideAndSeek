using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Application
{
    class OutsideWithDoor:Outside, IHasExteriorDoor
    {
        private string doorDescription;
        public OutsideWithDoor (string name, bool hot, string doorDescription)
            : base(hot, name)
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
                return base.Description + " Вы видите " + doorDescription + ".";
            }
        }
        

        
    }
}
