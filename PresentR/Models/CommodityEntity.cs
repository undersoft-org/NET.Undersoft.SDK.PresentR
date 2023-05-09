using Newtonsoft.Json;

namespace PresentR.Components;

public class CommodityEntity
{
    public string? Row { get; set; }

    [JsonProperty("word")]
    public string? CommodityName { get; set; }
}
