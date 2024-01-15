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
	public partial class EditOffice : Window
	{
		private const string _OfficeName = "Наименование";
		private const string _Region = "Регион";
		private const string _City = "Город";
		private const string _Street = "Улица";
		private const string _House = "Дом";
		private const string _Description = "Описание";

		private int? _nullInt = null;
		private WorkingLibrary.Models.Office _office;

		public Pages.AdminPages.Offices Offices;

		public EditOffice(object sender)
		{
			InitializeComponent();

			_office = (sender as Button).DataContext as WorkingLibrary.Models.Office;

			InitWindow();
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

			if (WorkingLibrary.SqlScripts.UpdateScripts.UpdateOffice(OfficeName.Text, Region.Text, City.Text, Street.Text, house, Description.Text, _office.Id))
			{
				MessageBox.Show("Офис успешно отредактирован");
			}

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
			OfficeName.Text = _office.Name;

			if (_office.Region != null)
			{
				Region.Text = _office.Region;
			}
			
			City.Text = _City;

			if (_office.Street != null)
			{
				Street.Text = _office.Street;
			}

			if (_office.House != null)
			{
				House.Text = Convert.ToString(_office.House);
			}

			if (_office.Description != null)
			{
				Description.Text = _office.Description;
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Offices.editOffice = null;
			Offices.InitPage();
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить офис?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteOffice(_office.Id))
			{
				System.Windows.MessageBox.Show("Офис был успешно удален");
				this.Close();
			}
		}
	}
}
