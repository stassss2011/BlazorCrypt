using CommonLibrary.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Pwa.ViewModels;

public class BabbageViewModel : ReactiveObject
{
    public BabbageViewModel()
    {
        Attack = new BabbageModel();
        MaxKeyLen = Attack.MaxKeyLen;
        InputText = Attack.Text;
        OutputText = "";
        UpdateAttack();
        this.WhenAnyValue(
                x => x.MaxKeyLen,
                x => x.InputText
            )
            .Subscribe(_ => UpdateAttack());
    }

    [Reactive] public string InputText { get; set; }

    [Reactive] public string OutputText { get; set; }

    [Reactive] public int MaxKeyLen { get; set; }

    private BabbageModel Attack { get; }

    private void UpdateAttack()
    {
        Attack.MaxKeyLen = MaxKeyLen;
        Attack.Text = InputText;
    }

    public void Reset()
    {
        Attack.Reset();
        MaxKeyLen = Attack.MaxKeyLen;
        InputText = Attack.Text;
        OutputText = "";
    }

    public void Decrypt()
    {
        OutputText = Attack.Attack();
    }
}