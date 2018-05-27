using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int ID { set; get; }

        [DataMember]
        public string ProductName { set; get; }

        [DataMember]
        public List<ProductRequirementViewModel> ProductRequirements { get; set; }

        [DataMember]
        public List<ProductStorageViewModel> ProductStorages { get; set; }
	}
}
