using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
	public class ProductBindingModel
	{
        [DataMember]
		public int ID { set; get; }
		
        [DataMember]
		public string ProductName { set; get; }
	}
}
