using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kour;

using Xamarin.Forms;

namespace Kour
{
	public partial class LoginPage : ContentPage
	{

		//it's set on the render
		public Action FBLoginAction;
		//it's set on InitActions();
		public Action<AuthResponse> FBLoginResponse;


		public LoginPage()
		{
			InitializeComponent();

			InitActions();

#if DEBUG
			_email.Text = "obc@mail.com";
			_pass.Text = "obc@mail.com";
#endif


			NavigationPage.SetHasNavigationBar(this, false);

			_forgot_password.Clicked += (sender, e) =>
			{
				ShowForgotPassword();
			};
		}

		async void ShowForgotPassword()
		{
			await Navigation.PushAsync(new ForgotPassword());
		}

		void InitActions()
		{
			FBLoginResponse = (obj) =>
			{
				if (obj != null)
				{

					if (obj.Properties != null)
					{
						if (obj.Properties.ContainsKey("email"))
						{
							System.Diagnostics.Debug.WriteLine("{0}, mail: {1}", obj.Name + " " + obj.LastName, obj.Properties["email"]);
						}

						if (obj.Properties.ContainsKey("acces_token"))
						{


						}
					}

					if (obj.Email != null)
					{


					}

				}
				else
				{

					//await Navigation.PushAsync(new SignUpPage(email: "nomail"));

				}
			};
		}

		#region UI

		#endregion

		#region SERVICES

		async void Login()
		{

			/*try
			{
				DependencyService.Get<IProgress>().ShowProgress("Cargando");

				var where = "Correo_Electronico='" + _email.Text + "'";

				//var res = await App.CurrentApp.Services.ListaSelAll<ClientePagingModel>(Cliente.TABLE_NAME, 0, 1, where);

				DependencyService.Get<IProgress>().Dismiss();

				//if (res != null && res.Clientes.Count > 0)
				//{
				//	var c = res.Clientes[0];

				//	if (c.Contrasena.Trim() == _pass.Text)
				//	{
				//		App.CurrentApp.User = c;
				//		Helpers.PropertiesManager.SaveUserInfo(c);
				//		await ShowHomeScreenPage();
				//		return;
				//	}
				//	else
				//	{
				//		await DisplayAlert("Error", "usuario/contraseña incorrectos", "ok");
				//	}

				//}
				//else if (res == null)
				//{
				//	await DisplayAlert("Error", "ocurrió un error al hacer login", "ok");
				//}
				//else
				//{
				//	await DisplayAlert("Error", "usuario/contraseña incorrectos", "ok");
				//}
			}
			catch (Exception ex)
			{
				DependencyService.Get<IProgress>().Dismiss();
				await DisplayAlert("Error", "ocurrió un error al hacer login", "ok");
			}*/

		await ShowHomeScreenPage();

		}


		#endregion

		#region GESTURES

		async void LoginClicked(object sender, System.EventArgs e)
		{
			//var image = sender as Image;
			//image.Opacity = 0.6;
			//image.FadeTo(1);

			Login();
		}

	/*	async void LoginFaceBookClicked(object sender, System.EventArgs e)
		{
			if (FBLoginAction != null)
				FBLoginAction();
		}*/

		void ShowProgress(bool showProgress)
		{

			var d = DependencyService.Get<IProgress>();

			if (showProgress)
				d.ShowProgress("Espere porfavor");
			else
				d.Dismiss();
		}

		async Task ShowHomeScreenPage()
		{
			await Navigation.PushModalAsync(new RootPage());
		}


		async void CloseClicked(object sender, System.EventArgs e)
		{
			var image = sender as Image;
			image.Opacity = 0.6;
			image.FadeTo(1);
			await Navigation.PopAsync();
		}


		#endregion
	}
}
