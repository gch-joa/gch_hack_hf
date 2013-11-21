using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using hackathon.Annotations;
using hackathon.data;

namespace hackathon.ViewModel
{
    internal class AbstimmungsViewModel : INotifyPropertyChanged
    {
        private readonly List<AbstimmungsStats> _stats = new List<AbstimmungsStats>();
        private IList<Abstimmung> _abstimmungen = new List<Abstimmung>();

        private Kanton _aktivKanton;

        public AbstimmungsViewModel()
        {
            var test01 = new Abstimmung(AbstimmungTyp.Initiativ, "test01", 1, DateTime.Now, 1000, 800, 100, 50, 500);
            test01.KantonJaStimmen = new Dictionary<Kanton, double>();
            test01.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 4);
            test01.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 16);
            test01.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 15.3);
            _abstimmungen.Add(test01);

            var test02 = new Abstimmung(AbstimmungTyp.Initiativ, "test02", 1, DateTime.Now, 1000, 800, 100, 50, 500);
            test02.KantonJaStimmen = new Dictionary<Kanton, double>();
            test02.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 45);
            test02.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 87);
            test02.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 34);
            _abstimmungen.Add(test02);

            var test03 = new Abstimmung(AbstimmungTyp.Initiativ, "test02", 1, DateTime.Now, 1000, 800, 100, 50, 500);
            test03.KantonJaStimmen = new Dictionary<Kanton, double>();
            test03.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 100);
            test03.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 87);
            test03.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 100);
            _abstimmungen.Add(test03);

            _aktivKanton = new Kanton("Bern", "BE");

            CaclStats();
            Statistics = new CollectionView(_stats);
        }

        public object Kantone { get; set; }

        public Kanton AktivKanton
        {
            get { return _aktivKanton; }
            set
            {
                _aktivKanton = value;
                CaclStats();
                OnPropertyChanged();
            }
        }

        public ICollectionView Statistics { get; private set; }

        public IList<Abstimmung> Abstimmungen
        {
            get { throw new NotImplementedException(); }
            set { _abstimmungen = value; }
        }

        public int AktiveJahr { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CaclStats()
        {
            if (_aktivKanton == null) return;

            _stats.Clear();
            foreach (Abstimmung ab in _abstimmungen.Where(i => i.KantonJaStimmen.Count > 0))
            {
                var stat = new AbstimmungsStats();
                stat.AnzahlJa = ab.KantonJaStimmen.Where(i => i.Key.Equals(_aktivKanton)).Average(p => p.Value);
                stat.AnzahlNein = 100 - stat.AnzahlJa;
                stat.UseLargeArc = stat.AnzahlJa > 50 ? true : false;
                stat.Name = ab.Beschreibung;
                _stats.Add(stat);
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}