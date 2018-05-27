using System.Runtime.Serialization;

namespace WebView
{
    [DataContract]
    public class HttpErrorMessage
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string ExceptionMessage { get; set; }
        [DataMember]
        public string MessageDetail { get; set; }
    }
}
