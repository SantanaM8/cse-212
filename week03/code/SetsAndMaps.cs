using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SetsAndMaps
{
    /// <summary>
    /// Find pairs of two-letter words in O(n) time using sets
    /// Example: ["am", "at", "ma", "if", "fi"] returns ["am & ma", "if & fi"]
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new HashSet<string>();
        
        foreach (var word in words)
        {
            // Skip palindromes (e.g., "aa")
            if (word[0] == word[1])
                continue;
            
            // Create the reverse of the current word
            var reverse = new string(new char[] { word[1], word[0] });
            
            // If we've seen the reverse, we found a pair
            if (seen.Contains(reverse))
            {
                // Store in alphabetical order to avoid duplicates
                var pair = string.Compare(word, reverse) < 0 
                    ? $"{word} & {reverse}" 
                    : $"{reverse} & {word}";
                pairs.Add(pair);
            }
            
            seen.Add(word);
        }
        
        return pairs.ToArray();
    }

    /// <summary>
    /// Read census.txt and create a dictionary summarizing degrees (column 4)
    /// Returns a dictionary where key = degree name, value = count
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        
        // Read all lines from the file
        var lines = File.ReadAllLines(filename);
        
        // Skip the header line and process each data line
        for (int i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');
            
            // Column 4 contains the degree (index 3 since arrays are 0-indexed)
            if (columns.Length > 3)
            {
                var degree = columns[3].Trim();
                
                // Add or increment the count for this degree
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        
        return degrees;
    }

    /// <summary>
    /// Determine if two words are anagrams using a dictionary
    /// Ignores spaces and case
    /// Example: "CAT" and "ACT" are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        
        // If lengths differ, they can't be anagrams
        if (word1.Length != word2.Length)
            return false;
        
        // Count letter frequencies in word1
        var letterCounts = new Dictionary<char, int>();
        
        foreach (var letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts[letter] = 1;
        }
        
        // Subtract letter frequencies for word2
        foreach (var letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false; // Letter in word2 not in word1
            
            letterCounts[letter]--;
            
            if (letterCounts[letter] < 0)
                return false; // More of this letter in word2 than word1
        }
        
        // Check if all counts are zero
        foreach (var count in letterCounts.Values)
        {
            if (count != 0)
                return false;
        }
        
        return true;
    }

    /// <summary>
    /// Fetch earthquake data from USGS and format as strings
    /// Returns array of formatted strings: "{place} - Mag {magnitude}"
    /// </summary>
    public static async Task<string[]> EarthquakeDailySummary()
    {
        const string usdUrl = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        
        using var client = new HttpClient();
        var json = await client.GetStringAsync(usdUrl);
        
        // Deserialize the JSON data
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        
        var results = new List<string>();
        
        // Format each earthquake
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag;
            results.Add($"{place} - Mag {mag}");
        }
        
        return results.ToArray();
    }
}

// Classes for JSON deserialization
public class FeatureCollection
{
    public string Type { get; set; }
    public Metadata Metadata { get; set; }
    public List<Feature> Features { get; set; }
}

public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    public Geometry Geometry { get; set; }
    public string Id { get; set; }
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
    public long Time { get; set; }
    public long Updated { get; set; }
    public int? Tz { get; set; }
    public string Url { get; set; }
    public string Detail { get; set; }
    public int? Felt { get; set; }
    public double? Cdi { get; set; }
    public double? Mmi { get; set; }
    public string Alert { get; set; }
    public string Status { get; set; }
    public int Tsunami { get; set; }
    public int? Sig { get; set; }
    public string Net { get; set; }
    public string Code { get; set; }
    public string Ids { get; set; }
    public string Sources { get; set; }
    public string Types { get; set; }
    public int? Nst { get; set; }
    public double? Dmin { get; set; }
    public double? Rms { get; set; }
    public double? Gap { get; set; }
    public string MagType { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public List<double> Coordinates { get; set; }
}
