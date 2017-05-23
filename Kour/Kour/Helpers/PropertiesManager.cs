using System;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Kour.Helpers
{
	public class PropertiesManager
{

	static string USER_INFO_KEY = "USER_INFO";
	static string APP_LAUNCH_COUNTER_KEY = "APP_LAUNCH_COUNTER_KEY";

	public static bool IsLogedIn()
	{
		//if (Application.Current.Properties.ContainsKey(USER_INFO_KEY))
		//{
		//	return true;
		//}
		//else {
		//	return false;
		//}

		/*var realm = App.CurrentApp.RealmInstance;

		var n = realm.All<Kour.Cliente>().ToList();
		if (n.Count > 0)
		{
			return n.Last().IsLoggedIn;
		}
*/

		return false;
	}

	public static async void SaveUserInfo(Kour.Cliente user)
	{
		//Application.Current.Properties[USER_INFO_KEY] = JsonConvert.SerializeObject(user);
		//await Application.Current.SavePropertiesAsync();
		//var realm = App.CurrentApp.RealmInstance;

		/*realm.Write(() =>
		{
			var n = realm.All<Kour.Cliente>().ToList();
			if (n.Count > 0)
			{
				var x = n.Last();
				x.Folio = user.Folio;
				x.Correo_Electronico = user.Correo_Electronico;
				x.Contrasena = user.Contrasena;
				x.Confirmar_Contrasena = user.Confirmar_Contrasena;
				x.Contrasena = user.Contrasena;
				x.Nombre = user.Nombre;
				x.IsLoggedIn = user.IsLoggedIn;
			}
			else
			{
				var x = realm.CreateObject<Kour.Cliente>();
				x.Folio = user.Folio;
				x.Correo_Electronico = user.Correo_Electronico;
				x.Contrasena = user.Contrasena;
				x.Confirmar_Contrasena = user.Confirmar_Contrasena;
				x.Contrasena = user.Contrasena;
				x.Nombre = user.Nombre;
				x.IsLoggedIn = user.IsLoggedIn;
			}
		});*/
	}

	public static Kour.Cliente GetUserInfo()
	{
		//if (IsLogedIn())
		//{
		//	var userJson = Application.Current.Properties[USER_INFO_KEY].ToString();
		//	return JsonConvert.DeserializeObject<Usuario>(userJson);
		//}
	//	var realm = App.CurrentApp.RealmInstance;

		//var n = realm.All<Kour.Cliente>().ToList();
		//if (n.Count > 0)
		//	return n.Last();

		return null;
	}

	public static async void LogOut()
	{
		//Application.Current.Properties.Remove(USER_INFO_KEY);
		//await Application.Current.SavePropertiesAsync();

		//var realm = App.CurrentApp.RealmInstance;
		/*var n = realm.All<Kour.Cliente>().ToList();
		realm.Write(() =>
		{
			realm.RemoveAll<Kour.Cliente>();
				//n.Last().IsLoggedIn = false;
			});*/


	}
}
}

