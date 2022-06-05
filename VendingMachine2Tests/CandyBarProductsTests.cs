using Moq;
using VendingMachine2.Models;
using VendingMachine2.Repository;
using VendingMachine2.Service;

namespace VendingMachine2Tests
{
    public class CandyBarProductsTests
    {
        CandyBarProduct _candyBarProduct;
        IVendingServices _vendingServices;
        Mock<ILedgerRepository> _ledgerRepo;

        Product _product;
        PurchaseInfo _purchaseInfo;

        public CandyBarProductsTests()
        {
            _candyBarProduct = new CandyBarProduct { InventoryInStock = 100};
            _ledgerRepo = new Mock<ILedgerRepository>();

            _purchaseInfo = new PurchaseInfo
            {
                PurchaseID = 111,
                Product = _candyBarProduct,
                DateTimeStamp = DateTime.Now,
                Quantity = 2
            };

            _vendingServices = new VendingServices(_candyBarProduct, _ledgerRepo.Object, _purchaseInfo);
        }

        [Fact]
        public void CandyBarProducts_VerifiesProductName()
        {
            Assert.Equal("Candy Bar", _candyBarProduct.ProductType);
        }

        [Fact]
        public void CandyBarProducts_VerifiesPrice()
        {
            Assert.Equal(.60m, _candyBarProduct.Price);
        }

        [Fact]
        public void CandyBarProducts_VerifiesPurchaseInventoryDecrement()
        {
            _vendingServices.RecordPurchaseTransaction();

            Assert.Equal(99, _candyBarProduct.InventoryInStock);
        }

        [Fact]
        public void CandyBarProducts_VerifiesReturnInventoryIncrement()
        {
            _candyBarProduct.InventoryInStock = 100;

            _vendingServices.RecordReturnTransaction();

            Assert.Equal(101, _candyBarProduct.InventoryInStock);
        }
    }
}