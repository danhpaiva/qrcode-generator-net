using QrCodeGenerator.Models;

Console.WriteLine("Digite a URL para gerar o QrCode: ");
string url = Console.ReadLine();

var resultadoProcessamento = Processamento.ValidarUrl(url);

if (resultadoProcessamento.Equals(true))
    Processamento.GerarImagem(url);