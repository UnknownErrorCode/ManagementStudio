using Structs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
   
    class DashboardMessageGenerator
    {
        internal static DashboardMessage CreateDashboardMessage(string titkle, string text, string author)
        {
            return new DashboardMessage()
            {
                Author = author,
                Title = titkle,
                Text = text,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow
            };
        }
    }
}
