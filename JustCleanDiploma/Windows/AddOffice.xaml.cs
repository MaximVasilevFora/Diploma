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
using System.Windows.Shapes;

namespace JustCleanDiploma.Windows
{
	public partial class AddOffice : Window
	{
		private const string _OfficeName = "Наименование";
		private const string _Region = "Регион";
		private const string _City = "Город";
		private const string _Street = "Улица";
		private const string _House = "Дом";
		private const string _Description = "Описание";

		private int? _nullInt = null;

		public Pages.AdminPages.Offices Offices;

		public AddOffice()
		{
			InitializeComponent();
		}

		private void OfficeName_GotFocus(object sender, RoutedEventArgs e)
		{
			OfficeName.Text = OfficeName.Text == _OfficeName ? "" : OfficeName.Text;
		}

		private void OfficeName_LostFocus(object sender, RoutedEventArgs e)
		{
			OfficeName.Text = OfficeName.Text == String.Empty ? _OfficeName : OfficeName.Text;
		}

		private void Region_GotFocus(object sender, RoutedEventArgs e)
		{
			Region.Text = Region.Text == _Region ? "" : Region.Text;
		}

		private void Region_LostFocus(object sender, RoutedEventArgs e)
		{
			Region.Text = Region.Text == String.Empty ? _Region : Region.Text;
		}

		private void City_GotFocus(object sender, RoutedEventArgs e)
		{
			City.Text = City.Text == _City ? "" : City.Text;
		}

		private void City_LostFocus(object sender, RoutedEventArgs e)
		{
			City.Text = City.Text == String.Empty ? _City : City.Text;
		}

		private void Street_GotFocus(object sender, RoutedEventArgs e)
		{
			Street.Text = Street.Text == _Street ? "" : Street.Text;
		}

		private void Street_LostFocus(object sender, RoutedEventArgs e)
		{
			Street.Text = Street.Text == String.Empty ? _Street : Street.Text;
		}

		private void House_GotFocus(object sender, RoutedEventArgs e)
		{
			House.Text = House.Text == _House ? "" : House.Text;
		}

		private void House_LostFocus(object sender, RoutedEventArgs e)
		{
			House.Text = House.Text == String.Empty ? _House : House.Text;
		}

		private void House_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (OfficeName.Text == _OfficeName)
			{
				MessageBox.Show("Введите корректное Наименование офиса");
				return;
			}

			if (City.Text == _City)
			{
				MessageBox.Show("Введите корректное Наименование города");
				return;
			}

			int? house = House.Text == _House ? _nullInt : Convert.ToInt32(House.Text);

			if (WorkingLibrary.SqlScripts.InsertScripts.InsertOffice(OfficeName.Text, Region.Text, City.Text, Street.Text, house, Description.Text))
			{
				MessageBox.Show("Офис был успешно добавлен");
			}

			Offices.InitPage();

			this.Close();
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите отменить изменения?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			InitWindow();
		}

		private void InitWindow()
		{
			OfficeName.Text = _OfficeName;
			Region.Text = _Region;
			City.Text = _City;
			Street.Text = _Street;
			House.Text = _House;
			Description.Text = _Description;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Offices.addOffice = null;
		}
	}
}
