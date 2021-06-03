using House_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide_and_Seek
{
    class RoomWithHidingPlace:Room, IHidingPlace
    {
        string hidingPlace;
        public RoomWithHidingPlace(string name, string decoration, string hidingPlace)
            :base(name, decoration)
        {
            this.hidingPlace = hidingPlace;
        }

        public string HidingPlace { get { return hidingPlace; } }
        public override string Description
        {

            get { return base.Description + " Отлично, я нашел " + hidingPlace + ", и могу проверить это укромное местечко!"; }
        }
    }
}
