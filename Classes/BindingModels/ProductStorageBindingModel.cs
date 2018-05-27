using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
	public class ProductStorageBindingModel
	{
        [DataMember]
		public int ID { set; get; }
		
        [DataMember]
		public int StorageId { set; get; }
		
        [DataMember]
		public int ProductId { set; get; }

        [DataMember]
		public int Count { set; get; }
	}
}
