using MyPostcodeApi.Model;

namespace MyPostcodeApi.Service
{
    public interface IPostcodeService
    {
        PostcodeModel GetPostcodeByAddressAsync(string state, string address);
        PostcodeModel GetPostcodeByDistrictAsync(string state, string district);
    }
}
