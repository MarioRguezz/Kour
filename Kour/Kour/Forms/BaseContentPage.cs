using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kour;
using Xamarin.Forms;


namespace Kour
{
	public class BaseContentPage : ContentPage
	{

		public string imagePath = null;
		public Action TakePicture, SelectFromGallery;

		public bool imageChanged = false;

		public string ImagePath
		{
			get
			{
				return imagePath;
			}

			set
			{
				imagePath = value;
				imageChanged = true;
			}
		}

		public object LastView;
		public Action ImageSourceChanged;

		ImageSource _source;
		public ImageSource Source
		{
			set
			{
				imageChanged = true;
				_source = value;

				if (ImageSourceChanged != null)
					ImageSourceChanged();
			}
			get
			{
				return _source;
			}
		}

		byte[] _bytes;

		public byte[] bytes
		{
			get
			{
				return _bytes;
			}

			set
			{
				_bytes = value;
			}
		}



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
	}
}

