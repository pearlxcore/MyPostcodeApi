namespace MyPostcodeApi.Model
{
    public class PostcodeModel
    {
        public string state { get; set; } = string.Empty;
        public List<Detail> detail { get; set; } = new();
    }

    public class Detail
    {
        public string postcode { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string district { get; set; } = string.Empty;
    }

    public class DistrictList
    {
        public string state { get; set; } = string.Empty;
        public List<string> districts { get; set; } = new();
    }
}
