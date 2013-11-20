using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackathon.data
{
    public class Kanton : IEquatable<Kanton>, IComparable<Kanton>
    {
        public Kanton(string name, string kuerzel)
        {
            Name = name;
            Kuerzel = kuerzel;
        }

        public string Name { get; set; }

        public string Kuerzel { get; set; }

        public string WappenUrl { get { return string.Format("data/wappen/{0}.png", Kuerzel.ToLowerInvariant()); } }

        public bool Equals(Kanton other)
        {
            return other.Name.Equals(Name);
        }

        public int CompareTo(Kanton other)
        {
            return String.Compare(other.Name, Name, StringComparison.Ordinal);
        }
    }
}
