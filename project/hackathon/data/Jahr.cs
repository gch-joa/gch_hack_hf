using System;
using System.Collections.Generic;

namespace hackathon.data
{
    public class Jahr
    {
        public Jahr(DateTime year)
        {
            Year = year;
        }

        public DateTime Year { get; set; }

        public IList<Abstimmung> Abstimmungen { get; set; }
        public IList<Event> Events { get; set; } 
    }
}