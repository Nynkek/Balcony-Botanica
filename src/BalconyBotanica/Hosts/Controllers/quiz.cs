using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Hosts.Models;
using Microsoft.AspNetCore.Mvc;

namespace BalconyBotanica.Hosts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewApiController : ControllerBase
    {
        public RecommendedPlants plantData()
        {
            //TODO: with the questions filled in, 
            // we generate an plant, or top 3, that fits the questions 

            return new RecommendedPlants();
        }
    }
}