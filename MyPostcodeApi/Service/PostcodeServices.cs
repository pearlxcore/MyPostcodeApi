using Microsoft.Data.SqlClient;
using MyPostcodeApi.Model;

namespace MyPostcodeApi.Service
{
    public class PostcodeServices : IPostcodeService
    {
        public static readonly IReadOnlyList<string> ValidStates = new List<string>
        {
            "johor", "kedah", "kelantan", "kuala_lumpur", "labuan", "melaka",
            "negeri_sembilan", "pahang", "penang", "perak", "perlis",
            "putrajaya", "sabah", "sarawak", "selangor", "terengganu"
        };

        private static readonly HashSet<string> ValidStatesSet = new(ValidStates, StringComparer.OrdinalIgnoreCase);

        private readonly string _connectionString;
        private readonly ILogger<PostcodeServices> _logger;

        public PostcodeServices(IConfiguration configuration, ILogger<PostcodeServices> logger)
        {
            _connectionString = configuration.GetConnectionString("MyPostcodeDb")
                ?? throw new InvalidOperationException("Connection string 'MyPostcodeDb' is not configured.");
            _logger = logger;
        }

        public List<string> GetStates() => new(ValidStates);

        public async Task<PostcodeModel?> GetPostcodeByAddressAsync(string state, string address)
        {
            if (!ValidStatesSet.Contains(state))
                return null;

            var postcodeModel = new PostcodeModel { detail = new List<Detail>() };

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = $"SELECT * FROM {state} WHERE address = @address";

                await using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@address", address);

                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    postcodeModel.state = reader.GetString(3);
                    postcodeModel.detail.Add(new Detail
                    {
                        postcode = reader.GetString(0),
                        address = reader.GetString(1),
                        district = reader.GetString(2)
                    });
                }

                return postcodeModel.detail.Count > 0 ? postcodeModel : null;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error fetching postcode by address for state={State}", state);
                throw;
            }
        }

        public async Task<PostcodeModel?> GetPostcodeByDistrictAsync(string state, string district)
        {
            if (!ValidStatesSet.Contains(state))
                return null;

            var postcodeModel = new PostcodeModel { detail = new List<Detail>() };

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = $"SELECT * FROM {state} WHERE city = @district";

                await using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@district", district);

                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    postcodeModel.state = reader.GetString(3);
                    postcodeModel.detail.Add(new Detail
                    {
                        postcode = reader.GetString(0),
                        address = reader.GetString(1),
                        district = reader.GetString(2)
                    });
                }

                return postcodeModel.detail.Count > 0 ? postcodeModel : null;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error fetching postcode by district for state={State}", state);
                throw;
            }
        }

        public async Task<PostcodeModel?> GetByPostcodeAsync(string postcode)
        {
            var clauses = ValidStates.Select(s => $"SELECT * FROM {s} WHERE postcode = @postcode");
            var sql = string.Join(" UNION ALL ", clauses);

            var postcodeModel = new PostcodeModel { detail = new List<Detail>() };

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                await using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@postcode", postcode);

                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    postcodeModel.state = reader.GetString(3);
                    postcodeModel.detail.Add(new Detail
                    {
                        postcode = reader.GetString(0),
                        address = reader.GetString(1),
                        district = reader.GetString(2)
                    });
                }

                return postcodeModel.detail.Count > 0 ? postcodeModel : null;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error fetching postcode {Postcode}", postcode);
                throw;
            }
        }

        public async Task<DistrictList?> GetDistrictsByStateAsync(string state)
        {
            if (!ValidStatesSet.Contains(state))
                return null;

            var result = new DistrictList { state = state, districts = new List<string>() };

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var sql = $"SELECT DISTINCT city FROM {state} ORDER BY city";
                await using var command = new SqlCommand(sql, connection);

                await using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    result.districts.Add(reader.GetString(0));
                }

                return result.districts.Count > 0 ? result : null;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database error fetching districts for state={State}", state);
                throw;
            }
        }
    }
}
