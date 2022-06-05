using Microsoft.AspNetCore.Mvc;
using System.Net;
using VendingMachine2.Models;
using VendingMachine2.Repository;
using VendingMachine2.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachine2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        // GET: api/<VendingMachineController>
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //Would be created in startup
            ILedgerRepository _ledgerRepository;

            var result = _ledgerRepository.GetAllEntries();

            return new HttpResponseMessage(HttpStatusCode.OK, result);
        }

        // GET: api/<VendingMachineController>/5
        public HttpResponseMessage Get(int id)
        {
            //Would be created in startup
            ILedgerRepository _ledgerRepository;

            var result = _ledgerRepository.GetSingleEntry(id);

            return new HttpResponseMessage(HttpStatusCode.OK, result);
        }

        [Route("api/vendingmachine/purchase")]
        [HttpPost]
        public HttpResponseMessage Post(PurchaseRequestDto purchaseRequestDto)
        {
            IPurchaseInfo purchaseInfo = new PurchaseInfo();
            if (purchaseRequestDto.productType == "Chips")
            {
                purchaseInfo.Product = new ChipsProduct();
            }
            if (purchaseRequestDto.productType == "Soda")
            {
                purchaseInfo.Product = new SodaProduct();
            }
            if (purchaseRequestDto.productType == "Candy Bar")
            {
                purchaseInfo.Product = new CandyBarProduct();
            }
            purchaseInfo.Product = new ChipsProduct();
                var vendingServices = new VendingServices(_ledgerRepostiory, purchaseInfo);

                vendingServices.RecordPurchaseTransaction();
            }

            return new HttpResponseMessage(HttpStatusCode.Ok, purchaseRequestDto);
        }
        
        [Route("api/vendingmachine/return")]
        [HttpPost]
        public HttpResponseMessage Post(PurchaseRequestDto purchaseReturnDto)
        {

            IPurchaseInfo purchaseInfo = new PurchaseInfo();
            if (purchaseReturnDto.productType == "Chips")
            {
                purchaseInfo.Product = new ChipsProduct();
            }
            if(purchaseReturnDto.productType == "Soda")
            {
                purchaseInfo.Product = new SodaProduct();
            }
            if (purchaseReturnDto.productType == "Candy Bar")
            {
                purchaseInfo.Product = new CandyBarProduct();
            }
            
            var vendingServices = new VendingServices(_ledgerRepostiory, purchaseInfo);

            vendingServices.RecordReturnTransaction();
            
            return new HttpResponseMessage(HttpStatusCode.Ok, purchaseRequestDto);
        }

    }
}
