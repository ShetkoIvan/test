using System.Net.Http.Json;
using System.Text.Json;

string[] firstNames =
{
    "Ivan","Anna","Maria","Alex","Olga",
    "Dmitry","Sergey","Elena","Natalia","Andrey",
    "Pavel","Irina","Viktor","Svetlana","Mikhail",
    "Tatiana","Denis","Yulia","Artem","Nikolai"
};

string[] lastNames =
{
    "Ivanov","Petrov","Sidorov","Smirnov","Kuznetsov",
    "Popov","Vasiliev","Sokolov","Mikhailov","Fedorov",
    "Morozov","Volkov","Alekseev","Lebedev","Semenov",
    "Egorov","Pavlov","Kozlov","Stepanov","Nikolaev"
};

var http = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7183"),
    Timeout = TimeSpan.FromSeconds(30)
};

for (int i = 0; i < 100; i++)
{
    var payload = new
    {
        family = lastNames[Random.Shared.Next(lastNames.Length)],
        given = new[] { firstNames[Random.Shared.Next(firstNames.Length)] },
        gender = i % 2 == 0 ? "male" : "female",
        use = "official",
        birthDate = GetRandomBirthDate(),
        active = i % 2 == 0 ? "True" : "False"
    };

    try
    {
        using var resp = await http.PostAsJsonAsync("/api/patients", payload, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        if (!resp.IsSuccessStatusCode)
        {
            var body = await resp.Content.ReadAsStringAsync();
            Console.WriteLine($"#{i} -> {(int)resp.StatusCode} {resp.ReasonPhrase}\n{body}\n");
        }
        else
        {
            Console.WriteLine($"#{i} -> OK");
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"#{i} -> HttpRequestException: {ex.Message}");
        break;
    }
    catch (TaskCanceledException ex)
    {
        Console.WriteLine($"#{i} -> Timeout/Cancelled: {ex.Message}");
        break;
    }

    await Task.Delay(20);
}


Console.ReadKey();
static DateTime GetRandomBirthDate()
{
    var start = new DateTime(1920, 1, 1);
    var end = new DateTime(2026, 12, 31, 23, 59, 59);

    var range = (end - start).TotalSeconds;

    var randomSeconds = Random.Shared.NextDouble() * range;

    return start.AddSeconds(randomSeconds);
}

