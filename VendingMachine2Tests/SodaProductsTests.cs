using Microsoft.Extensions.Logging;
using Moq;
using VendingMachine2.Models;
using VendingMachine2.Repository;
using VendingMachine2.Service;

namespace VendingMachine2Tests
{
    public class SodaProductsTests
    {
        SodaProduct _sodaProduct;
        IVendingServices _vendingServices;
        Mock<ILedgerRepository> _ledgerRepo;

        Product _product;
        PurchaseInfo _purchaseInfo;

        public SodaProductsTests()
        {
            _sodaProduct = new SodaProduct { InventoryInStock = 100 };
            _ledgerRepo = new Mock<ILedgerRepository>();

            _purchaseInfo = new PurchaseInfo
            {
                PurchaseID = 111,
                Product = _sodaProduct,
                DateTimeStamp = DateTime.Now,
                Quantity = 2
            };

            _vendingServices = new VendingServices(_ledgerRepo.Object, _purchaseInfo, Mock.Of<ILogger<VendingServices>>());
        }

        [Fact]
        public void SodaProducts_VerifiesProductName()
        {
            Assert.Equal("Soda", _sodaProduct.ProductType);
        }

        [Fact]
        public void SodaProducts_VerifiesPrice()
        {
            Assert.Equal(.95m, _sodaProduct.Price);
        }

        [Fact]
        public void SodaProducts_VerifiesPurchaseInventoryDecrement()
        {
            _vendingServices.RecordPurchaseTransaction();

            Assert.Equal(99, _sodaProduct.InventoryInStock);
        }

        [Fact]
        public void SodaProducts_VerifiesReturnInventoryIncrement()
        {
            _sodaProduct.InventoryInStock = 100;

            _vendingServices.RecordReturnTransaction();

            Assert.Equal(101, _sodaProduct.InventoryInStock);
        }
    }
}