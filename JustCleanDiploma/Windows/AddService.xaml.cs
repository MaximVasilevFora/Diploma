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
	public partial class AddService : Window
	{
		private const string _ServiceName = "Наименование";
		private const string _Price = "Цена";
		private const string _FilePath = "Не выбран";
		private const string _Description = "Описание";

		public Pages.AdminPages.Services services;

		private byte[] _goodImageOfByte = null;
		private System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();
		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();
		private List<WorkingLibrary.Models.Office> _office;

		public AddService()
		{
			InitializeComponent();

			_openFileDialog.Filter = "Png files(*.png)|*.png|Jpg files(*.jpg)|*.jpg|Jpeg files(*.jpeg)|*.jpeg";

			_office = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			InitWindow();
		}

		private void InitWindow()
		{
			Office.ItemsSource = _office;

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.SelectedItem = _office.Where(x => x.Id == CurrentUser.user.IdOffice).Last();
				Office.IsEnabled = false;
			}
			else
			{
				Office.SelectedIndex = -1;
			}

			ServiceName.Text = _ServiceName;
			Price.Text = _Price;
			Description.Text = _Description;

			EmptyImage();
		}

		private void EmptyImage()
		{
			FilePath.Text = _FilePath;
			_goodImageOfByte = null;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			services.addService = null;
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
			var mySqlCommand = new MySqlCommand("INSERT INTO `service` " +
				"(`name`, `price`, `image`, `description`, `id_office`) " +
				"VALUES (@name, @price, @image, @description, @id_office)", dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = ServiceName.Text;
			mySqlCommand.Parameters.Add("@price", MySqlDbType.Int32).Value = Convert.ToInt32(Price.Text);
			mySqlCommand.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = _goodImageOfByte == null ? null : _goodImageOfByte;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == _Description ? null : Description.Text;

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			dataBase.OpenConnection();

			try
			{
				if (mySqlCommand.ExecuteNonQuery() == 1)
				{
					System.Windows.MessageBox.Show("Услуга была успешно добавлена");
				}
				else
				{
					System.Windows.MessageBox.Show("Ошибка добавления услуги");
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

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[6], CurrentUser.user.Id, CurrentUser.user.IdOffice);

			services.RefreshGoodList();

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
	}
}
