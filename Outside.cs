using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Application
{
    class Outside : Location
    {
        private bool hot;
        public Outside(bool hot,string name)
            :base (name)
        {
            this.hot = hot;
        }
        public bool Hot {
            get { return hot; } 
        }

        public override string Description 
        {
            get
            {
                string NewDescription = base.Description;

                if (Hot)
                {
                    NewDescription += " Тут очень жарко.";
                }
                return NewDescription;
            }
        }
    }
}
