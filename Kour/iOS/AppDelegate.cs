using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using TK.CustomMap.iOSUnified;
using UIKit;

namespace Kour.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			Xamarin.FormsMaps.Init();
			TKCustomMapRenderer.InitMapRenderer();
			LoadApplication(new App());

			FFImageLoading.Forms.Touch.CachedImageRenderer.Init();
			var dummy = new FFImageLoading.Forms.Touch.CachedImageRenderer();
			var ignore = new FFImageLoading.Transformations.CircleTransformation();

			return base.FinishedLaunching(app, options);
		}
	}
}
