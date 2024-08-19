# TouchBehavior RelativeSource

[![Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/24313)](https://github.com/dotnet/maui/issues/24313)

Reproduction app for crashed caused by RelativeSource bindings

RelativeSource has never worked for the maui community toolkit touch behavior, it has been a major issue ever since we released this feature as it makes it extremely difficult to use the behavior in enumerated scenarios ie data templates. It also makes file independent data templates impossible.

## Walkthrough

To reproduce this issue:
- Load the sample app on any platform
- Click on the `x:Reference` example
- Click on any row & see the alert displayed
> This example uses `x:Reference` to the content page in order to set the command binding
- Navigate back to the landing page
- Click on the `RelativeSource` example
- Witness the app crash with the following stack trace:
```
System.InvalidOperationException: Operation is not valid due to the current state of the object.
   at Microsoft.Maui.Controls.Binding.ApplyRelativeSourceBinding(BindableObject targetObject, BindableProperty targetProperty, SetterSpecificity specificity)
   at System.Threading.Tasks.Task.<>c.<ThrowAsync>b__128_0(Object state)
   at Foundation.NSAsyncSynchronizationContextDispatcher.Apply() in /Users/builder/azdo/_work/1/s/xamarin-macios/src/Foundation/NSAction.cs:line 176
--- End of stack trace from previous location ---
   at ObjCRuntime.Runtime.ThrowException(IntPtr gchandle) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/ObjCRuntime/Runtime.cs:line 2594
   at UIKit.UIApplication.UIApplicationMain(Int32 argc, String[] argv, IntPtr principalClassName, IntPtr delegateClassName) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/UIKit/UIApplication.cs:line 60
   at UIKit.UIApplication.Main(String[] args, Type principalClass, Type delegateClass) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/UIKit/UIApplication.cs:line 94
   at TouchBehaviorRelativeBinding.Program.Main(String[] args) in /Users/axemasta/Documents/Dev/GitHub/TouchBehaviorRelativeSource/TouchBehaviorRelativeBinding/Platforms/iOS/Program.cs:line 13
2024-08-19 14:53:25.848207+0100 TouchBehaviorRelativeBinding[31391:15072770] Unhandled managed exception: Operation is not valid due to the current state of the object. (System.InvalidOperationException)
   at Microsoft.Maui.Controls.Binding.ApplyRelativeSourceBinding(BindableObject targetObject, BindableProperty targetProperty, SetterSpecificity specificity)
   at System.Threading.Tasks.Task.<>c.<ThrowAsync>b__128_0(Object state)
   at Foundation.NSAsyncSynchronizationContextDispatcher.Apply() in /Users/builder/azdo/_work/1/s/xamarin-macios/src/Foundation/NSAction.cs:line 176
--- End of stack trace from previous location ---
   at ObjCRuntime.Runtime.ThrowException(IntPtr gchandle) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/ObjCRuntime/Runtime.cs:line 2594
   at UIKit.UIApplication.UIApplicationMain(Int32 argc, String[] argv, IntPtr principalClassName, IntPtr delegateClassName) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/UIKit/UIApplication.cs:line 60
   at UIKit.UIApplication.Main(String[] args, Type principalClass, Type delegateClass) in /Users/builder/azdo/_work/1/s/xamarin-macios/src/UIKit/UIApplication.cs:line 94
   at TouchBehaviorRelativeBinding.Program.Main(String[] args) in /Users/axemasta/Documents/Dev/GitHub/TouchBehaviorRelativeSource/TouchBehaviorRelativeBinding/Platforms/iOS/Program.cs:line 13
```

![Video Demonstration](/assets/demonstration.mp4)

## Offending Code

The difference between the 2 samples are as follows:

```diff
<DataTemplate x:DataType="models:DisplayItem">
    <Grid ColumnDefinitions="Auto,*,Auto" RowDefinitions="*,*">
        <Grid.Behaviors>
            <mct:TouchBehavior DefaultOpacity="1"
                               PressedOpacity="0.8"
                               PressedBackgroundColor="LightGray"
                               DefaultBackgroundColor="White"
-                              Command="{Binding Source={x:Reference Root}, Path=BindingContext.ItemSelectedCommand}"
+                              Command="{Binding Source={RelativeSource Mode=FindAncestorBindingContext, AncestorType={x:Type viewmodels:ExampleViewModel}}, Path=ItemSelectedCommand}"
                               CommandParameter="{Binding .}"/>
    
        </Grid.Behaviors>
    </Grid>
</DataTemplate>
```