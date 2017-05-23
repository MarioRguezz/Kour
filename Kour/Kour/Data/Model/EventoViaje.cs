using System;
using System.Collections.Generic;

namespace Kour
{

	public class Calificacion
	{
		public int Clave { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class Estatus
	{
		public int Clave { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class Pais
	{
		public int Clave { get; set; }
		public string Nombre { get; set; }
		public int Id { get; set; }
	}

	public class Estado
	{
		public int Clave { get; set; }
		public string Nombre { get; set; }
		public object Pais { get; set; }
		public object Pais_Pais { get; set; }
		public int Id { get; set; }
	}

	public class Ciudad
	{
		public int Clave { get; set; }
		public string Nombre { get; set; }
		public object Estado { get; set; }
		public object Estado_Estado { get; set; }
		public int Id { get; set; }
	}

	public class Colonia
	{
		public int Clave { get; set; }
		public string Nombre { get; set; }
		public object Ciudad { get; set; }
		public object Ciudad_Ciudad { get; set; }
		public int Id { get; set; }
	}

	public class Cliente 
	{
		public int Folio { get; set; }
		public string Nombre { get; set; }
		public string Apellido_Paterno { get; set; }
		public string Apellido_Materno { get; set; }
		public string Fecha_de_Nacimiento { get; set; }
		public string Correo_Electronico { get; set; }
		public string Telefono_Celular { get; set; }
		public string Telefono_Fijo { get; set; }
		public string RFC { get; set; }
		public int? Foto { get; set; }
		public int? Calificacion { get; set; }
		public int? Estatus { get; set; }
		public int? Pais { get; set; }
		public int? Estado { get; set; }
		public int? Ciudad { get; set; }
		public int? Colonia { get; set; }
		public string Calle { get; set; }
		public string Numero_Exterior { get; set; }
		public string Numero_Interior { get; set; }
		public int? Codigo_Postal { get; set; }
		public string Contrasena { get; set; }
		public string Confirmar_Contrasena { get; set; }
		
		public int Id { get; set; }


		public bool IsLoggedIn { get; set; }
	}
	

	public class ClientePagingModel
	{
		public List<Cliente> Clientes { get; set; }
		public int RowCount { get; set; }
	}
}
