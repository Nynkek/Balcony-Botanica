using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace MyTestProject;

public class RecommendedPlantsBuilder : Builder<RecommendedPlants>
{
    private static PlantData plant1 = One.PlantData.WithCommonName("name");
    private static PlantData plant2 = One.PlantData.WithSunlight(Sunlight.FULL_SHADE);
    private static PlantData plant3 = One.PlantData.WithToxicity(Toxicity.POISONOUS_TO_HUMANS);
    private PlantData[] _plants = [plant1, plant2, plant3];

    public RecommendedPlantsBuilder WithPlants(params PlantData[] plants)
    {
        _plants = plants;
        return this;
    }


    public override RecommendedPlants Build()
    {
        return new RecommendedPlants
        {
            Plants = _plants
        };
    }
}
