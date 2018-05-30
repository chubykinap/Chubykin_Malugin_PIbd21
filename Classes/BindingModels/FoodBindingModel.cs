using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
    public class FoodBindingModel
	{
        [DataMember]
		public int ID { set; get; }

        [DataMember]
		public string FoodName { set; get; }

        [DataMember]
        public List<ProductRequirementBindingModel> ElementRequirement { get; set; }
    }
}
