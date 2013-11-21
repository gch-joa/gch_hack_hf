using System.Collections.Generic;

namespace hackathon.data
{
    public class Jahr
    {
        public Jahr(string year)
        {
            Year = year;
        }

        public string Year { get; set; }

        public IList<Abstimmung> Abstimmungen { get; set; }
        public IList<Event> Events { get; set; }
    }
}