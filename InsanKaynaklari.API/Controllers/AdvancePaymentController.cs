using InsanKaynaklari.Business.Manager.Abstract;
using InsanKaynaklari.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsanKaynaklari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancePaymentController : ControllerBase
    {
        private readonly IGeneralService<AdvancePayment> _advancePaymentService;
        public AdvancePaymentController(IGeneralService<AdvancePayment> advancePaymentService)
        {
            _advancePaymentService = advancePaymentService;
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonel(int id)
        {
            var advPayment = _advancePaymentService.GetAllAsync(x=>x.PersonelID==id);
           
            return Ok(advPayment);
        }
        [HttpGet("{id}")]
        public IActionResult GetAdvancePayment(int id)
        {
            var advPayment = _advancePaymentService.GetAllAsync(x => x.ID == id);

            return Ok(advPayment);
        }

    }
}
