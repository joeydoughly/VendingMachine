namespace VendingMachine2.Models
{
    public interface IPurchaseInfo
    {
        public int PurchaseID { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public int Quantity { get; set; }

        public IProduct Product { get; set; }
    }
}