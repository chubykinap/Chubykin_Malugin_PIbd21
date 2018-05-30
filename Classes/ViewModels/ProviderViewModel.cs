using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class ProviderViewModel
    {
        [DataMember]
        public int ID { set; get; }

        [DataMember]
        public string Login { set; get; }

        [DataMember]
        public string Password { get; set; }
    }
}
