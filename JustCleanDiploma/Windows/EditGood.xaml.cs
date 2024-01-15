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
	public partial class EditGood : Window
	{
		private const string _Description = "Описание";
		private const string _GoodName = "Наименование";
		private const string _PurchasePrice = "Цена закупочная";
		private const string _SalePrice = "Цена розничная";
		private const string _FilePath = "Не выбран";
		private const string _FilePathReady = "Выбран";

		private WorkingLibrary.DataWorking _dataWorking = new WorkingLibrary.DataWorking();

		private byte[] _goodImageOfByte = null;

		private System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();

		public Pages.AdminPages.Goods goodsPage;

		private WorkingLibrary.Models.Good _good;
		private List<WorkingLibrary.Models.Office> _offices;
		private List<WorkingLibrary.Models.Provider> _providers;

		public EditGood(object sender)
		{
			InitializeComponent();

			_offices = _dataWorking.GetOffices(WorkingLibrary.SqlScripts.SelectSripts.SelectOffices()).ToList();
			_providers = _dataWorking.GetProviders(WorkingLibrary.SqlScripts.SelectSripts.SelectProviders()).ToList();

			_good = (sender as Grid).DataContext as WorkingLibrary.Models.Good;

			InitWindow();
		}

		public void InitWindow()
		{
			Office.ItemsSource = _offices;
			Provider.ItemsSource = _providers;
			Office.SelectedItem = _offices.Where(x => x.Id == _good.IdOffice).Last();

			if (CurrentUser.user.IdUserRole != 1)
			{
				Office.IsEnabled = false;
			}
			
			if (_good.IdProvider != null)
			{
				Provider.SelectedValue = _providers.Where(x => x.Id == _good.IdProvider).Last();
			}

			GoodName.Text = _good.Name;
			PurchasePrice.Text = Convert.ToString(_good.PurchasePrice);
			SalePrice.Text = Convert.ToString(_good.SalePrice);
			Description.Text = _good.Description;

			if (_good.Image != null)
			{
				_goodImageOfByte = _good.Image;
				FilePath.Text = _FilePathReady;
			}
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(GoodName.Text) || GoodName.Text == _GoodName)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Наименование");
				return;
			}

			if (String.IsNullOrEmpty(PurchasePrice.Text) || PurchasePrice.Text == _PurchasePrice)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Цена закупочная");
				return;
			}

			if (String.IsNullOrEmpty(SalePrice.Text) || SalePrice.Text == _SalePrice)
			{
				System.Windows.MessageBox.Show("Введите значение в поле Цена розничная");
				return;
			}

			if (Office.SelectedValue == null)
			{
				System.Windows.MessageBox.Show("Выберите значение в поле Офис");
				return;
			}

			var dataBase = new WorkingLibrary.JustCleanDataBase();
			var mySqlCommand = new MySqlCommand("UPDATE `good` " +
				"SET `name` = @name, " +
				"`purchase_price` = @purchase_price, " +
				"`sale_price` = @sale_price, " +
				"`image` = @image, " +
				"`description` = @description, " +
				"`id_provider` = @id_provider, " +
				"`id_office` = @id_office " +
				"WHERE `id` = @id",
				dataBase.GetConnection());

			mySqlCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = _good.Id;
			mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = GoodName.Text;
			mySqlCommand.Parameters.Add("@purchase_price", MySqlDbType.Int32).Value = Convert.ToUInt32(PurchasePrice.Text);
			mySqlCommand.Parameters.Add("@sale_price", MySqlDbType.Int32).Value = Convert.ToUInt32(SalePrice.Text);

			mySqlCommand.Parameters.Add("@image", MySqlDbType.MediumBlob).Value = _goodImageOfByte == null ? null : _goodImageOfByte;
			mySqlCommand.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description.Text == null ? null : Description.Text;

			if (Provider.SelectedItem == null)
			{
				mySqlCommand.Parameters.Add("@id_provider", MySqlDbType.Int32).Value = null;
			}
			else
			{
				WorkingLibrary.Models.Provider provider = (WorkingLibrary.Models.Provider)Provider.SelectedValue;
				mySqlCommand.Parameters.Add("@id_provider", MySqlDbType.Int32).Value = provider.Id;
			}

			WorkingLibrary.Models.Office office = (WorkingLibrary.Models.Office)Office.SelectedValue;
			mySqlCommand.Parameters.Add("@id_office", MySqlDbType.Int32).Value = office.Id;

			dataBase.OpenConnection();

			if (mySqlCommand.ExecuteNonQuery() == 1)
			{
				System.Windows.MessageBox.Show("Данные были изменены");
			}
			else
			{
				System.Windows.MessageBox.Show("Ошибка изменения данных");
				return;
			}

			dataBase.CloseConnection();

			WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[11], CurrentUser.user.Id, CurrentUser.user.IdOffice);

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
			FilePath.Text = _FilePath;
			_goodImageOfByte = null;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			goodsPage.editGood = null;
			goodsPage.RefreshGoodList();
		}

		private bool SimbolIsDigit(TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				return true;
			}

			return false;
		}

		private void PurchasePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void SalePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = SimbolIsDigit(e);
		}

		private void GoodName_GotFocus(object sender, RoutedEventArgs e)
		{
			GoodName.Text = GoodName.Text == _GoodName ? "" : GoodName.Text;
		}

		private void GoodName_LostFocus(object sender, RoutedEventArgs e)
		{
			GoodName.Text = GoodName.Text == String.Empty ? _GoodName : GoodName.Text;
		}

		private void PurchasePrice_GotFocus(object sender, RoutedEventArgs e)
		{
			PurchasePrice.Text = PurchasePrice.Text == _PurchasePrice ? "" : PurchasePrice.Text;
		}

		private void PurchasePrice_LostFocus(object sender, RoutedEventArgs e)
		{
			PurchasePrice.Text = PurchasePrice.Text == String.Empty ? _PurchasePrice : PurchasePrice.Text;
		}

		private void SalePrice_GotFocus(object sender, RoutedEventArgs e)
		{
			SalePrice.Text = SalePrice.Text == _SalePrice ? "" : SalePrice.Text;
		}

		private void SalePrice_LostFocus(object sender, RoutedEventArgs e)
		{
			SalePrice.Text = SalePrice.Text == String.Empty ? _SalePrice : SalePrice.Text;
		}

		private void Description_GotFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == _Description ? "" : Description.Text;
		}

		private void Description_LostFocus(object sender, RoutedEventArgs e)
		{
			Description.Text = Description.Text == String.Empty ? _Description : Description.Text;
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var result = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить товар?",
				"Confirmation",
				MessageBoxButton.YesNo,
				MessageBoxImage.Question);

			if (result == MessageBoxResult.No)
			{
				return;
			}

			if (WorkingLibrary.SqlScripts.DeleteScripts.DeleteGood(_good.Id))
			{
				System.Windows.MessageBox.Show("Товар был успешно удален");

				WorkingLibrary.SqlScripts.InsertScripts.InsertActionToAudit(DateTime.Now, DataWorking.EventType[12], CurrentUser.user.Id, CurrentUser.user.IdOffice);

				this.Close();
			}
		}
	}
}
