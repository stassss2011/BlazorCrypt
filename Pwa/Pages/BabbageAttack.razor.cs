using Pwa.ViewModels;
using ReactiveUI;

namespace Pwa.Pages;

public partial class BabbageAttack
{
    // public new ReactiveObject ViewModel;
    public BabbageAttack()
    {
        ViewModel = new BabbageViewModel();
    }
}