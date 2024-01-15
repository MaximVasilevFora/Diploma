using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WorkingLibrary.Models
{
	public class Service
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public byte[] Image { get; set; }
		public string Description { get; set; }
		public int IdOffice { get; set; }

		public BitmapImage ImageFromByteArray
		{
			get
			{
				return new DataWorking().GetBitmapImage(Image);
			}
		}

		public string GetPrice
		{
			get
			{
				return Price.ToString() + "Р";
			}
		}
	}
}
