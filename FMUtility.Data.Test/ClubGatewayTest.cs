using System.Collections.Generic;
using FMUtility.Data.Queries;
using FMUtility.Data.Test.Fakes;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Data.Test
{
    [TestFixture]
    public class ClubGatewayTest
    {
        [SetUp]
        public void Setup()
        {
            _clubs = new List<ClubModel>();

            _fmContextMock = new Mock<IFmContext>();
            _fmContextMock.Setup(s => s.Clubs).Returns(_clubs);

            _taskFactory = new FakeTaskFactory();
            _clubGateway = new ClubGateway(_fmContextMock.Object, _taskFactory);
        }

        private ClubGateway _clubGateway;
        private List<ClubModel> _clubs;
        private Mock<IFmContext> _fmContextMock;
        private FakeTaskFactory _taskFactory;

        [Test]
        public async void GetShouldReturnMatchingClub()
        {
            var club = new ClubModel
            {
                Id = 3
            };
            _clubs.Add(club);

            var result = await _clubGateway.Get(3);
            Assert.AreSame(club, result);
        }

        [Test]
        public async void QueryShouldReturnResults()
        {
            var matchingClub = new ClubModel();
            var notMatchingClub = new ClubModel();
            _clubs.Add(matchingClub);
            _clubs.Add(notMatchingClub);

            var clubQueryMock = new Mock<IQuery<ClubModel>>();
            clubQueryMock.Setup(s => s.IsMatch(matchingClub)).Returns(true);
            clubQueryMock.Setup(s => s.IsMatch(notMatchingClub)).Returns(false);

            var result = await _clubGateway.Get(clubQueryMock.Object);
            Assert.Contains(matchingClub, result);
        }
    }
}