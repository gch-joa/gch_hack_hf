﻿using System;
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

		private string _minYear;

		private string _maxYear;

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

		public string MaxYear
		{
			get
			{
				return this._maxYear;
			}
			set
			{
				this._maxYear = value;
				this.OnPropertyChanged()
			}
		}

		public string MinYear
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