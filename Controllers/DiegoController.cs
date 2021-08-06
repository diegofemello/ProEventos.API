using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiegoController : ControllerBase
    {
        public DiegoController()
        {
            
        }

        [HttpGet]
        public string Get()
        {
            return "value";

        }
    }
}
