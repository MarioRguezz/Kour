using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kour
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
		}
		 
		async void LoginClicked(object sender, System.EventArgs e)
		{
		//	var image = sender as Image;
		//	image.Opacity = 0.6;
		//	image.FadeTo(1);

			await Navigation.PushAsync(new LoginPage());


		}

		async void SignUpClicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SignUp());
		}

	}
}
