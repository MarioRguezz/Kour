using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kour
{
	public partial class ConductoresPage : ContentPage
	{
		public event EventHandler Closed;


		public ConductoresPage()
		{
			InitializeComponent();

			_listView.ItemsSource = new List<string>() { "" };
			_listView.ItemSelected += (sender, e) =>
			{
				CloseClicked(null, null);
			};

			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (Closed != null)
				Closed(this, null);
		}

		async void CloseClicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}


	}
}
