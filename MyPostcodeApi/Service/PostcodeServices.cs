using Microsoft.Data.SqlClient;
using MyPostcodeApi.Model;

namespace MyPostcodeApi.Service
{
    public class PostcodeServices : IPostcodeService
    {
        public PostcodeModel GetPostcodeByAddressAsync(string state, string address)
        {
            var postcodeModel = new PostcodeModel();
            postcodeModel.detail = new List<Detail>();
            try
            {
                string cs = connection_string.connectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    string sql = $"SELECT * FROM {state} WHERE address='{address}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var postcode_ = reader.GetString(0);
                                var address_ = reader.GetString(1);
                                var city_ = reader.GetString(2);
                                var state_ = reader.GetString(3);
                                postcodeModel.state = state_;
                                postcodeModel.detail.Add(new Detail
                                {
                                    postcode = postcode_,
                                    address = address_,
                                    district = city_
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return postcodeModel;
        }

        public PostcodeModel GetPostcodeByDistrictAsync(string state, string district)
        {
            var postcodeModel = new PostcodeModel();
            postcodeModel.detail = new List<Detail>();
            try
            {
                string cs = connection_string.connectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    string sql = $"SELECT * FROM {state} WHERE city='{district}'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var postcode_ = reader.GetString(0);
                                var address_ = reader.GetString(1);
                                var city_ = reader.GetString(2);
                                var state_ = reader.GetString(3);

                                postcodeModel.state = state_;
                                postcodeModel.detail.Add(new Detail
                                {
                                    postcode = postcode_,
                                    address = address_,
                                    district = city_
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return postcodeModel;
        }
    }
}
