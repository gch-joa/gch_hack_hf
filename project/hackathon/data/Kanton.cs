using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackathon.data
{
    public class Kanton : IEquatable<Kanton>, IComparable<Kanton>
    {
        public Kanton(string name)
        {
            Name = name;
        }

        public string Name { get; set; }


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
