# How to add multiple trackballs in Xamarin.Forms Chart (SfChart)?

[SfChart](https://help.syncfusion.com/xamarin/charts/getting-started) allows you add multiple trackballs to a single chart and drag them independently to view the information of different data points at the same time.

The following steps describe how to add multiple trackballs to [SfChart](https://help.syncfusion.com/xamarin/charts/getting-started):

**Step 1:** Create a custom ChartTrackballBehaviorExt class, which is inherited from [ChartTrackballBehavior](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfChart.XForms.ChartTrackballBehavior.html).
```
public class ChartTrackballBehaviorExt : ChartTrackballBehavior
{
}
```

**Step 2:** Create an instance of ChartTrackballBehaviorExt, and add it to the **ChartBehaviors** collection.
```
<chart:SfChart.ChartBehaviors>
     <local:ChartTrackballBehaviorExt />
     <local:ChartTrackballBehaviorExt />
</chart:SfChart.ChartBehaviors>
```

**Step 3:** Activate the multiple trackballs at load time using the [Show](https://help.syncfusion.com/xamarin/charts/trackball#methods) method.
```
protected override void OnAppearing()
{
    base.OnAppearing();
 
    Task.Run(async () =>
    {
        await ShowTrackball();
    });
}
 
async Task ShowTrackball()
{
    Task.Delay(1000).Wait();
 
    Device.BeginInvokeOnMainThread(() =>
    {
        trackballBehavior1.Show(pointX, pointY);
        trackballBehavior2.Show(pointX, pointY);
    });
}
```

**Step 4:** Set [ActivationMode](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfChart.XForms.ChartTrackballBehavior.html#Syncfusion_SfChart_XForms_ChartTrackballBehavior_ActivationMode) to [None](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfChart.XForms.ChartTrackballActivationMode.html) to restrict the default movement of the trackball behavior.
```
<chart:SfChart.ChartBehaviors>
    <local:ChartTrackballBehaviorExt ActivationMode="None" x:Name="trackballBehavior1" />
    <local:ChartTrackballBehaviorExt ActivationMode="None" x:Name="trackballBehavior2" />
</chart:SfChart.ChartBehaviors>
```

**Step 5:** Interact with multiple trackballs by overriding the touch methods of ChartTrackballBehavior class and the [HitTest](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfChart.XForms.ChartTrackballBehavior.html#Syncfusion_SfChart_XForms_ChartTrackballBehavior_HitTest_System_Single_System_Single_) method. The HitTest method is used to find the trackball that is currently activated by user.
```
public class ChartTrackballBehaviorExt : ChartTrackballBehavior
{
    bool isActivated = false;
                
    protected override void OnTouchDown(float pointX, float pointY)
    {
        if (HitTest(pointX, pointY))
        {
            isActivated = true;
            base.OnTouchDown(pointX, pointY);
        }
    }
 
    protected override void OnTouchMove(float pointX, float pointY)
    {
        if (isActivated)
        {
            Show(pointX, pointY);
            base.OnTouchMove(pointX, pointY);
        }
    }
 
    protected override void OnTouchUp(float pointX, float pointY)
    {
        isActivated = false;
    }
}
```

**Step 6:** Tap and drag each trackball separately to view the data points at different positions simultaneously.

## Output:

![Xamarin.Forms multiple trackball behavior](https://user-images.githubusercontent.com/53489303/200632320-b3b8b3d3-faf7-49e6-895c-64be2917ab47.gif)

KB article - [How to add multiple trackballs in Xamarin.Forms Chart?](https://www.syncfusion.com/kb/10400/how-to-add-multiple-trackballs-in-xamarin-forms-chart)

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.


