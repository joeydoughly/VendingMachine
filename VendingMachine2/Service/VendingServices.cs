using VendingMachine2.Models;
using VendingMachine2.Repository;

namespace VendingMachine2.Service
{
    public class VendingServices : IVendingServices
    {
        private readonly ILedgerRepository _ledgerRepository;
        private readonly PurchaseInfo _purchaseInfo;
        private readonly ILogger _logger;


        public VendingServices(
            ILedgerRepository ledgerRepository,
            PurchaseInfo purchaseInfo,
            ILogger logger)
        {
            _ledgerRepository = ledgerRepository;
            _purchaseInfo = purchaseInfo;
            _logger = logger;
        }

        //Coupled the writing to the ledger as well as decrementing stock to make sure
        //everything is tracked.
        public void RecordPurchaseTransaction()
        {
            string record = "Purchase - " + _purchaseInfo.PurchaseID +
                            "Quanitity - " + _purchaseInfo.Quantity +
                            "Product - " + _purchaseInfo.Product.ProductType +
                            "Price -  " + _purchaseInfo.Product.Price;

            _logger.LogInformation(record);
            try
            {
                _ledgerRepository.AddPurchase(record);

            }
            catch (Exception ex)
            {
                throw new("Unable to update ledger at this time.");
            }

            _purchaseInfo.Product.InventoryInStock--;
        }

        //Coupled the writing to the ledger as well as returning stock to make sure
        //everything is tracked.
        public void RecordReturnTransaction()
        {
            string record = "Returned - " + _purchaseInfo.PurchaseID +
                            "Quanitity - " + _purchaseInfo.Quantity +
                            "Product - " + _purchaseInfo.Product.ProductType +
                            "Price -  " + _purchaseInfo.Product.Price;

            _logger.LogInformation(record);

            try
            {
                _ledgerRepository.AddPurchase(record);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to update ledger at this time.");
            }

            _purchaseInfo.Product.InventoryInStock++;
        }

        private bool OkToPurchase()
        {
            if (_purchaseInfo.Product.InventoryInStock > 0)
            {
                return true;
            }
            return false;
        }
    }
}
