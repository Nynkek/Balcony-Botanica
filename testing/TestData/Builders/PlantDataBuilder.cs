using BalconyBotanica.Core.DomainObjects;

namespace MyTestProject;

public class PlantDataBuilder : Builder<PlantData>
{
    private string _id = "default-id";
    private string _commonName = "default-common-name";
    private string[] _scientificName = ["default-scientific-name"];
    private string[]? _otherName = ["other-name"];
    private string? _cycle = "Annual";
    private WateringSchedule _wateringSchedule = new WateringSchedule();
    private Sunlight[] _sunlight = [Sunlight.PART_SHADE];
    private Toxicity[] _toxicity = [Toxicity.POISONOUS_TO_PETS];

    public PlantDataBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public PlantDataBuilder WithCommonName(string commonName)
    {
        _commonName = commonName;
        return this;
    }

    public PlantDataBuilder WithScientificName(params string[] scientificName)
    {
        _scientificName = scientificName;
        return this;
    }

    public PlantDataBuilder WithOtherName(params string[]? otherName)
    {
        _otherName = otherName;
        return this;
    }

    public PlantDataBuilder WithCycle(string? cycle)
    {
        _cycle = cycle;
        return this;
    }

    public PlantDataBuilder WithWateringSchedule(WateringSchedule wateringSchedule)
    {
        _wateringSchedule = wateringSchedule;
        return this;
    }

    public PlantDataBuilder WithSunlight(params Sunlight[] sunlight)
    {
        _sunlight = sunlight;
        return this;
    }

    public PlantDataBuilder WithToxicity(params Toxicity[] toxicity)
    {
        _toxicity = toxicity;
        return this;
    }

    public override PlantData Build()
    {
        return new PlantData
        {
            Id = _id,
            Common_name = _commonName,
            Scientific_name = _scientificName,
            Other_name = _otherName,
            Cycle = _cycle,
            WateringSchedule = _wateringSchedule,
            Sunlight = _sunlight,
            Toxicity = _toxicity
        };
    }


}