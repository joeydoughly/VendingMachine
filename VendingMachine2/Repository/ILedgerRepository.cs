namespace VendingMachine2.Repository
{
    public interface ILedgerRepository
    {
        //Note there is no remove funcationaily as this is a ledger and should
        //Keep track of all actions including purchases and returns.
        public void AddPurchase(string purchaseLine);

        public IEnumerable<string> GetAllEntries();

        public string GetSingleEntry(int id);
    }
}
