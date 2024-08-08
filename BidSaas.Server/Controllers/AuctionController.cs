using BidSaas.Core.Models;
using BidSaas.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BidSaas.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly AuctionCalculator _auctionCalculator;


        public AuctionController(ILogger<AuctionController> logger)
        {
            _logger = logger;
            _auctionCalculator = new AuctionCalculator();
        }

        [HttpPost(Name = "GetVehicleAuctionCost")]
        public IActionResult GetVehicleAuctionCost([FromBody] Vehicle vehicle)
        {
            var auctionCost = _auctionCalculator.CalculateTotalPrice(vehicle);
            return Ok(new { Cost = auctionCost });
        }
    }
}