

namespace BalconyBotanica.Core.DomainObjects
{
    public class QuizAnswers(Sunlight sunlight, int spaceSizeSquareMeters, WateringSchedule wateringSchedule, PlantFunction plantFunction, Toxicity toxicity)
    {
        public Sunlight sunlight = sunlight;
        public int spaceSizeSquareMeters = spaceSizeSquareMeters;
        public WateringSchedule wateringSchedule = wateringSchedule;
        public PlantFunction plantFunction = plantFunction;
        public Toxicity toxicity = toxicity;
    }
}