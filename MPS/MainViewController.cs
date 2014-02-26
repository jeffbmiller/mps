using System;
using MonoTouch.UIKit;
using SegmentedControl;
using System.Drawing;

namespace MPS
{
    public class MainViewController : UIViewController
    {
        public MainViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var labels = new [] { "Omega 3", "Herb", "RJ", "JD","RWA","NP", "NPO" };
            var segments = new SDSegmentedControl (labels) {
                Frame = new RectangleF (0, 0, 320, 44)
            };
            segments.ValueChanged += (sender, e) => {
                Console.WriteLine ("Selected " + segments.SelectedSegment);
                View.Add(new ProductionSegmentsTableView(new RectangleF (0, 44, View.Bounds.Width, View.Bounds.Height)));
            };

            View.AddSubview (segments);
        }
    }
}

