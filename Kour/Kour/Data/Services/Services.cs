//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Xamarin.Forms;

//namespace Kour
//{
//	public class Services
//	{

//		//TokenManager TokenManager;

//		public Services()
//		{
//		//TokenManager = new TokenManager();
//		}

//		enum CallType
//		{
//			Get,
//			GetAll,
//			ListaSelAll,
//			Post,
//			Put,
//			Delete,
//			Insert
//		}

//		object Lock = new object();


//		async Task<HttpClient> GetHttpClient(string table, CallType callType, int start = -1, int rows = -1, string where = null, string order = null, int timpeout = 30)
//		{

//			HttpClient httpClient = null;
//			try
//			{
//				httpClient = new HttpClient();
//			}
//			catch
//			{
//				return null;
//			}
//			httpClient.Timeout = TimeSpan.FromSeconds(timpeout);
//			httpClient.DefaultRequestHeaders.ExpectContinue = true;
//			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//			httpClient.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
//			httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF-8"));
//			//string token = await TokenManager.GetToken();

//			//System.Diagnostics.Debug.WriteLine("TOKEN: " + token);

//			//httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//			string url = Configuration.BaseURL + "api/" + table + "/";
//			if (callType == CallType.Get)
//			{
//				url += "Get";
//			}
//			if (callType == CallType.GetAll)
//			{
//				url += "GetAll";
//			}
//			if (callType == CallType.ListaSelAll)
//			{
//				url += "ListaSelAll";
//			}
//			if (callType == CallType.Post)
//			{
//				url += "Post";
//			}
//			if (callType == CallType.Put)
//			{
//				url += "Put";
//			}
//			if (callType == CallType.Delete)
//			{
//				url += "Delete";
//			}
//			if (callType == CallType.Insert)
//			{
//				url += "Insert";
//			}

//			if (callType == CallType.Get || callType == CallType.GetAll || callType == CallType.ListaSelAll)
//			{
//				url += start == -1 ? "" : "?startRowIndex=" + start;
//				url += rows == -1 ? "" : "&maximumRows=" + rows;

//				if (callType == CallType.Get && start == -1 && rows == -1)
//					url += (string.IsNullOrEmpty(where) ? "" : "?" + where);
//				else
//					url += (string.IsNullOrEmpty(where) ? "" : "&Where=" + where);
//				url += (string.IsNullOrEmpty(order) ? "" : "&1=" + order);
//			}

//			if (callType == CallType.Delete || callType == CallType.Put)
//			{
//				url += (string.IsNullOrEmpty(where) ? "" : "?Id=" + where);
//			}

//			httpClient.BaseAddress = new Uri(url);

//			return httpClient;
//		}

//		internal Task ListaSelAll<T>()
//		{
//			throw new NotImplementedException();
//		}

//		public async Task<T> ListaSelAll<T>(string table, int start = 1, int rows = 1, string where = "", string order = "")
//		{
//			try
//			{
//				System.Diagnostics.Debug.WriteLine("get " + table + " where " + where);
//				var client = await GetHttpClient(table, CallType.ListaSelAll, start, rows, where, order);
//				var response = await client.GetAsync("");
//				var result = await response.Content.ReadAsStringAsync();
//				if (response.IsSuccessStatusCode)
//				{
//					result = await response.Content.ReadAsStringAsync();
//					var model = JsonConvert.DeserializeObject<T>(result.Trim());
//					return model;
//				}
//				return default(T);
//			}
//			catch (Exception ex)
//			{

//				System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}", ex.Message, ex.StackTrace));
//				return default(T);
//			}
//		}

//		public async Task<int> PostObjectToTable<T>(object item, string table)
//		{
//			try
//			{
//				var client = await GetHttpClient(table, CallType.Post);
//				var json = JsonConvert.SerializeObject((T)item);
//				System.Diagnostics.Debug.WriteLine("post {0} \n to {1}", json, table);
//				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
//				var response = await client.PostAsync("", content);
//				var result = await response.Content.ReadAsStringAsync();
//				System.Diagnostics.Debug.WriteLine("result: {0}", result);
//				if (response.IsSuccessStatusCode)
//				{

//					int id = 0;
//					if (int.TryParse(result.Replace("\"", ""), out id))
//					{
//						return id;
//					}
//					return -1;
//				}
//				return -1;
//			}
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine(ex.Message);
//				return -1;
//			}
//		}

