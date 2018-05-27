using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class FoodViewModel
	{
        [DataMember]
        public int ID { set; get; }

        [DataMember]
        public string FoodName { set; get; }

        [DataMember]
        public List<ProductRequirementViewModel> ProductRequirements { get; set; }
	}
}
