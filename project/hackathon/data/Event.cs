using System;

namespace hackathon.data
{
    public class Event
    {
        public Event(DateTime datum, string name, string description)
        {
            Datum = datum;
            Name = name;
            Description = description;
        }

        public DateTime Datum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}