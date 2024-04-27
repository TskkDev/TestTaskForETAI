using LinqToDB;
using TestTaskForETAI__CategoriesService.Entity;
using TestTaskForETAI__CategoriesService.Interfaces;
using TestTaskForETAI__CategoriesService.Models;
using TestTaskForETAI__CategoriesService.Models.RequestModel;

namespace TestTaskForETAI__CategoriesService.Repositories;

public class CategoryRepository : ICategoriesRepository
{
    //Возможно данная реализация репозитория будет ошибкой из за того, что преобразовывается сразу из моделек в ентити,
    //в это случае докину сервайс на это 
    
    private readonly DbConection _db;

    public CategoryRepository(DbConection db)
    {
        _db = db;
    }

    public void Add(Category category)
    {
        _db.Insert(category);
    }
    public Category Update(Category category, Category newCategory)
    {
        category.Name = newCategory.Name;
        category.ParentCategoryId = newCategory.ParentCategoryId;
        _db.Update(category);
        return category;
    }
    public Category? GetById(int id)
    {
        return _db.Categories.LoadWith(c=>c.SubCategories)
            .FirstOrDefault(c=>c.Id==id);
    }
    
    public IEnumerable<Category> GetAllTopicCategories()
    {
        return _db.Categories.LoadWith(c => c.SubCategories)
            .Where(c => c.ParentCategoryId == null);
    }
}