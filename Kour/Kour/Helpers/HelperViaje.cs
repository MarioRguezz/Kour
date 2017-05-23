using System;
using Kour;

using Xamarin.Forms;

namespace Kour
{
	public class HelperViaje
{
	public static TipoViaje TipoViaje { get; set; }

	static ItemLocation startPoint = null;

	public static ItemLocation StartPoint
	{
		get
		{
			return startPoint;
		}

		set
		{
			startPoint = value;
		}
	}

	static ItemLocation endPoint = null;

	public static ItemLocation EndPoint
	{
		get
		{
			return endPoint;
		}

		set
		{
			endPoint = value;
		}
	}

	public static Factor Factor { get; internal set; }
	public static Tarifa Tarifa { get; internal set; }

	public static RegistroDeViajess Viaje { get; set; }

	public static double CostEstimado { get; internal set; }
	public static string TiempoEstimado { get; internal set; }
	public static double DistanciaKM { get; internal set; }
}
}
