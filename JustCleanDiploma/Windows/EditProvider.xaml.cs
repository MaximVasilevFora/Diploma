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
using WorkingLibrary;

namespace JustCleanDiploma.Windows
{
	public partial class EditProvider : Window
	{
		private const string _Name = "Имя";
		private const string _Phone = "Телефон";
		private const string _Mail = "Почта";
		private const string _Description = "Описание";

		public Pages.AdminPages.Providers providers;

		private WorkingLibrary.Models.Provider _provider;

		public EditProvider(object sender)
		{
			InitializeComponent();

			_provider = (sender as Button).DataContext as WorkingLibrary.Models.Provider;
			InitWindow();
		}

		private void InitWindow()
		{
			ProviderName.Text = _provider.Name;
			Phone.Text = _provider.Phone;

			if (_provider.Mail != null)
			{
				Mail.Text = _provider.Mail;
			}

			if (_provider.Description != null)
			{
				Description.Text = _provider.Description;
			}
		}

		private void ProviderName_GotFocus(object sender, RoutedEventArgs e)
		{
			ProviderName.Text = ProviderName.Text == _Name ? "" : ProviderName.Text;
		}

		private void ProviderName_LostFocus(object sender, RoutedEventArgs e)
		{
			ProviderName.Text = ProviderName.Text == String.Empty ? _Name : ProviderName.Text;
		}

		private void Phone_GotFocus(object sender, RoutedEventArgs e)
		{
			Phone.Text = Phone.Text == _Phone ? "" : Phone.Text;
		}

		private void Phone_LostFocus(object sender, RoutedEventArgs e)
		{
			Phone.Text = Phone.Text == String.Empty ? _Phone : Phone.Text;
		}

		private void Mail_GotFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == _Mail ? "" : Mail.Text;
		}

		private void Mail_LostFocus(object sender, RoutedEventArgs e)
		{
			Mail.Text = Mail.Text == String.Empty ? _Mail : Mail.Text;
		}

		private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			providers.editProvider = null;
			providers.InitPage();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (ProviderName.Text == _Name)
			{
				MessageBox.Show("Введите значение в поле Имя");
				return;
			}

			if (Phone.Text == _Phone)
			{
				MessageBox.Show("Введите значение в поле Телефон");
				return;
			}

			if (!WorkingLibrary.MailWorking.CheckMail(Mail.Text))
			{
				System.Windows.MessageBox.Show("Введите корректный почтовый адрес");
				return;
			}

			if (WorkingLibrary.SqlScripts.UpdateScripts.UpdateProvider(ProviderName.Text, Phone.Text, Mail.Text, Description.Text, _provider.Id))
			{
				MessageBox.Show("Сведения о поставщике были успешно изменены");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[15], CurrentUser.user.Id, CurrentUser.user.IdOffice);
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

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить сведения о поставщике?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteProvider(_provider.Id))
			{
				System.Windows.MessageBox.Show("Сведения о поставщике были успешно удалены");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[16], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
