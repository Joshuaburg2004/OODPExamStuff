public class DigitalProduct : Product
{
    public string DownloadUrl;
    public DigitalProduct(string name, int price, int quantity, string downloadUrl) : base(name, price, quantity) { DownloadUrl = downloadUrl; }
}
