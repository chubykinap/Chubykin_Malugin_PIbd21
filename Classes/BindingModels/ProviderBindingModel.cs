using System.Runtime.Serialization;

namespace Classes.BindingModels
{
    [DataContract]
    public class ProviderBindingModel
	{
        [DataMember]
		public int ID { set; get; }
		
        [DataMember]
		public string Login { set; get; }
		
        [DataMember]
		public string Password { set; get; }
	}
}
