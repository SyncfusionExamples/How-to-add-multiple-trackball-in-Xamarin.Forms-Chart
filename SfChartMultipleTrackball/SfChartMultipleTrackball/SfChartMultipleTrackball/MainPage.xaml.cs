using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SfChartMultipleTrackball
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
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
                trackballBehavior1.Show((float)chart.ValueToPoint(chart.PrimaryAxis, new DateTime(2000, 9, 14).ToOADate()), (float)chart.ValueToPoint(chart.SecondaryAxis, 55));
                trackballBehavior2.Show((float)chart.ValueToPoint(chart.PrimaryAxis, new DateTime(2005, 2, 11).ToOADate()), (float)chart.ValueToPoint(chart.SecondaryAxis, 60));
            });
        }
    }
}