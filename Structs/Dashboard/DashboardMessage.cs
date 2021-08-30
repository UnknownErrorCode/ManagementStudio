using System;

namespace Structs.Dashboard
{
    public struct DashboardMessage
    {
        public string Title;
        public string Author;
        public DateTime Created;
        public string Text;

        public DashboardMessage(string title, string text, string author)
        {
            Title = title;
            Author = author;
            Text = text;
            Created = DateTime.UtcNow;
        }
    }
}
