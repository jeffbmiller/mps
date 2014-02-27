using System;
using MonoTouch.UIKit;
using SegmentedControl;
using System.Drawing;

namespace MPS
{
    public class MainViewController : UIViewController
    {
		UIToolbar toolbar;

        public MainViewController()
        {
			Title = "Production Sequence";


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var shift1Button = new UIBarButtonItem ();
			shift1Button.Title = "Shift 1";
			shift1Button.Style = UIBarButtonItemStyle.Bordered;
			var shift2Button = new UIBarButtonItem ();
			shift2Button.Title = "Shift 2";
			shift2Button.Style = UIBarButtonItemStyle.Bordered;
			SetToolbarItems (new UIBarButtonItem[] {
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
				shift1Button,
				shift2Button,
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace)
			},false);
			NavigationController.ToolbarHidden = false;
            var labels = new [] { "Omega 3", "Herb", "RJ", "JD","RWA","NP", "NPO" };
            var segments = new SDSegmentedControl (labels) {
                Frame = new RectangleF (0, 0, 320, 44)
            };
            segments.ValueChanged += (sender, e) => {
                Console.WriteLine ("Selected " + segments.SelectedSegment);
                View.Add(new ProductionSegmentsTableView(new RectangleF (0, 44, View.Bounds.Width, View.Bounds.Height)));
                View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            };

            View.AddSubview (segments);
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
        }
    }
}

