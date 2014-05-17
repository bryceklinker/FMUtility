using FMUtility.Data.Queries;
using NUnit.Framework;

namespace FMUtility.Data.Test.Queries
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