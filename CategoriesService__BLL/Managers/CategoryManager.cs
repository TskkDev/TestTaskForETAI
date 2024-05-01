﻿using CategoriesService__BLL.Services;
using CategoriesService__DAL.Entities;
using CategoriesService__DAL.Repositories;
using LinqToDB.Common;
using SharedModels.MessageModels;
using SharedModels.RequestModels;
using SharedModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesService__BLL.Managers
{
    public class CategoryManager
    {
        private readonly string _connectionString;
        private readonly ConvertModelToEntityService _converter;
        public CategoryManager(string connectionString)
        {
            _connectionString = connectionString;
            _converter = new ConvertModelToEntityService();
        }

        public CategoryResponseModel AddCategory (CategoryRequestModel newCategory)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                return(_converter.EntityToResponseModel(
                    repos.Add(_converter.RequestModelToEntity(newCategory))));
            }
        }

        public CategoryResponseModel UpdateCategory(int categoryId, CategoryRequestModel newCategory)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var oldCategory = repos.GetById(categoryId);
                if (oldCategory is null) throw new NullReferenceException("Old category doesn't found");
                return (_converter.EntityToResponseModel(
                    repos.Update(oldCategory, _converter.RequestModelToEntity(newCategory))));
            }
        }
        
        public CategoryResponseModel? GetCategoryById(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var category = repos.GetById(categoryId);
                if(category is null) throw new NullReferenceException("Category doesn't found");
                 return(_converter.EntityToResponseModel(category));
            }
        }

        public List<CategoryResponseModel> GetAllTopicCategory()
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var categories = repos.GetAllTopicCategories().ToList();
                if(categories.Count == 0) throw new NullReferenceException("No topic category");
                return _converter.EntitiesToResponseModels(categories);
            }
        }
    }
}
