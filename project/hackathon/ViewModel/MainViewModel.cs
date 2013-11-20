using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;

using hackathon.Annotations;
using hackathon.data;

namespace hackathon.ViewModel
{
	class MainViewModel : INotifyPropertyChanged
	{
		private ICollectionView _cantons;

		private int _minYear;

		private int _maxYear;

		public MainViewModel()
		{
			var loader = new Loader();
			IList<Abstimmung> abstimmung = loader.Load();

			var subList = abstimmung.Where(i => i.KantonJaStimmen.Count > 0);
			this.MaxYear = Convert.ToInt16(subList.Max(p => p.Datum).ToString("yyyy"));
			this.MinYear = Convert.ToInt16(subList.Min(p => p.Datum).ToString("yyyy"));

			_cantons = new ListCollectionView(loader.GetKantone().ToList());
			_cantons.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
		}

		public ICollectionView Kantone
		{
			get
			{
				return this._cantons;
			}
			set
			{
				this._cantons = value;
			}
		}

		public int MaxYear
		{
			get
			{
				return this._maxYear;
			}
			private set
			{
				this._maxYear = value;
				this.OnPropertyChanged();
			}
		}

		public int MinYear
		{
			get
			{
				return this._minYear;
			}
			private set
			{
				this._minYear = value;
				this.OnPropertyChanged();
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
