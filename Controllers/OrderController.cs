using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderModel _model;
        
        public OrderController(IOrderModel model)
        {
            _model = model;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Index()
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
        public async Task<ActionResult<Order>> GetById(int id)
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
        public async Task<ActionResult> Save(Order order)
        {
            try
            {
                await _model.Save(order);
                return Ok();
            }
            catch
            {
                return BadRequest("Error al procesar la solicitud");
            }
        }

    }
}
