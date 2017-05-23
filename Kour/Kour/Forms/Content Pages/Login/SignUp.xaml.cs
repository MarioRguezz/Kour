using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Kour;

namespace Kour
{
	public partial class SignUp : BaseContentPage
	{
		Cliente Cliente;
		bool FromFacebook = false;

		public SignUp(Cliente cliente = null, bool fromFacebook = false)
		{
			InitializeComponent();

			Cliente = cliente;
			FromFacebook = fromFacebook;

			InitViews();

			ImageSourceChanged = async() =>
			{
				if (LastView is FFImageLoading.Forms.CachedImage)
					(LastView as FFImageLoading.Forms.CachedImage).Source = Source;

				_imageView.Source = Source;

				//await PostLastFoto();
			};


			NavigationPage.SetHasNavigationBar(this, false);
		}

		void InitViews()
		{
			if (Cliente != null)
			{
				_name.Text = Cliente.Nombre;
				_apellidoP.Text = Cliente.Apellido_Paterno;
				//_apellidoM.Text = Cliente.Apellido_Materno;
				_email.Text = Cliente.Correo_Electronico;
				_pass.Text = Cliente.Contrasena;
				//_confirmPass.Text = Cliente.Contrasena;
				if (FromFacebook)
				{
					_email.IsEnabled = false;
					//_passContainer.IsVisible = false;
				}

				_phone.TextChanged += ViewUtils.PhoneTextLimit;
			}
		}

		protected override void OnDisappearing()
		{
			_phone.TextChanged -= ViewUtils.PhoneTextLimit;
			base.OnDisappearing();
		}

		#region UI

		#endregion

		#region SERVICES

		async void Registrar()
		{
			if (await valid())
			{
				try
				{
					DependencyService.Get<IProgress>().ShowProgress("Cargando");

					//var resL = await App.CurrentApp.Services.ListaSelAll<ClientePagingModel>(Cliente.TABLE_NAME, 0, 1, "Correo_Electronico='" + _email.Text + "'");


					//if (resL != null && resL.RowCount == 0)
					//{
					//	var cliente = new Cliente();
					//	cliente.Nombre = _name.Text;
					//	cliente.Apellido_Materno = _apellidoM.Text;
					//	cliente.Apellido_Paterno = _apellidoP.Text;
					//	cliente.Correo_Electronico = _email.Text;
					//	cliente.Contrasena = _pass.Text;
					//	cliente.Confirmar_Contrasena = _confirmPass.Text;
					//	cliente.Telefono_Celular = _phone.Text;
					//	cliente.Calificacion = 1;
					//	cliente.Estatus = 1;
					//	cliente.Pais = 2;
					//	cliente.Estado = 33;
					//	cliente.Ciudad = 2459;
					//	cliente.Colonia = 6919;

					//	var res = await App.CurrentApp.Services.PostObjectToTable<Cliente>(cliente, Cliente.TABLE_NAME);
					//	if (res != -1)
					//	{
					//		cliente.Folio = res;
					//		Helpers.PropertiesManager.SaveUserInfo(cliente);
					//		App.CurrentApp.User = cliente;
					//		DependencyService.Get<IProgress>().Dismiss();
					//		await Navigation.PushModalAsync(new RootPage());
					//	}
					//	else
					//	{
					//		DependencyService.Get<IProgress>().Dismiss();
					//		await DisplayAlert("", "Ocurrió un error", "ok");
					//	}

					//}
					//else
					//{
					//	DependencyService.Get<IProgress>().Dismiss();
					//	await DisplayAlert("", "Ese correo ya se esta registrado.", "ok");
					//}

				}
				catch (Exception ex)
				{
					DependencyService.Get<IProgress>().Dismiss();
					await DisplayAlert("", "Ocurrió un error", "ok");
				}
			}
		}

		async Task<bool> valid()
		{
			if (string.IsNullOrEmpty(_email.Text) || string.IsNullOrEmpty(_pass.Text) || string.IsNullOrEmpty(_name.Text) || string.IsNullOrEmpty(_apellidoP.Text))
			{
				await DisplayAlert("", "Favor de llenar todos los campos", "ok");
				return false;
			}


			if (string.IsNullOrEmpty(_phone.Text))
			{
				await DisplayAlert("", "Ingresa un teléfono", "ok");
				return false;
			}
			else
			{
				if (!Validators.JustNumbers(_phone.Text))
				{
					await DisplayAlert("", "Ingresa un teléfono válido", "ok");
					return false;
				}
				else if (_phone.Text.Length != 10)
				{
					await DisplayAlert("", "Ingresa un teléfono de diez digitos", "ok");
					return false;
				}
			}


			return true;
		}

		#endregion

		#region GESTURES

		void SignUpClicked(object sender, System.EventArgs e)
		{
			//var image = sender as Image;
			//image.Opacity = 0.6;
			//image.FadeTo(1);


			Registrar();

		}

		async void CloseClicked(object sender, System.EventArgs e)
		{
			var image = sender as Image;
			image.Opacity = 0.6;
			image.FadeTo(1);
			await Navigation.PopAsync();
		}

		async void ChangePicture(object sender, EventArgs e)
		{
			TakePictureActionSheet(_imageView);
		}

		#endregion

		#region PICTURES



		public async void TakePictureActionSheet(object imageView = null)
		{
			LastView = imageView;
			var n = await DisplayActionSheet("Elige una imagen", "cancelar", null, new string[] { "Cámara", "Galería" });
			switch (n)
			{
				case "Cámara":
					if (TakePicture != null)
					{
						TakePicture();
					}
					break;
				case "Galería":
					if (SelectFromGallery != null)
					{
						SelectFromGallery();
					}
					break;
			}
		}

		#endregion
	}
}
