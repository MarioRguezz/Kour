using System;
using System.Collections.Generic;
using Kour;

namespace Kour
{

	public class Tarjeta
{
	public const string TABLE_NAME = "registro_de_token_de_tarjeta";

	public int Folio { get; set; }
	public int Usuario_que_Registra { get; set; }
	public string Fecha_de_Registro { get; set; }
	public string Hora_de_Registro { get; set; }
	public int UsuarioID { get; set; }
	public string Token { get; set; }
	public int? Ultimos_Digitos_de_Tarjeta { get; set; }
	public int Mes_de_Vencimiento { get; set; }
	public int Ano_de_Vencimiento { get; set; }
	public string Nombre { get; set; }
	public TTUsuario Usuario_que_Registra_TTUsuarios { get; set; }
	public Cliente UsuarioID_Cliente { get; set; }
	public int Id { get; set; }


	public string LabelTarjeta
	{
		get
		{
			if (Ultimos_Digitos_de_Tarjeta != null)
			{
				return "****-****-****-" + Ultimos_Digitos_de_Tarjeta;
			}

			return "N/A";
		}
	}

	public string NumeroTarjeta
	{
		get
		{
			if (Nombre != null && Nombre.Contains(";"))
			{
				var str = Nombre.Split(';');
				if (str.Length > 1)
				{
					return str[0];
				}
			}

			return null;
		}
	}

	public string CCV
	{
		get
		{
			if (Nombre != null && Nombre.Contains(";"))
			{
				var str = Nombre.Split(';');
				if (str.Length > 1)
				{
					return str[1];
				}
			}

			return null;
		}
	}

}

public class TarjetaPaginModel
{
	public List<Tarjeta> REGISTRO_DE_TOKEN_DE_TARJETAs { get; set; }
	public int RowCount { get; set; }
}
}
