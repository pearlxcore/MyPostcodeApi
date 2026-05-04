using Microsoft.AspNetCore.Mvc;
using MyPostcodeApi.Service;

namespace MyPostcodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostcodeController : ControllerBase
    {
        private readonly IPostcodeService _postcodeService;

        public PostcodeController(IPostcodeService postcodeService)
        {
            _postcodeService = postcodeService;
        }

        [HttpGet("States")]
        public ActionResult GetStates()
        {
            return Ok(_postcodeService.GetStates());
        }

        [HttpGet("ByPostcode")]
        public async Task<ActionResult> GetByPostcode(string postcode)
        {
            var result = await _postcodeService.GetByPostcodeAsync(postcode);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("ByAddress")]
        public async Task<ActionResult> GetPostcodeByAddress(string state, string address)
        {
            var result = await _postcodeService.GetPostcodeByAddressAsync(state, address);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("ByDistrict")]
        public async Task<ActionResult> GetPostcodeByDistrict(string state, string district)
        {
            var result = await _postcodeService.GetPostcodeByDistrictAsync(state, district);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("Districts")]
        public async Task<ActionResult> GetDistrictsByState(string state)
        {
            var districts = await _postcodeService.GetDistrictsByStateAsync(state);
            return districts is null ? NotFound() : Ok(districts);
        }
    }
}
