using System;
using System.Collections.Generic;

namespace Kour
{
	public class TipoDePagoTipoDePago
	{
		public int Folio { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class Tarifa
	{
		public const string TABLE_NAME_VIAJES = "tarifas_sloop";
		public const string TABLE_NAME_PAQUETERIA = "tarifa_paqueteria";

		public int Folio { get; set; }
		public string Compania { get; set; }
		public double Base { get; set; }
		public double Por_Minuto { get; set; }
		public double Por_Km { get; set; }
		public double Minima { get; set; }
		public double Por_Cancelacion { get; set; }
		public int Tipo_de_Pago { get; set; }
		public string Comentarios { get; set; }
		public TipoDePagoTipoDePago Tipo_de_Pago_Tipo_de_Pago { get; set; }
		public int Id { get; set; }
	}

}
