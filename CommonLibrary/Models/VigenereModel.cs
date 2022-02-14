using CommonLibrary.Ciphers;
using CommonLibrary.Ciphers.Defaults;

namespace CommonLibrary.Models;

public class VigenereModel : AbstractCipherModel
{
    public VigenereModel()
    {
        Key = VigenereCipherDefaults.Key;
    }

    public string Key { get; set; }

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
        Key = VigenereCipherDefaults.Key;
        Text = "";
    }


    protected override void CheckCipher()
    {
        _cipher ??= new VigenereCipher(Key, Alphabet);
        if ((_cipher as VigenereCipher)?.Key != Key || _cipher.Alphabet != Alphabet)
            _cipher = new VigenereCipher(Key, Alphabet);
    }
}