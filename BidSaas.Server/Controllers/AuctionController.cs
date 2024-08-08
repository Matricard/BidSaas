using BidSaas.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidSaas.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly ILogger<AuctionController> _logger;

        public AuctionController(ILogger<AuctionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVehicleAuctionCost")]
        public IActionResult GetVehicleAuctionCost()
        {
            //if 200 return response with object -> VehicleAuctionCost 
            return Ok();
        }
    }
}
