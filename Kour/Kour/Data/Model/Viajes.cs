using System;
using System.Collections.Generic;

namespace Kour
{


	public class RegistroDeViajess
	{
		public const string TABLE_NAME = "registro_de_paqueteria";


		public int Folio { get; set; }
		public int? Socio_de_Negocio { get; set; }
		public string Vehiculo { get; set; }
		public int? Conductor { get; set; }
		public int? Foto_de_Perfil { get; set; }
		public int Cliente { get; set; }
		public string Fecha_de_Inicio_de_Viaje { get; set; }
		public string Hora_de_Inicio_de_Viaje { get; set; }
		public string Fecha_de_Fin_de_Viaje { get; set; }
		public string Hora_de_Fin_de_Viaje { get; set; }
		public string Ubicacion_de_Inicio { get; set; }
		public string Ubicacion_de_Paquete { get; set; }
		public string Ubicacion_de_Destino { get; set; }
		public string Tiempo_de_Viaje { get; set; }
		public string Distancia_Recorrida { get; set; }
		public int Factor { get; set; }
		public double Costo_Total { get; set; }
		public int? Calificacion { get; set; }
		public string Comentario_Conductor { get; set; }
		public string Comentario_Cliente { get; set; }
		public int? Estatus { get; set; }
		public int? Foto_del_Paquete { get; set; }
		public int? Foto_del_Paquete_al_Inicio { get; set; }
		public int? Foto_del_Paquete_al_Finalizar { get; set; }
		public string Ubicacion_Actual_del_Cliente { get; set; }
		public string Ubicacion_Actual_del_Conductor { get; set; }
		public string Estimacion_del_Tiempo { get; set; }
		public double Estimacion_del_Costo { get; set; }
		public string Placas_del_vehiculo { get; set; }
		public string Folio_de_Pago { get; set; }
		public int Estado_del_Pago { get; set; }
		public int Tipo_de_Servicio { get; set; }
		public SocioDeNegocioSocioDeNegocio Socio_de_Negocio_Socio_de_Negocio { get; set; }
		public ConductorRegistroDeConductorDeSocio Conductor_Registro_de_Conductor_de_Socio { get; set; }
		public TTArchivo Foto_de_Perfil_TTArchivos { get; set; }
		public Cliente Cliente_Cliente { get; set; }
		public FactorFactor Factor_Factor { get; set; }
		public CalificacionCalificacion Calificacion_Calificacion { get; set; }
		public Estatus Estatus_Estatus_de_Paqueteria { get; set; }
		public FotoDelPaqueteTTArchivos Foto_del_Paquete_TTArchivos { get; set; }
		public FotoDelPaqueteAlInicioTTArchivos Foto_del_Paquete_al_Inicio_TTArchivos { get; set; }
		public FotoDelPaqueteAlFinalizarTTArchivos Foto_del_Paquete_al_Finalizar_TTArchivos { get; set; }
		public EstadoDelPagoESTADODEPAGO Estado_del_Pago_ESTADO_DE_PAGO { get; set; }
		public TipoDeServicioTIPODESERVICIO Tipo_de_Servicio_TIPO_DE_SERVICIO { get; set; }
		public int Id { get; set; }


		public DateTime FechaInicioDateTime
		{
			get
			{
				return DateTime.Parse(Fecha_de_Inicio_de_Viaje);
			}
		}
	}

	public class ViajePaginModel
	{
		public List<RegistroDeViajess> Registro_de_Paqueterias { get; set; }
		public int RowCount { get; set; }
	}

