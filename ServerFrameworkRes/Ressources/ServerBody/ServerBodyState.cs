
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Ressources.ServerBody
{
    public enum ServerBodyState : int
    {

        None = 0,
        Wait = 1,
        Busy = 2,
        Cert = 3,
        Gray = 4,
        Blue = 5,
        Red = 6,
        Exit = 7,
        Hide = 8,
    }
}

