using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherForecastWithPOCOs weatherForecast = new WeatherForecastWithPOCOs();
            weatherForecast.Summary = "Summer";
            weatherForecast.TemperatureCelsius = 25;





            // Сериализация в строку
            Console.WriteLine(new string('-', 30));
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            Console.WriteLine(jsonString);


            // Сериализация в файл
            StreamWriter file = File.CreateText(@"my.json");
            file.Close();
            jsonString = JsonSerializer.Serialize(weatherForecast);  
            File.WriteAllText(@"my.json", jsonString);               
           
            Console.WriteLine("serialisation File created");
            //сериализация в UTF - 8
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);
            //Десериалиация

            Console.WriteLine(new string('-', 30));
            //в строку 
            weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);
            //из файла
           // jsonString = File.ReadAllText(@"my.json");
            //weatherForecast = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);
            Console.WriteLine(weatherForecast);
            //Десериализация из UTF8
            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            WeatherForecastWithPOCOs deserializedWeatherForecast =
                JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(readOnlySpan);

            Console.ReadKey();
        }
    }
}
