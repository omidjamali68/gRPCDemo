using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace server_side.Contracts;
public partial class Temperatures
{
    [JsonPropertyName("coord")]
    public Coord Coord { get; set; }

    [JsonPropertyName("weather")]
    public Weather[] Weather { get; set; }

    [JsonPropertyName("base")]
    public string Base { get; set; }

    [JsonPropertyName("main")]
    public Main Main { get; set; }

    [JsonPropertyName("visibility")]
    public long Visibility { get; set; }

    [JsonPropertyName("wind")]
    public Wind Wind { get; set; }

    [JsonPropertyName("clouds")]
    public Clouds Clouds { get; set; }

    [JsonPropertyName("dt")]
    public long Dt { get; set; }

    [JsonPropertyName("sys")]
    public Sys Sys { get; set; }

    [JsonPropertyName("timezone")]
    public long Timezone { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("cod")]
    public long Cod { get; set; }
}

public partial class Clouds
{
    [JsonPropertyName("all")]
    public long All { get; set; }
}

public partial class Coord
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }
}

public partial class Main
{
    [JsonPropertyName("temp")]
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double TempMin { get; set; }

    [JsonPropertyName("temp_max")]
    public double TempMax { get; set; }

    [JsonPropertyName("pressure")]
    public long Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public long Humidity { get; set; }
}

public partial class Sys
{
    [JsonPropertyName("type")]
    public long Type { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("sunrise")]
    public long Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; set; }
}

    public partial class Weather
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public partial class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public long Deg { get; set; }
    }

   