using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class ProductRequirementViewModel
	{
        [DataMember]
        public int ID { set; get; }

        [DataMember]
        public int FoodId { set; get; }

        [DataMember]
        public int ProductId { set; get; }

        [DataMember]
        public int Count { set; get; }

        [DataMember]
        public string ProductName { set; get; }

        [DataMember]
        public string FoodName { set; get; }
	}
}
