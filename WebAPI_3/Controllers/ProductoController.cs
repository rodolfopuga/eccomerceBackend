using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_3.Contexts;
using WebAPI_3.Models;

namespace WebAPI_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }


        // GET api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return context.Producto.ToList();
        }

        // GET api/<controller>
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(string id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.pro_id==id);
            return producto;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {

                producto.imgstring = producto.imgstring.Replace("data:image/jpeg;base64,", "");
                producto.imgstring = producto.imgstring.Replace("data:image/png;base64,", "");
                producto.imgstring = producto.imgstring.Replace("data:image/jpg;base64,", "");

                byte[] file;
                file = Convert.FromBase64String(producto.imgstring);
                producto.pro_img = file;
                context.Producto.Add(producto);
                context.SaveChanges();
                 return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
        }

        // PUT api/<controller>
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] Producto producto)
        {
            if(producto.pro_id == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.pro_id == id);
            if (producto != null)
            {
                context.Producto.Remove(producto);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}