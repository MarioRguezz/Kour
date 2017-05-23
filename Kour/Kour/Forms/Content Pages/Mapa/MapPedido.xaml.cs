using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Kour
{
	public partial class MapPedido : ContentPage
	{

		enum EstadoMapa
		{
			Desde,
			Hasta,
			Confirmacion,
			Seguimiento
		}

		enum TipoDeServicio
		{
			Express,
			Standard,
			Mariachi,
			Comida,
			LavadoAuto
		}


		EstadoMapa CurrentEstado = EstadoMapa.Desde;

		RootPage RootPage;

		public MapPedido(RootPage _rootPage)
		{
			InitializeComponent();
			RootPage = _rootPage;

			NavigationPage.SetHasNavigationBar(this, false);

			InitViews();

			UpdateView();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await LoadCurrentLocation();
		}

		async Task LoadCurrentLocation()
		{

			var helper = LocationHelper.Instance;

			var position = new Plugin.Geolocator.Abstractions.Position();

			if (helper.CurrentPosition != null)
			{
				position = helper.CurrentPosition;
			}
			else
			{
				position = await helper.Geolocator.GetPositionAsync(10000);
			}

			_map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
		}


		void InitViews()
		{

			_map.PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName == "VisibleRegion")
				{
					if (_map.VisibleRegion != null)
					{
						GetLocationOnce(_map.VisibleRegion);
					}
				}
			};
		}

		void UpdateView()
		{
			switch (CurrentEstado)
			{
				case EstadoMapa.Desde:
					_centerPin.IsVisible = true;
					_boxCenter.IsVisible = true;
					_centerPin.Source = "ic_place_orange.png";
					_boxCenter.BackgroundColor = Color.FromHex("#FE7400");
					_boxCenter.IsVisible = true;

					_contSeguimiento.IsVisible = false;
					break;
				case EstadoMapa.Hasta:
					_centerPin.IsVisible = true;
					_boxCenter.IsVisible = true;
					_centerPin.Source = "ic_place_green.png";
					_boxCenter.BackgroundColor = Color.FromHex("#00C37A");
					_boxCenter.IsVisible = true;
					_contSeguimiento.IsVisible = false;

					break;
				case EstadoMapa.Confirmacion:
					_centerPin.IsVisible = false;
					_boxCenter.IsVisible = false;

					_confirmDialog.IsVisible = true;
					_contSeguimiento.IsVisible = false;

					break;
				case EstadoMapa.Seguimiento:

					_centerPin.IsVisible = false;
					_boxCenter.IsVisible = false;
					_confirmDialog.IsVisible = false;

					_contSeguimiento.IsVisible = true;
					break;
			}


			var pins = new List<TK.CustomMap.TKCustomMapPin>();

			if (_desdeRef != null)
			{
				pins.Add(new TK.CustomMap.TKCustomMapPin()
				{
					Image = "ic_place_orange.png",
					Anchor = new Point(0.5, 1),
					Title = "DESDE",
					ShowCallout = false,
					Position = new Position(_desdeRef.Latitud, _desdeRef.Longitud),
				});
			}

			if (_hastaRef != null)
			{
				pins.Add(new TK.CustomMap.TKCustomMapPin()
				{
					Image = "ic_place_green.png",
					Anchor = new Point(0.5, 1),
					Title = "HASTA",
					ShowCallout = false,
					Position = new Position(_hastaRef.Latitud, _hastaRef.Longitud),
				});
			}


			_map.CustomPins = pins;

			var routes = new List<TK.CustomMap.Overlays.TKRoute>();
			if (pins.Count > 1)
			{
				TK.CustomMap.Overlays.TKRoute r = new TK.CustomMap.Overlays.TKRoute();
				r.Source = new Xamarin.Forms.Maps.Position(_desdeRef.Latitud, _desdeRef.Longitud);
				r.Destination = new Xamarin.Forms.Maps.Position(_hastaRef.Latitud, _hastaRef.Longitud);
				r.Color = Color.Black;
				r.LineWidth = 2;

				routes.Add(r);
			}

			_map.Routes = routes;

		}

		void MenuClicked(object sender, EventArgs args)
		{
			RootPage.IsPresented = true;
		}



		#region SERVICO

		async void SolicitarServicioClicked(object sender, System.EventArgs e)
		{
			var page = new ConductoresPage();
			page.Closed += (ss, ee) =>
			{
				CurrentEstado = EstadoMapa.Seguimiento;
				UpdateView();
			};
			await Navigation.PushModalAsync(page);
		}


		void ServiceOptions(object sender, EventArgs args)
		{
			_serviceDialog.IsVisible = true;
		}

		void ServiceClicked(object sender, EventArgs args)
		{
			if (sender == _servExpress)
			{
				_serviceImage.Source = "express.png";
			}
			else if (sender == _servStandard)
			{
				_serviceImage.Source = "standard.png";
			}
			else if (sender == _servMariachi)
			{
				_serviceImage.Source = "mariachi.png";
			}
			else if (sender == _servComida)
			{
				_serviceImage.Source = "comida.png";
			}
			else
			{
				_serviceImage.Source = "lavado.png";
			}

			_serviceDialog.IsVisible = false;
		}

		async void ShowCurrentLocation(object sender, EventArgs args)
		{
			await LoadCurrentLocation();
		}

		void DismissServiceDialog(object sender, EventArgs args)
		{
			_serviceDialog.IsVisible = false;
		}

		void DismissConfirmDialog(object sender, EventArgs args)
		{
			_confirmDialog.IsVisible = false;

			CurrentEstado = EstadoMapa.Desde;

			_hastaRef = null;
			_desdeRef = null;

			UpdateView();
		}

		void CallClicked(object sender, EventArgs args)
		{
			Device.OpenUri(new Uri("tel:4777002855"));
		}


		void CancelClicked(object sender, EventArgs args)
		{
			_desdeRef = null;
			_hastaRef = null;
			CurrentEstado = EstadoMapa.Desde;
			UpdateView();
		}


		#endregion

		#region MAPA

		ReferenciaMapa _desdeRef, _hastaRef, _current;

		void MarcadorClicked(object sender, EventArgs args)
		{
			if (CurrentEstado == EstadoMapa.Desde)
			{
				SetLocation(EstadoMapa.Desde);
				CurrentEstado = EstadoMapa.Hasta;
			}
			else if (CurrentEstado == EstadoMapa.Hasta)
			{
				SetLocation(EstadoMapa.Hasta);
				CurrentEstado = EstadoMapa.Confirmacion;
			}
			else if (CurrentEstado == EstadoMapa.Confirmacion)
			{

			}

			UpdateView();
		}

		async void SetLocation(EstadoMapa estado)
		{
			var resAddress = await GooglePlacesHelper.GetAddress(_map.VisibleRegion.Center.Latitude, _map.VisibleRegion.Center.Longitude);
			if (resAddress != null && resAddress.results.Count > 0)
			{
				var place = resAddress.results[0];
				var refPlace = new ReferenciaMapa()
				{
					Label = place.formatted_address,
					Latitud = _map.VisibleRegion.Center.Latitude,
					Longitud = _map.VisibleRegion.Center.Longitude
				};

				if (estado == EstadoMapa.Desde)
				{
					_desdeRef = refPlace;
					_desdeEntry.Text = refPlace.Label;
				}

				if (estado == EstadoMapa.Hasta)
				{
					_hastaRef = refPlace;
					_hastaEntry.Text = refPlace.Label;
				}

				UpdateView();
			}

		}

		#endregion

		#region LOCATION


		//LOCATIONS LIST
		private CancellationTokenSource CancellationTokenSource;
		private readonly SemaphoreSlim Mutex = new SemaphoreSlim(1, 1);

		void GetLocationOnce(MapSpan visibleRegion)
		{

			var newCts = new CancellationTokenSource();
			var oldCts = Interlocked.Exchange(ref this.CancellationTokenSource, newCts);

			Device.BeginInvokeOnMainThread(() =>
				{
					_direccion.IsVisible = false;
					_loadingAddress.IsVisible = true;
				});

			if (oldCts != null)
			{
				oldCts.Cancel();
			}

			var cancellationToken = newCts.Token;

			Task.Factory.StartNew(async () =>
			{
				// Ensure that only one thread can execute
				// the try body at any given time.
				this.Mutex.Wait(cancellationToken);

				try
				{
					await Task.Delay(TimeSpan.FromMilliseconds(1000), cancellationToken);

					cancellationToken.ThrowIfCancellationRequested();

					GetAddress(new Plugin.Geolocator.Abstractions.Position()
					{
						Latitude = visibleRegion.Center.Latitude,
						Longitude = visibleRegion.Center.Longitude,
					});

					cancellationToken.ThrowIfCancellationRequested();
				}
				finally
				{
					this.Mutex.Release();
				}
			}, cancellationToken);

		}

		async void GetAddress(Plugin.Geolocator.Abstractions.Position po)
		{
			try
			{
				var resAddress = await GooglePlacesHelper.GetAddress(po.Latitude, po.Longitude);
				if (resAddress != null && resAddress.results.Count > 0)
				{
					Traverse(resAddress);
					//ServicioModel.Lat = po.Latitude;
					//ServicioModel.Lang = po.Longitude;
					var place = resAddress.results[0];
					Device.BeginInvokeOnMainThread(() =>
					{
						_direccion.Text = place.formatted_address;

						_direccion.IsVisible = true;
						_loadingAddress.IsVisible = false;
					});

				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		string street = null, streetNumber, colony = null, city = null, postalCode = null, state = null, country = null;
		void Traverse(AddressSearch googleMaps)
		{
			if (googleMaps == null || googleMaps.results == null || googleMaps.results.Count == 0)
				return;

			street = null; streetNumber = null; colony = null; city = null; postalCode = null; state = null;
			country = null;
			foreach (var result in googleMaps.results)
			{
				//System.Diagnostics.Debug.WriteLine(string.Format("result: formatted_address: {0}, types: [{1}]", result.formatted_address, String.Join(" ", result.types)));
				foreach (var addresComponent in result.address_components)
				{
					//System.Diagnostics.Debug.WriteLine(string.Format(" addresComponent[{0}]: formatted_address: {1}, short_name:{2} types: [{3}]", ncomp, addresComponent.long_name, addresComponent.short_name, String.Join(" ", addresComponent.types)));
					foreach (var item in addresComponent.types)
					{
						//System.Diagnostics.Debug.WriteLine(string.Format("{0} {1} {2} {3}", item, addresComponent.long_name, addresComponent.short_name, "types: " + String.Join("; ", addresComponent.types)));
						//System.Diagnostics.Debug.WriteLine(string.Format("{0}", result.formatted_address));

						if (item == "route" && street == null)
						{
							street = addresComponent.long_name;
						}
						else if (item == "administrative_area_level_2" && city == null)
						{
							city = addresComponent.long_name;
						}
						else if (item == "street_number" && streetNumber == null)
						{
							streetNumber = addresComponent.long_name;
						}
						else if ((item == "neighborhood" || item == "sublocality") && colony == null)
						{
							colony = addresComponent.long_name;
						}
						else if (item == "administrative_area_level_1" && state == null)
						{
							state = addresComponent.long_name;
						}
						else if (item == "country" && country == null)
						{
							country = addresComponent.short_name;
						}
						else if (item == "postal_code" && postalCode == null)
						{
							postalCode = addresComponent.long_name;
						}
					}
				}

			}
		}

		#endregion
	}

	public class ReferenciaMapa
	{
		public string Label { get; set; }
		public double Latitud { get; set; }
		public double Longitud { get; set; }
	}
}