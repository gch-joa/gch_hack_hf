using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using hackathon.Annotations;
using hackathon.data;

namespace hackathon.ViewModel
{
	class AbstimmungsViewModel : INotifyPropertyChanged
	{
		private Abstimmung _abstimmung;

		private AbstimmungsStats _stats;

		public AbstimmungsStats Statistics
		{
			get
			{
				return this._stats;
			}
			private set
			{
				this._stats = value;
			}
		}

		public AbstimmungsViewModel()
		{
			this._abstimmung = new Abstimmung(AbstimmungTyp.Initiativ, "test", 1, DateTime.Now, 1000, 800, 100, 50, 500);
			this._abstimmung.KantonJaStimmen = new Dictionary<Kanton, double>();
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Bern","BE"), 30);
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Zürich", "ZH"), 34);
			this._abstimmung.KantonJaStimmen.Add(new Kanton("Aarau", "AG"), 65.3);

		}


		private void CaclStats()
		{
			AbstimmungsStats stats = new AbstimmungsStats();
			stats.AnzahlJa = this._abstimmung.KantonJaStimmen.Sum(p => p.Value);
			stats.AnzahlNein = 100 - stats.AnzahlJa;
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
