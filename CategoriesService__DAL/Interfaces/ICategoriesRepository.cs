using CategoriesService__DAL.Entities;

namespace CategoriesService__DAL.Interfaces;

public interface ICategoriesRepository
{
    Category Add(Category category);
    Category Update(Category category, Category newCategory);
    string GetCategoryNameById(int id);
    Category? GetById(int id);
    IEnumerable<Category> GetAllTopicCategories();
}