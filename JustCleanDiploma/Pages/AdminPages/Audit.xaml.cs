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

namespace JustCleanDiploma.Pages.AdminPages
{
	public partial class Audit : Page
	{
		private List<WorkingLibrary.Models.Audit> _audit;
		private DataWorking _dataWorking = new DataWorking();

		public Audit()
		{
			InitializeComponent();

			InitWindow();
		}

		private void InitWindow()
		{
			_audit = _dataWorking.GetAudit(WorkingLibrary.SqlScripts.SelectSripts.SelectAudit()).ToList();
			_audit = _audit.Where(x => x.IdOffice == CurrentUser.user.IdOffice).ToList();
			_audit.Reverse();
			_audit.RemoveRange(25, _audit.Count - 25);
			AuditGrid.ItemsSource = _audit;
		}
	}
}
