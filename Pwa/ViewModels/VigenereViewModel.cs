using CommonLibrary.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Pwa.ViewModels;

public class VigenereViewModel : ReactiveObject
{
    public VigenereViewModel()
    {
        Cipher = new VigenereModel();
        Alphabet = Cipher.Alphabet;
        Key = Cipher.Key;
        InputText = Cipher.Text;
        OutputText = "";
        this.WhenAnyValue(
                x => x.Key,
                x => x.Alphabet,
                x => x.InputText
            )
            .Subscribe(_ => UpdateCipher());
    }

    [Reactive] public string InputText { get; set; }

    [Reactive] public string OutputText { get; set; }

    [Reactive] public string Key { get; set; }

    [Reactive] public string Alphabet { get; set; }

    private VigenereModel Cipher { get; }

    private void UpdateCipher()
    {
        Cipher.Key = Key;
        Cipher.Alphabet = Alphabet;
        Cipher.Text = InputText;
    }

    public void Reset()
    {
        Cipher.Reset();
        Alphabet = Cipher.Alphabet;
        Key = Cipher.Key;
        InputText = Cipher.Text;
        OutputText = "";
    }

    public void Encrypt()
    {
        OutputText = Cipher.Encrypt();
    }

    public void Decrypt()
    {
        OutputText = Cipher.Decrypt();
    }
}