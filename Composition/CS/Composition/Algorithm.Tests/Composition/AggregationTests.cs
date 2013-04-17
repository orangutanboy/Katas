using Algorithm.Composition;
using NUnit.Framework;

namespace Algorithm.Tests.Composition
{
    public class AggregationTests
    {
        [Test]
        public void SummingAggregation_Produces_Sum()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new SummingStrategy());

            var result = aggregator.Aggregate();

            Assert.AreEqual(107, result.X);
            Assert.AreEqual(30, result.Y);
        }

        [Test]
        public void AveragingAggregagtor_Produces_Average()
        {
            var aggregator = new PointsAggregator(_measurements, new EmptyFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

            Assert.AreEqual(35, result.X);
            Assert.AreEqual(10, result.Y);
        }

        [Test]
        public void LowPassAveragingAggregator_Applys_Filter()
        {
            var aggregator = new PointsAggregator(_measurements, new LowPassFilter(), new AveragingStrategy());

            var result = aggregator.Aggregate();

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(12, result.Y);            
        }

        // Uncomment this test and make it pass reusing as much code as 
        // possible from other classes that are available in the Composition folder
        //[Test]
        //public void HighPassSummingAggregator_Applys_Filter()
        //{                
        //    var aggregator = new PointsAggregator(_measurements, new HighPassFilter(), new SummingStrategy());

        //    var result = aggregator.Aggregate();

        //    Assert.AreEqual(105, result.X);
        //    Assert.AreEqual(15, result.Y);
        //}

        /// Uncomment this test and make it pass by building a new class to 
        /// hide the "composition" of strategies and filters ...
        //[Test]
        //public void CustomHighPassSummingAggregator_Applys_Filter()
        //{                
        //    var aggregator = new HighPassSummingAggregator(_measurements);

        //    var result = aggregator.Aggregate();

        //    Assert.AreEqual(105, result.X);
        //    Assert.AreEqual(15, result.Y);
        //}

        readonly Measurement[] _measurements = new[]
        {
            new Measurement { X = 5, Y = 10},
            new Measurement { X = 2, Y = 15},
            new Measurement { X = 100, Y = 5}                  
        };
    }
}