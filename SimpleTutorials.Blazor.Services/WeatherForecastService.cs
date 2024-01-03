using SimpleTutorials.Blazor.Models;

namespace SimpleTutorials.Blazor.Services
{
    public class WeatherForecastService
    {
        private static readonly  string[] _Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            await Task.Delay(100);
            DateTime startDate = DateTime.Now;
            return  Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(startDate.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _Summaries[Random.Shared.Next(_Summaries.Length)]
            }).ToArray();
        }

    }
}