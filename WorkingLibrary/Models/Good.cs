using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WorkingLibrary;

namespace WorkingLibrary.Models
{
	public class Good
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int PurchasePrice { get; set; }
		public int SalePrice { get; set; }
		public byte[] Image { get; set; }
		public string Description { get; set; }
		public int? IdProvider { get; set; }
		public int IdOffice { get; set; }
		public BitmapImage ImageFromByteArray
		{
			get
			{
				return new DataWorking().GetBitmapImage(Image);
			}
		}
		public string GetPurchasePrice
		{
			get
			{
				return "Опт: " + PurchasePrice.ToString() + "Р";
			}
		}

		public string GetSalePrice
		{
			get
			{
				return "Роз: " + SalePrice.ToString() + "Р";
			}
		}
	}
}
