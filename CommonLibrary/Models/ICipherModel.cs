namespace CommonLibrary.Models;

public interface ICipherModel
{
    public string Alphabet { get; set; }
    public string Text { get; set; }

    public string Encrypt();
    public string Decrypt();
    public void Reset();
}