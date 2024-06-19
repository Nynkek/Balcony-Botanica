using BalconyBotanica.Core.DomainObjects;

namespace MyTestProject;

internal class One
{
    public static PlantDataBuilder PlantData => new();
    public static RecommendedPlantsBuilder RecommendedPlants => new();
    public static QuizAnswersBuilder QuizAnswers => new();
}
