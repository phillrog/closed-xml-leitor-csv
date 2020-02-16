# Leitor Csv
Solução para efetuar leitura e mapeamento de um csv

## TinyCsvParser
para mapeamento do modelo de dominio

```
PM> Pacote de instalação TinyCsvParser
```

## CsvReader alterado - original é do [NReco.Csv](https://github.com/nreco/csv)
para ler todas as linhas do arquivo 

Com os 2 foi possível ler o arquivo csv de até + de 100.000 linhas e mapear colunas com uma classe que implementa a configuração do modelo. E a partir disso efetuar as conversões com o proprio tiny.

```
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
```

# Resultado

```
public void LoadDataFromMappingCsv()
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
```
