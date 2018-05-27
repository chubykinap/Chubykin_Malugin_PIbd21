using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
    public class ProductRequirementBindingModel
	{
        [DataMember]
		public int ID { set; get; }
		
        [DataMember]
		public int FoodId { set; get; }
		
        [DataMember]
		public int ProductId { set; get; }

        [DataMember]
		public int Count { set; get; }
	}
}
