using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //====================   אובייקט של מוצרים  ================================

        //מוצרים
        static product p1 = new product() { ID = "100", Name = "Milk", Price = 5, Category = "aa" };
        static product p2 = new product() { ID = "101", Name = "Meat", Price = 58,Category = "bb" };
        static product p3 = new product() { ID = "102", Name = "Bread",Price = 7, Category = "cc" };
        static product p4 = new product() { ID = "103", Name = "Rice", Price = 10,Category = "dd" };
        static product p5 = new product() { ID = "104", Name = "Pasta",Price = 4, Category = "dd" };
        //רשימת של מוצרים
        static List<product> allProducts = new List<product>() { p1, p2, p3, p4, p5 };

        //====================   1   ================================
        // GET: api/Product
        [HttpGet("")]
        public ActionResult<List<product>> GetAllProduct()
        {
            //החזרה של רשימת המוצרים 
            //200= ok
            if (allProducts.Count>0)
            {
                return Ok(allProducts);
            }
            return Ok();

        }
        //===================   2   =================================
        // GET api/<Product>/5
        [HttpGet("{ID}")]
        public ActionResult<product> GetProductById(string ID)
        {
            product p = new product();
            p = allProducts.Find(e => e.ID == ID);
            return Ok( p);
        }
        //===================   3   =================================
        // POST api/<roductController>
        [HttpPost("")]
        public void createProduct([FromBody] product newProd)
        {
            allProducts.Add(newProd);
        }
        //===================   4   =================================
        // PUT api/<roductController>/5
        [HttpPut("{ID}")]
        public void updateProd(string ID,[FromBody] string value,string name,int price , string category)
        {

            product p = allProducts.Find((e) => e.ID == ID);
            if (p!=null)
            {
                p.Name = name;
                p.Price = price;
                p.Category = category;
               // Console.WriteLine(p);
            }
        }
        //===================   5   =================================
        // DELETE api/<roductController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            product p = allProducts.Find((e) => e.ID == id);
            allProducts.Remove(p);
            Console.WriteLine("!");


        }
        //===================   6   =================================
        [HttpGet("Name")]
        public ActionResult<product> GetProductByName(string name)
        {
            product p = allProducts.Find(e => e.Name == name);
            return Ok(p);
        }
        //===================   7   =================================
        [HttpGet("GetProductByCategory/{Category}")]
        public ActionResult<product> GetProductByCategory(string Category)
        {
            List<product> p = allProducts.FindAll(e => e.Category == Category);
            return Ok(p);
        }
        //===================   8   =================================
        [HttpPost("GetProductByPriceRange")]
        public ActionResult<product> GetProductByPriceRange([FromBody] string value,int nim ,int max)
        {
            List<product> p = allProducts.FindAll(e => e.Price>= nim && e.Price <= max);
            return Ok(p);
        }

        [HttpPost("הדר שירה היקרה!")]
        public ActionResult<product> אאא([FromBody] string value, int nim, int max)
        {
            List<product> p = allProducts.FindAll(e => e.Price >= nim && e.Price <= max);
            return Ok(p);
        }
    }
}
