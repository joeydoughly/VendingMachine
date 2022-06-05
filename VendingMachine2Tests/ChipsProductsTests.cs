using Moq;
using VendingMachine2.Models;
using VendingMachine2.Repository;
using VendingMachine2.Service;

namespace VendingMachine2Tests
{
    public class ChipsProductsTests
    {
        ChipsProduct _chipsProduct;
        IVendingServices _vendingServices;
        Mock<ILedgerRepository> _ledgerRepo;

        Product _product;
        PurchaseInfo _purchaseInfo;

        public ChipsProductsTests()
        {
            _chipsProduct = new ChipsProduct { InventoryInStock = 100 };
            _ledgerRepo = new Mock<ILedgerRepository>();

            _purchaseInfo = new PurchaseInfo
            {
                PurchaseID = 111,
                Product = _chipsProduct,
                DateTimeStamp = DateTime.Now,
                Quantity = 2
            };

            _vendingServices = new VendingServices(_chipsProduct, _ledgerRepo.Object, _purchaseInfo);
        }

        [Fact]
        public void ChipsProducts_VerifiesProductName()
        {
            Assert.Equal("Chips", _chipsProduct.ProductType);
        }

        [Fact]
        public void ChipsProducts_VerifiesPrice()
        {
            Assert.Equal(.99m, _chipsProduct.Price);
        }

        [Fact]
        public void ChipsProducts_VerifiesPurchaseInventoryDecrement()
        {
            _vendingServices.RecordPurchaseTransaction();

            Assert.Equal(99, _chipsProduct.InventoryInStock);
        }

        [Fact]
        public void ChipsProducts_VerifiesReturnInventoryIncrement()
        {
            _chipsProduct.InventoryInStock = 100;

            _vendingServices.RecordReturnTransaction();

            Assert.Equal(101, _chipsProduct.InventoryInStock);
        }
    }
}