using QRCoder;

Console.WriteLine("Digite a URL para gerar o QrCode: ");
string url = Console.ReadLine();

if (string.IsNullOrEmpty(url))
{
    Console.WriteLine("A url está inválida...");
    return;
}

try
{
    QRCodeGenerator qRCodeGenerator = new();
    QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

    using (PngByteQRCode qrCode = new PngByteQRCode(qRCodeData))
    {
        byte[] qrCodeImage = qrCode.GetGraphic(40);

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string filePath = Path.Combine(desktopPath, "qrCode.png");

        File.WriteAllBytes(filePath, qrCodeImage);

        Console.WriteLine($"QrCode gerado com sucesso no diretorio: " + filePath);
    }
}
catch (Exception e)
{
    Console.WriteLine("Aconteceu um erro ao gerar um QrCode: " + e.Message);
}