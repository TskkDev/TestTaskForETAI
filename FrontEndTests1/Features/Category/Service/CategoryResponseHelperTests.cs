using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrontEnd.Features.Category.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedModels.Models.RequestModels;

namespace FrontEnd.Features.Category.Service.Tests
{
    [TestClass()]
    public class CategoryResponseHelperTests
    {
        [TestMethod()]
        public async Task SendAndAcceptResponseTest()
        {
            // Arrange
            var responseHelper = new CategoryResponseHelper(new HttpClient());


            var categoryRequest = new CategoryRequestModel()
            {
                Name = "name",
                ParentCategoryId = 77,
            };
            var content = new StringContent(JsonConvert.SerializeObject(categoryRequest), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7273/category/add"),
                Content = content
            };
            // Act
            var response = await responseHelper.SendAndAcceptResponse(request);


            // Assert
            Assert.AreEqual(response.Name, categoryRequest.Name);
        }
    }
}