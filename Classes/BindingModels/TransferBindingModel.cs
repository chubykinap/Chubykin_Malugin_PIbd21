using System;
using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
	public class TransferBindingModel
	{
        [DataMember]
		public int ID { set; get; }

        [DataMember]
		public int AdminId { set; get; }

        [DataMember]
		public int ProviderId { set; get; }

        [DataMember]
		public string StorageName { get; set; }

        [DataMember]
		public int ProductId { set; get; }

        [DataMember]
		public string ProductName { get; set; }

        [DataMember]
		public int Count { get; set; }

        [DataMember]
		public DateTime DateCreate { get; set; }
	}
}
