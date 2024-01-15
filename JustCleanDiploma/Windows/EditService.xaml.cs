using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
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
	public partial class EditService : Window
	{
		private const string _ServiceName = "Наименование";
		private const string _Price = "Цена";
		private const string _FilePath = "Не выбран";
		private const string _FilePathReady = "Выбран";
		private const string _Description = "Описание";

		public Pages.AdminPages.Services services;

		private byte[] _goodImageOfByte = null;
		private System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();
		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private WorkingLibrary.Models.Service _service;
		private List<WorkingLibrary.Models.Office> _offices;

		public EditService(object sender)
		{
			InitializeComponent();

			_openFileDialog.Filter = "Png files(*.png)|*.png|Jpg files(*.jpg)|*.jpg|Jpeg files(*.jpeg)|*.jpeg";

			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			Office.ItemsSource = _offices;

			_service = (sender as Grid).DataContext as WorkingLibrary.Models.Service;
			InitWindow();
		}

		private void InitWindow()
		{
			Office.SelectedItem = _offices.Where(x => x.Id == _service.IdOffice).Last();

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.IsEnabled = false;
			}

			ServiceName.Text = _service.Name;
			Price.Text = _service.Price.ToString();

			if (_service.Description != null)
			{
				Description.Text = _service.Description;
			}

			if (_service.Image != null)
			{
				FilePath.Text = _FilePathReady;
				_goodImageOfByte = _service.Image;
			}
		}

		private void EmptyImage()
		{
			FilePath.Text = _FilePath;
			_goodImageOfByte = null;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			services.editService = null;
			services.RefreshGoodList();
		}

		private void ServiceName_GotFocus(object sender, RoutedEventArgs e)
		{
			ServiceName.Text = ServiceName.Text == _ServiceName ? "" : ServiceName.Text;
		}

		private void ServiceName_LostFocus(object sender, RoutedEventArgs e)
		{
			ServiceName.Text = ServiceName.Text == String.Empty ? _ServiceName : ServiceName.Text;
		}

		private void Price_GotFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Price.Text == _Price ? "" : Price.Text;
		}

		private void Price_LostFocus(object sender, RoutedEventArgs e)
		{
			Price.Text = Price.Text == String.Empty ? _Price : Price.Text;
		}

		private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void GetImage_Click(object sender, RoutedEventArgs e)
		{
			if (_openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var image = new Bitmap(_openFileDialog.FileName);

				FilePath.Text = _openFileDialog.FileName;

				_goodImageOfByte = _dataWorking.ImageToByte(image);
			}
		}

		private void CancelImage_Click(object sender, RoutedEventArgs e)
		{
			EmptyImage();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (Office.SelectedItem == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			if (ServiceName.Text == _ServiceName)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Наименование услуги");
				return;
			}

			if (Price.Text == _Price)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Цену");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `service` " +
				"SET `name` = @name, " +
				"`price` = @price, " +
				"`image` = @image, " +
				"`description` = @description, " +
				"`id_office` = @id_office " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = ServiceName.Text;
			mySqlCommand.Parameters.Add("@price", MySqlDbType.Int32).Value = Convert.ToInt32(Price.Text);
			mySqlCommand.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = _goodImageOfByte == null ? null : _goodImageOfByte;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _service.Id;

			dataBase.OpenConnection();

			try
			{
				if (mySqlCommand.ExecuteNonQuery() == 1)
				{
					System.Windows.MessageBox.Show("Сведения услуги были успешно изменены");
				}
				else
				{
					System.Windows.MessageBox.Show("Ошибка изменениия сведений услуги");
					return;
				}
			}
			catch
			{
				MessageBox.Show("Изображение услуги с данным форматом имеет слишком большой вес, выберите другое изображние.");
				dataBase.CloseConnection();
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[19], CurrentUser.user.Id, CurrentUser.user.IdOffice);

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

		private bool SimbolIsDigit(TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				return true;
			}

			return false;
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить услугу?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteService(_service.Id))
			{
				System.Windows.MessageBox.Show("Услуга была успешно удалена");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[20], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
