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

            // DONE: check sunlight and delete all the plants who can’t function with that climate
            // TODO: If answer has "full sun" delete "full shade".
            // TODO: if awnser had "full shade" delete "full sun".
            if (quizAnswers.sunlight == Sunlight.FULL_SUN)
            {
                Sunlight optionToRemove = Sunlight.FULL_SHADE;
                arrayToFilter = arrayToFilter
                                    .Where(x => x.Sunlight.Contains(optionToRemove))
                                    .ToArray();
            }
            // check watering
            // DONE: if "minimum" than delete "frequent", 
            //      order "minimum" as first, en "avg" as second.
            // TODO: if average than nothing, 
            //      order "frequent" last
            // TODO: if frequent than nothing, 
            //      order nothing
            if (quizAnswers.wateringSchedule == WateringSchedule.MINIMUM)
            {
                WateringSchedule optionToRemove = WateringSchedule.FREQUENT;
                arrayToFilter = arrayToFilter
                                    .Where(x => x.WateringSchedule != optionToRemove)
                                    .ToArray();

                arrayToFilter = arrayToFilter
                    .OrderBy(x =>
                    {
                        if (x.WateringSchedule == WateringSchedule.MINIMUM)
                            return 10; // front of array
                        if (x.WateringSchedule == WateringSchedule.AVERAGE)
                            return 20; // back of array
                        return 15; // middle position of array
                    })
                    .ToArray();
            }

            RecommendedPlants recommendedPlants = new()
            {
                Plants = arrayToFilter
            };

            return recommendedPlants;
        }
    }
}
