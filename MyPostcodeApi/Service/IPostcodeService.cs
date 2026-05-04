using MyPostcodeApi.Model;

namespace MyPostcodeApi.Service
{
    public interface IPostcodeService
    {
        Task<PostcodeModel?> GetPostcodeByAddressAsync(string state, string address);
        Task<PostcodeModel?> GetPostcodeByDistrictAsync(string state, string district);
        Task<PostcodeModel?> GetByPostcodeAsync(string postcode);
        Task<DistrictList?> GetDistrictsByStateAsync(string state);
        List<string> GetStates();
    }
}
