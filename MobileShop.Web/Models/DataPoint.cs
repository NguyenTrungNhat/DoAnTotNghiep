using System.Runtime.Serialization;

namespace MobileShop.Web.Models
{
	[DataContract]
	public class DataPoint
	{
		public DataPoint(string label, double y)
		{
			this.label = label;
			this.Y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string label;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
	}
}