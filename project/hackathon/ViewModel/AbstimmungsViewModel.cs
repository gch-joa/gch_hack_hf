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

		public AbstimmungsViewModel()
		{
			var test01 = new Abstimmung(AbstimmungTyp.Initiativ, "test01", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			test01.KantonJaStimmen = new Dictionary<Kanton, double>();
			test01.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 30);
			test01.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 34);
			test01.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 65.3);
			this._abstimmung.Add(test01);

			var test02= new Abstimmung(AbstimmungTyp.Initiativ, "test02", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			test02.KantonJaStimmen = new Dictionary<Kanton, double>();
			test02.KantonJaStimmen.Add(new Kanton("Bern", "BE"), 45);
			test02.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 87);
			test02.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 34);
			this._abstimmung.Add(test02);

			this.CaclStats();
			Statistics = new CollectionView(this._stats);
		}

		public ICollectionView Statistics { get; private set; }

		private void CaclStats()
		{
			foreach (var ab in this._abstimmung)
			{
				AbstimmungsStats stat = new AbstimmungsStats();
				stat.AnzahlJa = ab.KantonJaStimmen.Average(p => p.Value);
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

	public class AbstimmungsStats
	{
		private double _anzahlNein;

		private double _anzahlJa;

		public double AnzahlNein
		{
			get
			{
				return this._anzahlNein;
			}
			set
			{
				this._anzahlNein = value;
			}
		}

		public double AnzahlJa
		{
			get
			{
				return this._anzahlJa;
			}
			set
			{
				this._anzahlJa = value;
			}
		}
	}
}
