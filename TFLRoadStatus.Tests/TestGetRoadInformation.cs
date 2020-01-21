using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFLRoadStatus.Interfaces;
using TFLRoadStatus.Model;
using Moq;
using System.Net;
using System.Net.Http;

namespace TFLRoadStatus.Tests
{
    [TestClass]
    public class TestGetRoadInformation
    {
        private Mock<IConfigurationWrapper> _configurationManager;
        [TestInitialize]
        public void Setup()
        {
            _configurationManager = new Mock<IConfigurationWrapper>();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _configurationManager.Setup(cm => cm.GetValue("app_Id")).Returns("6a9443be");
            _configurationManager.Setup(cm => cm.GetValue("app_Key")).Returns("a8a924e6ff54cca17e5318efc891f197");
            _configurationManager.Setup(cm => cm.GetValue("Url")).Returns("https://api.tfl.gov.uk/Road/");

        }
        [TestMethod]
        public void GetRodeName_ShouldReturnValidName()
        {
           GetRoadInformation rodeInformation = new GetRoadInformation(_configurationManager.Object);
            Task<IEnumerable<Road>> roads= rodeInformation.GetRoadById("A2");
            foreach (Road rd in roads.Result)
            {
                Assert.AreEqual("A2", rd.displayName);
            }
                
        }
        [TestMethod]
        public void GetRodeName_ShouldReturnNotFound()
        {
            GetRoadInformation rodeInformation = new GetRoadInformation(_configurationManager.Object);
            HttpResponseMessage roads = rodeInformation.IsValidStatusCode("A233");
            Assert.AreEqual(roads.StatusCode, HttpStatusCode.NotFound);

        }
    }
}
