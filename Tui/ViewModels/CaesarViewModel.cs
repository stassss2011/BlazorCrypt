using System.Reactive.Linq;
using CommonLibrary.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Tui.ViewModels;

public class CaesarViewModel : ReactiveObject
{
    public CaesarViewModel()
    {
        Cipher = new CaesarModel();
        Alphabet = Cipher.Alphabet;
        Shift = Cipher.Shift;
        InputText = Cipher.Text;
        OutputText = "";
        this.WhenAnyValue(
                x => x.Shift,
                x => x.Alphabet,
                x => x.InputText
            )
            .Throttle(TimeSpan.FromMilliseconds(100))
            .Subscribe(_ => UpdateCipher());
    }

    [Reactive] public string InputText { get; set; }

    [Reactive] public string OutputText { get; set; }

    [Reactive] public int Shift { get; set; }

    [Reactive] public string Alphabet { get; set; }

    private CaesarModel Cipher { get; }

    private void UpdateCipher()
    {
        Cipher.Shift = Shift;
        Cipher.Alphabet = Alphabet;
        Cipher.Text = InputText;
    }

    public void Reset()
    {
        Cipher.Reset();
        Alphabet = Cipher.Alphabet;
        Shift = Cipher.Shift;
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