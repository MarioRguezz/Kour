using System;

using Xamarin.Forms;

namespace Kour
{
	public class RootPage : MasterDetailPage
	{

		public DrawerListPage _drawer;

		public RootPage(DrawerPage page = DrawerPage.Mapa)
		{

			_drawer = new DrawerListPage(this);
			_drawer.PageSelected += (pageType) =>
			{
				bool presented = false;
				switch (pageType) 
				{
					case DrawerPage.Envios:
					//Detail.Navigation.PushAsync(new DeliveriesPage());
					break;
					case DrawerPage.MetodosPago:

						break;
					case DrawerPage.Perfil:
					//Detail.Navigation.PushAsync(new PerfilPage());

					break;
				}

				IsPresented = presented;
			};
			Master = _drawer;

			if (page == DrawerPage.Mapa)
			{
				//Detail = new NavigationPage(new MapPage(this));
				Detail = new NavigationPage(new MapPedido(this));
			}
			else
			{
				switch (page)
				{
					case DrawerPage.MapaViajeEnCurso:
						//Detail = new NavigationPage(new MapInfoDelivery(this));
						break;
				}
			}

			MasterBehavior = MasterBehavior.Popover;

			IsPresentedChanged += (sender, e) =>
			{
			//_drawer.UpdateView();
		};

			NavigationPage.SetHasNavigationBar(this, false);
		}

	}
}