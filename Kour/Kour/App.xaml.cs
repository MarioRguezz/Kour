using System;
using Xamarin.Forms;
using Kour;


namespace Kour
{
	public partial class App : Application
	{
		public static App CurrentApp
		{
			get;
			private set;
		}



		public Cliente User { get; set; }

		public App()
		{
			InitializeComponent();

			CurrentApp = this;
			InitServices();

			MainPage = new NavigationPage(new HomePage());

			//MainPage = new NavigationPage(new RootPage());
		}

		void InitServices()
		{

            			 
			//MainPage = new PerfilPage();

			User = Helpers.PropertiesManager.GetUserInfo();



			LocationHelper.Instance.Geolocator.PositionChanged += (sender, e) =>
			{
				System.Diagnostics.Debug.WriteLine("Position changed {0} {1}", e.Position.Latitude, e.Position.Longitude);
			};


		}



		async void Test()
		{
			//var res = await Services.ListaSelAll<ClientePagingModel>(Cliente.TABLE_NAME, 0, 1);

		}

		protected override void OnStart()
		{
			Test();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
