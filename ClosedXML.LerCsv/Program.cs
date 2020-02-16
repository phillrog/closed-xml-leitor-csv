using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace ClosedXML.LerCsv
{
	class Program
	{
		static void Main(string[] args)
		{
			var data = LoadDataFromCsv();
			LoadDataFromMappingCsv();
			Console.WriteLine("Hello World!");
		}

		private static void LoadDataFromMappingCsv()
		{
			CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
			CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
			CsvDadosSolicitacaoMapping csvMapper = new CsvDadosSolicitacaoMapping();
			CsvParser<DadosSolicitacoes> csvParser = new CsvParser<DadosSolicitacoes>(csvParserOptions, csvMapper);

			var caminhoDoCsv = @".\exemplos\simulacao_arquivo_gigante.csv";

			using (var streamRdr = new StreamReader(File.OpenRead(caminhoDoCsv)))
			{
				var csvReader = new CsvReader(streamRdr, ";");
				var stringBuilder = new StringBuilder();
				while (csvReader.Read())
				{
					var line = csvReader.GetLine();
					stringBuilder.AppendLine(line.ToString());
					
				}

				var result = csvParser.ReadFromString(csvReaderOptions, stringBuilder.ToString()).ToList();
			}
		}

		private static List<DadosSolicitacoes> LoadDataFromCsv()
		{
			var caminhoDoCsv = @".\exemplos\simulacao.csv";

			using (var streamRdr = new StreamReader(File.OpenRead(caminhoDoCsv)))
			{
				var listaDeDados = new List<DadosSolicitacoes>();
				var csvReader = new CsvReader(streamRdr, ";");
				while (csvReader.Read())
				{
					DadosSolicitacoes dados = null;
					for (int i = 0; i <= csvReader.FieldsCount; i++)
					{
						dados = new DadosSolicitacoes
						{
							TipoDoc = csvReader[i],
							NumeroDocTransp = csvReader[i]
						};
					}

					listaDeDados.Add(dados);
				}
				return listaDeDados;
			}
		}
	}

}
