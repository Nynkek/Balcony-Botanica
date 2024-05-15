namespace BalconyBotanica.Core.DomainObjects;
public class PlantData
{
    public string Id { get; set; }
    public string Common_name { get; set; }
    public string[] Scientific_name { get; set; }
    public string[] Other_name { get; set; }
    public string Cycle { get; set; }
    public string Watering { get; set; }
    public string[] Sunlight { get; set; }


}