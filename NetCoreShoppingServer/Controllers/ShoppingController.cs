using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetCoreAngularExample.Data;
using NetCoreShoppingServer.Hubs;
using ShoppingShared.Models;

namespace NetCoreAngularExample.Controllers
{
    [Route("/shopping")]
    [ApiController]
    [Produces("application/json")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShopping _shopping;
        private readonly IHubContext<ShoppingHub> _shoppingHubContext;

        public ShoppingController(IShopping shopping, IHubContext<ShoppingHub> shoppingHubContext)
        {
            _shopping = shopping;
            _shoppingHubContext = shoppingHubContext;
        }

        [HttpGet]
        public IEnumerable<Shopping> Get()
        {
            var shoppingData = _shopping.GetAll();
            return shoppingData;
        }

        [HttpGet("{id}")]
        public Shopping Get(int id)
        {
            var shopping = _shopping.FindById(id);
            return shopping;
        }

        [HttpPut("{id}")]
        public Shopping Put(int id, [FromForm]string name)
        {
            var shopping = _shopping.SaveOrUpdate(id, name);
            
            _shoppingHubContext.Clients.All.SendAsync("ReceiveMessage", shopping);

            return shopping;
        }

        [HttpPost]
        public Shopping AddItem([FromForm] int shoppingId, [FromForm] string item)
        {
            var shopping = _shopping.AddItem(shoppingId, item);
            return shopping;
        }

        [HttpDelete("{id}/item/{item}")]
        public void Delete(int id, string item)
        {
            _shopping.DeleteItem(id, item);
        }
    }
}
