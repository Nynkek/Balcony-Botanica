using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace tests.Hosts
{
    [TestFixture]
    public class QuizControllerUnitTests
    {
        // TO DO:
        // [ ] happy flow: all answers provided returns  successful
        // [ ] happy flow: least amount of anwsers provided returns  successful
        // [ ] happy flow: all other answers options [data test?]
        // [ ] unhappy flow: wrong Type of awnsers retun bad request
        // [ ] (un)happy flow: null, 0 and empty for every answer returns corresponding (un)successful

        private Mock<PlantRepository> _mockPlantRepository;
        private Mock<Recommender> _mockRecommender;
        private QuizController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockPlantRepository = new Mock<PlantRepository>();
            _mockRecommender = new Mock<Recommender>();
            _controller = new QuizController(_mockPlantRepository.Object, _mockRecommender.Object);
        }

        [Test]
        public void GetPlantTopThree_ShouldReturnRecommendedPlants()
        {
            // Arrange
            var quizAnswers = new QuizAnswers(Sunlight.FullSun, 10, WateringSchedule.Weekly, PlantFunction.Decorative, Toxicity.NonToxic);
            var plantDataDbos = new List<PlantDataDbo>
            {
                new PlantDataDbo { Id = 1, Name = "Plant1" },
                new PlantDataDbo { Id = 2, Name = "Plant2" },
                new PlantDataDbo { Id = 3, Name = "Plant3" }
            };

            var recommendedPlants = plantDataDbos.MapToRecommendedPlants();
            _mockPlantRepository.Setup(repo => repo.GetPlants()).Returns(plantDataDbos);
            _mockRecommender.Setup(recommender => recommender.Recommend(It.IsAny<RecommendedPlants>(), It.IsAny<QuizAnswers>()))
                .Returns(recommendedPlants);

            // Act
            var result = _controller.getPlantTopThree("FullSun", 10, "Weekly", "Decorative", "NonToxic");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RecommendedPlants>(result);
            Assert.AreEqual(3, result.Plants.Count());
        }
    }
}