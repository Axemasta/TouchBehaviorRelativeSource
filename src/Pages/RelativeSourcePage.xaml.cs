using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchBehaviorRelativeBinding.ViewModels;

namespace TouchBehaviorRelativeBinding.Pages;

public partial class RelativeSourcePage : ContentPage
{
    public RelativeSourcePage(ExampleViewModel exampleViewModel)
    {
        InitializeComponent();
        
        BindingContext = exampleViewModel;
    }
}