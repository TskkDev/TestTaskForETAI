using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Services;
using CategoriesService__DAL.Entities;
using CategoriesService__DAL.Repositories;
using SharedModels.Models.RequestModels;
using SharedModels.Models.RespondModels.Request;

namespace CategoriesService__BLL.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly string _connectionString;
        private readonly ConvertModelToEntityService _converter;
        public CategoryManager(string connectionString)
        {
            _connectionString = connectionString;
            _converter = new ConvertModelToEntityService();
        }

        public GetCountGoodsRequest AddCategory (CategoryRequestModel newCategory)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                if (newCategory.ParentCategoryId is not null
                    && repos.GetById(newCategory.ParentCategoryId ?? 0) is null)
                {
                    throw new NullReferenceException("Invalid parentId");
                }
                return (_converter.EntityToGetCountGoodsRequest(
                repos.Add(_converter.RequestModelToEntity(newCategory))));
            }
        }

        public GetCountGoodsRequest UpdateCategory(int categoryId, CategoryRequestModel newCategory)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var oldCategory = repos.GetById(categoryId);
                if (newCategory.ParentCategoryId is not null 
                    && repos.GetById(newCategory.ParentCategoryId??0) is null )
                {
                    throw new NullReferenceException("New category parent doesn't found");
                }
                if (oldCategory is null) throw new NullReferenceException("Old category doesn't found");
                return (_converter.EntityToGetCountGoodsRequest(
                    repos.Update(oldCategory, _converter.RequestModelToEntity(newCategory))));
            }
        }
        public string GetCategoryNameById(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                return repos.GetCategoryNameById(categoryId);
            }
        }
        public GetCountGoodsRequest? GetCategoryById(int categoryId)
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var category = repos.GetById(categoryId);
                if(category is null) throw new NullReferenceException("Category doesn't found");
                 return(_converter.EntityToGetCountGoodsRequest(category));
            }
        }

        public ListGetCountGoodsRequest GetAllTopicCategory()
        {
            using (var db = new DbConection(_connectionString))
            {
                var repos = new CategoriesRepository(db);
                var categories = repos.GetAllTopicCategories().ToList();
                if(categories.Count == 0) throw new NullReferenceException("No topic category");
                return _converter.EntitiesToListGetCountGoodsRequest(categories);
            }
        }
    }
}