	public class EstadoDelPagoESTADODEPAGO
	{
		public int Folio { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class TipoDeServicioTIPODESERVICIO
	{
		public int Folio { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}



	public class SocioDeNegocioSocioDeNegocio
	{
		public int Folio { get; set; }
		public string Fecha_de_Registro { get; set; }
		public object Nombre { get; set; }
		public object Apellido_Paterno { get; set; }
		public object Apellido_Materno { get; set; }
		public object Fecha_de_Nacimiento { get; set; }
		public object Correo_Electronico { get; set; }
		public object Telefono_Celular { get; set; }
		public object Telefono_Fijo { get; set; }
		public object RFC { get; set; }
		public object CURP { get; set; }
		public object CURP_Digitalizado { get; set; }
		public object Comprobante_de_Domicilio { get; set; }
		public object Pais { get; set; }
		public object Estado { get; set; }
		public object Ciudad { get; set; }
		public object Colonia { get; set; }
		public object Calle { get; set; }
		public object Numero_Exterior { get; set; }
		public object Numero_Interior { get; set; }
		public object Codigo_Postal { get; set; }
		public object Tipo_de_Persona { get; set; }
		public object Razon_Social { get; set; }
		public object Fiscal_Pais { get; set; }
		public object Fiscal_Estado { get; set; }
		public object Fiscal_Ciudad { get; set; }
		public object Fiscal_Colonia { get; set; }
		public object Fiscal_Calle { get; set; }
		public object Fiscal_Numero_Exterior { get; set; }
		public object Fiscal_Numero_Interior { get; set; }
		public object Fiscal_Codigo_Postal { get; set; }
		public object Fiscal_Correo_Electronico { get; set; }
		public object Estatus { get; set; }
		public object Calificacion { get; set; }
		public object Alta_en_el_SAT { get; set; }
		public object Credencial_de_Estudiantes { get; set; }
		public object Contrasena { get; set; }
		public object Confirmar_Contrasena { get; set; }
		public object Foto_del_Socio_de_Negocio { get; set; }
		public object INE_Digitalizado { get; set; }
		public object IFE_Digitalizado { get; set; }
		public object Pasaporte_Digitalizado { get; set; }
		public object CURP_Digitalizado_TTArchivos { get; set; }
		public object Comprobante_de_Domicilio_TTArchivos { get; set; }
		public object Pais_Pais { get; set; }
		public object Estado_Estado { get; set; }
		public object Ciudad_Ciudad { get; set; }
		public object Colonia_Colonia { get; set; }
		public object Tipo_de_Persona_Tipo_de_Persona { get; set; }
		public object Fiscal_Pais_Pais { get; set; }
		public object Fiscal_Estado_Estado { get; set; }
		public object Fiscal_Ciudad_Ciudad { get; set; }
		public object Fiscal_Colonia_Colonia { get; set; }
		public object Estatus_Estatus_de_Socio_de_Negocio { get; set; }
		public object Calificacion_Calificacion { get; set; }
		public object Alta_en_el_SAT_TTArchivos { get; set; }
		public object Credencial_de_Estudiantes_TTArchivos { get; set; }
		public object Foto_del_Socio_de_Negocio_TTArchivos { get; set; }
		public object INE_Digitalizado_TTArchivos { get; set; }
		public object IFE_Digitalizado_TTArchivos { get; set; }
		public object Pasaporte_Digitalizado_TTArchivos { get; set; }
		public int Id { get; set; }
	}

	public class ConductorRegistroDeConductorDeSocio
	{
		public static string TABLE_NAME = "registro_de_conductor_de_socio";

		public int Folio { get; set; }
		public object Fecha_de_Registro { get; set; }
		public object Hora_de_Registro { get; set; }
		public object Usuario_que_Registra { get; set; }
		public object Socio_de_Negocio { get; set; }
		public string Nombre { get; set; }
		public string Apellido_Paterno { get; set; }
		public string Apellido_Materno { get; set; }
		public string Fecha_de_Nacimiento { get; set; }
		public string CURP { get; set; }
		public string Numero_de_Licencia { get; set; }
		public string Vencimiento_de_Licencia { get; set; }
		public object Calificacion { get; set; }
		public object Estatus { get; set; }
		public object CURP_Digitalizado { get; set; }
		public object Licencia_para_Conducir_Digitalizada { get; set; }
		public object Carta_de_Antecedentes { get; set; }
		public int? Foto_de_Frente { get; set; }
		public object Foto_de_Perfil { get; set; }
		public object Resultado_Evaluacion_Medica { get; set; }
		public object Fecha_de_Evaluacion_Medica { get; set; }
		public object Evaluador_Medico { get; set; }
		public object Resultado_Evaluacion_Toxicologica { get; set; }
		public object Fecha_Evaluacion_Toxicologica { get; set; }
		public object Evaluador_Toxicologico { get; set; }
		public object Resultado_Evaluacion_Psicologica { get; set; }
		public object Fecha_Evaluacion_Psicologica { get; set; }
		public object Evaluador_Psicologico { get; set; }
		public object Comprobante_de_Domicilio { get; set; }
		public object Numero_de_Pagos { get; set; }
		public object Fecha_de_Pagos { get; set; }
		public object Monto_del_Pago { get; set; }
		public object Estatus_del_Pago { get; set; }
		public object Telefono { get; set; }
		public object INE_Digitalizado { get; set; }
		public object IFE_Digitalizado { get; set; }
		public object Pasaporte_Digitalizado { get; set; }
		public object Usuario_que_Registra_TTUsuarios { get; set; }
		public object Socio_de_Negocio_Socio_de_Negocio { get; set; }
		public object Calificacion_Calificacion { get; set; }
		public object Estatus_Estatus_de_Conductor { get; set; }
		public object CURP_Digitalizado_TTArchivos { get; set; }
		public object Licencia_para_Conducir_Digitalizada_TTArchivos { get; set; }
		public object Carta_de_Antecedentes_TTArchivos { get; set; }
		public object Foto_de_Frente_TTArchivos { get; set; }
		public object Foto_de_Perfil_TTArchivos { get; set; }
		public object Resultado_Evaluacion_Medica_Resultado_de_Evaluacion { get; set; }
		public object Resultado_Evaluacion_Toxicologica_Resultado_de_Evaluacion { get; set; }
		public object Resultado_Evaluacion_Psicologica_Resultado_de_Evaluacion { get; set; }
		public object Comprobante_de_Domicilio_TTArchivos { get; set; }
		public object Estatus_del_Pago_Estatus_del_Pago { get; set; }
		public object INE_Digitalizado_TTArchivos { get; set; }
		public object IFE_Digitalizado_TTArchivos { get; set; }
		public object Pasaporte_Digitalizado_TTArchivos { get; set; }
		public int Id { get; set; }
	}


	public class ConductorPagingModel
	{
		public List<ConductorRegistroDeConductorDeSocio> Registro_de_Conductor_de_Socios { get; set; }
		public int RowCount { get; set; }
	}

	public class FactorFactor
	{
		public int Folio { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class CalificacionCalificacion
	{
		public int Clave { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class EstatusViaje
	{
		public int Folio { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
	}

	public class FotoDelPaqueteTTArchivos
	{
		public int Folio { get; set; }
		public string Nombre { get; set; }
		public object Archivo { get; set; }
		public object ArchivoURL { get; set; }
		public int Id { get; set; }
	}

	public class FotoDelPaqueteAlInicioTTArchivos
	{
		public int Folio { get; set; }
		public object Nombre { get; set; }
		public object Archivo { get; set; }
		public object ArchivoURL { get; set; }
		public int Id { get; set; }
	}

	public class FotoDelPaqueteAlFinalizarTTArchivos
	{
		public int Folio { get; set; }
		public object Nombre { get; set; }
		public object Archivo { get; set; }
		public object ArchivoURL { get; set; }
		public int Id { get; set; }
	}

}
