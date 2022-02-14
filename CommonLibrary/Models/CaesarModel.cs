using CommonLibrary.Ciphers;
using CommonLibrary.Ciphers.Defaults;

namespace CommonLibrary.Models;

public class CaesarModel : AbstractCipherModel
{
    public CaesarModel()
    {
        Shift = CaesarCipherDefaults.Shift;
    }

    public int Shift { get; set; }

    public override string Encrypt()
    {
        CheckCipher();
        return _cipher?.Encrypt(Text) ?? throw new NullReferenceException();
    }

    public override string Decrypt()
    {
        CheckCipher();
        return _cipher?.Decrypt(Text) ?? throw new NullReferenceException();
    }

    public override void Reset()
    {
        Alphabet = AbstractCipherDefaults.Alphabet;
        Shift = CaesarCipherDefaults.Shift;
        Text = "";
    }

    protected override void CheckCipher()
    {
        _cipher ??= new CaesarCipher(Shift, Alphabet);
        if ((_cipher as CaesarCipher)?.Shift != Shift || _cipher.Alphabet != Alphabet)
            _cipher = new CaesarCipher(Shift, Alphabet);
    }
}