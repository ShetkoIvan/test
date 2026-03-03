using System.Net.Http.Json;

var http = new HttpClient(); 

for (int i = 0; i < 100; i++)
{
    await http.PostAsJsonAsync(
        "http://localhost:5000/api/patients",
        new
        {
            family = $"Family{i}",
            given = new[] { $"Name{i}" },
            gender = i%2 == 0 ? "male" : "female",
            birthDate = GetRandomBirthDate(),
            active = true
        });
}

static DateTime GetRandomBirthDate()
{
    var start = new DateTime(1920, 1, 1);
    var end = new DateTime(2026, 12, 31, 23, 59, 59);

    var range = (end - start).TotalSeconds;

    var randomSeconds = Random.Shared.NextDouble() * range;

    return start.AddSeconds(randomSeconds);
}