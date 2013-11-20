using System;
using System.Collections.Generic;

namespace hackathon.data
{
    public class Abstimmung
    {
        public Abstimmung(AbstimmungTyp typ, string beschreibung, int nummer, DateTime datum, int stimmberechtigte,
                          int stimmen, int leerstimmen, int ungueltig, int jastimmen)
        {
            Typ = typ;
            Beschreibung = beschreibung;
            Datum = datum;
            Nummer = nummer;
            Stimmberechtigte = stimmberechtigte;
            Stimmen = stimmen;
            Leerstimmen = leerstimmen;
            Ungueltig = ungueltig;
            JaStimmen = jastimmen;
        }

        public AbstimmungTyp Typ { get; private set; }
        public string Beschreibung { get; private set; }
        public int Nummer { get; private set; }
        public DateTime Datum { get; private set; }
        public int Stimmberechtigte { get; private set; }
        public int Stimmen { get; private set; }

        public double Beteiligung
        {
            get { return Stimmberechtigte/100*Stimmen; }
        }

        public int Leerstimmen { get; private set; }
        public int Ungueltig { get; private set; }

        public int Gueltig
        {
            get { return Stimmen - Leerstimmen - Ungueltig; }
        }

        public int JaStimmen { get; private set; }

        public int NeinStimmen
        {
            get { return Gueltig - JaStimmen; }
        }

        public bool Angenommen
        {
            get { return JaStimmen > NeinStimmen; }
        }

        public IDictionary<Kanton, int> KantonJaStimmen { get; set; }
    }

    public enum AbstimmungTyp
    {
        Obligatorisch,
        Fakultativ,
        Initiativ,
        Gegenentwurf
    }
}