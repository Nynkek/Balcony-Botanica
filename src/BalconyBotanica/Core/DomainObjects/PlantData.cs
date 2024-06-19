using System.Text.Json.Serialization;

namespace BalconyBotanica.Core.DomainObjects;
public class PlantData
{
    public required string Id { get; set; }
    public required string Common_name { get; set; }
    public required string[] Scientific_name { get; set; }
    public string[]? Other_name { get; set; }
    public string? Cycle { get; set; }
    public required WateringSchedule WateringSchedule { get; set; }
    public required Sunlight[] Sunlight { get; set; }
    public required Toxicity[] Toxicity { get; set; }




}

