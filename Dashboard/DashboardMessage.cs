using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    class DashboardMessage
    {
        internal struct DashboardMessageStruct
        {
            public string Title;
            public string Author;
            public DateTime Created;
            public DateTime Edited;
            public string Text;
        }

        internal static DashboardMessageStruct CreateDashboardMessage(string titkle, string text, string author)
        {
            return new DashboardMessageStruct()
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
