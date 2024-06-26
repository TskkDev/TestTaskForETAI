﻿using CategoriesService__DAL.Entities;
using CategoriesService__DAL.Interfaces;
using LinqToDB;

namespace CategoriesService__DAL.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    //Возможно данная реализация репозитория будет ошибкой из за того, что преобразовывается сразу из моделек в ентити,
    //в это случае докину сервайс на это 

    private readonly DbConection _db;

    public CategoriesRepository(DbConection db)
    {
        _db = db;
    }

    public Category Add(Category category)
    {
        var newId = _db.InsertWithInt32Identity(category);
        category.Id = newId;
        return category;
    }
    public Category Update(Category category, Category newCategory)
    {
        category.Name = newCategory.Name;
        category.ParentCategoryId = newCategory.ParentCategoryId;
        _db.Update(category);
        return category;
    }
    public string GetCategoryNameById(int id)
    {
        return _db.Categories.FirstOrDefault(c => c.Id == id).Name;
    }
    public Category? GetById(int id)
    {
        return _db.Categories.LoadWith(c => c.SubCategories)
            .FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Category> GetAllTopicCategories()
    {
        return _db.Categories.Where(c => c.ParentCategoryId == null);
    }
}