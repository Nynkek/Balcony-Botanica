using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace testing.TestData.Builders;

public class RecommendedPlantsBuilder : Builder<RecommendedPlants>
{
    private static readonly PlantData plant1 = One.PlantData.WithCommonName("name");
    private static readonly PlantData plant2 = One.PlantData.WithSunlight(Sunlight.FULL_SHADE);
    private static readonly PlantData plant3 = One.PlantData.WithToxicity(Toxicity.POISONOUS_TO_HUMANS);
    private static readonly PlantData plant4 = One.PlantData.WithToxicity(Toxicity.POISONOUS_TO_PETS);

    private PlantData[] _plants = [plant1, plant2, plant3, plant4];

    public RecommendedPlantsBuilder WithPlants(params PlantData[] plants)
    {
        _plants = plants;
        return this;
    }

    public RecommendedPlantsBuilder WithPlantsWithAllSunlightOptions()
    {
        var plant1 = One.PlantData.WithSunlight(Sunlight.FULL_SHADE).WithId("1").WithWateringSchedule(WateringSchedule.AVERAGE);
        var plant2 = One.PlantData.WithSunlight(Sunlight.FILTERED_SHADE).WithId("2").WithWateringSchedule(WateringSchedule.AVERAGE);
        var plant3 = One.PlantData.WithSunlight(Sunlight.PART_SHADE).WithId("3").WithWateringSchedule(WateringSchedule.AVERAGE);
        var plant4 = One.PlantData.WithSunlight(Sunlight.FULL_SUN).WithId("4").WithWateringSchedule(WateringSchedule.AVERAGE);
        var plant5 = One.PlantData.WithSunlight(Sunlight.FULL_SUN, Sunlight.PART_SHADE).WithId("5").WithWateringSchedule(WateringSchedule.AVERAGE);
        _plants = [plant1, plant2, plant3, plant4, plant5];
        return this;
    }

    public RecommendedPlantsBuilder WithPlantsWithAllWateringScheduleOptions()
    {
        var plant1 = One.PlantData.WithId("1").WithWateringSchedule(WateringSchedule.MINIMUM).WithSunlight(Sunlight.FULL_SUN);
        var plant2 = One.PlantData.WithId("2").WithWateringSchedule(WateringSchedule.AVERAGE).WithSunlight(Sunlight.FULL_SUN);
        var plant3 = One.PlantData.WithId("3").WithWateringSchedule(WateringSchedule.FREQUENT).WithSunlight(Sunlight.FULL_SUN);
        var plant4 = One.PlantData.WithId("4").WithWateringSchedule(WateringSchedule.AVERAGE).WithSunlight(Sunlight.FULL_SUN);

        _plants = [plant1, plant2, plant3, plant4];
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
