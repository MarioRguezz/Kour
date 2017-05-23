using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Kour
{
	public class InputFile
	{
		public static string TABLE_NAME = "TTArchivos";

		public string FileName { get; set; }

		public string Path { get; set; }

		[JsonConverter(typeof(ByteArrayConverter))]
		public byte[] FileArray { get; set; }

	}

}
