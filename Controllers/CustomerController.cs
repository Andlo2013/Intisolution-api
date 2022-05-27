using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        ICustomerModel _model;

        public CustomerController(ICustomerModel model)
        {
            this._model = model;
        }

        // GET: CustomerController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customer>>> Index()
        {
            try
            {
                var data = await _model.Get();
                return Ok(data);
            }
            catch {
                return BadRequest("Error al procesar la solicitud");
            }
        }

        // GET: CustomerController
        [HttpGet("{customerId}")]
        public async Task<ActionResult<customer>> GetById(int customerId)
        {
            try
            {
                var data = await _model.GetByID(customerId);
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
        public async Task<ActionResult>Save(customer customer)
        {
            try
            {
                await _model.Save(customer);
                return Ok();
            }
            catch 
            {
                return BadRequest("Error al procesar la solicitud");
            }
        }



    }
}
