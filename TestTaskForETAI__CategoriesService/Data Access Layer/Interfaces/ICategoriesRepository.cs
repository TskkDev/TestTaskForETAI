using TestTaskForETAI__CategoriesService.Data_Access_Layer.Entities;

namespace TestTaskForETAI__CategoriesService.Data_Access_Layer.Interfaces;

public interface ICategoriesRepository
{
    Category Add(Category category);
    Category Update(Category category, Category newCategory);
    Category? GetById(int id);
    IEnumerable<Category> GetAllTopicCategories();
}