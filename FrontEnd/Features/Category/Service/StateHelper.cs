using SharedModels.Models.RespondModels.Response;
using System.Runtime.InteropServices;

namespace FrontEnd.Features.Category.Service
{
    public class StateHelper
    {
        public GetCountGoodsResponse DeletedCategory { get; private set; }
        public List<GetCountGoodsResponse> ChangeCategoryInListCategories
            (
            IEnumerable<GetCountGoodsResponse> categoryList, int oldCategoryId,
            GetCountGoodsResponse newCategory, bool isAdd = false)
        {
            var newCategoryList = categoryList.Select(c =>
            {
                if (c.Id == oldCategoryId)
                {
                    if (isAdd)
                    {
                        c.SubCategories.Add(newCategory);
                        return c;
                    }
                    if (c.IsVisible)
                    {
                        newCategory.IsVisible = false;
                    }
                    if (newCategory.SubCategories.Any())
                    {
                        return newCategory;
                    }
                    return c;
                }
                else if (c.SubCategories != null && c.SubCategories.Any())
                {
                    var updatedSubCategories = ChangeCategoryInListCategories(c.SubCategories, oldCategoryId, newCategory, isAdd);
                    c.SubCategories = updatedSubCategories;
                }
                return c;
            }).ToList();

            return newCategoryList;
        }
        public List<GetCountGoodsResponse> AddCategoryInListCategories
            (GetCountGoodsResponse tempCategory, IEnumerable<GetCountGoodsResponse> categories)
        {
            if (tempCategory.ParentCategoryId == null)
            {
                var newCategories = categories.ToList();
                newCategories.Add(tempCategory);
                return newCategories;
            }
            return ChangeCategoryInListCategories(categories, tempCategory.ParentCategoryId ?? throw new Exception("Noway error"), tempCategory, true);
        }

        public List<GetCountGoodsResponse> DeleteCategoryFromListCategories (IEnumerable<GetCountGoodsResponse> categories,
            int categoryId)
        {
            var newCategories = categories.Select(c =>
            {
                if(c.Id == categoryId)
                {
                    DeletedCategory = c;
                    return null;
                }
                else if (c.SubCategories != null && c.SubCategories.Any())
                {
                    var updatedSubCategories = DeleteCategoryFromListCategories(c.SubCategories, categoryId);
                    c.SubCategories = updatedSubCategories;
                }
                return c;
            }).Where(c=>c!=null).ToList();
            return newCategories;
        }
    }
}
