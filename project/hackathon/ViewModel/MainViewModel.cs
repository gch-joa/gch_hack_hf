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
    internal class MainViewModel : INotifyPropertyChanged
    {
        private IList<Abstimmung> _abstimmungen;
        private int _aktivYear;
        private ICollectionView _cantons;

        private int _maxYear;
        private int _minYear;

        public MainViewModel()
        {
            var loader = new Loader();
            _abstimmungen = loader.Load();

            IEnumerable<Abstimmung> subList = _abstimmungen.Where(i => i.KantonJaStimmen.Count > 0);
            MaxYear = Convert.ToInt16(subList.Max(p => p.Datum).ToString("yyyy"));
            MinYear = Convert.ToInt16(subList.Min(p => p.Datum).ToString("yyyy"));
            Jahre = subList.Select(p => p.Datum.ToString("yyyy")).Distinct().ToList();

            _cantons = new ListCollectionView(loader.GetKantone().ToList());
            _cantons.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            _aktivYear = MaxYear;
        }

        public IList<string> Jahre { get; set; }

        public IList<Abstimmung> Abstimmungen
        {
            get { return _abstimmungen; }
            set { _abstimmungen = value; }
        }

        public int AktivYear
        {
            get { return _aktivYear; }
            set
            {
                _aktivYear = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView Kantone
        {
            get { return _cantons; }
            set { _cantons = value; }
        }

        public int MaxYear
        {
            get { return _maxYear; }
            private set
            {
                _maxYear = value;
                OnPropertyChanged();
            }
        }

        public int MinYear
        {
            get { return _minYear; }
            private set
            {
                _minYear = value;
                OnPropertyChanged();
            }
        }

        #region property changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}