using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace BalconyBotanica.Core.Algorithm

{
    /// <summary>
    /// provides a list of (generic) items when given a set of quiz-answers
    /// </summary>
    public class Recommender
    {
        // TODO: make Recommend more generic, for now I want it working
        public RecommendedPlants Recommend(RecommendedPlants insertedArray, QuizAnswers quizAnswers)
        {

            PlantData[] arrayToFilter = insertedArray.Plants;

            if (quizAnswers.sunlight > Sunlight.FILTERED_SHADE)
            {
                arrayToFilter = arrayToFilter
                    .Where(x => x.Sunlight.All(s => s > Sunlight.FILTERED_SHADE))
                    .ToArray();
            }
            if (quizAnswers.sunlight <= Sunlight.FILTERED_SHADE)
            {
                arrayToFilter = arrayToFilter
                    .Where(x => x.Sunlight.All(s => s <= Sunlight.PART_SHADE))
                    .ToArray();
            }

            if (quizAnswers.wateringSchedule <= WateringSchedule.MINIMUM)
            {
                arrayToFilter = arrayToFilter
                    .Where(x => x.WateringSchedule <= WateringSchedule.AVERAGE)
                    .OrderBy(x => x.WateringSchedule)
                    .ToArray();
            }
            else
            {
                arrayToFilter = arrayToFilter
                   .OrderBy(x => x.WateringSchedule)
                   .ToArray();
            }

            arrayToFilter = arrayToFilter
                  .Where(x => x.Toxicity.All(s => s != quizAnswers.toxicity))
                  .ToArray();

            RecommendedPlants recommendedPlants = new()
            {
                Plants = arrayToFilter
            };

            return recommendedPlants;
        }
    }
}
