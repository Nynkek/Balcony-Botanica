using BalconyBotanica.Core.Algorithm;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;
using testing.TestData.Builders;

namespace testing.Core
{
    [TestFixture]
    public class RecommenderUnitTests
    {
        // TO DO: all scenario's
        // [x] happy flow: all answers provided returns plants successful
        // [ ] happy flow: least amount of anwsers provided returns plants successful
        // [ ] happy flow: all other answers options [data test?]
        //  [x]  test sunlight
        //  [ ]  test balcony size
        //  [x]  test often water
        //  [ ]  test functiom
        //  [ ]  test toxicity
        // [ ] happy flow: test database items 0, 1, 10 and max amount 
        // [ ] unhappy flow: null provided returns should-not-be-null-error
        // [ ] unhappy flow: wrong input returns bad request
        // [ ] unhappy flow: 


        [Test]
        public void All_Answers_Should_Return_Successfull()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants;
            QuizAnswers quizAnswers = One.QuizAnswers;

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Plants.Any());
        }

        // Question: Bij de Recommender werk je met enum-values, juist om het future proof te maken. 
        // Moet je de unit tests wel hardcoded specifiek maken, of ook met de enum values werken?
        [Test]
        public void Recommend_WithSunlightAnswer_FULL_SHADE_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllSunlightOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithSunlight(Sunlight.FULL_SHADE);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(2));
            foreach (var plant in result.Plants)
            {
                bool hasFullShadeOrFilteredShade = plant.Sunlight.Contains(Sunlight.FULL_SHADE) || plant.Sunlight.Contains(Sunlight.FILTERED_SHADE);
                Assert.IsTrue(hasFullShadeOrFilteredShade,
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.PART_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FULL_SUN),
                $"Plant {plant.Id} should have correct Sunlight property");
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[0]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[1]));
        }

        [Test]
        public void Recommend_WithSunlightAnswer_FILTERED_SHADE_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllSunlightOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithSunlight(Sunlight.FILTERED_SHADE);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(2));
            foreach (var plant in result.Plants)
            {
                bool hasFullShadeOrFilteredShade = plant.Sunlight.Contains(Sunlight.FULL_SHADE) || plant.Sunlight.Contains(Sunlight.FILTERED_SHADE);
                Assert.IsTrue(hasFullShadeOrFilteredShade,
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.PART_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FULL_SUN),
                $"Plant {plant.Id} should have correct Sunlight property");
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[0]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[1]));
        }

        [Test]
        public void Recommend_WithSunlightAnswer_PART_SHADE_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllSunlightOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithSunlight(Sunlight.PART_SHADE);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(3));
            foreach (var plant in result.Plants)
            {
                bool sunlightOptionsToFilter = plant.Sunlight.Contains(Sunlight.PART_SHADE) || plant.Sunlight.Contains(Sunlight.FULL_SUN);
                Assert.IsTrue(sunlightOptionsToFilter,
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FULL_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FILTERED_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[2]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[3]));
            Assert.That(result.Plants[2], Is.EqualTo(insertedArray.Plants[4]));
        }

        [Test]
        public void Recommend_WithSunlightAnswer_FULL_SUN_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllSunlightOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithSunlight(Sunlight.FULL_SUN);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(3));
            foreach (var plant in result.Plants)
            {
                bool sunlightOptionsToFilter = plant.Sunlight.Contains(Sunlight.PART_SHADE) || plant.Sunlight.Contains(Sunlight.FULL_SUN);
                Assert.IsTrue(sunlightOptionsToFilter,
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FULL_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
                Assert.IsFalse(plant.Sunlight.Contains(Sunlight.FILTERED_SHADE),
                $"Plant {plant.Id} should have correct Sunlight property");
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[2]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[3]));
            Assert.That(result.Plants[2], Is.EqualTo(insertedArray.Plants[4]));
        }

        [Test]
        public void Recommend_WithWateringScheduleAnswer_MINIMUM_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllWateringScheduleOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithWateringSchedule(WateringSchedule.MINIMUM).WithSunlight(Sunlight.FULL_SUN);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(3));
            foreach (var plant in result.Plants)
            {
                Assert.That(plant.WateringSchedule == WateringSchedule.MINIMUM || plant.WateringSchedule == WateringSchedule.AVERAGE,
                $"Plant {plant.Id} should have correct WateringSchedule");
                Assert.That(plant.WateringSchedule != WateringSchedule.FREQUENT);
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[0]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[1]));
            Assert.That(result.Plants[2], Is.EqualTo(insertedArray.Plants[3]));
        }

        [Test]
        public void Recommend_WithWateringScheduleAnswer_AVERAGE_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllWateringScheduleOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithWateringSchedule(WateringSchedule.AVERAGE).WithSunlight(Sunlight.FULL_SUN);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(3));
            foreach (var plant in result.Plants)
            {
                Assert.That(plant.WateringSchedule == WateringSchedule.MINIMUM || plant.WateringSchedule == WateringSchedule.AVERAGE,
                $"Plant {plant.Id} should have correct WateringSchedule");
                Assert.That(plant.WateringSchedule != WateringSchedule.FREQUENT);
            }
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[0]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[1]));
            Assert.That(result.Plants[2], Is.EqualTo(insertedArray.Plants[3]));
        }

        [Test]
        public void Recommend_WithWateringScheduleAnswer_FREQUENT_Should_Return_Correct_Plants_And_Order()
        {
            Recommender recommender = new Recommender();
            RecommendedPlants insertedArray = One.RecommendedPlants.WithPlantsWithAllWateringScheduleOptions();
            QuizAnswers quizAnswers = One.QuizAnswers.WithWateringSchedule(WateringSchedule.FREQUENT).WithSunlight(Sunlight.FULL_SUN);

            var result = recommender.Recommend(insertedArray, quizAnswers);

            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.IsNotNull(result);
            Assert.That(result.Plants.Length, Is.EqualTo(4));
            Assert.That(result.Plants[0], Is.EqualTo(insertedArray.Plants[0]));
            Assert.That(result.Plants[1], Is.EqualTo(insertedArray.Plants[1]));
            Assert.That(result.Plants[2], Is.EqualTo(insertedArray.Plants[3]));
            Assert.That(result.Plants[3], Is.EqualTo(insertedArray.Plants[2]));
        }

    }
}