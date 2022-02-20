using System.Reactive.Disposables;
using ReactiveUI;
using Terminal.Gui;
using Tui.ViewModels;

namespace Tui.Views;

public class BabbageView: FrameView, IViewFor<BabbageViewModel>
{
    private readonly CompositeDisposable _disposable = new();
    private readonly Label _text;

    public BabbageView(BabbageViewModel viewModel)
    {
        ViewModel = viewModel;
        _text = TitleLabel();
    }

    private Label TitleLabel () {
        var label = new Label("Bab")
        {
            X = 5,
            Y = 5
        };
        Add (label);
        return label;
    }

    object IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (BabbageViewModel)value;
    }

    public BabbageViewModel ViewModel { get; set; }

    protected override void Dispose(bool disposing)
    {
        _disposable.Dispose();
        base.Dispose(disposing);
    }
}