using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VendingMachineWebAPI.Models;
using VendingMachineWebAPI.Models.EF;

namespace VendingMachineWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [Route("items/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            // Entity Framework...
            var repository = new ItemCatalogEntities();
            return Ok(repository.Items);
            
            // Item Repository....
            //return Ok(ItemRepository.GetAll());
        }

        [Route("money/{amount}/item/{itemid}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Purchase(decimal amount, int itemId)
        {
            // Entity Framework...
            //var repository = new ItemCatalogEntities();
            //Item item = repository.Items.FirstOrDefault(i => i.ItemId == itemId);

            // Item Repository....
            Item item = ItemRepository.GetItem(itemId);

            if (item == null)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError("Invalid item selected")
                ));
                //return BadRequest("Invalid item selected");
            }
            else if (item.Quantity <= 0)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError("SOLD OUT!!!")
                ));
            }
            else if (amount < item.Price)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                   Request.CreateErrorResponse(
                       (HttpStatusCode)422,
                       new HttpError($"Please deposit: {amount}")
                   ));
            }
            else
            {
                amount -= item.Price;
                item.Quantity -= 1;
                return Ok(ReturnChange(amount));
            }
        }

        private Change ReturnChange(decimal balance)
        {
            Change change = new Change();

            change.Quarters = Convert.ToInt32(Decimal.Truncate(balance / 0.25M));
            balance%= 0.25M;
            change.Dimes = Convert.ToInt32(Decimal.Truncate(balance / 0.10M));
            balance %= 0.10M;
            change.Nickels = Convert.ToInt32(Decimal.Truncate(balance / 0.05M));
            balance %= 0.05M;
            change.Pennies = Convert.ToInt32(Decimal.Truncate(balance / 0.01M)); 
           
            return change;
        }

    }
}