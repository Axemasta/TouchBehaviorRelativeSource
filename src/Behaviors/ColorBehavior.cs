#if IOS || MACOS || MACCATALYST
using PlatformView = UIKit.UIView;
#elif ANDROID
using AndroidX.ConstraintLayout.Motion.Widget;

using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Tizen.NUI.BaseComponents.View;
#elif NET6_0_OR_GREATER || (NETSTANDARD || !PLATFORM)
using PlatformView = System.Object;
#endif

using System.Diagnostics;

namespace TouchBehaviorRelativeBinding.Behaviors;

public partial class ColorBehavior : PlatformBehavior<VisualElement>
{
    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(ColorBehavior),
        null ,
        propertyChanged: UpdateColor);
    
    public Color? Color
    {
        get => (Color?)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    
    private static void UpdateColor(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is ColorBehavior colorBehavior)
        {
            colorBehavior.UpdateColor();
        }
    }

    private void UpdateColor()
    {
        if (View is null)
        {
            return;
        }
        
        View.BackgroundColor = Color;

        AnnounceColors();
    }
    
    protected VisualElement? View { get; set; }
    
    protected override void OnAttachedTo(VisualElement bindable, PlatformView platformView)
    {
        base.OnAttachedTo(bindable, platformView);
        
        View = bindable;
        UpdateColor();
        
        Application.Current.RequestedThemeChanged += OnAppThemeChanged;
    }

    private void OnAppThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        UpdateColor();
    }

    private void AnnounceColors()
    {
        var isRed = Color == Colors.Red; // Dark
        var isBlue = Color == Colors.Blue; // Light

        if (isRed)
        {
            Debug.WriteLine($"The color was red (dark) when app theme is {Application.Current.RequestedTheme}");
        }
        else if (isBlue)
        {
            Debug.WriteLine($"The color was blue (light) when app theme is {Application.Current.RequestedTheme}");
        }
        else
        {
            throw new InvalidOperationException("The color was not set to red or blue...");
        }
    }
}