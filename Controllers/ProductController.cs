using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private IProductModel _model;

        public ProductController(IProductModel model)
        {
            _model = model;
        }



        // GET: CustomerController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            try
            {
                var data = await _model.Get();
                return Ok(data);
            }
            catch
            {
                return BadRequest("Error al procesar la solicitud");
            }
        }

        // GET: CustomerController
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            try
            {
                var data = await _model.GetByID(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch
            {
                return BadRequest("Error al procesar la solicitud");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Save(Product product)
        {
            try
            {
                await _model.Save(product);
                return Ok();
            }
            catch
            {
                return BadRequest("Error al procesar la solicitud");
            }
        }
    }
}
