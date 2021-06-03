using House_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide_and_Seek
{
    class OutsideWithHidingPlace:Outside, IHidingPlace
    {
        private string hidingPlace;
        public OutsideWithHidingPlace (bool hot, string name, string hidingPlace)
            :base(hot, name)
        {
            this.hidingPlace = hidingPlace;
        }

        public string HidingPlace { get { return hidingPlace; } }
        public override string Description
        {

            get { return base.Description + " Отлично, я нашел " + hidingPlace + ", и могу проверить это укромное местечко"; }
        }
    }
}
