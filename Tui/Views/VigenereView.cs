using System.Reactive.Disposables;
using ReactiveUI;
using Terminal.Gui;
using Tui.ViewModels;

namespace Tui.Views;

public class VigenereView: FrameView, IViewFor<VigenereViewModel>
{
    private readonly CompositeDisposable _disposable = new();
    private readonly Label _text;

    public VigenereView(VigenereViewModel viewModel)
    {
        ViewModel = viewModel;
        _text = TitleLabel();
    }

    private Label TitleLabel () {
        var label = new Label("Vig")
        {
            X = 0,
            Y = 0
        };
        Add (label);
        return label;
    }

    object IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (VigenereViewModel)value;
    }

    public VigenereViewModel ViewModel { get; set; }

    protected override void Dispose(bool disposing)
    {
        _disposable.Dispose();
        base.Dispose(disposing);
    }
}