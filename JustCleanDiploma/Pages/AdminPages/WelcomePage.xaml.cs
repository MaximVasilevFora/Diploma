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

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class WelcomePage : Page
	{
		public static Windows.AdminWindow adminWindow;
		public static Windows.ContentWindow contentWindow;

		public WelcomePage()
		{
			InitializeComponent();
		}

		private void Enter_Click(object sender, RoutedEventArgs e)
		{
			if (adminWindow != null)
			{
				adminWindow.ChangePage("Pages/AdminPages/Services.xaml");
			}
			else
			{
				contentWindow.ChangePage("Pages/AdminPages/Services.xaml");
			}
		}

		private void Enter_MouseLeave(object sender, MouseEventArgs e)
		{
			Enter.Opacity = 1;
		}

		private void Enter_MouseEnter(object sender, MouseEventArgs e)
		{
			Enter.Opacity = 0.8;
		}
	}
}
