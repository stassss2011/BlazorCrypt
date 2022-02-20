using System.Reactive.Linq;
using CommonLibrary.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Tui.ViewModels;

public class BabbageViewModel: ReactiveObject
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
            .Throttle(TimeSpan.FromMilliseconds(100))
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

    public async void Decrypt()
    {
        var decryptTask = Task.Run((() => Attack.Attack()));
        OutputText = await decryptTask;
    }
}