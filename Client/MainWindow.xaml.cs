using Client.Communications;
using Client.Models.Entities;
using Common;
using Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		#region Domains
		private ObservableCollection<Domain> _domains;

		public ObservableCollection<Domain> Domains
		{
			get { return _domains; }
			set
			{
				if (_domains != value)
				{
					_domains = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Domains)));
				}
			}
		}
		#endregion Domains

		#region Domain
		private Domain _domain;

		public Domain Domain
		{
			get { return _domain; }
			set
			{
				if (_domain != value)
				{
					_domain = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Domain)));
				}
			}
		}
		#endregion Domain

		#region Error
		private string _error = "";
		public string Error
		{
			get { return _error; }
			set
			{
				if (_error != value)
				{
					_error = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
				}
			}
		}
		#endregion Domain

		private CommunicationManager _com = new CommunicationManager();

		public event PropertyChangedEventHandler PropertyChanged;

		public string DomainInput { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			_com.ServerResponseReceived += OnResponseReceived;
			InitData();
		}

		private void OnResponseReceived(object sender, PropertyChangedEventArgs e)
		{
			//Debug.WriteLine((sender as CommunicationManager).ServerResponse.ToString());
		}

		public void InitData()
		{
			var communication = new Communication { Type = EType.READ, Target = ETarget.DOMAIN, Success = true };
			var response = _com.Communicate(communication);
			Domains = JsonConvert.DeserializeObject<ObservableCollection<Domain>>(response.Content.ToString());
		}

		private void Test_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine(DomainInput);
			if (DomainInput != null)
			{
				Error = "";
				var communication = new Communication
				{
					Origin = "client",
					Type = EType.CREATE,
					Target = ETarget.DOMAIN,
					Content = DomainInput,
					Success = true
				};
				var response = _com.Communicate(communication);
				Domains = JsonConvert.DeserializeObject<ObservableCollection<Domain>>(response.Content.ToString());

				Debug.WriteLine(response.ToString());
			}
			else
			{
				Error = "Veuillez remplir le champ";
			}
		}
	}
}
