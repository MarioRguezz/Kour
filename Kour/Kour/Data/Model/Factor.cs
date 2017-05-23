using System;
using System.Collections.Generic;

namespace Kour
{
	public class Factor
{
	//public const string TABLE_NAME = "factor";
	public int Folio { get; set; }
	public string Descripcion { get; set; }
	public int Valor { get; set; }
	public int Id { get; set; }
}

public class FactorPaginModel
{
	public List<Factor> Factors { get; set; }
	public int RowCount { get; set; }
}
}

