using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using hackathon.data;

namespace hackathon
{
    public class Loader
    {
        private readonly IList<Kanton> _kantone= new List<Kanton>();

        public IList<Abstimmung> Load()
        {
            var abstimmungen = parseCSV("data/abstimmungen.csv");
            var kantonwerte = parseCSV("data/jastimmen.csv");

            var abstimmunglist = new Dictionary<int, Abstimmung>();
            foreach (var line in abstimmungen)
            {
                try
                {
                    var abst = new Abstimmung(ConvertTyp(line[3]), line[2], int.Parse(line[0]), MakeDatum(line[1]),
                                              int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[7]),
                                              int.Parse(line[8]),
                                              int.Parse(line[9]));

                    abstimmunglist.Add(int.Parse(line[0]), abst);
                }
                catch
                {
                    // skip
                }
            }

            string[] nummern = new string[kantonwerte[0].Count()];
            foreach (var line in kantonwerte)
            {
                if (line[0].Equals("Kanton"))
                {
                    nummern = line;
                }
                else
                {
                    var currentKanton = new Kanton(line[0],line[1]);
                    if (!_kantone.Contains(currentKanton))
                    {
                        _kantone.Add(currentKanton);
                    }
                    for (int i = 2; i < nummern.Count(); i++)
                    {
                        var s = nummern[i];
                        try
                        {
                            abstimmunglist[int.Parse(s)].KantonJaStimmen.Add(currentKanton, double.Parse(line[i]));
                        }
                        catch
                        {
                            // ignore
                        }
                    }
                }
            }

            return abstimmunglist.Values.ToList();
        }

        public IList<Kanton> GetKantone()
        {
            return _kantone;
        }

        private DateTime MakeDatum(string s)
        {
            var tag = s.Substring(0, 2);
            var monat = s.Substring(3, 2);
            var jahr = s.Substring(6, 4);

            return new DateTime(int.Parse(jahr), int.Parse(monat), int.Parse(tag));
        }

        private AbstimmungTyp ConvertTyp(string type)
        {
            if(type.Equals("Fak.")) return AbstimmungTyp.Fakultativ;
            if(type.Equals("I.")) return AbstimmungTyp.Initiativ;
            if(type.Equals("Obl.")) return AbstimmungTyp.Obligatorisch;
            if(type.Equals("GE")) return AbstimmungTyp.Gegenentwurf;
            return AbstimmungTyp.Unknown;
        }

        private List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            try
            {
                using (StreamReader readFile = new StreamReader(path, true))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(';');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return parsedData;
        }

        
    }
}
