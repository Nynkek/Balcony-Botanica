using BalconyBotanica.Core.Algorithm;
using BalconyBotanica.Core.DomainObjects;
using BalconyBotanica.Hosts.Models;

namespace MyTestProject.Core
{
    [TestFixture]
    public class RecommenderUnitTests
    {
        // TO DO: all scenario's
        // [ ] happy flow: all answers provided returns plants successful
        // [ ] happy flow: least amount of anwsers provided returns plants successful
        // [ ] happy flow: all other answers options [data test?]
        // [ ] happy flow: test database items 0, 1, 10 and max amount 
        // [ ] unhappy flow: null provided returns should-not-be-null-error
        // [ ] unhappy flow: wrong input returns bad request
        // [ ] unhappy flow: 


        [SetUp]
        public void Setup()
        {
        }
        // TODO: write tests, just made all the builders to make testing easier
        [Test]
        public void All_Answers_Should_Return_Successfull()
        {
            Recommender recommender = new Recommender();

            RecommendedPlants insertedArray = One.RecommendedPlants;
            QuizAnswers quizAnswers = One.QuizAnswers;


            recommender.Recommend(insertedArray, quizAnswers);


            Assert.Pass();
        }
    }
}