//		public async Task<int> PutObjectToTable<T>(object item, string id_str, string table)
//		{
//			try
//			{
//				var client = await GetHttpClient(table, CallType.Put, -1, -1, id_str);
//				var json = JsonConvert.SerializeObject((T)item, Newtonsoft.Json.Formatting.None,
//							new JsonSerializerSettings
//							{
//								NullValueHandling = NullValueHandling.Ignore
//							});
//				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
//				var response = await client.PutAsync("", content);
//				var result = await response.Content.ReadAsStringAsync();
//				if (response.IsSuccessStatusCode)
//				{

//					int id = 0;
//					if (int.TryParse(result.Replace("\"", ""), out id))
//					{
//						return id;
//					}
//					return -1;
//				}
//				return -1;
//			}
//			catch (Exception ex)
//			{
//				return -1;
//			}
//		}

//		public async Task<bool> DeleteObject(string id_str, string table)
//		{
//			try
//			{
//				var client = await GetHttpClient(table, CallType.Delete, -1, -1, id_str);
//				//HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
//				var response = await client.DeleteAsync("");

//				if (response.IsSuccessStatusCode)
//				{
//					var result = await response.Content.ReadAsStringAsync();
//					bool did = false;
//					if (bool.TryParse(result, out did))
//					{
//						return did;
//					}
//					return did;
//				}
//				return false;
//			}
//			catch (Exception ex)
//			{
//				return false;
//			}
//		}

//		public async Task<T> GetAllObjects<T>(string TABLE_NAME, int min = -1, int max = -1, string where = null, string order = null)
//		{

//			try
//			{
//				var client = await GetHttpClient(TABLE_NAME, CallType.GetAll, min, max, where, order);
//				var response = await client.GetAsync("");
//				if (response.IsSuccessStatusCode)
//				{
//					var result = await response.Content.ReadAsStringAsync();
//					var model = JsonConvert.DeserializeObject<T>(result.Trim());
//					return model;
//				}
//				return default(T);
//			}
//			catch (Exception ex)
//			{
//				return default(T);
//			}
//		}


//		public async Task<T> GetObject<T>(string TABLE_NAME, int min = -1, int max = -1, string where = null, string order = null)
//		{

//			try
//			{
//				var client = await GetHttpClient(TABLE_NAME, CallType.Get, min, max, where, order);
//				var response = await client.GetAsync("");
//				var result = await response.Content.ReadAsStringAsync();
//				if (response.IsSuccessStatusCode)
//				{

//					var model = JsonConvert.DeserializeObject<T>(result.Trim());
//					return model;
//				}
//				return default(T);
//			}
//			catch (Exception ex)
//			{
//				return default(T);
//			}
//		}


//		public async Task<List<TTArchivo>> GetFotos(List<string> IDs, bool getPhysicalFile = false)
//		{
//			try
//			{
//				var response = await GetObject<List<TTArchivo>>(TTArchivo.TABLE_NAME, -1, -1, string.Format("FolioId={0}&getPhysicalFile={1}", String.Join(",", IDs), getPhysicalFile), "");
//				return response;
//			}
//			catch (Exception ex)
//			{
//				System.Diagnostics.Debug.WriteLine(string.Format("{0}", ex.Message));
//				return null;
//			}

//			return null;
//		}

//		public async Task<List<TTArchivo>> PostFotos(List<InputFile> fotos)
//		{

//			//if (foto.Count == 0)
//			//	return new List<TTArchivo>();
//			try
//			{
//				var client = await GetHttpClient(InputFile.TABLE_NAME, CallType.Insert, -1, -1, null, null, 9999);
//				var json = JsonConvert.SerializeObject(fotos);
//				//System.Diagnostics.Debug.WriteLine(json);
//				//DependencyService.Get<ILogHelp>().SaveStringToFile(json, "POST_FOTO_" + DateTime.Now.ToString("hh_mm_ss"));
//				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
//				var response = await client.PostAsync("", content);


//				if (response.IsSuccessStatusCode)
//				{
//					var result = await response.Content.ReadAsStringAsync();
//					var model = JsonConvert.DeserializeObject<List<TTArchivo>>(result);
//					return model;
//				}
//				return new List<TTArchivo>();
//			}
//			catch (Exception ex)
//			{
//				return new List<TTArchivo>();
//			}
//		}


//	}
//}

