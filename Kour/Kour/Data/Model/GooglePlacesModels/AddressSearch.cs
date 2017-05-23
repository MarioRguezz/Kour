using System;
using System.Collections.Generic;


namespace Kour
{
	public class AddressSearch
	{
		public List<AddressResults> results { get; set; }

		public string status { get; set; }
	}

	public class AddressResults
	{
		public List<AddressComponent> address_components { get; set; }
		public string formatted_address { get; set; }
		public Geometry geometry { get; set; }
		public string place_id { get; set; }
		public List<string> types { get; set; }
	}

	public class Geometry
	{
		public Location location { get; set; }
	}

	public class Location
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
}
