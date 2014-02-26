using System;
using System.Collections.Generic;
using System.Linq;

namespace MPS
{
	public class HogType
	{
		public HogType ()
		{
			Segments = new List<ProductionSegments> ();
            Segments.Add(new ProductionSegments(new List<string>(){"12345 Product A - Chilled","54321 Product B - Chilled","11111 Product E - Frozen","1000 Product Z - Frozen"},1,100) );
			Segments.Add(new ProductionSegments(new List<string>(){"12345 Product C - Chilled","54321 Product D - Frozen"},101,500) );

		}

		public List<ProductionSegments> Segments {get;set;}
	}

	public class ProductionSegments
	{
		public ProductionSegments (List<string> products, int startPiece, int endPiece)
		{
			SegQtys = products.Select (x => new SegmentQty (x)).ToList();
            SegQtys.First().ProductionType = "Primary";
            SegQtys[1].ProductionType = "Accumulating";
            if (SegQtys.Count >3)
                SegQtys[2].ProductionType = "Accumulating";
			StartingPiece = startPiece;
			EndingPiece = endPiece;
		}
		public List<SegmentQty> SegQtys { get; set; }
		public int StartingPiece { get; set; }
		public int EndingPiece { get; set; }

		public override string ToString ()
		{
			return string.Format ("{0} - {1}",StartingPiece, EndingPiece);
		}
	}

	public class SegmentQty
	{

		public SegmentQty (string product)
		{
			this.Product = product;
		}
		public string Product { get; set; }
		public int Pieces { get { return 5; } }
		public int Cartons { get { return 2; } }
        public string ProductionType {get;set;}
        public string DemandType { get {return "Order";}}
        public string PO { get; set; }
        public int PassRate { get; set; }

        public override string ToString()
        {
            return string.Format("Prod Type:{0} Demand Type:{1} PO:{2} Pieces:{3} Cartons:{4}  PassRate:{5}%", ProductionType, DemandType, PO,Pieces,Cartons, PassRate);
        }

	}
}

