using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace tests.Core
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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}