using static System.Console;
using System.Net.Http;
using Newtonsoft.Json.Linq;



class Program
{
    private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather?";
    private const string ApiKey = "89b03fb69db0a881d3b9274015f1da99"; // Ersätt med din OpenWeatherMap API-nyckel



    static async System.Threading.Tasks.Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            while (true)
            {
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Sök väder för en stad");
                Console.WriteLine("2. Avsluta");
                Console.Write("Välj ett alternativ: ");



                var choice = Console.ReadLine();



                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Ange stadens namn: ");
                        var city = Console.ReadLine();



                        var weatherResponse = await client.GetStringAsync($"{BaseUrl}q={city}&appid={ApiKey}&units=metric");
                        var weatherData = JObject.Parse(weatherResponse);



                        Console.WriteLine($"Väder i {city}:");
                        Console.WriteLine($"Temperatur: {weatherData["main"]["temp"]}°C");
                        WriteLine($"Väder: {weatherData["weather"][0]["description"]}");
                        break;



                    case "2":
                        return;



                    default:
                        WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}

