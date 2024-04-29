using TestTaskForETAI__CategoriesService.Entity;

namespace TestTaskForETAI__CategoriesService.Interfaces;

public interface ICategoriesRepository
{
    void Add(Category category);
    Category Update(Category category, Category newCategory);
    Category? GetById(int id);
    IEnumerable<Category> GetAllTopicCategories();
}