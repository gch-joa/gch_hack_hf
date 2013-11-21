using System;

namespace hackathon.data
{
    public class Kanton : IEquatable<Kanton>, IComparable<Kanton>
    {
        public Kanton(string name, string kuerzel)
        {
            Name = name.ToLower();
            Kuerzel = kuerzel;
        }

        public string Name { get; set; }

        public string Kuerzel { get; set; }

        public string WappenUrl
        {
            get { return string.Format("data/wappen/{0}.png", Kuerzel.ToLowerInvariant()); }
        }

        public int CompareTo(Kanton other)
        {
            return String.Compare(other.Name, Name, StringComparison.Ordinal);
        }

        public bool Equals(Kanton other)
        {
            return other.Name.Equals(Name);
        }
    }
}