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
    public class CategoryServiceTests
    {
        [TestMethod()]
        public async Task AddCategoryTestAsync()
        {
            // Arrange
            var categoryService = new CategoryService( new HttpClient(),"https://localhost:7273/category/");


            var categoryRequest = new CategoryRequestModel()
            {
                Name = "name",
                ParentCategoryId = 77,
            };

            // Act
            var response = await categoryService.AddCategory(categoryRequest);


            // Assert
            Assert.AreEqual(response.Name, categoryRequest.Name);
        }
    }
}