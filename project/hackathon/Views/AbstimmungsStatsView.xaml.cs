using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using hackathon.ViewModel;
using hackathon.data;

namespace hackathon.Views
{
    /// <summary>
    ///     Interaction logic for AbstimmungsStatsView.xaml
    /// </summary>
    public partial class AbstimmungsStatsView : UserControl
    {
        public static readonly DependencyProperty AktivKantoneProperty =
            DependencyProperty.Register("AktivKantone", typeof (Kanton), typeof (AbstimmungsStatsView),
                                        new PropertyMetadata(null));

        public AbstimmungsStatsView()
        {
            InitializeComponent();
            DataContext = new AbstimmungsViewModel();
        }


		public int AktivJahr
		{
			get
			{
				return ((AbstimmungsViewModel)DataContext).AktiveJahr;
			}
			set
			{
				((AbstimmungsViewModel)DataContext).AktiveJahr = value;
			}
		}

        public Kanton AktivKantone
        {
            get { return (Kanton) GetValue(AktivKantoneProperty); }
            set
            {
                SetValue(AktivKantoneProperty, value);
                ((AbstimmungsViewModel) DataContext).AktivKanton = value;
            }
        }

        public IList<Abstimmung> Abstimmungen
        {
            get { return ((AbstimmungsViewModel) DataContext).Abstimmungen; }
            set { ((AbstimmungsViewModel) DataContext).Abstimmungen = value; }
        }
    }
}
