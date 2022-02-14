namespace CommonLibrary.Ciphers;

public abstract class AbstractCipher : ICipher
{
    protected AbstractCipher(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Alphabet { get; }

    public abstract string Encrypt(string message);

    public abstract string Decrypt(string message);
}