using CommonLibrary.Ciphers;
using CommonLibrary.Ciphers.Defaults;

namespace CommonLibrary.Models;

public abstract class AbstractCipherModel : ICipherModel
{
    // ReSharper disable once InconsistentNaming
    protected AbstractCipher? _cipher;

    protected AbstractCipherModel()
    {
        Alphabet = AbstractCipherDefaults.Alphabet;
        Text = "";
    }

    public string Alphabet { get; set; }
    public string Text { get; set; }

    public abstract string Encrypt();
    public abstract string Decrypt();
    public abstract void Reset();

    protected abstract void CheckCipher();
}