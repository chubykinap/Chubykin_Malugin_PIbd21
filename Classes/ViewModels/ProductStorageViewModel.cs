using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class ProductStorageViewModel
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
