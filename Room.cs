using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Application
{
    class Room : Location
    {
        private string decoration;
        public Room(string name, string decoration)
            :base(name)
        {
            this.decoration = decoration;
        }

        public string Decoration
        {
            get
            {
                return decoration;
            }
        }
        public override string Description
        {
            get
            {
                return base.Description + "Вы видите " + Decoration + ". ";
            }
        }
    }
}
