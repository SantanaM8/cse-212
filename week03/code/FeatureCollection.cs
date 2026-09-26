public static async Task<string[]> EarthquakeDailySummary()
{
    const string url =
        "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

    using var client = new HttpClient();

    string json = await client.GetStringAsync(url);

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    var featureCollection =
        JsonSerializer.Deserialize<FeatureCollection>(json, options);

    var results = new List<string>();

    foreach (var feature in featureCollection.Features)
    {
        string place = feature.Properties.Place;
        double? magnitude = feature.Properties.Mag;

        results.Add($"{place} - Mag {magnitude}");
    }

    return results.ToArray();
}
