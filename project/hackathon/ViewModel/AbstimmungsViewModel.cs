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
		private Abstimmung _abstimmung;

		private List<AbstimmungsStats> _stats = new List<AbstimmungsStats>();

		public AbstimmungsViewModel()
		{
			this._abstimmung = new Abstimmung(AbstimmungTyp.Initiativ, "test", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			this._abstimmung.KantonJaStimmen = new Dictionary<Kanton, double>();
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Bern","BE"), 30);
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 34);
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 65.3);

			this.CaclStats();
			Statistics = new CollectionView(this._stats);
		}

		public ICollectionView Statistics;

		private void CaclStats()
		{
			AbstimmungsStats stat = new AbstimmungsStats();
			stat.AnzahlJa = this._abstimmung.KantonJaStimmen.Sum(p => p.Value);
			stat.AnzahlNein = 100 - stat.AnzahlJa;
			this._stats.Add(stat);
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
