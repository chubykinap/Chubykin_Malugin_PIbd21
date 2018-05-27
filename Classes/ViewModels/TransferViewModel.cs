using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
	public class TransferViewModel
	{
        [DataMember]
		public int ID { get; set; }

        [DataMember]
        public int AdminId { set; get; }

        [DataMember]
        public string LoginA { get; set; }

        [DataMember]
        public int ProviderId { set; get; }

        [DataMember]
        public string LoginP { get; set; }

        [DataMember]
        public int StorageId { set; get; }

        [DataMember]
        public string StorageName { get; set; }

        [DataMember]
        public int ProductId { set; get; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string DateCreate { get; set; }
	}
}
