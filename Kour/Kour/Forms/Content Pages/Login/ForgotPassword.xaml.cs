using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Kour;
using Xamarin.Forms;

namespace Kour
{
	public partial class ForgotPassword : ContentPage
	{
		string _code = "";
		Cliente _socio;

		enum ForgotPasswordState
		{
			Email,
			VerifyCode,
			ChangePassword
		}

		public ForgotPassword()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);

			/*_emailEntry.TextChanged += (sender, e) =>
			{
				UpdateViews(ForgotPasswordState.Email);
			};
			_okButton.Clicked += (sender, e) =>
			{
				VerifyIfEmailExists();
			};
			_codeButton.Clicked += (sender, e) =>
			{
				ValidateCode();
			};

			_changePasswordButton.Clicked += (sender, e) =>
			{
				ChangePassword();
			};*/
		}

		async void VerifyIfEmailExists()
		{
		/*	var email = _emailEntry.Text;
			if (string.IsNullOrEmpty(email) || !Validators.EmailIsValid(email))
			{
				await ShowMessage("Error", "Ingresa un email valido");
				return;
			}

			DependencyService.Get<IProgress>().ShowProgress("Validando");

			try
			{
				//string where = "Correo_Electronico='" + email + "'";
				//var res = await App.CurrentApp.Services.ListaSelAll<ClientePagingModel>(Cliente.TABLE_NAME, 0, 1000, where);

				//DependencyService.Get<IProgress>().Dismiss();

				//if (res != null && res.Clientes != null && res.Clientes.Count > 0)
				//{
				//	_socio = res.Clientes[0];
				//	SendCode();
				//}
				//else
				//{
				//	ShowMessage("", "El correo no se encuentra registrado");
				//}
			}
			catch (Exception ex)
			{
				DependencyService.Get<IProgress>().Dismiss();

				ShowMessage("", "El correo no se encuentra registrado");
			}
*/
		}

		async void ChangePassword()
		{

		/*	if (ValidateNewPassword())
			{
				try
				{
					DependencyService.Get<IProgress>().ShowProgress("Guardando");

					var newPassword = _new_password.Text;

					var socio = GetCliente(_socio);
					socio.Contrasena = newPassword;


					//var resp = await App.CurrentApp.Services.PutObjectToTable<Cliente>(socio, socio.Folio + "", Cliente.TABLE_NAME);

					DependencyService.Get<IProgress>().Dismiss();

					//if (resp == 0)
					//{
					//	await DisplayAlert("", "Contraseña actualizada correctamente", "OK");

					//	Navigation.PopAsync();
					//}
					//else
					//{
					//	await DisplayAlert("", "Hubo un error al actualizar la contraseña", "OK");
					//}
				}
				catch (Exception ex)
				{
					DependencyService.Get<IProgress>().Dismiss();
					await DisplayAlert("", "Hubo un error al actualizar la contraseña", "OK");
				}
			}*/
		}

		bool ValidateNewPassword()
		{
			bool isValid = true;

			/*if (string.IsNullOrEmpty(_new_password.Text) || string.IsNullOrEmpty(_confirm_password.Text) || !_new_password.Text.Equals(_confirm_password.Text))
			{
				ShowMessage("", "Las nuevas contraseñas no coinciden");
				isValid = false;

				return isValid;
			}

			return isValid;*/
			return true;
		}

		async void SendCode()
		{
			//var email = _emailEntry.Text;

			try
			{
				DependencyService.Get<IProgress>().ShowProgress("Generando código");

				//_code = GenerateCode();

				//var code = new RegistroDeRecuperacionDeContrasena();
				//code.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
				//code.Hora = DateTime.Now.ToString("HH:mm:ss");
				//code.Usuario = "N/A";
				//code.Correo_Electronico = _emailEntry.Text;
				//code.Codigo = _code;

				//var res = await App.CurrentApp.Services.PostObjectToTable<RegistroDeRecuperacionDeContrasena>(code, RegistroDeRecuperacionDeContrasena.TABLE_NAME);

				//DependencyService.Get<IProgress>().Dismiss();
				//if (res != -1)
				//{
				//	//_codeContainer.IsVisible = true;
				//	//_codeButton.IsVisible = true;
				//	//_okButton.IsVisible = false;
				//	UpdateViews(ForgotPasswordState.VerifyCode);

				//	SendEmail();
				//}
				//else
				//{
					DependencyService.Get<IProgress>().Dismiss();

				//	ShowMessage("", "Error el enviar el código");
				//}

			}
			catch (Exception ex)
			{
				DependencyService.Get<IProgress>().Dismiss();
			}
		}

		string GenerateCode()
		{
			Random rnd = new Random();
			int code = rnd.Next(10000, 99999);

			return code.ToString();
		}

		async void SendEmail()
		{

			//var emailText = _emailEntry.Text;

			try
			{
				DependencyService.Get<IProgress>().ShowProgress("Enviando email");
				var client = new HttpClient();
				client.BaseAddress = new Uri("http://104.131.189.226:3000");

			//	var jsonData = JsonConvert.SerializeObject(new { email = emailText, code = _code });

				//var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
				//HttpResponseMessage response = await client.PostAsync("/forgot_password_qc", content);

				//var result = await response.Content.ReadAsStringAsync();

				DependencyService.Get<IProgress>().Dismiss();
			/*	if (result.Equals("{\"status\":\"ok\"}"))
				{
				//	await ShowMessage("", "Se envio un email a la cuenta " + emailText + " con el código para recuperar tu contraseña");
				}
				else
				{
					await ShowMessage("Error", "Hubo un error al enviar el código para recuperar tu contraseña");
				}*/

			}
			catch (Exception ex)
			{
				DependencyService.Get<IProgress>().Dismiss();
				await ShowMessage("Error", "Hubo un error al enviar las intrucciones para recuperar tu contraseña");
			}
		}

		async void ValidateCode()
		{

		//if (string.IsNullOrEmpty(_codeEntry.Text))
			//{
			//	ShowMessage("", "Código invalido");

			//	return;
			//}

			try
			{
				DependencyService.Get<IProgress>().ShowProgress("Validando código");

				//string where = "Correo_Electronico='" + _emailEntry.Text + "'";
				//var res = await App.CurrentApp.Services.ListaSelAll<ForgotPasswordCodePagingModel>(RegistroDeRecuperacionDeContrasena.TABLE_NAME, 0, 1000, where);

				DependencyService.Get<IProgress>().Dismiss();

				//if (res != null && res.Registro_de_Recuperacion_de_Contrasenas != null && res.Registro_de_Recuperacion_de_Contrasenas.Count > 0)
				//{
				//	var code = res.Registro_de_Recuperacion_de_Contrasenas.Last();

				//	if (code.Codigo.Equals(_codeEntry.Text))
				//	{
				//		UpdateViews(ForgotPasswordState.ChangePassword);
				//	}
				//	else
				//	{
				//		ShowMessage("", "El código es incorrecto");
				//	}
				//}
				//else
				//{
				//	ShowMessage("", "El código es incorrecto");
				//}
			}
			catch (Exception ex)
			{
				DependencyService.Get<IProgress>().Dismiss();
			}
		}

		void UpdateViews(ForgotPasswordState state)
		{
			switch (state)
			{
			/*	case ForgotPasswordState.Email:
					_okButton.IsVisible = true;
					_codeButton.IsVisible = false;
					_new_password.IsVisible = false;
					_newPasswordContainer.IsVisible = false;
					_changePasswordButton.IsVisible = false;
					_codeContainer.IsVisible = false;
					break;
				case ForgotPasswordState.VerifyCode:
					_okButton.IsVisible = false;
					_codeButton.IsVisible = true;
					_new_password.IsVisible = false;
					_newPasswordContainer.IsVisible = false;
					_changePasswordButton.IsVisible = false;
					_codeContainer.IsVisible = true;
					break;
				case ForgotPasswordState.ChangePassword:
					_okButton.IsVisible = false;
					_codeButton.IsVisible = false;
					_newPasswordContainer.IsVisible = true;
					_changePasswordButton.IsVisible = true;
					_codeContainer.IsVisible = false;
					_new_password.IsVisible = true;
					_confirm_password.IsVisible = true;
					break;
				default:
					break;*/
			}
		}

		private Cliente GetCliente(Cliente cliente)
		{

			if (cliente.RFC == null)
			{
				cliente.RFC = "N/A";
			}

			if (cliente.Numero_Interior == null)
			{
				cliente.Numero_Interior = "N/A";
			}

			if (cliente.Numero_Exterior == null)
			{
				cliente.Numero_Exterior = "N/A";
			}

			if (cliente.Calle == null)
			{
				cliente.Calle = "N/A";
			}

			return cliente;
		}

		async void BackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		async Task ShowMessage(string title, string message)
		{
			await DisplayAlert(title, message, "Ok");
		}
	}
}
