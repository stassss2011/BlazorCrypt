namespace CommonLibrary.Ciphers;

public class CaesarCipher : AbstractCipher
{
    #region Constructors

    public CaesarCipher(int shift, string alphabet) : base(alphabet)
    {
        Shift = shift;
    }

    #endregion

    #region Properties

    public int Shift { get; }

    #endregion

    #region Methods

    public override string Encrypt(string message)
    {
        return new string(message.Select(symbol =>
                !Alphabet.Contains(symbol)
                    ? symbol
                    : Alphabet[(Alphabet.IndexOf(symbol) + Shift) % Alphabet.Length])
            .ToArray()
        );
    }

    public override string Decrypt(string message)
    {
        return new string(message.Select(symbol =>
                !Alphabet.Contains(symbol)
                    ? symbol
                    : Alphabet[(Alphabet.IndexOf(symbol) - Shift) % Alphabet.Length])
            .ToArray()
        );
    }

    #endregion
}