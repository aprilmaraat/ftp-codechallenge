using System.Linq;
using System.Threading.Tasks;

namespace FTP.CodeChallenge
{
    public class WeatherStackService : IWeatherStackService
    {
        public async Task<QuestionResponse> RespondFromCurrentForecast(string query) 
        {
            var result = new QuestionResponse();
            var weatherStackClient = new WeatherStackClient();
            Current current = await weatherStackClient.GetCurrentWeatherForecast(query);
            result.GoOutside = !current.weather_descriptions.Any(x => x.ToLower().Contains("rain"));
            result.WearSunscreen = current.uv_index > 3;
            result.FlyKite = (result.GoOutside && current.wind_speed > 15);
            return result;
        }
    }
}
