using Microsoft.VisualStudio.TestTools.UnitTesting;
using FrontEnd.Features.Category.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels.Models.RespondModels.Response;

namespace FrontEnd.Features.Category.Service.Tests
{
    [TestClass()]
    public class CategoryServiceTests
    {
        [TestMethod()]
        public void ChangeCategoryInListCategoriesTestaEasy()
        {
            //arrange
            var service = new CategoryService(new HttpClient());

            var categoryList = new List<GetCountGoodsResponse>
            {
            new GetCountGoodsResponse { Id = 1, Name = "Category 1" },
            new GetCountGoodsResponse
                {
                    Id = 2, Name = "Category 2", SubCategories = new List<GetCountGoodsResponse>
                    {
                        new GetCountGoodsResponse { Id = 3, Name = "Subcategory 3" }
                    }
                }
            };

            var newCategory = new GetCountGoodsResponse { Id = 3, Name = "New Subcategory 3" };
            // Act
            var newCategoryList = service.ChangeCategoryInListCategories(categoryList, 3, newCategory);

            // Assert
            Assert.AreEqual("New Subcategory 3", newCategoryList[1].SubCategories[0].Name);
        }

        [TestMethod()]
        public void ChangeCategoryInListCategoriesTestHard()
        {
            //arrange
            var service = new CategoryService(new HttpClient());

            var categoryList = new List<GetCountGoodsResponse>
            {
                new GetCountGoodsResponse { Id = 1, Name = "Category 1",
                    SubCategories = new List<GetCountGoodsResponse>
                    {
                        new GetCountGoodsResponse { Id = 5, Name = "Category 5" },
                        new GetCountGoodsResponse { Id = 6, Name = "Category 6" },
                        new GetCountGoodsResponse { Id = 7, Name = "Category 7" ,
                        SubCategories = new List<GetCountGoodsResponse>{
                            new GetCountGoodsResponse { Id = 8, Name = "Category 8" },
                            new GetCountGoodsResponse { Id = 9, Name = "Category 9",
                            SubCategories = new List<GetCountGoodsResponse>
                            {
                                new GetCountGoodsResponse { Id = 10, Name = "Category 10" },
                            }
                            },
                        } 
                        },
                    }
            },
            new GetCountGoodsResponse { Id = 11, Name = "Category 11" },
            new GetCountGoodsResponse { Id = 12, Name = "Category 12" },
            new GetCountGoodsResponse { Id = 13, Name = "Category 13" },
            new GetCountGoodsResponse
                {
                    Id = 2, Name = "Category 2", SubCategories = new List<GetCountGoodsResponse>
                    {
                        new GetCountGoodsResponse { Id = 3, Name = "Subcategory 3" }
                    }
                }
            };

            var newCategory = new GetCountGoodsResponse { Id = 10, Name = "New Subcategory 10" };
            // Act
            var newCategoryList = service.ChangeCategoryInListCategories(categoryList, 10, newCategory);

            // Assert

            var validName = newCategoryList[0].SubCategories[2]
                .SubCategories[1].SubCategories[0].Name;
            Assert.AreEqual("New Subcategory 10", validName);
        }

        [TestMethod()]
        public async Task ChangeCategoryInListCategoriesTestFromApiAsync()
        {
            //arrange
            //arrange
            var service = new CategoryService(new HttpClient());

            var categoryList = await service.GetAllTopicCategory();


            var newCategory = await service.GetCategoryById(77);
            // Act
            var newCategoryList = service.ChangeCategoryInListCategories(categoryList, 77, newCategory);

            // Assert

            var validName = newCategoryList[2].SubCategories[0].Name;
            Assert.AreEqual("2", validName);
        }
    }
}