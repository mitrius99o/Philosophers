using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philosophers
{
    interface IStick
    {
        bool IsUsing { get; }
        void Take();
        void Put();
    }
}
