using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosophers
{
    class Stick:IStick
    {
        bool isUsing;
        public bool IsUsing { get { return isUsing; } }
        public Stick() { isUsing = false; }
        public void Take()
        {
            isUsing = true;
        }
        public void Put()
        {
            isUsing = false;
        }

    }
}
