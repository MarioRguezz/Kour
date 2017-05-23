using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kour;
using Xamarin.Forms;

namespace Kour
{

	public enum DrawerPage
	{
		Mapa,
		MapaViajeEnCurso,
		Perfil,
		Envios,
		MetodosPago,
		Ajuste,
	}

	public partial class DrawerListPage : BaseContentPage
	{

		RootPage _rootPage;
		public Action<DrawerPage> PageSelected;
		public ObservableCollection<ItemDrawer> list;

		public DrawerListPage(RootPage rootPage)
		{
			_rootPage = rootPage;
			InitializeComponent();


			Title = " ";

			if (App.CurrentApp.User != null)
			{
				_labelNombre.Text += " " + App.CurrentApp.User.Nombre + " " + App.CurrentApp.User.Apellido_Paterno;
			}

			list = new ObservableCollection<ItemDrawer>();

			list.Add(new ItemDrawer()
			{
				Label = "Perfil",
				Page = DrawerPage.Perfil,
				Image = "avatar.png",
			});

			list.Add(new ItemDrawer()
			{
				Label = "Historial",
				Page = DrawerPage.Envios,
				Image = "history-clock-button.png",
			});

			list.Add(new ItemDrawer()
			{
				Label = "Pago",
				Page = DrawerPage.MetodosPago,
				Image = "credit-card.png",
			});
			list.Add(new ItemDrawer()
			{
				Label = "Instrucciones",
				Page = DrawerPage.MetodosPago,
				Image = "bullets.png",
			});
			list.Add(new ItemDrawer()
			{
				Label = "Privacidad",
				Page = DrawerPage.MetodosPago,
				Image = "protection-shield.png",
			});
			list.Add(new ItemDrawer()
			{
				Label = "Referral",
				Page = DrawerPage.MetodosPago,
				Image = "share.png",
			});
			list.Add(new ItemDrawer()
			{
				Label = "Cerrar Sesión",
				Page = DrawerPage.MetodosPago,
				Image = "turnoff.png",
			});

			//list.Add(new ItemDrawer()
			//{
			//	Label = "Ajustes",
			//	Page = DrawerPage.Ajuste,
			//	Image="cogW.png",
			//});

			ListView.ItemsSource = list;
			ListView.ItemSelected += (sender, e) =>
			{
				if (e.SelectedItem == null)
					return;
				var item = e.SelectedItem as ItemDrawer;
				if (PageSelected != null)
					PageSelected(item.Page);

				foreach (var n in list)
				{
					n.Selected = false;
				}
				item.Selected = true;

				//if (item.Page == DrawerPage.Obvservatorios || item.Page == DrawerPage.Categorias)
				//	item.Selected = false;

				ListView.ItemsSource = new ObservableCollection<ItemDrawer>(list);
				ListView.SelectedItem = null;
			};

			ImageSourceChanged = async () =>
			{
				if (LastView is FFImageLoading.Forms.CachedImage)
					(LastView as FFImageLoading.Forms.CachedImage).Source = Source;

				_imageView.Source = Source;

				//await PostLastFoto();
			};


			//ImagesUploaded += (folio) =>
			//{
			//	ActualizarFotoCliente(folio);
			//};

			//MessagingCenter.Subscribe<PerfilPage>(this, "update_info_user", (sender) =>
			//{
			//		// do something whenever the "Hi" message is sent
			//		if (App.CurrentApp.User != null)
			//		_labelNombre.Text = App.CurrentApp.User.Nombre;
			//	GetFoto();
			//});

			GetFoto();
		}

		async void GetFoto()
		{
			//try
			//{
			//	var cliente = App.CurrentApp.User;
			//	var n = await App.CurrentApp.Services.GetFotos(new List<string>() { "" + cliente.Foto });
			//	if (n != null && n.Count > 0)
			//	{
			//		var str = n[0].ArchivoURL;
			//		str = str.Replace("http://www.totalcase.com.mx/Uploads/TTArchivos/", Configuration.BaseURL + "Uploads/TTArchivos/");
			//		_imageView.Source = str;
			//	}
			//}
			//catch
			//{

			//}
		}

		async void ActualizarFotoCliente(int folio)
		{
			//var cliente = GetCliente();
			//cliente.Foto = folio;

			//var resp = await App.CurrentApp.Services.PutObjectToTable<Cliente>(cliente, cliente.Folio + "", Cliente.TABLE_NAME);

			//if (resp == 0)
			//{

			//}
			//else
			//{

			//}
		}

		async void ChangePicture(object sender, EventArgs e)
		{
			TakePictureActionSheet(_imageView);
		}

		private Cliente GetCliente()
		{
			var cliente = App.CurrentApp.User;

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

			if (cliente.Telefono_Celular == null)
				cliente.Telefono_Celular = "N/A";

			if (cliente.Telefono_Fijo == null)
				cliente.Telefono_Fijo = "N/A";

			if (cliente.Calle == null)
				cliente.Calle = "N/A";

			return cliente;
		}

		void MenuClicked(object sender, System.EventArgs e)
		{
			var image = sender as Image;
			image.Opacity = 0.6;
			image.FadeTo(1);
			_rootPage.IsPresented = false;
		}

		public void SelectPage(DrawerPage page)
		{
			foreach (var n in list)
			{
				if (n.Page == page)
					n.Selected = true;
				else n.Selected = false;
			}
			ListView.ItemsSource = new ObservableCollection<DrawerListPage.ItemDrawer>(list);
			ListView.SelectedItem = null;
		}

		public class ItemDrawer
		{
			public string Label { get; set; }
			public DrawerPage Page { get; set; }
			public bool Selected { get; set; }

			public string Image { get; set; }
		}
	}
}
