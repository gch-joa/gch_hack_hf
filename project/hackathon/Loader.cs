using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hackathon.data;

namespace hackathon
{
    public class Loader
    {
        private string _filenameAbstimmungen;

        public Loader(string abstimmungen)
        {
            _filenameAbstimmungen = abstimmungen;
        }

        public IEnumerable<Jahr> Load()
        {
            IList<Kanton> kantone = new List<Kanton>
                {
                    new Kanton("Bern"),
                    new Kanton("Zürich"),
                    new Kanton("Basel Stadt"),
                    new Kanton("Basel Land"),
                    new Kanton("Genf"),
                    new Kanton("Waadt"),
                    new Kanton("Wallis"),
                    new Kanton("Fribourg"),
                    new Kanton("Neuchatel"),
                    new Kanton("Jura"),
                    new Kanton("Aarau"),
                    new Kanton("Solothurn"),
                    new Kanton("Thurgau"),
                    new Kanton("Schaffhausen"),
                    new Kanton("St. Gallen"),
                    new Kanton("Uri"),
                    new Kanton("Schwyz"),
                    new Kanton("Luzern")

                };
        }

        
    }
}
