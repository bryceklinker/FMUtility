using System.Collections.Generic;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data.Gateways;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using FMUtility.Server.Controllers;
using Moq;
using NUnit.Framework;

namespace FMUtility.Server.Test.Controllers
{
    [TestFixture]
    public class ClubControllerTest
    {
        private ClubController _clubController;
        private Mock<IClubGateway> _clubGatewayMock;

        [SetUp]
        public void Setup()
        {
            _clubGatewayMock = new Mock<IClubGateway>();
            _clubController = new ClubController(_clubGatewayMock.Object);
        }

        [Test]
        public void GetGivenClubIdShouldGetClubFromGateway()
        {
            var club = new ClubModel();
            _clubGatewayMock.Setup(s => s.Get(2)).ReturnsAsync(club);

            var result = _clubController.Get(2);
            Assert.AreSame(club, result.Content);
        }

        [Test]
        public void SearchShouldSearchClubGateway()
        {
            var clubs = new List<ClubSimple>
            {
                new ClubSimple()
            };
            _clubGatewayMock.Setup(s => s.Get(It.IsAny<IQuery<ClubModel>>())).ReturnsAsync(clubs);

            var args = new ClubSearchArgs();
            var result = _clubController.Search(args);
            Assert.AreSame(clubs, result.Content);
        }
    }
}
