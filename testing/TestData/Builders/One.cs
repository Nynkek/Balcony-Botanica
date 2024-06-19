using BalconyBotanica.Core.DomainObjects;

namespace testing.TestData.Builders;

internal class One
{
    public static PlantDataBuilder PlantData => new();
    public static RecommendedPlantsBuilder RecommendedPlants => new();
    public static QuizAnswersBuilder QuizAnswers => new();
}
