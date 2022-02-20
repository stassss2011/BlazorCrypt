using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Terminal.Gui;
using Tui.Views;

namespace Tui.ViewModels;

public class MainViewModel : ReactiveObject
{
    public List<string> _methods = new() {"Caesar", "Vigenere", "Babbage"};
    public List<FrameView> _methodsViews = new()
    {
        new CaesarView(new CaesarViewModel()),
        new VigenereView(new VigenereViewModel()),
        new BabbageView(new BabbageViewModel())
    };
    
    [Reactive]
    public FrameView rightPaneView { get; set; }
    
    [Reactive]
    public int menuItem { get; set; }

    public MainViewModel()
    {
        this
            .WhenAnyValue(x => x.menuItem)
            .Subscribe(_ => UpdateRightPane());
    }

    private void UpdateRightPane()
    {
        rightPaneView = _methodsViews[menuItem];
    }
}