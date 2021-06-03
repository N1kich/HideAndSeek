using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Application
{
    abstract class Location
    {
        private string name;
        public Location (string name)
        {
            this.name = name;
        }

        public Location[] Exists;

        public string Name {
            get { return name; }
        }

        public virtual string Description
        {
            get
            {
                string description = "Вы находитесь в " + Name + ". Вы видите следующие участки: ";
                for (int i = 0; i < Exists.Length; i++)
                {
                    description += " " + Exists[i].Name;
                    if (i != (Exists.Length - 1))
                    {
                        description += ",";
                    }
                }
                description += ".";
                return description;
            }
        }



    }
}
