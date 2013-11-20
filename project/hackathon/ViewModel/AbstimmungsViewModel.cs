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
	class AbstimmungsViewModel : INotifyPropertyChanged
	{
		private IList<Abstimmung> _abstimmung = new List<Abstimmung>();

		private List<AbstimmungsStats> _stats = new List<AbstimmungsStats>();

		private Kanton _aktivKanton;

		public AbstimmungsViewModel()
		{
			var test01 = new Abstimmung(AbstimmungTyp.Initiativ, "test01", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			test01.KantonJaStimmen = new Dictionary<Kanton, double>();
			test01.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 4);
			test01.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 16);
			test01.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 15.3);
			this._abstimmung.Add(test01);

			var test02= new Abstimmung(AbstimmungTyp.Initiativ, "test02", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			test02.KantonJaStimmen = new Dictionary<Kanton, double>();
			test02.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 45);
			test02.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 87);
			test02.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 34);
			this._abstimmung.Add(test02);

			var test03 = new Abstimmung(AbstimmungTyp.Initiativ, "test02", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			test03.KantonJaStimmen = new Dictionary<Kanton, double>();
			test03.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 100);
			test03.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 87);
			test03.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 100);
			this._abstimmung.Add(test03);

			this._aktivKanton = new Kanton("Bern", "BE");
			this.CaclStats();
			Statistics = new CollectionView(this._stats);
		}

		public object Kantone { get; set; }
		public Kanton AktivKanton
		{
			get
			{
				return this._aktivKanton;
			}
			set
			{
				this._aktivKanton = value;
				this.CaclStats();
			}
		}

		public ICollectionView Statistics { get; private set; }

		private void CaclStats()
		{

			foreach (var ab in this._abstimmung)
			{
				AbstimmungsStats stat = new AbstimmungsStats();
				stat.AnzahlJa = ab.KantonJaStimmen.Where(i => i.Key.Equals(this._aktivKanton)).Average(p => p.Value);
				stat.AnzahlNein = 100 - stat.AnzahlJa;
				this._stats.Add(stat);
				
			}
		}

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
	}
}
