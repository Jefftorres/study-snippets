using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = Products.Count() + 1;
            Products.Add(model);

            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        [HttpPut("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalEntry = Products.Single(x => x.Id == productId);

            originalEntry.Name = model.Name;
            originalEntry.Description = model.Description;
            originalEntry.Price = model.Price;

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            Products = Products.Where(x => x.Id != productId).ToList();

            return NoContent();
        }

        private static List<Product> Products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Guitarra eléctrica",
                Price = 1200,
                Description = "Ideal para tocar jazz, blues, rock clásico y afines."
            },
            new Product
            {
                Id = 2,
                Name = "Amplificador para guitarra eléctrica",
                Price = 699,
                Description = "Excelente amplificador con un sonido cálido."
            }
        };

    }
}
