using Microsoft.AspNetCore.Mvc;
using MyPostcodeApi.Service;

namespace MyPostcodeApi.Controllers
{
    [ApiController]
    [Route("api/postcode")]
    public class PostcodeController : ControllerBase
    {
        private readonly IPostcodeService postcodeService;

        public PostcodeController(IPostcodeService postcodeService)
        {
            this.postcodeService=postcodeService;
        }

        [HttpGet("ByAddress")]
        public ActionResult GetPostcodeByAddressAsync(string state, string address)
        {
            var postcode = postcodeService.GetPostcodeByAddressAsync(state, address);
            return postcode == null ? NotFound("Unsupported input state: https://github.com/pearlxcore/MyPostcodeApi#state-list") : Ok(postcode);
        }

        [HttpGet("ByDistrict")]
        public ActionResult GetPostcodeByDistrictAsync(string state, string district)
        {
            var postcode = postcodeService.GetPostcodeByDistrictAsync(state, district);
            return postcode == null ? NotFound("Unsupported input state: https://github.com/pearlxcore/MyPostcodeApi#state-list") : Ok(postcode);
        }
    }
}
