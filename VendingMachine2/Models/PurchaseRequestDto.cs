using System.Runtime.Serialization;

namespace VendingMachine2.Models
{
    public class PurchaseRequestDto
    {
        [DataMember]
        public string productType { get; set; }
    }
}
