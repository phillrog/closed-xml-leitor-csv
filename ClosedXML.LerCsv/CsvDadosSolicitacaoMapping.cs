using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace ClosedXML.LerCsv
{
	public class CsvDadosSolicitacaoMapping : CsvMapping<DadosSolicitacoes>
	{
		public CsvDadosSolicitacaoMapping() : base()
		{
			MapProperty(0, x => x.TipoDoc);
			MapProperty(1, x => x.NumeroDocTransp);
			MapProperty(2, x => x.SerieFrete);
			MapProperty(3, x => x.UnE);
			MapProperty(4, x => x.FreteDataEmissao);
			MapProperty(5, x => x.FreteValor);
			MapProperty(6, x => x.NumeroPrefatura);
			MapProperty(7, x => x.NumeroFatura);
			MapProperty(8, x => x.SerieFatura);
			MapProperty(9, x => x.FaturaDataEmissao);
			MapProperty(10, x => x.FaturaValor);
		}
	}
}
