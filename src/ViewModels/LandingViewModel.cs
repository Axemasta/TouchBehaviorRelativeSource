using CommunityToolkit.Mvvm.Input;

namespace TouchBehaviorRelativeBinding.ViewModels;

public partial class LandingViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task ShowReference()
    {
        await Shell.Current.GoToAsync("ReferencePage");
    }
    
    [RelayCommand]
    private async Task ShowRelativeSource()
    {
        await Shell.Current.GoToAsync("RelativeSourcePage");
    }
}