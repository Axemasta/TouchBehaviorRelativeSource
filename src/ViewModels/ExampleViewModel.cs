using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TouchBehaviorRelativeBinding.Helpers;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.ViewModels;

public partial class ExampleViewModel : ViewModelBase
{
    public ObservableCollection<DisplayItem> Items { get; } = new(DisplayItemHelper.GetDisplayItems());

    [RelayCommand]
    private async Task ItemSelected(DisplayItem displayItem)
    {
        await Shell.Current.CurrentPage.DisplayAlert("Item Selected", $"The following item has been selected: {displayItem.Title}", "OK");
    }
}