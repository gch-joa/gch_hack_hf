using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using hackathon.ViewModel;
using hackathon.data;

namespace hackathon.Views
{
	/// <summary>
	/// Interaction logic for AbstimmungsStatsView.xaml
	/// </summary>
	public partial class AbstimmungsStatsView : UserControl
	{
		public static readonly DependencyProperty AktivKantoneProperty =
			DependencyProperty.Register("AktivKantone", typeof(Kanton), typeof(AbstimmungsStatsView), new FrameworkPropertyMetadata(null));

		public AbstimmungsStatsView()
		{
			InitializeComponent();
			DataContext = new AbstimmungsViewModel();
		}

		public Kanton AktivKantone
		{
			get
			{
				return (Kanton)GetValue(AktivKantoneProperty);
			}
			set
			{
				SetValue(AktivKantoneProperty, value);
			}
		}

	}
}
