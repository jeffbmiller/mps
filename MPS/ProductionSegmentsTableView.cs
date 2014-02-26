using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using System.Linq;

namespace MPS
{
    public class ProductionSegmentsTableView : UITableView
    {
        public ProductionSegmentsTableView(System.Drawing.RectangleF frame):base(frame, UITableViewStyle.Grouped)
        {
            Source = new MyTableViewSource(new HogType());

        }
    }

    public class MyTableViewSource : UITableViewSource
    {
        private HogType hogType;
        string cellIdentifier = "MyCell";
        public MyTableViewSource(HogType hogType)
		{
			this.hogType = hogType;
		}

        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as ProductionSegmentCell;
            if (cell == null)
                cell = new ProductionSegmentCell(cellIdentifier);
			cell.UpdateCell(hogType.Segments[indexPath.Section].SegQtys[indexPath.Row]);
            return cell;
        }

		public override int NumberOfSections (UITableView tableView)
		{
			return hogType.Segments.Count;
		}
		public override int RowsInSection (UITableView tableview, int section)
		{
			return hogType.Segments[section].SegQtys.Count;
		}
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return hogType.Segments[section].ToString();
		}
    }

    public class ProductionSegmentCell: UITableViewCell
    {
        UILabel titleLabel;
		UILabel cartonsLabel;
		UILabel piecesLabel;

        public ProductionSegmentCell(string cellId):base(UITableViewCellStyle.Default, cellId)
        {
            ContentView.BackgroundColor = UIColor.Blue;
            titleLabel = new UILabel()
            {
                Font = UIFont.FromName("Helvetica-Bold", 15f),
                TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear
            };
            ContentView.Add(titleLabel);
			cartonsLabel = new UILabel()
			{
				Font = UIFont.FromName("Helvetica-Bold", 12f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear
			};
			ContentView.Add(cartonsLabel);
			piecesLabel = new UILabel()
			{
				Font = UIFont.FromName("Helvetica-Bold", 12f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear
			};
			ContentView.Add(piecesLabel);
        }

        public void UpdateCell(SegmentQty segQty)
        {
            titleLabel.Text = segQty.Product;
			piecesLabel.Text = string.Format ("Pieces: {0}", segQty.Pieces.ToString ());
			cartonsLabel.Text = string.Format ("Cartons: {0}", segQty.Cartons.ToString ());
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            titleLabel.Frame  = new RectangleF(5, 1, ContentView.Bounds.Width, 25);
			piecesLabel.Frame  = new RectangleF(5, 15, ContentView.Bounds.Width, 25);
			cartonsLabel.Frame  = new RectangleF(75, 15, ContentView.Bounds.Width, 25);
        }
    }
}

