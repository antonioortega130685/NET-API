using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        
        [HttpGet]
        public Product[] List() {
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet ("{id}")]
        public Product Get (int id) {
            if (FakeData.Products.ContainsKey(id))
                return FakeData.Products[id];
            else
                return null;
        }

        [HttpPost]
        public Product CreateProduct([FromBody]Product product){
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return product; 
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody]Product product){
            if (FakeData.Products.ContainsKey(id)){
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id){
            if (FakeData.Products.ContainsKey(id)){
                FakeData.Products.Remove(id);
            }
        }
    }
}