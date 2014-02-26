using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;

namespace MPS
{
    public class ProductionSegmentsTableView : UITableView
    {
        public ProductionSegmentsTableView(System.Drawing.RectangleF frame):base(frame, UITableViewStyle.Grouped)
        {
            Source = new MyTableViewSource(new List<string>(){"12345 Product A - Chilled","54321 Product B - Frozen"});

        }
    }

    public class MyTableViewSource : UITableViewSource
    {
        private List<string> tableItems;
        string cellIdentifier = "MyCell";
        public MyTableViewSource(List<string> tableItems)
        {
            this.tableItems = tableItems;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as ProductionSegmentCell;
            if (cell == null)
                cell = new ProductionSegmentCell(cellIdentifier);
            cell.UpdateCell(tableItems[indexPath.Row]);
            return cell;
        }
    }

    public class ProductionSegmentCell: UITableViewCell
    {
        UILabel titleLabel;

        public ProductionSegmentCell(string cellId):base(UITableViewCellStyle.Default, cellId)
        {
            ContentView.BackgroundColor = UIColor.Blue;
            titleLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica-Bold", 12f),
                TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear
            };
            ContentView.Add(titleLabel);
        }

        public void UpdateCell(string title)
        {
            titleLabel.Text = title;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            titleLabel.Frame  = new RectangleF(5, 1, ContentView.Bounds.Width, 25);
        }
    }
}

