using BookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly SqlConnection _connection;
        public BookingController(IConfiguration config) 
        {
            _connection = new SqlConnection(config.GetConnectionString("connString"));
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<JsonResult> Get(int? start, int? end)
        {

            try
            {

                List<MBooking> bookings = new List<MBooking>();
                JsonResult result = new JsonResult(bookings);

                //Set defaults for start and end indeces if not given
                start = start ?? 0;
                end = end ?? 100;

                end = end > 1000 ? 100 : end;

                //Connect to database then read booking records
                _connection.OpenAsync().Wait();

                using (SqlCommand command = new SqlCommand("spSelectAllBookings", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("start", SqlDbType.Int).Value = start;
                    command.Parameters.AddWithValue("end", SqlDbType.Int).Value = end;

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        bookings.Add(new MBooking
                        {
                            BookingId = reader.GetInt64(0),
                            ExternalSchemeAdmin = reader.GetString(1),
                            CourseDate = reader.GetDateTime(2).Date.ToString(),
                            BookingType = reader.GetString(3),
                            RetirementSchemeName = reader.GetString(4),
                            SchemePosition = reader.GetString(5),
                            TrainingVenue = reader.GetString(6),
                            PaymentMode = reader.GetString(7),
                            AdditionalRequirements = reader.GetString(8),
                            UserId = reader.GetInt64(9)

                        });

                    }

                }

                return result;

            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetbyDate")]
        public async Task<JsonResult> GetByDate(string? startdate="yyyy-mm-dd", string? enddate = "yyyy-mm-dd")
        {
            try
            {
                List<MBooking> bookings = new List<MBooking>();
                JsonResult result = new JsonResult(bookings);


                DateOnly start, end, _default;

                DateOnly.TryParse("default", out _default);


                DateOnly.TryParse(startdate, out start);
                DateOnly.TryParse(enddate, out end);

                if(start == _default)
                {
                    start = end;
                }
                
                
                if(start > end)
                {
                    end= start;
                }


                //Connect to database then read booking records
                _connection.OpenAsync().Wait();

                using (SqlCommand command = new SqlCommand("spSelectBookingDate", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("start", SqlDbType.NVarChar).Value = start.ToLongDateString();
                    command.Parameters.AddWithValue("end", SqlDbType.NVarChar).Value = end.ToLongDateString();

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                      
                        bookings.Add(new MBooking
                        {
                            BookingId = reader.GetInt64(0),
                            ExternalSchemeAdmin = reader.GetString(1),
                            CourseDate = reader.GetDateTime(2).Date.ToString(),
                            BookingType = reader.GetString(3),
                            RetirementSchemeName = reader.GetString(4),
                            SchemePosition = reader.GetString(5),
                            TrainingVenue = reader.GetString(6),
                            PaymentMode = reader.GetString(7),
                            AdditionalRequirements = reader.GetString(8),
                            UserId = reader.GetInt64(9)

                        });


                    }
                }


                return result;

            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
