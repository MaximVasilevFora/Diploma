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
using WorkingLibrary;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class Money : System.Windows.Controls.Page
	{
		private List<WorkingLibrary.Models.Sale> _sales;
		private List<WorkingLibrary.Models.Deal> _deals;
		private List<WorkingLibrary.Models.Good> _goods;

		private DataWorking _dataWorking = new DataWorking();
		private int _goodRevenue = 0;
		private int _orderRevenue = 0;
		private int _goodProfit = 0;
		private int _imagineCost = 0;
		private bool _flag = false;

		public Money()
		{
			InitializeComponent();

			InitWindow();
		}

		public void InitWindow()
		{
			_sales = _dataWorking.GetSales(WorkingLibrary.SqlScripts.SelectSripts.SelectSales()).ToList();
			_deals = _dataWorking.GetDeals(WorkingLibrary.SqlScripts.SelectSripts.SelectDeals()).ToList();
			_goods = _dataWorking.GetGoods(WorkingLibrary.SqlScripts.SelectSripts.SelectGoods()).ToList();
		}

		private void Update_Click(object sender, RoutedEventArgs e)
		{
			if (BeginDate.SelectedDate == null)
			{
				MessageBox.Show("Выберите значение в поле Начало периода");
				return;
			}

			if (EndDate.SelectedDate == null || EndDate.SelectedDate > DateTime.Now)
			{
				EndDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
			}

			if (BeginDate.SelectedDate > EndDate.SelectedDate)
			{
				MessageBox.Show("Начало периода не может быть больше Конца периода");
				return;
			}

			_goodRevenue = 0;
			_orderRevenue = 0;
			_goodProfit = 0;
			_imagineCost = 0;

			foreach (var item in _sales)
			{
				if (item.Date >= BeginDate.SelectedDate && item.Date <= EndDate.SelectedDate)
				{
					_goodRevenue += item.Price;
					_goodProfit += item.Quantity * _goods.Where(x => x.Id == item.IdGood).Last().SalePrice;
				}
			}

			_imagineCost = _goodProfit;
			_goodProfit = _goodRevenue - _goodProfit;

			foreach (var item in _deals.Where(x => x.IdStatus == 4))
			{
				if (item.ProvisionDate != null && item.ProvisionDate >= BeginDate.SelectedDate && item.ProvisionDate <= EndDate.SelectedDate)
				{
					_orderRevenue += item.Cost;
				}
			}

			GoodRevenue.Text = _goodRevenue.ToString();
			OrderRevenue.Text = _orderRevenue.ToString();
			GoodProfit.Text = _goodProfit.ToString();
			ImagineCost.Text = _imagineCost.ToString();
			_flag = true;
		}

		private void Export_Click(object sender, RoutedEventArgs e)
		{
			if (!_flag)
			{
				MessageBox.Show("Обновите таблицу для занесения данных");
				return;
			}

			var app = new Microsoft.Office.Interop.Word.Application();
			var document = app.Documents.Add();

			var tableParagraph = document.Paragraphs.Add();
			var tableRange = tableParagraph.Range;

			var clubTable = document.Tables.Add(tableRange, 5, 2);

			clubTable.Borders.InsideLineStyle =
				clubTable.Borders.InsideLineStyle =
				WdLineStyle.wdLineStyleSingle;

			clubTable.Borders.OutsideLineStyle =
				clubTable.Borders.OutsideLineStyle =
				WdLineStyle.wdLineStyleSingle;

			clubTable.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

			var cellRange = clubTable.Cell(1, 1).Range;
			cellRange.Text = "Статья";
			cellRange.Font.Bold = 2;

			cellRange = clubTable.Cell(1, 2).Range;
			cellRange.Text = "Прибыль/Убыток";
			cellRange.Bold = 2;

			clubTable.Rows[1].Range.Bold = 1;
			clubTable.Rows[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(2, 1).Range;
			cellRange.Text = "Выручка с товаров";
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(3, 1).Range;
			cellRange.Text = "Выручка с заявок";
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(4, 1).Range;
			cellRange.Text = "Чистая прибыль с товаров";
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(5, 1).Range;
			cellRange.Text = "Себе стоимость товаров";
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(2, 2).Range;
			cellRange.Text = _goodRevenue.ToString();
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(3, 2).Range;
			cellRange.Text = _orderRevenue.ToString();
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(4, 2).Range;
			cellRange.Text = _goodProfit.ToString();
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			cellRange = clubTable.Cell(5, 2).Range;
			cellRange.Text = _imagineCost.ToString();
			cellRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

			app.Visible = true;
			document.SaveAs2(@"D:\outputFileWord.docx");
			document.SaveAs2(@"D:\outputFileWord.pdf", WdExportFormat.wdExportFormatPDF);
		}
	}
}
