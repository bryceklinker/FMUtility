using System.Collections.Generic;
using FMUtility.Data.Gateways;
using FMUtility.Data.Mappers;
using FMUtility.Data.Queries;
using FMUtility.Data.Test.Fakes;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using Moq;
using NUnit.Framework;

namespace FMUtility.Data.Test.Gateways
{
    [TestFixture]
    public class ClubGatewayTest
    {
        private ClubGateway _clubGateway;
        private List<ClubModel> _clubs;
        private Mock<IFmContext> _fmContextMock;
        private FakeTaskFactory _taskFactory;
        private Mock<IClubSimpleMapper> _clubSimpleMapperMock;

        [SetUp]
        public void Setup()
        {
            _clubs = new List<ClubModel>();

            _fmContextMock = new Mock<IFmContext>();
            _fmContextMock.Setup(s => s.Clubs).Returns(_clubs);

            _taskFactory = new FakeTaskFactory();
            _clubSimpleMapperMock = new Mock<IClubSimpleMapper>();
            _clubGateway = new ClubGateway(_fmContextMock.Object, _clubSimpleMapperMock.Object, _taskFactory);
        }

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

            var simpleClub = new ClubSimple();
            _clubSimpleMapperMock.Setup(s => s.Map(matchingClub)).Returns(simpleClub);

            var result = await _clubGateway.Get(clubQueryMock.Object);
            Assert.Contains(simpleClub, result);
            _clubSimpleMapperMock.Verify(s => s.Map(notMatchingClub), Times.Never());
        }
    }
}