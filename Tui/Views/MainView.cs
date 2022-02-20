using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Terminal.Gui;
using Tui.ViewModels;
using ReactiveMarbles.ObservableEvents;

namespace Tui.Views;

public class MainView : Window, IViewFor<MainViewModel>
{
    readonly CompositeDisposable _disposable = new CompositeDisposable();
    private readonly FrameView _leftPane;
    private readonly FrameView _rightPane;
    private readonly ListView _menu;
    

    public MainView(MainViewModel viewModel) : base("Tui Crypt")
    {
        ViewModel = viewModel;
        _leftPane = LeftPane();
        _rightPane = RightPane();
        _menu = Menu();
    }

    private FrameView RightPane()
    {
        var rightPane = new FrameView("<- Select Method")
        {
            X = 25,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill (),
            CanFocus = false,
            Shortcut = Key.CtrlMask | Key.V
        };
        rightPane.Title = $"{rightPane.Title} ({rightPane.ShortcutTag})";
        rightPane.ShortcutAction = () => rightPane.SetFocus ();

        ViewModel
            .WhenAnyValue(x => x.rightPaneView)
            .BindTo(rightPane, x => x.Subviews);
        
        Add (rightPane);
        return rightPane;
    }

    private void UpdateRightPane()
    {
        _rightPane.RemoveAll();
        _rightPane.Add(ViewModel.rightPaneView);
    }

    private FrameView LeftPane()
    {
        var leftPane = new FrameView ("Methods") {
            X = 0,
            Y = 0,
            Width = 25,
            Height = Dim.Fill (),
            CanFocus = false,
            Shortcut = Key.CtrlMask | Key.C
        };
        leftPane.Title = $"{leftPane.Title} ({leftPane.ShortcutTag})";
        leftPane.ShortcutAction = () => leftPane.SetFocus ();

        Add(leftPane);
        return leftPane;
    }

    private ListView Menu()
    {
        var menu = new ListView (ViewModel._methods) {
            X = 0,
            Y = 0,
            Width = Dim.Fill (0),
            Height = Dim.Fill (0),
            AllowsMarking = false,
            CanFocus = true,
        };
        menu.OpenSelectedItem += (a) => {
            _rightPane.FocusFirst();
        };
        ViewModel
            .WhenAnyValue(x => x.menuItem)
            .BindTo(menu, x => x.SelectedItem);
        menu
            .Events()
            .SelectedItemChanged
            .Select(_ => menu.SelectedItem)
            .DistinctUntilChanged()
            .BindTo(ViewModel, x => x.menuItem)
            .DisposeWith(_disposable);
        _leftPane.Add (menu);
        return menu;
    }
    
    
    
    

    protected override void Dispose (bool disposing) {
        _disposable.Dispose ();
        base.Dispose (disposing);
    }
    object IViewFor.ViewModel {
        get => ViewModel;
        set => ViewModel = (MainViewModel) value;
    }
    
    public MainViewModel ViewModel { get; set; }
}