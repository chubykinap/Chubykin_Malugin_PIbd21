using System.Runtime.Serialization;

namespace Classes.ViewModels
{
    [DataContract]
    public class AdminViewModel
    {
        [DataMember]
        public int ID { set; get; }

        [DataMember]
        public string Password { set; get; }

        [DataMember]
        public string Login { set; get; }

        [DataMember]
        public string Mail { set; get; }
    }
}
