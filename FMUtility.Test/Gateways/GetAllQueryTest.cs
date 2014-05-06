using FMUtility.Gateways;
using NUnit.Framework;

namespace FMUtility.Test.Gateways
{
    [TestFixture]
    public class GetAllQueryTest
    {
        [Test]
        public void IsMatchShouldAlwaysBeTrue()
        {
            var query = new GetAllQuery<object>();
            Assert.IsTrue(query.IsMatch(new object()));
        }
    }
}
