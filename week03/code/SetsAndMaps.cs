using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SetsAndMaps
{
    // Problem 1 - Find symmetric pairs in O(n) using a set.
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new HashSet<string>();

        foreach (var word in words)
        {
            // The assignment assumes two-character words.
            if (word.Length != 2 || word[0] == word[1])
                continue;

            string reverse = $"{word[1]}{word[0]}";

            if (seen.Contains(reverse))
            {
                string pair = string.CompareOrdinal(word, reverse) < 0
                    ? $"{word} & {reverse}"
                    : $"{reverse} & {word}";

                pairs.Add(pair);
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    // Problem 2 - Summarize the degrees in column 4 of census.txt.
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        var lines = File.ReadAllLines(filename);

        // The census file contains data rows; the first line is skipped
        // to match the assignment/test data.
        for (int i = 1; i < lines.Length; i++)
        {
            string[] columns = lines[i].Split(',');

            if (columns.Length <= 3)
                continue;

            string degree = columns[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }
   
    // Problem 3 - Determine whether two words are anagrams.
        // Spaces and letter case are ignored.
    // Uses a Dictionary as required by the assignment.
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLowerInvariant();
        word2 = word2.Replace(" ", "").ToLowerInvariant();

        if (word1.Length != word2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts[letter] = 1;
        }

        foreach (char letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
                return false;
        }

        foreach (int count in letterCounts.Values)
        {
            if (count != 0)
                return false;
        }

        return true;
    }

    // Problem 5 - Get the current day's earthquake summary from USGS.
    //
    // The supplied tests call this method synchronously, so the HTTP
    // request is completed here before returning the string array.
    public static string[] EarthquakeDailySummary()
    {
        const string usgsUrl =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();

        string json = client.GetStringAsync(usgsUrl)
            .GetAwaiter()
            .GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
            return Array.Empty<string>();

        var results = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties?.Place ?? "Unknown";
            string magnitude = feature.Properties?.Mag?.ToString() ?? "null";

            results.Add($"{place} - Mag {magnitude}");
        }

        return results.ToArray();
    }
}
