using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace SfChartMultipleTrackball
{
    public class ChartTrackballBehaviorExt : ChartTrackballBehavior
    {
        bool isActivate = false;

        protected override void OnTouchDown(float pointX, float pointY)
        {
            var chart = (Chart as ChartExt);
            if (!chart.IsTrackballSelected)
            {
                if (HitTest(pointX, pointY))
                {
                    isActivate = true;
                    base.OnTouchDown(pointX, pointY);
                    chart.IsTrackballSelected = true;
                }
            }
        }

        protected override void OnTouchMove(float pointX, float pointY)
        {
            if (isActivate)
            {
                Show(pointX, pointY);
                base.OnTouchMove(pointX, pointY);
            }
        }

        protected override void OnTouchUp(float pointX, float pointY)
        {
            isActivate = false;
            (Chart as ChartExt).IsTrackballSelected = false;
        }
    }

    public class ChartExt : SfChart
    {
        // Used to activate the first trackball, if multiple trackballs are placed in the same position.
        internal bool IsTrackballSelected { get; set; } = false;
    }
}
