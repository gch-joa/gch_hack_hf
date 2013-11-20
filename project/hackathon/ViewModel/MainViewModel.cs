using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using hackathon.Annotations;
using hackathon.data;

namespace hackathon.ViewModel
{
	class MainViewModel : INotifyPropertyChanged
	{
		private ICollectionView _cantons;

		public MainViewModel()
		{
			List<Kanton> c = new List<Kanton>
				{
					new Kanton("Bern"),
					new Kanton("Basel Land")
				};

			_cantons = new ListCollectionView(c);
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
