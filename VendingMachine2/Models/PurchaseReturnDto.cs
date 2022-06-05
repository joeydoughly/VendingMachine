using System.Runtime.Serialization;

namespace VendingMachine2.Models
{
    public class PurchaseReturnDto
    {
        [DataMember]
        public string productType { get; set; }
    }
}
