using System.Threading.Tasks;

namespace FTP.CodeChallenge
{
    public interface IWeatherStackService
    {
        Task<QuestionResponse> RespondFromCurrentForecast(string query);
    }
}
