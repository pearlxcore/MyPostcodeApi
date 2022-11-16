namespace MyPostcodeApi.Model
{
    public class PostcodeModel
    {
        public string state { get; set; }
        public List<Detail> detail { get; set; }
    }

    public class Detail
    {
        public string postcode { get; set; }
        public string address { get; set; }
        public string district { get; set; }
    }
}
