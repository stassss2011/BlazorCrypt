using System.Reactive.Disposables;
using ReactiveUI;
using Terminal.Gui;
using Tui.ViewModels;

namespace Tui.Views;

public class CaesarView : FrameView, IViewFor<CaesarViewModel>
{
    private readonly CompositeDisposable _disposable = new();
    private readonly Label _text;

    public CaesarView(CaesarViewModel viewModel) : base("Title")
    {
        ViewModel = viewModel;
        _text = TitleLabel();
    }

    private Label TitleLabel () {
        var label = new Label("Caes")
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
        set => ViewModel = (CaesarViewModel)value;
    }

    public CaesarViewModel ViewModel { get; set; }

    protected override void Dispose(bool disposing)
    {
        _disposable.Dispose();
        base.Dispose(disposing);
    }
}