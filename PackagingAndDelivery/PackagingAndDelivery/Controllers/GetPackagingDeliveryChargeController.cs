using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PackagingAndDelivery.Data;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PackagingAndDelivery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GetPackagingDeliveryChargeController :Controller
    {

        // GET api/<GetPackagingDeliveryCharge>/5
        [HttpGet("{ComponentType}/{Quantity}")]
        public IActionResult Get(string componentType, int Quantity, [FromHeader] string Authorization)
        {
            PackagingAndDelvieryChargeCalculation pdCharge = new PackagingAndDelvieryChargeCalculation();
            return Ok(pdCharge.TotalChargeCalculation(componentType, Quantity));
        }

    }
}
