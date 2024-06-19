using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalconyBotanica.Core.DomainObjects
{
    public class QuizAnswers
    {
        public Sunlight sunlight;
        public int spaceSizeSquareMeters;
        public WateringSchedule wateringSchedule;
        public PlantFunction? plantFunction;
        public Toxicity toxicity;

        public QuizAnswers(Sunlight sunlight, int spaceSizeSquareMeters, WateringSchedule wateringSchedule, PlantFunction plantFunction, Toxicity toxicity)
        {
            this.sunlight = sunlight;
            this.spaceSizeSquareMeters = spaceSizeSquareMeters;
            this.wateringSchedule = wateringSchedule;
            this.plantFunction = plantFunction;
            this.toxicity = toxicity;
        }
    }
}