using System.Reactive.Concurrency;
using ReactiveUI;
using Terminal.Gui;
using Tui.ViewModels;
using Tui.Views;

namespace Tui {
    public static class Program {
        static void Main (string [] args) {
            Application.Init ();
            RxApp.MainThreadScheduler = TerminalScheduler.Default;
            RxApp.TaskpoolScheduler = TaskPoolScheduler.Default;
            Application.Run (new MainView (new MainViewModel ()));
            Application.Shutdown ();
        }
    }
}